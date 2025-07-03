using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace WindowProgramming_Assignments
{
    public partial class CheckTicker : Form
    {
        private string bookingID;

        // UI 컨트롤
        private Panel mainPanel;
        private Panel headerPanel;
        private Panel routePanel;
        private Panel infoPanel;
        private Panel passengerPanel;
        private Panel buttonPanel;

        private Label titleLabel;
        private Label bookingIDLabel;
        private Label routeLabel;
        private Label dateTimeLabel;
        private Label trainLabel;
        private Label seatLabel;
        private Label passengerLabel;
        private Label priceLabel;
        private Label statusLabel;
        private Button closeButton;
        private Button printButton;
        private Button cancelBookingButton;

        public CheckTicker(string bookingID)
        {
            this.bookingID = bookingID;
            InitializeComponent();
            LoadBookingDetail();
        }

        private void InitializeComponent()
        {
            // 폼 설정
            this.Size = new Size(450, 720);
            this.Text = "예약 상세 정보";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(230, 248, 255);

            CreateControls();
            SetupLayout();
        }

        private void CreateControls()
        {
            int formWidth = this.ClientSize.Width;
            int panelWidth = 380;
            int centerX = (formWidth - panelWidth) / 2;

            // 메인 패널
            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(10);

            // 헤더 패널
            headerPanel = new Panel();
            headerPanel.Size = new Size(panelWidth, 80);
            headerPanel.BackColor = Color.FromArgb(70, 130, 180);
            headerPanel.Location = new Point(centerX, 20);

            titleLabel = new Label();
            titleLabel.Text = "🎫 예약 상세 정보";
            titleLabel.Font = new Font("한컴 고딕", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Size = new Size(panelWidth - 40, 25);
            titleLabel.Location = new Point(20, 15);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            bookingIDLabel = new Label();
            bookingIDLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
            bookingIDLabel.ForeColor = Color.White;
            bookingIDLabel.Size = new Size(panelWidth - 40, 20);
            bookingIDLabel.Location = new Point(20, 45);
            bookingIDLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 경로 패널
            routePanel = new Panel();
            routePanel.Size = new Size(panelWidth, 100);
            routePanel.BackColor = Color.White;
            routePanel.Location = new Point(centerX, 110);
            routePanel.BorderStyle = BorderStyle.FixedSingle;

            routeLabel = new Label();
            routeLabel.Font = new Font("한컴 고딕", 18F, FontStyle.Bold);
            routeLabel.ForeColor = Color.FromArgb(50, 50, 50);
            routeLabel.Location = new Point(20, 20);
            routeLabel.Size = new Size(panelWidth - 40, 30);
            routeLabel.TextAlign = ContentAlignment.MiddleCenter;

            dateTimeLabel = new Label();
            dateTimeLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
            dateTimeLabel.ForeColor = Color.FromArgb(100, 100, 100);
            dateTimeLabel.Location = new Point(20, 55);
            dateTimeLabel.Size = new Size(panelWidth - 40, 25);
            dateTimeLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 정보 패널
            infoPanel = new Panel();
            infoPanel.Size = new Size(panelWidth, 180);
            infoPanel.BackColor = Color.White;
            infoPanel.Location = new Point(centerX, 220);
            infoPanel.BorderStyle = BorderStyle.FixedSingle;

            trainLabel = new Label();
            trainLabel.Font = new Font("한컴 고딕", 14F, FontStyle.Bold);
            trainLabel.Location = new Point(30, 20);
            trainLabel.Size = new Size(panelWidth - 60, 30);
            trainLabel.TextAlign = ContentAlignment.MiddleLeft;

            seatLabel = new Label();
            seatLabel.Font = new Font("한컴 고딕", 14F, FontStyle.Bold);
            seatLabel.Location = new Point(30, 55);
            seatLabel.Size = new Size(panelWidth - 60, 30);
            seatLabel.TextAlign = ContentAlignment.MiddleLeft;

            passengerLabel = new Label();
            passengerLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
            passengerLabel.Location = new Point(30, 90);
            passengerLabel.Size = new Size(panelWidth - 60, 40);
            passengerLabel.TextAlign = ContentAlignment.MiddleLeft;

            priceLabel = new Label();
            priceLabel.Font = new Font("한컴 고딕", 16F, FontStyle.Bold);
            priceLabel.ForeColor = Color.FromArgb(220, 20, 60);
            priceLabel.Location = new Point(30, 135);
            priceLabel.Size = new Size(panelWidth - 60, 35);
            priceLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 상태 패널
            statusLabel = new Label();
            statusLabel.Font = new Font("한컴 고딕", 14F, FontStyle.Bold);
            statusLabel.BackColor = Color.FromArgb(144, 238, 144);
            statusLabel.ForeColor = Color.FromArgb(0, 100, 0);
            statusLabel.Location = new Point(centerX, 410);
            statusLabel.Size = new Size(panelWidth, 40);
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.BorderStyle = BorderStyle.FixedSingle;

            // 예약 취소 버튼
            cancelBookingButton = new Button();
            cancelBookingButton.Text = "❌ 예약 취소";
            cancelBookingButton.Size = new Size(150, 40);
            cancelBookingButton.Location = new Point(centerX + (panelWidth - 150) / 2, 460);
            cancelBookingButton.BackColor = Color.FromArgb(220, 20, 60);
            cancelBookingButton.ForeColor = Color.White;
            cancelBookingButton.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            cancelBookingButton.FlatStyle = FlatStyle.Flat;
            cancelBookingButton.Click += CancelBookingButton_Click;

            // 버튼 패널
            buttonPanel = new Panel();
            buttonPanel.Size = new Size(panelWidth, 60);
            buttonPanel.Location = new Point(centerX, 510);

            int buttonWidth = 100;
            int buttonSpacing = 20;
            int totalButtonWidth = (buttonWidth * 2) + buttonSpacing;
            int buttonStartX = (panelWidth - totalButtonWidth) / 2;

            printButton = new Button();
            printButton.Text = "인쇄";
            printButton.Size = new Size(buttonWidth, 35);
            printButton.Location = new Point(buttonStartX, 15);
            printButton.BackColor = Color.FromArgb(255, 140, 0);
            printButton.ForeColor = Color.White;
            printButton.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            printButton.FlatStyle = FlatStyle.Flat;

            closeButton = new Button();
            closeButton.Text = "닫기";
            closeButton.Size = new Size(buttonWidth, 35);
            closeButton.Location = new Point(buttonStartX + buttonWidth + buttonSpacing, 15);
            closeButton.BackColor = Color.FromArgb(70, 130, 180);
            closeButton.ForeColor = Color.White;
            closeButton.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Click += CloseButton_Click;
        }

        private void SetupLayout()
        {
            // 컨트롤 패널 추가
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(bookingIDLabel);

            routePanel.Controls.Add(routeLabel);
            routePanel.Controls.Add(dateTimeLabel);

            infoPanel.Controls.Add(trainLabel);
            infoPanel.Controls.Add(seatLabel);
            infoPanel.Controls.Add(passengerLabel);
            infoPanel.Controls.Add(priceLabel);

            buttonPanel.Controls.Add(printButton);
            buttonPanel.Controls.Add(closeButton);

            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(routePanel);
            mainPanel.Controls.Add(infoPanel);
            mainPanel.Controls.Add(statusLabel);
            mainPanel.Controls.Add(cancelBookingButton);
            mainPanel.Controls.Add(buttonPanel);

            this.Controls.Add(mainPanel);
        }

        private void LoadBookingDetail()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainBook.xml");

                // 전달받은 예약번호로 해당 예약 정보 찾기
                XmlNode bookingNode = xmlDoc.SelectSingleNode($"//booking[bookingID='{bookingID}']");

                if (bookingNode != null)
                {
                    // 기본 정보
                    bookingIDLabel.Text = $"예약번호: {bookingID}";

                    // 경로 정보
                    string departure = bookingNode.SelectSingleNode("departure")?.InnerText ?? "-";
                    string arrival = bookingNode.SelectSingleNode("arrival")?.InnerText ?? "-";
                    routeLabel.Text = $"{departure} → {arrival}";

                    // 날짜/시간 정보
                    string date = bookingNode.SelectSingleNode("departureDate")?.InnerText ?? "-";
                    string time = bookingNode.SelectSingleNode("departureTime")?.InnerText ?? "-";
                    string tripType = bookingNode.SelectSingleNode("tripType")?.InnerText ?? "";

                    string dateTimeInfo = $"{date} {time} 출발";
                    if (!string.IsNullOrEmpty(tripType))
                    {
                        dateTimeInfo += $" ({tripType})";
                    }
                    dateTimeLabel.Text = dateTimeInfo;

                    // 열차 정보
                    string trainNumber = bookingNode.SelectSingleNode("trainNumber")?.InnerText ?? "-";
                    trainLabel.Text = $"🚄 열차: {trainNumber}";

                    // 좌석 정보
                    string seatNumber = bookingNode.SelectSingleNode("seatNumber")?.InnerText ?? "-";
                    seatLabel.Text = $"💺 좌석: {seatNumber}";

                    // 승객 정보
                    XmlNode passengersNode = bookingNode.SelectSingleNode("passengers");
                    if (passengersNode != null)
                    {
                        string adult = passengersNode.SelectSingleNode("adult")?.InnerText ?? "0";
                        string child = passengersNode.SelectSingleNode("child")?.InnerText ?? "0";
                        string infant = passengersNode.SelectSingleNode("infant")?.InnerText ?? "0";

                        string passengerInfo = $"👥 승객: 성인 {adult}명, 소아 {child}명, 유아 {infant}명";

                        // 사용자 정보 추가
                        string userID = bookingNode.SelectSingleNode("userID")?.InnerText ?? "";
                        string userName = bookingNode.SelectSingleNode("userName")?.InnerText ?? "";
                        string memberType = bookingNode.SelectSingleNode("memberType")?.InnerText ?? "";

                        if (!string.IsNullOrEmpty(userID))
                        {
                            // 회원인 경우 -> 이름(ID) 형태로 표시
                            string displayName = !string.IsNullOrEmpty(userName) ? $"{userName}({userID})" : userID;
                            passengerInfo += $"\n👤 예약자: {displayName} ({memberType})";
                        }
                        else if (!string.IsNullOrEmpty(memberType))
                        {
                            // 비회원인 경우 -> 비회원만 표시
                            passengerInfo += $"\n👤 예약자: {memberType}";
                        }

                        passengerLabel.Text = passengerInfo;
                    }

                    // 가격 정보
                    string price = bookingNode.SelectSingleNode("totalPrice")?.InnerText ?? "0";
                    priceLabel.Text = $"💰 총 요금: {int.Parse(price):N0}원";

                    // 상태 정보
                    string status = bookingNode.SelectSingleNode("status")?.InnerText ?? "-";
                    statusLabel.Text = $"📋 {status}";

                    // 상태에 따른 색상 변경
                    switch (status)
                    {
                        case "예약완료":
                            statusLabel.BackColor = Color.FromArgb(144, 238, 144);
                            statusLabel.ForeColor = Color.FromArgb(0, 100, 0);
                            cancelBookingButton.Visible = true; // 예약완료일 때만 취소 버튼 표시
                            break;
                        case "취소됨":
                            statusLabel.BackColor = Color.FromArgb(255, 182, 193);
                            statusLabel.ForeColor = Color.FromArgb(139, 0, 0);
                            cancelBookingButton.Visible = false; // 이미 취소된 예약은 취소 버튼 숨김
                            break;
                        case "변경됨":
                            statusLabel.BackColor = Color.FromArgb(255, 255, 224);
                            statusLabel.ForeColor = Color.FromArgb(255, 140, 0);
                            cancelBookingButton.Visible = true; // 변경된 예약도 취소 가능
                            break;
                        default:
                            cancelBookingButton.Visible = false;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"예약번호 '{bookingID}'에 해당하는 예약 정보를 찾을 수 없습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 정보를 불러오는 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // 예약 취소 버튼 클릭
        private void CancelBookingButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 예약 정보에서 회원 여부 확인
                if (IsBookingByMember())
                {
                    // 회원 예약인 경우 로그인 확인
                    if (!CheckLoginStatus())
                    {
                        // 로그인되지 않은 경우 로그인 요청
                        DialogResult loginResult = MessageBox.Show(
                            "회원 예약 취소를 위해서는 로그인이 필요합니다.\n\n로그인하시겠습니까?",
                            "로그인 필요",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (loginResult == DialogResult.Yes)
                        {
                            // 로그인 폼 실행
                            LogIn loginForm = new LogIn();
                            DialogResult result = loginForm.ShowDialog();

                            if (result != DialogResult.OK)
                            {
                                MessageBox.Show("로그인이 취소되었습니다.\n예약 취소를 진행할 수 없습니다.", "취소",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // 로그인 성공 후 예약자 본인 확인
                            if (!IsBookingOwner())
                            {
                                MessageBox.Show("예약자 본인만 취소할 수 있습니다.\n현재 로그인된 계정과 예약자가 일치하지 않습니다.", "권한 오류",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("로그인이 필요합니다.\n예약 취소를 진행할 수 없습니다.", "취소",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        // 이미 로그인된 경우에도 예약자 본인 확인
                        if (!IsBookingOwner())
                        {
                            MessageBox.Show("예약자 본인만 취소할 수 있습니다.\n현재 로그인된 계정과 예약자가 일치하지 않습니다.", "권한 오류",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // 취소 확인 대화상자
                DialogResult confirmResult = MessageBox.Show(
                    $"정말로 예약번호 '{bookingID}' 표를 취소하시겠습니까?\n\n취소된 예약은 복구할 수 없습니다.",
                    "예약 취소 확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // 예약 취소 처리
                    if (CancelBookingInXml())
                    {
                        MessageBox.Show("표를 취소하였습니다.", "취소 완료",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 창 닫기
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("예약 취소 처리 중 오류가 발생했습니다.", "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 취소 처리 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 회원 예약인지 확인
        private bool IsBookingByMember()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainBook.xml");

                XmlNode bookingNode = xmlDoc.SelectSingleNode($"//booking[bookingID='{bookingID}']");
                if (bookingNode != null)
                {
                    string memberType = bookingNode.SelectSingleNode("memberType")?.InnerText ?? "";
                    string userID = bookingNode.SelectSingleNode("userID")?.InnerText ?? "";

                    return memberType == "회원" && !string.IsNullOrEmpty(userID);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // 로그인 상태 확인
        private bool CheckLoginStatus()
        {
            try
            {
                return MainScreen.IsLoggedIn;
            }
            catch
            {
                return false;
            }
        }

        // 예약자 본인인지 확인
        private bool IsBookingOwner()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainBook.xml");

                XmlNode bookingNode = xmlDoc.SelectSingleNode($"//booking[bookingID='{bookingID}']");
                if (bookingNode != null)
                {
                    string bookingUserID = bookingNode.SelectSingleNode("userID")?.InnerText ?? "";
                    string currentUserID = MainScreen.CurrentUser ?? "";

                    // 현재 로그인된 사용자가 이름으로 저장되어 있을 경우를 대비
                    // CustomerInfo.xml에서 이름으로 ID 찾기
                    if (!string.IsNullOrEmpty(currentUserID))
                    {
                        string actualUserID = GetUserIDFromName(currentUserID);
                        if (!string.IsNullOrEmpty(actualUserID))
                        {
                            currentUserID = actualUserID;
                        }
                    }

                    return bookingUserID == currentUserID;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // 이름으로 사용자 ID 찾기
        private string GetUserIDFromName(string userName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CustomerInfo.xml");

                XmlNode userNode = xmlDoc.SelectSingleNode($"//user[name='{userName}']");
                if (userNode != null)
                {
                    return userNode.SelectSingleNode("ID")?.InnerText ?? "";
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        // XML에서 예약 정보 삭제 및 잔여 좌석 복구
        private bool CancelBookingInXml()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainBook.xml");

                // 해당 예약번호의 booking 노드 찾기
                XmlNode bookingNode = xmlDoc.SelectSingleNode($"//booking[bookingID='{bookingID}']");

                if (bookingNode != null)
                {
                    // 예약 정보에서 필요한 데이터 추출
                    string trainNumber = bookingNode.SelectSingleNode("trainNumber")?.InnerText ?? "";
                    string departureDate = bookingNode.SelectSingleNode("departureDate")?.InnerText ?? "";

                    // 승객 수 계산
                    XmlNode passengersNode = bookingNode.SelectSingleNode("passengers");
                    int seatsToRestore = 0;

                    if (passengersNode != null)
                    {
                        int adultCount = int.Parse(passengersNode.SelectSingleNode("adult")?.InnerText ?? "0");
                        int childCount = int.Parse(passengersNode.SelectSingleNode("child")?.InnerText ?? "0");
                        // 유아는 별도 좌석이 필요하지 않으므로 제외
                        seatsToRestore = adultCount + childCount;
                    }

                    // 예약 정보 삭제
                    bookingNode.ParentNode.RemoveChild(bookingNode);
                    xmlDoc.Save("trainBook.xml");

                    // 잔여 좌석 복구
                    if (seatsToRestore > 0 && !string.IsNullOrEmpty(trainNumber) && !string.IsNullOrEmpty(departureDate))
                    {
                        bool seatRestored = RestoreAvailableSeats(trainNumber, departureDate, seatsToRestore);
                        if (seatRestored)
                        {
                            System.Diagnostics.Debug.WriteLine("잔여 좌석 복구 성공");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("잔여 좌석 복구 실패 (예약 취소는 완료됨)");
                        }
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("삭제할 예약 정보를 찾을 수 없습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 취소 처리 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 잔여 좌석 복구 메서드
        private bool RestoreAvailableSeats(string trainNumber, string date, int seatsToRestore)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                // 해당 날짜의 열차 잔여석 정보 찾기
                XmlNode seatNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']/train[@trainNumber='{trainNumber}']");

                if (seatNode != null)
                {
                    // 현재 잔여석 수 가져오기
                    string availableSeatsStr = seatNode.Attributes["availableSeats"]?.Value ?? "0";
                    if (int.TryParse(availableSeatsStr, out int currentAvailableSeats))
                    {
                        // 잔여석 수에 취소된 좌석 수 추가
                        int newAvailableSeats = currentAvailableSeats + seatsToRestore;

                        // 전체 좌석 수를 초과하지 않도록 제한
                        int maxSeats = GetTotalSeats(trainNumber);
                        if (newAvailableSeats > maxSeats)
                        {
                            newAvailableSeats = maxSeats;
                        }

                        // 새로운 잔여석 수 업데이트
                        seatNode.Attributes["availableSeats"].Value = newAvailableSeats.ToString();

                        // XML 파일 저장
                        xmlDoc.Save("trainInfo.xml");

                        System.Diagnostics.Debug.WriteLine($"잔여석 복구: {currentAvailableSeats} → {newAvailableSeats} (복구된 좌석: {seatsToRestore})");
                        return true;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"해당 날짜({date})의 열차({trainNumber}) 정보를 찾을 수 없습니다.");
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RestoreAvailableSeats 오류: {ex.Message}");
                return false;
            }
        }

        // 열차의 총 좌석 수 조회
        private int GetTotalSeats(string trainNumber)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                XmlNode trainNode = xmlDoc.SelectSingleNode($"//train[trainNumber='{trainNumber}']");
                if (trainNode != null)
                {
                    XmlNode seatsNode = trainNode.SelectSingleNode("seats/totalSeats");
                    if (seatsNode != null)
                    {
                        if (int.TryParse(seatsNode.InnerText, out int totalSeats))
                        {
                            return totalSeats;
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}