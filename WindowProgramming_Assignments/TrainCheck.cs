using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace WindowProgramming_Assignments
{
    public partial class TrainCheck : Form
    {
        private TrainSearchCondition searchCondition;
        private DataGridView trainTable;
        private Label searchInfoLabel;
        private Button btnReserve;
        private Button btnClose;

        public TrainCheck(TrainSearchCondition condition)
        {
            this.searchCondition = condition;

            // 폼 크기 늘리기
            this.Size = new Size(1100, 650);

            InitializeComponent();
            SetupTrainTable();
            LoadTrainData();
        }

        private void SetupTrainTable()
        {
            // 검색 조건 표시 라벨
            searchInfoLabel = new Label();
            searchInfoLabel.Text = $"🔍 {searchCondition.Departure} → {searchCondition.Arrival} | " +
                                 $"{searchCondition.DepartureDate} | " +
                                 $"승객 {searchCondition.TotalPassengers}명 ({searchCondition.TripType})";
            searchInfoLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            searchInfoLabel.ForeColor = Color.FromArgb(0, 37, 84);
            searchInfoLabel.Location = new Point(20, 30);
            searchInfoLabel.Size = new Size(1000, 25);
            groupBox1.Controls.Add(searchInfoLabel);

            // 열차 목록 테이블
            trainTable = new DataGridView();
            trainTable.Location = new Point(20, 70);
            trainTable.Size = new Size(1000, 250);
            trainTable.ReadOnly = true;
            trainTable.AllowUserToAddRows = false;
            trainTable.AllowUserToDeleteRows = false;
            trainTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            trainTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            trainTable.Font = new Font("한컴 고딕", 10F, FontStyle.Regular);

            // 컬럼
            trainTable.Columns.Add("TrainNumber", "열차번호");
            trainTable.Columns.Add("TrainName", "열차명");
            trainTable.Columns.Add("TrainType", "유형");
            trainTable.Columns.Add("DepartureTime", "출발시간");
            trainTable.Columns.Add("ArrivalTime", "도착시간");
            trainTable.Columns.Add("Duration", "소요시간");
            trainTable.Columns.Add("AvailableSeats", "잔여석");
            trainTable.Columns.Add("AdultPrice", "성인요금");
            trainTable.Columns.Add("ChildPrice", "아이요금");

            trainTable.Columns["TrainNumber"].Width = 100;
            trainTable.Columns["TrainName"].Width = 120;
            trainTable.Columns["TrainType"].Width = 80;
            trainTable.Columns["DepartureTime"].Width = 100;
            trainTable.Columns["ArrivalTime"].Width = 100;
            trainTable.Columns["Duration"].Width = 100;
            trainTable.Columns["AvailableSeats"].Width = 80;
            trainTable.Columns["AdultPrice"].Width = 100;
            trainTable.Columns["ChildPrice"].Width = 100;

            // 헤더
            trainTable.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            trainTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            trainTable.ColumnHeadersDefaultCellStyle.Font = new Font("한컴 고딕", 10F, FontStyle.Bold);
            trainTable.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trainTable.ColumnHeadersHeight = trainTable.ColumnHeadersHeight + 20;

            // 셀 스타일
            trainTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trainTable.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // 더블클릭 이벤트 연결
            trainTable.CellDoubleClick += TrainTable_CellDoubleClick;

            groupBox1.Controls.Add(trainTable);

            // 예약 버튼
            btnReserve = new Button();
            btnReserve.Text = "🎫 선택한 열차 예약";
            btnReserve.Size = new Size(180, 40);
            btnReserve.Location = new Point(720, 330); // x축 590에서 시작
            btnReserve.BackColor = Color.Orange;
            btnReserve.ForeColor = Color.White;
            btnReserve.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            btnReserve.FlatStyle = FlatStyle.Flat;
            btnReserve.Click += BtnReserve_Click;
            groupBox1.Controls.Add(btnReserve);

            // 닫기 버튼
            btnClose = new Button();
            btnClose.Text = "닫기";
            btnClose.Size = new Size(100, 40);
            btnClose.Location = new Point(920, 330);
            btnClose.BackColor = Color.FromArgb(70, 130, 180);
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += BtnClose_Click;
            groupBox1.Controls.Add(btnClose);
        }

        private void LoadTrainData()
        {
            try
            {
                // 기존 데이터 초기화
                trainTable.Rows.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                // 조건에 맞는 열차 검색
                XmlNodeList trainNodes = xmlDoc.SelectNodes("//train");
                bool foundTrains = false;

                // 중복 방지를 위한 HashSet
                HashSet<string> addedTrains = new HashSet<string>();

                foreach (XmlNode trainNode in trainNodes)
                {
                    string departure = trainNode.SelectSingleNode("departure")?.InnerText ?? "";
                    string arrival = trainNode.SelectSingleNode("arrival")?.InnerText ?? "";

                    // 출발지와 도착지가 일치하는 열차만
                    if (departure == searchCondition.Departure && arrival == searchCondition.Arrival)
                    {
                        string trainNumber = trainNode.SelectSingleNode("trainNumber")?.InnerText ?? "-";

                        // 중복 체크 - 이미 추가된 열차라면 건너뛰기
                        if (addedTrains.Contains(trainNumber))
                        {
                            continue;
                        }

                        // 선택한 날짜에 해당 열차가 운행하는지 확인
                        if (!IsTrainRunningOnDate(xmlDoc, trainNumber, searchCondition.DepartureDate))
                        {
                            continue; // 해당 날짜에 운행하지 않는 열차는 건너뛰기
                        }

                        foundTrains = true;
                        addedTrains.Add(trainNumber); // 열차 기록 추가

                        string trainName = trainNode.SelectSingleNode("trainName")?.InnerText ?? "-";
                        string trainType = trainNode.SelectSingleNode("trainType")?.InnerText ?? "-";
                        string departureTime = trainNode.SelectSingleNode("departureTime")?.InnerText ?? "-";
                        string arrivalTime = trainNode.SelectSingleNode("arrivalTime")?.InnerText ?? "-";
                        string duration = trainNode.SelectSingleNode("duration")?.InnerText ?? "0";

                        // 요금 정보
                        XmlNode pricingNode = trainNode.SelectSingleNode("pricing");
                        int adultPrice = 0;
                        int childPrice = 0;

                        if (pricingNode != null)
                        {
                            int.TryParse(pricingNode.SelectSingleNode("adultPrice")?.InnerText ?? "0", out adultPrice);
                            int.TryParse(pricingNode.SelectSingleNode("childPrice")?.InnerText ?? "0", out childPrice);
                        }

                        // 잔여석 정보 (날짜별로)
                        int availableSeats = GetAvailableSeats(trainNumber, searchCondition.DepartureDate);

                        // 소요시간 변환 (분 → 시간:분)
                        string durationStr = ConvertMinutesToHourMin(duration);

                        // 테이블에 행 추가
                        trainTable.Rows.Add(
                            trainNumber,
                            trainName,
                            trainType,
                            departureTime,
                            arrivalTime,
                            durationStr,
                            availableSeats.ToString(),
                            $"{adultPrice:N0}원",
                            $"{childPrice:N0}원"
                        );

                        // 잔여석이 부족한 경우 행 색상 변경
                        int rowIndex = trainTable.Rows.Count - 1;
                        if (availableSeats < searchCondition.TotalPassengers)
                        {
                            trainTable.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                            trainTable.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                        }
                    }
                }
                if (!foundTrains)
                {
                    MessageBox.Show("예상치 못한 오류가 발생했습니다. 다시 시도해주세요.",
                        "시스템 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("열차 정보를 불러오는 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 특정 열차가 특정 날짜에 운행하는지 확인
        private bool IsTrainRunningOnDate(XmlDocument xmlDoc, string trainNumber, string date)
        {
            try
            {
                XmlNode trainOnDateNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']/train[@trainNumber='{trainNumber}']");
                return trainOnDateNode != null;
            }
            catch
            {
                return false;
            }
        }

        // 특정 날짜의 열차 잔여석 조회
        private int GetAvailableSeats(string trainNumber, string date)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainInfo.xml");

                XmlNode seatNode = xmlDoc.SelectSingleNode($"//seatAvailability/date[@value='{date}']/train[@trainNumber='{trainNumber}']");
                if (seatNode != null)
                {
                    string availableSeatsStr = seatNode.Attributes["availableSeats"]?.Value ?? "0";
                    int.TryParse(availableSeatsStr, out int availableSeats);
                    return availableSeats;
                }

                // 해당 날짜의 정보가 없으면 기본 좌석수 반환
                XmlNode trainNode = xmlDoc.SelectSingleNode($"//train[trainNumber='{trainNumber}']");
                if (trainNode != null)
                {
                    XmlNode seatsNode = trainNode.SelectSingleNode("seats/totalSeats");
                    if (seatsNode != null)
                    {
                        int.TryParse(seatsNode.InnerText, out int totalSeats);
                        return totalSeats;
                    }
                }

                return 0;
            }
            catch
            {
                return 0;
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

        // 열차 테이블 더블클릭
        private void TrainTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 선택한 열차로 예약 진행
                ReserveSelectedTrain(e.RowIndex);
            }
        }

        // 예약 버튼 클릭
        private void BtnReserve_Click(object sender, EventArgs e)
        {
            if (trainTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("예약할 열차를 선택해주세요.", "선택 필요",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = trainTable.SelectedRows[0].Index;
            ReserveSelectedTrain(selectedRowIndex);
        }

        // 선택한 열차 예약 처리
        private void ReserveSelectedTrain(int rowIndex)
        {
            try
            {
                string trainNumber = trainTable.Rows[rowIndex].Cells["TrainNumber"].Value.ToString();
                string availableSeatsStr = trainTable.Rows[rowIndex].Cells["AvailableSeats"].Value.ToString();
                int availableSeats = int.Parse(availableSeatsStr);

                // 잔여석 확인 (실제 좌석이 필요한 승객 수만 계산 |  유아는 별도 좌석 불필요)
                int requiredSeats = searchCondition.AdultCount + searchCondition.ChildCount; // 유아는 제외
                if (availableSeats < requiredSeats)
                {
                    MessageBox.Show($"잔여석이 부족합니다.\n필요: {requiredSeats}석, 잔여: {availableSeats}석",
                        "좌석 부족", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 요금 계산
                string adultPriceStr = trainTable.Rows[rowIndex].Cells["AdultPrice"].Value.ToString().Replace("원", "").Replace(",", "");
                string childPriceStr = trainTable.Rows[rowIndex].Cells["ChildPrice"].Value.ToString().Replace("원", "").Replace(",", "");
                int adultPrice = int.Parse(adultPriceStr);
                int childPrice = int.Parse(childPriceStr);

                // 총 요금 계산 (유아는 무료)
                int totalPrice = (adultPrice * searchCondition.AdultCount) +
                               (childPrice * searchCondition.ChildCount);

                string trainName = trainTable.Rows[rowIndex].Cells["TrainName"].Value.ToString();

                // 예약 확인
                DialogResult result = MessageBox.Show(
                    $"다음 열차를 예약하시겠습니까?\n\n" +
                    $"🚄 열차: {trainNumber} ({trainName})\n" +
                    $"📍 구간: {searchCondition.Departure} → {searchCondition.Arrival}\n" +
                    $"📅 날짜: {searchCondition.DepartureDate} ({searchCondition.TripType ?? "편도"})\n" +
                    $"👥 승객: 성인 {searchCondition.AdultCount}명, 소아 {searchCondition.ChildCount}명, 유아 {searchCondition.InfantCount}명\n" +
                    $"💰 총 요금: {totalPrice:N0}원\n" +
                    $"   - 성인 요금: {adultPrice:N0}원 x {searchCondition.AdultCount}명 = {(adultPrice * searchCondition.AdultCount):N0}원\n" +
                    $"   - 소아 요금: {childPrice:N0}원 x {searchCondition.ChildCount}명 = {(childPrice * searchCondition.ChildCount):N0}원\n" +
                    $"   - 유아 요금: 무료 x {searchCondition.InfantCount}명 = 0원",
                    "예약 확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // searchCondition null 체크
                    if (searchCondition == null)
                    {
                        MessageBox.Show("검색 조건이 설정되지 않았습니다.", "오류",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Booking 폼 열기
                    using (Booking bookingForm = new Booking(searchCondition, trainNumber, trainName,
                                                           adultPrice, childPrice, availableSeats))
                    {
                        DialogResult bookingResult = bookingForm.ShowDialog();

                        if (bookingResult == DialogResult.OK)
                        {
                            // 예약이 완료되면 열차 목록을 새로고침하여 업데이트된 잔여석 정보 표시
                            LoadTrainData();

                            MessageBox.Show("예약이 완료되었습니다!\n열차 목록이 업데이트되었습니다.", "성공",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 처리 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 닫기 버튼 클릭
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}