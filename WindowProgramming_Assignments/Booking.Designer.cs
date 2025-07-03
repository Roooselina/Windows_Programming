using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace WindowProgramming_Assignments
{
    public partial class Booking : Form
    {
        private TrainSearchCondition searchCondition;
        private string trainNumber;
        private string trainName;
        private int adultPrice;
        private int childPrice;
        private int totalPrice;
        private int availableSeats;

        // UI 컨트롤
        private Panel mainPanel;
        private Panel headerPanel;
        private Panel routePanel;
        private Panel trainPanel;
        private Panel passengerPanel;
        private Panel pricePanel;
        private Panel buttonPanel;

        private Label titleLabel;
        private Label routeLabel;
        private Label dateTimeLabel;
        private Label trainLabel;
        private Label seatLabel;
        private Label passengerLabel;
        private Label adultPriceLabel;
        private Label childPriceLabel;
        private Label infantPriceLabel;
        private Label totalPriceLabel;
        private Button paymentButton;
        private Button closeButton;

        // 추가 열차 정보
        private string departureTime;
        private string arrivalTime;
        private string duration;
        private string trainType;

        public Booking(TrainSearchCondition condition, string trainNumber, string trainName,
                      int adultPrice, int childPrice, int availableSeats)
        {
            this.searchCondition = condition;
            this.trainNumber = trainNumber;
            this.trainName = trainName;
            this.adultPrice = adultPrice;
            this.childPrice = childPrice;
            this.availableSeats = availableSeats;

            // 총 요금 계산
            this.totalPrice = (adultPrice * condition.AdultCount) + (childPrice * condition.ChildCount);

            // XML에서 추가 열차 정보 로드
            LoadTrainDetailInfo();

            InitializeComponent();
            LoadBookingInfo();
        }

        private void InitializeComponent()
        {
            // 폼 설정
            this.Size = new Size(450, 690);
            this.Text = "예약 확인 및 결제";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 248, 255);

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
            headerPanel.Size = new Size(panelWidth, 70);
            headerPanel.BackColor = Color.FromArgb(30, 144, 255);
            headerPanel.Location = new Point(centerX, 20);

            titleLabel = new Label();
            titleLabel.Text = "🎫 예약 확인 및 결제";
            titleLabel.Font = new Font("한컴 고딕", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Size = new Size(panelWidth - 40, 30);
            titleLabel.Location = new Point(20, 20);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 경로 패널
            routePanel = new Panel();
            routePanel.Size = new Size(panelWidth, 80);
            routePanel.BackColor = Color.White;
            routePanel.Location = new Point(centerX, 100);
            routePanel.BorderStyle = BorderStyle.FixedSingle;

            routeLabel = new Label();
            routeLabel.Font = new Font("한컴 고딕", 18F, FontStyle.Bold);
            routeLabel.ForeColor = Color.FromArgb(50, 50, 50);
            routeLabel.Location = new Point(20, 15);
            routeLabel.Size = new Size(panelWidth - 40, 30);
            routeLabel.TextAlign = ContentAlignment.MiddleCenter;

            dateTimeLabel = new Label();
            dateTimeLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
            dateTimeLabel.ForeColor = Color.FromArgb(100, 100, 100);
            dateTimeLabel.Location = new Point(20, 45);
            dateTimeLabel.Size = new Size(panelWidth - 40, 25);
            dateTimeLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 열차 정보 패널
            trainPanel = new Panel();
            trainPanel.Size = new Size(panelWidth, 120);
            trainPanel.BackColor = Color.White;
            trainPanel.Location = new Point(centerX, 190);
            trainPanel.BorderStyle = BorderStyle.FixedSingle;

            trainLabel = new Label();
            trainLabel.Font = new Font("한컴 고딕", 14F, FontStyle.Bold);
            trainLabel.Location = new Point(30, 15);
            trainLabel.Size = new Size(panelWidth - 60, 25);
            trainLabel.TextAlign = ContentAlignment.MiddleLeft;

            seatLabel = new Label();
            seatLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
            seatLabel.ForeColor = Color.FromArgb(100, 100, 100);
            seatLabel.Location = new Point(30, 45);
            seatLabel.Size = new Size(panelWidth - 60, 25);
            seatLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 시간 정보 라벨
            Label timeLabel = new Label();
            timeLabel.Font = new Font("한컴 고딕", 11F, FontStyle.Regular);
            timeLabel.ForeColor = Color.FromArgb(70, 70, 70);
            timeLabel.Location = new Point(30, 70);
            timeLabel.Size = new Size(panelWidth - 60, 20);
            timeLabel.TextAlign = ContentAlignment.MiddleLeft;
            timeLabel.Name = "timeLabel";

            // 소요시간 라벨
            Label durationLabel = new Label();
            durationLabel.Font = new Font("한컴 고딕", 11F, FontStyle.Regular);
            durationLabel.ForeColor = Color.FromArgb(70, 70, 70);
            durationLabel.Location = new Point(30, 90);
            durationLabel.Size = new Size(panelWidth - 60, 20);
            durationLabel.TextAlign = ContentAlignment.MiddleLeft;
            durationLabel.Name = "durationLabel";

            trainPanel.Controls.Add(timeLabel);
            trainPanel.Controls.Add(durationLabel);

            // 승객 정보 패널
            passengerPanel = new Panel();
            passengerPanel.Size = new Size(panelWidth, 60);
            passengerPanel.BackColor = Color.White;
            passengerPanel.Location = new Point(centerX, 320);
            passengerPanel.BorderStyle = BorderStyle.FixedSingle;

            passengerLabel = new Label();
            passengerLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            passengerLabel.Location = new Point(30, 20);
            passengerLabel.Size = new Size(panelWidth - 60, 25);
            passengerLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 요금 정보 패널
            pricePanel = new Panel();
            pricePanel.Size = new Size(panelWidth, 120);
            pricePanel.BackColor = Color.White;
            pricePanel.Location = new Point(centerX, 390);
            pricePanel.BorderStyle = BorderStyle.FixedSingle;

            adultPriceLabel = new Label();
            adultPriceLabel.Font = new Font("한컴 고딕", 11F, FontStyle.Regular);
            adultPriceLabel.Location = new Point(30, 15);
            adultPriceLabel.Size = new Size(panelWidth - 60, 20);
            adultPriceLabel.TextAlign = ContentAlignment.MiddleLeft;

            childPriceLabel = new Label();
            childPriceLabel.Font = new Font("한컴 고딕", 11F, FontStyle.Regular);
            childPriceLabel.Location = new Point(30, 40);
            childPriceLabel.Size = new Size(panelWidth - 60, 20);
            childPriceLabel.TextAlign = ContentAlignment.MiddleLeft;

            infantPriceLabel = new Label();
            infantPriceLabel.Font = new Font("한컴 고딕", 11F, FontStyle.Regular);
            infantPriceLabel.Location = new Point(30, 65);
            infantPriceLabel.Size = new Size(panelWidth - 60, 20);
            infantPriceLabel.TextAlign = ContentAlignment.MiddleLeft;

            totalPriceLabel = new Label();
            totalPriceLabel.Font = new Font("한컴 고딕", 16F, FontStyle.Bold);
            totalPriceLabel.ForeColor = Color.FromArgb(220, 20, 60);
            totalPriceLabel.Location = new Point(30, 90);
            totalPriceLabel.Size = new Size(panelWidth - 60, 25);
            totalPriceLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 버튼 패널
            buttonPanel = new Panel();
            buttonPanel.Size = new Size(panelWidth, 60);
            buttonPanel.Location = new Point(centerX, 520);

            // 중앙 배치
            int buttonWidth = 120;
            int buttonSpacing = 20;
            int totalButtonWidth = (buttonWidth * 2) + buttonSpacing;
            int buttonStartX = (panelWidth - totalButtonWidth) / 2;

            paymentButton = new Button();
            paymentButton.Text = "💳 결제하기";
            paymentButton.Size = new Size(buttonWidth, 40);
            paymentButton.Location = new Point(buttonStartX, 10);
            paymentButton.BackColor = Color.FromArgb(34, 139, 34);
            paymentButton.ForeColor = Color.White;
            paymentButton.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            paymentButton.FlatStyle = FlatStyle.Flat;
            paymentButton.Click += PaymentButton_Click;

            closeButton = new Button();
            closeButton.Text = "❌ 취소";
            closeButton.Size = new Size(buttonWidth, 40);
            closeButton.Location = new Point(buttonStartX + buttonWidth + buttonSpacing, 10);
            closeButton.BackColor = Color.FromArgb(220, 20, 60);
            closeButton.ForeColor = Color.White;
            closeButton.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Click += CloseButton_Click;
        }

        private void SetupLayout()
        {
            // 패널 추가
            headerPanel.Controls.Add(titleLabel);

            routePanel.Controls.Add(routeLabel);
            routePanel.Controls.Add(dateTimeLabel);

            trainPanel.Controls.Add(trainLabel);
            trainPanel.Controls.Add(seatLabel);

            passengerPanel.Controls.Add(passengerLabel);

            pricePanel.Controls.Add(adultPriceLabel);
            pricePanel.Controls.Add(childPriceLabel);
            pricePanel.Controls.Add(infantPriceLabel);
            pricePanel.Controls.Add(totalPriceLabel);

            buttonPanel.Controls.Add(paymentButton);
            buttonPanel.Controls.Add(closeButton);

            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(routePanel);
            mainPanel.Controls.Add(trainPanel);
            mainPanel.Controls.Add(passengerPanel);
            mainPanel.Controls.Add(pricePanel);
            mainPanel.Controls.Add(buttonPanel);

            this.Controls.Add(mainPanel);
        }

        private void LoadBookingInfo()
        {
            // null 체크 및 기본값 설정
            if (searchCondition == null)
            {
                MessageBox.Show("검색 조건 정보가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 경로 정보
            string departure = searchCondition.Departure ?? "출발지";
            string arrival = searchCondition.Arrival ?? "도착지";
            string departureDate = searchCondition.DepartureDate ?? "날짜";

            routeLabel.Text = $"{departure} → {arrival}";

            // 왕복/편도 정보 포함
            string tripTypeInfo = !string.IsNullOrEmpty(searchCondition.TripType) ? $" ({searchCondition.TripType})" : "";
            dateTimeLabel.Text = $"{departureDate} 출발{tripTypeInfo}";

            // 열차 정보
            trainLabel.Text = $"🚄 {trainNumber ?? "미정"} ({trainName ?? "일반열차"})";

            // 열차 유형 표시
            string typeInfo = !string.IsNullOrEmpty(trainType) ? $" [{trainType}]" : "";
            trainLabel.Text += typeInfo;

            seatLabel.Text = $"💺 잔여석: {availableSeats}석";

            // 시간 정보 표시
            Label timeLabel = trainPanel.Controls.Find("timeLabel", false).FirstOrDefault() as Label;
            if (timeLabel != null)
            {
                string timeInfo = "";
                if (!string.IsNullOrEmpty(departureTime) && !string.IsNullOrEmpty(arrivalTime))
                {
                    timeInfo = $"🕐 {departureTime} → {arrivalTime}";
                }
                else
                {
                    timeInfo = "🕐 시간 정보 없음";
                }
                timeLabel.Text = timeInfo;
            }

            // 소요시간 정보 표시
            Label durationLabel = trainPanel.Controls.Find("durationLabel", false).FirstOrDefault() as Label;
            if (durationLabel != null)
            {
                string durationInfo = "";
                if (!string.IsNullOrEmpty(duration))
                {
                    durationInfo = $"⏱️ 소요시간: {ConvertMinutesToHourMin(duration)}";
                }
                else
                {
                    durationInfo = "⏱️ 소요시간: 정보 없음";
                }
                durationLabel.Text = durationInfo;
            }

            // 승객 정보
            passengerLabel.Text = $"👥 성인 {searchCondition.AdultCount}명, 소아 {searchCondition.ChildCount}명, 유아 {searchCondition.InfantCount}명";

            // 요금 정보
            // trainInfo에 있는 요금대로 계산 | 유아는 무료
            int adultTotal = adultPrice * searchCondition.AdultCount;
            int childTotal = childPrice * searchCondition.ChildCount;

            adultPriceLabel.Text = $"성인 요금: {adultPrice:N0}원 × {searchCondition.AdultCount}명 = {adultTotal:N0}원";
            childPriceLabel.Text = $"소아 요금: {childPrice:N0}원 × {searchCondition.ChildCount}명 = {childTotal:N0}원";
            infantPriceLabel.Text = $"유아 요금: 무료 × {searchCondition.InfantCount}명 = 0원";
            totalPriceLabel.Text = $"💰 총 요금: {totalPrice:N0}원";
        }

        // XML에서 추가 열차 정보 import
        private void LoadTrainDetailInfo()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                // 해당 열차번호의 상세 정보 조회
                XmlNode trainNode = xmlDoc.SelectSingleNode($"//train[trainNumber='{trainNumber}']");
                if (trainNode != null)
                {
                    departureTime = trainNode.SelectSingleNode("departureTime")?.InnerText ?? "";
                    arrivalTime = trainNode.SelectSingleNode("arrivalTime")?.InnerText ?? "";
                    duration = trainNode.SelectSingleNode("duration")?.InnerText ?? "";
                    trainType = trainNode.SelectSingleNode("trainType")?.InnerText ?? "";
                }
            }
            catch (Exception ex)
            {
                // 오류 발생해도 예약 진행할 수 있도록 default data 유지
                departureTime = "";
                arrivalTime = "";
                duration = "";
                trainType = "";
            }
        }

        // 분을 시간:분 형식으로 변환
        private string ConvertMinutesToHourMin(string minutesStr)
        {
            if (int.TryParse(minutesStr, out int minutes))
            {
                int hours = minutes / 60;
                int remainingMinutes = minutes % 60;
                return $"{hours}시간 {remainingMinutes}분";
            }
            return minutesStr;
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            // null 체크
            if (searchCondition == null)
            {
                MessageBox.Show("검색 조건 정보가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // MainScreen의 정적 변수로 로그인 상태 확인
            bool isLoggedIn = CheckLoginStatus();
            string userID = GetCurrentUserID();
            string userName = GetCurrentUserName();

            if (!isLoggedIn)
            {
                // 로그인 X 경우 -> 로그인 권유
                DialogResult loginResult = MessageBox.Show(
                    "로그인하시면 예약 내역을 조회하고 관리할 수 있습니다.\n\n로그인하시겠습니까?",
                    "로그인 권유",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (loginResult == DialogResult.Yes)
                {
                    // 로그인 폼 실행
                    try
                    {
                        LogIn loginForm = new LogIn();
                        DialogResult result = loginForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            // 로그인 성공 시 MainScreen의 정적 변수에서 다시 확인
                            // 성공하면 MainScreen과 연동해서 쭉 로그인 상태로 진행
                            isLoggedIn = CheckLoginStatus();
                            userID = GetCurrentUserID();
                            userName = GetCurrentUserName();

                        }
                        else
                        {
                            // 로그인 취소 시 비회원으로 진행
                            isLoggedIn = false;
                            userID = "";
                            userName = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("로그인 폼을 열 수 없습니다: " + ex.Message, "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isLoggedIn = false;
                        userID = "";
                        userName = "";
                    }
                }
                else
                {
                    // 로그인 거절 시 비회원으로 진행
                    MessageBox.Show("비회원으로 결제를 진행합니다.", "비회원 결제",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    userID = "";
                    userName = "";
                }
            }

            // 최종 결제 확인 대화상자
            string paymentMessage = $"총 {totalPrice:N0}원을 결제하시겠습니까?\n\n" +
                $"🚄 열차: {trainNumber ?? "미정"} ({trainName ?? "일반열차"})\n" +
                $"📍 구간: {searchCondition.Departure ?? "출발지"} → {searchCondition.Arrival ?? "도착지"}\n" +
                $"📅 날짜: {searchCondition.DepartureDate ?? "날짜"}\n" +
                $"👥 승객: 성인 {searchCondition.AdultCount}명, 소아 {searchCondition.ChildCount}명, 유아 {searchCondition.InfantCount}명";

            if (isLoggedIn && !string.IsNullOrEmpty(userID))
            {
                string displayName = !string.IsNullOrEmpty(userName) ? userName : userID;
                paymentMessage += $"\n👤 예약자: {displayName} (회원)";
            }
            else
            {
                paymentMessage += "\n👤 비회원 예약";
            }

            DialogResult paymentResult = MessageBox.Show(paymentMessage, "결제 확인",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (paymentResult == DialogResult.Yes)
            {
                // 예약 (ID와 이름 모두 전달)
                if (ProcessBooking(userID, userName, isLoggedIn))
                {
                    string completionMessage = "결제가 완료되었습니다!\n예약이 성공적으로 처리되었습니다.";

                    if (!isLoggedIn || string.IsNullOrEmpty(userID))
                    {
                        completionMessage += "\n\n⚠️ 비회원 예약이므로 예약번호를 꼭 기억해 주십시오.";
                    }

                    MessageBox.Show(completionMessage, "결제 완료",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("예약 처리 중 오류가 발생했습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 로그인 상태 확인
        private bool CheckLoginStatus()
        {
            // MainScreen 정적 변수 사용
            try
            {
                return MainScreen.IsLoggedIn;
            }
            catch
            {
                return false;
            }
        }

        // 현재 로그인된 사용자 ID 가져오기
        private string GetCurrentUserID()
        {
            try
            {
                return MainScreen.CurrentUser ?? "";
            }
            catch
            {
                return "";
            }
        }

        // 현재 로그인된 사용자 이름 가져오기
        private string GetCurrentUserName()
        {
            try
            {
                return MainScreen.CurrentName ?? "";
            }
            catch
            {
                return "";
            }
        }

        private bool ProcessBooking(string userID = "", string userName = "", bool isLoggedIn = false)
        {
            try
            {
                // 예약번호 생성 (현재 시간 기반)
                string bookingID = DateTime.Now.ToString("yyyyMMddHHmmss");

                // 좌석번호 생성
                Random random = new Random();
                int carNumber = random.Next(1, 11); // 1~10호차
                int seatNumber = random.Next(1, 65); // 1~64번 좌석
                string seatInfo = $"{carNumber}호차 {seatNumber}번";

                // 실제 좌석이 필요한 승객 수 계산
                int requiredSeats = searchCondition.AdultCount + searchCondition.ChildCount;

                // XML 파일에 예약 정보 저장
                // 사용자 ID, 이름 모두 포함
                if (SaveBookingToXml(bookingID, seatInfo, userID, userName, isLoggedIn))
                {
                    // 잔여석 수 업데이트
                    if (UpdateAvailableSeats(trainNumber, searchCondition.DepartureDate, requiredSeats))
                    {
                        // 비회원인 경우 예약번호 별도 알림
                        if (!isLoggedIn)
                        {
                            MessageBox.Show($"📋 예약번호: {bookingID}\n\n위 예약번호를 꼭 기억해 주세요!\n예약 조회 시 필요합니다.",
                                "예약번호 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        return true;
                    }
                    else
                    {
                        // 잔여석 업데이트 실패 시 예약 정보 롤백
                        MessageBox.Show("좌석 정보 업데이트에 실패했습니다.", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 처리 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 잔여석 수 업데이트
        private bool UpdateAvailableSeats(string trainNumber, string date, int bookedSeats)
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
                        // 잔여석 수에서 예약된 좌석 수 차감
                        int newAvailableSeats = currentAvailableSeats - bookedSeats;

                        // 잔여석이 음수가 되지 않도록 보정
                        if (newAvailableSeats < 0)
                        {
                            newAvailableSeats = 0;
                        }

                        // 새로운 잔여석 수 업데이트
                        seatNode.Attributes["availableSeats"].Value = newAvailableSeats.ToString();

                        // XML 파일 저장
                        xmlDoc.Save("trainInfo.xml");

                        return true;
                    }
                }
                else
                {
                    // 해당 날짜의 정보가 없는 경우 새로 생성
                    return CreateSeatAvailabilityRecord(xmlDoc, trainNumber, date, bookedSeats);
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("잔여석 정보 업데이트 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 새로운 좌석 가용성 레코드 생성
        private bool CreateSeatAvailabilityRecord(XmlDocument xmlDoc, string trainNumber, string date, int bookedSeats)
        {
            try
            {
                // 기본 좌석 수 조회
                XmlNode trainNode = xmlDoc.SelectSingleNode($"//train[trainNumber='{trainNumber}']");
                if (trainNode == null) return false;

                XmlNode seatsNode = trainNode.SelectSingleNode("seats/totalSeats");
                if (seatsNode == null) return false;

                if (!int.TryParse(seatsNode.InnerText, out int totalSeats)) return false;

                // seatAvailability 루트 찾기 또는 생성
                XmlNode seatAvailabilityRoot = xmlDoc.SelectSingleNode("//seatAvailability");
                if (seatAvailabilityRoot == null)
                {
                    seatAvailabilityRoot = xmlDoc.CreateElement("seatAvailability");
                    xmlDoc.DocumentElement.AppendChild(seatAvailabilityRoot);
                }

                // 해당 날짜 노드 찾기 또는 생성
                XmlNode dateNode = seatAvailabilityRoot.SelectSingleNode($"date[@value='{date}']");
                if (dateNode == null)
                {
                    dateNode = xmlDoc.CreateElement("date");
                    XmlAttribute dateAttr = xmlDoc.CreateAttribute("value");
                    dateAttr.Value = date;
                    dateNode.Attributes.Append(dateAttr);
                    seatAvailabilityRoot.AppendChild(dateNode);
                }

                // 새로운 열차 노드 생성
                XmlElement trainElement = xmlDoc.CreateElement("train");

                XmlAttribute trainNumberAttr = xmlDoc.CreateAttribute("trainNumber");
                trainNumberAttr.Value = trainNumber;
                trainElement.Attributes.Append(trainNumberAttr);

                XmlAttribute availableSeatsAttr = xmlDoc.CreateAttribute("availableSeats");
                int newAvailableSeats = totalSeats - bookedSeats;
                if (newAvailableSeats < 0) newAvailableSeats = 0;
                availableSeatsAttr.Value = newAvailableSeats.ToString();
                trainElement.Attributes.Append(availableSeatsAttr);

                dateNode.AppendChild(trainElement);

                // XML 파일 저장
                xmlDoc.Save("trainInfo.xml");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("새 좌석 정보 생성 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool SaveBookingToXml(string bookingID, string seatInfo, string userID = "", string userName = "", bool isLoggedIn = false)
        {
            try
            {
                // null 체크
                if (searchCondition == null)
                {
                    MessageBox.Show("검색 조건 정보가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // 로그인 상태; MainScreen에서 직접 가져오기
                if (isLoggedIn)
                {
                    // MainScreen의 정적 변수에서 직접 가져오기
                    string currentUserID = GetCurrentUserID();    // 실제 ID
                    string currentUserName = GetCurrentUserName(); // 실제 이름

                    // 값이 비어있지 않으면 사용
                    if (!string.IsNullOrEmpty(currentUserID))
                    {
                        userID = currentUserID;
                    }
                    if (!string.IsNullOrEmpty(currentUserName))
                    {
                        userName = currentUserName;
                    }

                }

                XmlDocument xmlDoc = new XmlDocument();
                if (!System.IO.File.Exists("trainBook.xml"))
                {
                    xmlDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><bookings></bookings>");
                }
                else
                {
                    xmlDoc.Load("trainBook.xml");
                }

                XmlElement root = xmlDoc.DocumentElement;

                // 새 예약 노드 생성
                XmlElement bookingElement = xmlDoc.CreateElement("booking");

                // 기본 예약 정보 추가
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "bookingID", bookingID ?? ""));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "departure", searchCondition.Departure ?? ""));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "arrival", searchCondition.Arrival ?? ""));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "departureDate", searchCondition.DepartureDate ?? ""));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "returnDate", searchCondition.ReturnDate ?? "")); // 왕복일 경우
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "tripType", searchCondition.TripType ?? "편도"));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "departureTime", "미정")); // 실제로는 선택된 시간
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "trainNumber", trainNumber ?? ""));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "seatNumber", seatInfo ?? ""));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "totalPrice", totalPrice.ToString()));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "status", "예약완료"));
                bookingElement.AppendChild(CreateXmlElement(xmlDoc, "bookingDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                // 사용자 정보 추가 - 올바른 순서로 저장
                if (isLoggedIn && !string.IsNullOrEmpty(userID))
                {
                    // 실제 사용자 ID 저장 (123, admin, user01 등)
                    bookingElement.AppendChild(CreateXmlElement(xmlDoc, "userID", userID));
                    // 사용자 이름 저장 (이은정, 김철수, 박영희 등)
                    bookingElement.AppendChild(CreateXmlElement(xmlDoc, "userName", userName ?? ""));
                    bookingElement.AppendChild(CreateXmlElement(xmlDoc, "memberType", "회원"));
                }
                else
                {
                    bookingElement.AppendChild(CreateXmlElement(xmlDoc, "userID", ""));
                    bookingElement.AppendChild(CreateXmlElement(xmlDoc, "userName", ""));
                    bookingElement.AppendChild(CreateXmlElement(xmlDoc, "memberType", "비회원"));
                }

                // 승객 정보 노드
                XmlElement passengersElement = xmlDoc.CreateElement("passengers");
                passengersElement.AppendChild(CreateXmlElement(xmlDoc, "adult", searchCondition.AdultCount.ToString()));
                passengersElement.AppendChild(CreateXmlElement(xmlDoc, "child", searchCondition.ChildCount.ToString()));
                passengersElement.AppendChild(CreateXmlElement(xmlDoc, "infant", searchCondition.InfantCount.ToString()));
                bookingElement.AppendChild(passengersElement);

                // 요금 정보 노드
                XmlElement priceElement = xmlDoc.CreateElement("priceDetails");
                priceElement.AppendChild(CreateXmlElement(xmlDoc, "adultPrice", adultPrice.ToString()));
                priceElement.AppendChild(CreateXmlElement(xmlDoc, "childPrice", childPrice.ToString()));
                priceElement.AppendChild(CreateXmlElement(xmlDoc, "adultTotal", (adultPrice * searchCondition.AdultCount).ToString()));
                priceElement.AppendChild(CreateXmlElement(xmlDoc, "childTotal", (childPrice * searchCondition.ChildCount).ToString()));
                bookingElement.AppendChild(priceElement);

                // 루트에 예약 추가
                root.AppendChild(bookingElement);

                // 파일 저장
                xmlDoc.Save("trainBook.xml");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML 저장 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private XmlElement CreateXmlElement(XmlDocument doc, string name, string value)
        {
            XmlElement element = doc.CreateElement(name);
            element.InnerText = value;
            return element;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}