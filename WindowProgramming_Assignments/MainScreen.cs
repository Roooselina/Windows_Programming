using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            // �ΰ� �̹��� ����
            try
            {
                pictureBox1.Image = Image.FromFile("Logo.png");
                pictureBox2.Image = Image.FromFile("Logo.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ΰ� �̹����� �ҷ��� �� �����ϴ�: " + ex.Message, "�̹��� ����",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // �α��� ���� �ʱ�ȭ
            UpdateLoginStatus();

            // �� Ȱ��ȭ �̺�Ʈ ����
            this.Activated += MainScreen_Activated;

            // �¼� ��ȸ ��ư �̺�Ʈ ����
            btnSearchFlights.Click += BtnSearchFlights_Click;
        }

        // �¼� ��ȸ ��ư Ŭ�� �̺�Ʈ
        private void BtnSearchFlights_Click(object sender, EventArgs e)
        {
            try
            {
                // �Է°� ����
                string departure = comboFrom.Text.Trim();
                string arrival = comboTo.Text.Trim();

                if (string.IsNullOrEmpty(departure))
                {
                    MessageBox.Show("������� �������ּ���.", "�Է� ����",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboFrom.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(arrival))
                {
                    MessageBox.Show("�������� �������ּ���.", "�Է� ����",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboTo.Focus();
                    return;
                }

                if (departure == arrival)
                {
                    MessageBox.Show("������� �������� ���� �� �����ϴ�.", "�Է� ����",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboTo.Focus();
                    return;
                }

                // ��¥ ����
                DateTime today = DateTime.Today;
                DateTime departureDate = dateStart.Value.Date;
                DateTime returnDate = dateReturn.Value.Date;

                // ������� ���ú��� �������� ����
                if (departureDate < today)
                {
                    MessageBox.Show($"������� ����({today:yyyy-MM-dd}) ���� ��¥�� �������ּ���.\n���� ���õ� �����: {departureDate:yyyy-MM-dd}",
                        "��¥ ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateStart.Focus();
                    return;
                }

                // ������� �����Ϻ��� ���� ��� ����
                if (departureDate > returnDate)
                {
                    MessageBox.Show($"������� �����Ϻ��� ���� �� �����ϴ�.\n�����: {departureDate:yyyy-MM-dd}\n������: {returnDate:yyyy-MM-dd}\n\n��¥�� �ٽ� �������ּ���.",
                        "��¥ ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateReturn.Focus();
                    return;
                }

                // �°� �� Ȯ��
                string adultCount = comboAdult.Text;
                string childCount = comboChild.Text;
                string infantCount = comboInfant.Text;

                if (string.IsNullOrEmpty(adultCount)) adultCount = "0";
                if (string.IsNullOrEmpty(childCount)) childCount = "0";
                if (string.IsNullOrEmpty(infantCount)) infantCount = "0";

                int totalPassengers = int.Parse(adultCount) + int.Parse(childCount) + int.Parse(infantCount);
                if (totalPassengers == 0)
                {
                    MessageBox.Show("�ּ� 1�� �̻��� �°��� �������ּ���.", "�Է� ����",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboAdult.Focus();
                    return;
                }

                // ���� Ÿ�� Ȯ��
                string tripType = radioRoundTrip.Checked ? "�պ�" : "��";
                string departureDateStr = departureDate.ToString("yyyy-MM-dd");
                string returnDateStr = returnDate.ToString("yyyy-MM-dd");

                // ������ ��¥�� �����ϴ� ���� ���� ���� �̸� Ȯ��
                // �׷��� checkTrain���� �� ĭ ������ �ʵ���
                if (!CheckTrainsAvailableOnDate(departure, arrival, departureDateStr))
                {
                    MessageBox.Show($"�����Ͻ� ��¥({departureDateStr})�� {departure}���� {arrival}�� ���� ������ �����ϴ�.",
                        "���� ���� ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // �պ��� ��� �����Ͽ��� ������ �ִ��� Ȯ��
                if (radioRoundTrip.Checked && !CheckTrainsAvailableOnDate(arrival, departure, returnDateStr))
                {
                    MessageBox.Show($"�����Ͻ� ������({returnDateStr})�� {arrival}���� {departure}�� ���� ������ �����ϴ�.",
                        "���� ���� ���� ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // �˻� ���� ��ü ����
                var searchCondition = new TrainSearchCondition
                {
                    Departure = departure,
                    Arrival = arrival,
                    DepartureDate = departureDateStr,
                    ReturnDate = returnDateStr,
                    AdultCount = int.Parse(adultCount),
                    ChildCount = int.Parse(childCount),
                    InfantCount = int.Parse(infantCount),
                    TripType = tripType
                };

                // TrainCheck �� ����
                TrainCheck trainCheckForm = new TrainCheck(searchCondition);
                trainCheckForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� ��ȸ �� ������ �߻��߽��ϴ�: " + ex.Message, "����",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ������ ��¥�� �뼱�� �����ϴ� ���� ���� ���� Ȯ��
        private bool CheckTrainsAvailableOnDate(string departure, string arrival, string date)
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                // �ش� ��¥�� �����ϴ� ������ �ִ��� Ȯ��
                System.Xml.XmlNode dateNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']");
                if (dateNode == null || !dateNode.HasChildNodes)
                {
                    return false; // �ش� ��¥�� �����ϴ� ������ ����
                }

                // �ش� �뼱(����� -> ������)�� �´� ������ �ִ��� Ȯ��
                System.Xml.XmlNodeList trainNodes = xmlDoc.SelectNodes("//train");
                foreach (System.Xml.XmlNode trainNode in trainNodes)
                {
                    string trainDeparture = trainNode.SelectSingleNode("departure")?.InnerText ?? "";
                    string trainArrival = trainNode.SelectSingleNode("arrival")?.InnerText ?? "";

                    // �뼱�� ��ġ�ϴ� ������ ������
                    if (trainDeparture == departure && trainArrival == arrival)
                    {
                        string trainNumber = trainNode.SelectSingleNode("trainNumber")?.InnerText ?? "";

                        // �ش� ��¥�� �� ������ �����ϴ��� Ȯ��
                        System.Xml.XmlNode trainOnDateNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']/train[@trainNumber='{trainNumber}']");
                        if (trainOnDateNode != null)
                        {
                            return true; // �����ϴ� ������ ����
                        }
                    }
                }

                return false; // �ش� �뼱�� �����ϴ� ������ ����
            }
            catch
            {
                return false; // ���� �߻� �� false ��ȯ
            }
        }

        // ���̵� ��ȸ ��ư Ŭ�� �̺�Ʈ �޼���
        private void BtnSearchID_Click(object sender, EventArgs e)
        {
            try
            {
                // �Էµ� �����ȣ ��������
                string bookingID = txtSearchID.Text.Trim();

                if (string.IsNullOrEmpty(bookingID))
                {
                    MessageBox.Show("�����ȣ�� �Է����ּ���.", "�Է� ����",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearchID.Focus();
                    return;
                }

                // �����ȣ ���� ���� Ȯ��
                if (CheckBookingExists(bookingID))
                {
                    // ������ �����ϸ� CheckTicker �� ����
                    try
                    {
                        CheckTicker checkTickerForm = new CheckTicker(bookingID);
                        checkTickerForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("���� ��ȸ â�� �� �� �����ϴ�: " + ex.Message, "����",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // ������ �������� ������ �ȳ� �޽���
                    MessageBox.Show($"�����ȣ '{bookingID}'�� �ش��ϴ� ������ ã�� �� �����ϴ�.\n\n�����ȣ�� �ٽ� Ȯ�����ּ���.",
                        "���� ��ȸ ����", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // �ؽ�Ʈ�ڽ� ��Ŀ�� �� ��ü ����
                    txtSearchID.Focus();
                    txtSearchID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� ��ȸ �� ������ �߻��߽��ϴ�: " + ex.Message, "����",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �����ȣ ���� ���� Ȯ�� �޼���
        private bool CheckBookingExists(string bookingID)
        {
            try
            {
                // trainBook.xml �ν� ������ ����
                if (!System.IO.File.Exists("trainBook.xml"))
                {
                    return false;
                }

                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load("trainBook.xml");

                // �ش� �����ȣ�� booking ��� ã��
                System.Xml.XmlNode bookingNode = xmlDoc.SelectSingleNode($"//booking[bookingID='{bookingID}']");

                // ��尡 �����ϸ� true, �ƴϸ� false
                return bookingNode != null;
            }
            catch (Exception ex)
            {
                // ���� �߻� �� false ��ȯ
                System.Diagnostics.Debug.WriteLine($"CheckBookingExists ����: {ex.Message}");
                return false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}