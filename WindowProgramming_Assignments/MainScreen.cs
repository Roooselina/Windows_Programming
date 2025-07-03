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

            // 로고 이미지 삽입
            try
            {
                pictureBox1.Image = Image.FromFile("Logo.png");
                pictureBox2.Image = Image.FromFile("Logo.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("로고 이미지를 불러올 수 없습니다: " + ex.Message, "이미지 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 로그인 상태 초기화
            UpdateLoginStatus();

            // 폼 활성화 이벤트 연결
            this.Activated += MainScreen_Activated;

            // 좌석 조회 버튼 이벤트 연결
            btnSearchFlights.Click += BtnSearchFlights_Click;
        }

        // 좌석 조회 버튼 클릭 이벤트
        private void BtnSearchFlights_Click(object sender, EventArgs e)
        {
            try
            {
                // 입력값 검증
                string departure = comboFrom.Text.Trim();
                string arrival = comboTo.Text.Trim();

                if (string.IsNullOrEmpty(departure))
                {
                    MessageBox.Show("출발지를 선택해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboFrom.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(arrival))
                {
                    MessageBox.Show("도착지를 선택해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboTo.Focus();
                    return;
                }

                if (departure == arrival)
                {
                    MessageBox.Show("출발지와 도착지가 같을 수 없습니다.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboTo.Focus();
                    return;
                }

                // 날짜 검증
                DateTime today = DateTime.Today;
                DateTime departureDate = dateStart.Value.Date;
                DateTime returnDate = dateReturn.Value.Date;

                // 출발일이 오늘보다 이전인지 검증
                if (departureDate < today)
                {
                    MessageBox.Show($"출발일은 오늘({today:yyyy-MM-dd}) 이후 날짜를 선택해주세요.\n현재 선택된 출발일: {departureDate:yyyy-MM-dd}",
                        "날짜 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateStart.Focus();
                    return;
                }

                // 출발일이 복귀일보다 늦은 경우 검증
                if (departureDate > returnDate)
                {
                    MessageBox.Show($"출발일이 복귀일보다 늦을 수 없습니다.\n출발일: {departureDate:yyyy-MM-dd}\n복귀일: {returnDate:yyyy-MM-dd}\n\n날짜를 다시 설정해주세요.",
                        "날짜 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateReturn.Focus();
                    return;
                }

                // 승객 수 확인
                string adultCount = comboAdult.Text;
                string childCount = comboChild.Text;
                string infantCount = comboInfant.Text;

                if (string.IsNullOrEmpty(adultCount)) adultCount = "0";
                if (string.IsNullOrEmpty(childCount)) childCount = "0";
                if (string.IsNullOrEmpty(infantCount)) infantCount = "0";

                int totalPassengers = int.Parse(adultCount) + int.Parse(childCount) + int.Parse(infantCount);
                if (totalPassengers == 0)
                {
                    MessageBox.Show("최소 1명 이상의 승객을 선택해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboAdult.Focus();
                    return;
                }

                // 여행 타입 확인
                string tripType = radioRoundTrip.Checked ? "왕복" : "편도";
                string departureDateStr = departureDate.ToString("yyyy-MM-dd");
                string returnDateStr = returnDate.ToString("yyyy-MM-dd");

                // 선택한 날짜에 운행하는 열차 존재 여부 미리 확인
                // 그래서 checkTrain에서 빈 칸 보이지 않도록
                if (!CheckTrainsAvailableOnDate(departure, arrival, departureDateStr))
                {
                    MessageBox.Show($"선택하신 날짜({departureDateStr})에 {departure}에서 {arrival}로 가는 열차가 없습니다.",
                        "운행 정보 없음", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 왕복의 경우 복귀일에도 열차가 있는지 확인
                if (radioRoundTrip.Checked && !CheckTrainsAvailableOnDate(arrival, departure, returnDateStr))
                {
                    MessageBox.Show($"선택하신 복귀일({returnDateStr})에 {arrival}에서 {departure}로 가는 열차가 없습니다.",
                        "복귀 운행 정보 없음", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 검색 조건 객체 생성
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

                // TrainCheck 폼 열기
                TrainCheck trainCheckForm = new TrainCheck(searchCondition);
                trainCheckForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("열차 조회 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 선택한 날짜와 노선에 운행하는 열차 존재 여부 확인
        private bool CheckTrainsAvailableOnDate(string departure, string arrival, string date)
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                // 해당 날짜에 운행하는 열차가 있는지 확인
                System.Xml.XmlNode dateNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']");
                if (dateNode == null || !dateNode.HasChildNodes)
                {
                    return false; // 해당 날짜에 운행하는 열차가 없음
                }

                // 해당 노선(출발지 -> 도착지)에 맞는 열차가 있는지 확인
                System.Xml.XmlNodeList trainNodes = xmlDoc.SelectNodes("//train");
                foreach (System.Xml.XmlNode trainNode in trainNodes)
                {
                    string trainDeparture = trainNode.SelectSingleNode("departure")?.InnerText ?? "";
                    string trainArrival = trainNode.SelectSingleNode("arrival")?.InnerText ?? "";

                    // 노선이 일치하는 열차가 있으면
                    if (trainDeparture == departure && trainArrival == arrival)
                    {
                        string trainNumber = trainNode.SelectSingleNode("trainNumber")?.InnerText ?? "";

                        // 해당 날짜에 이 열차가 운행하는지 확인
                        System.Xml.XmlNode trainOnDateNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']/train[@trainNumber='{trainNumber}']");
                        if (trainOnDateNode != null)
                        {
                            return true; // 운행하는 열차가 있음
                        }
                    }
                }

                return false; // 해당 노선에 운행하는 열차가 없음
            }
            catch
            {
                return false; // 오류 발생 시 false 반환
            }
        }

        // 아이디 조회 버튼 클릭 이벤트 메서드
        private void BtnSearchID_Click(object sender, EventArgs e)
        {
            try
            {
                // 입력된 예약번호 가져오기
                string bookingID = txtSearchID.Text.Trim();

                if (string.IsNullOrEmpty(bookingID))
                {
                    MessageBox.Show("예약번호를 입력해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearchID.Focus();
                    return;
                }

                // 예약번호 존재 여부 확인
                if (CheckBookingExists(bookingID))
                {
                    // 예약이 존재하면 CheckTicker 폼 열기
                    try
                    {
                        CheckTicker checkTickerForm = new CheckTicker(bookingID);
                        checkTickerForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("예약 조회 창을 열 수 없습니다: " + ex.Message, "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // 예약이 존재하지 않으면 안내 메시지
                    MessageBox.Show($"예약번호 '{bookingID}'에 해당하는 예약을 찾을 수 없습니다.\n\n예약번호를 다시 확인해주세요.",
                        "예약 조회 실패", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 텍스트박스 포커스 및 전체 선택
                    txtSearchID.Focus();
                    txtSearchID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 조회 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 예약번호 존재 여부 확인 메서드
        private bool CheckBookingExists(string bookingID)
        {
            try
            {
                // trainBook.xml 인식 오류시 에러
                if (!System.IO.File.Exists("trainBook.xml"))
                {
                    return false;
                }

                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load("trainBook.xml");

                // 해당 예약번호의 booking 노드 찾기
                System.Xml.XmlNode bookingNode = xmlDoc.SelectSingleNode($"//booking[bookingID='{bookingID}']");

                // 노드가 존재하면 true, 아니면 false
                return bookingNode != null;
            }
            catch (Exception ex)
            {
                // 오류 발생 시 false 반환
                System.Diagnostics.Debug.WriteLine($"CheckBookingExists 오류: {ex.Message}");
                return false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}