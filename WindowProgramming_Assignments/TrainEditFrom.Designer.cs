using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{
    public partial class TrainEditForm : Form
    {
        public Dictionary<string, string> TrainData { get; set; }

        private TextBox txtTrainNumber;
        private TextBox txtTrainName;
        private ComboBox cmbDeparture;
        private ComboBox cmbArrival;
        private DateTimePicker dtpDepartureTime;
        private DateTimePicker dtpArrivalTime;
        private TextBox txtDuration;
        private ComboBox cmbTrainType;
        private TextBox txtAdultPrice;
        private TextBox txtChildPrice;
        private TextBox txtInfantPrice;
        private TextBox txtRouteID;
        private ComboBox cmbOperatingDays;
        private TextBox txtTotalSeats;
        private TextBox txtStandardSeats;
        private TextBox txtSpecialSeats;
        private TextBox txtSpecialSeatSurcharge;
        private CheckBox chkComplexStructure;
        private Button btnOK;
        private Button btnCancel;

        // 라벨 참조를 위한 필드 추가
        private Label lblChildPrice;
        private Label lblInfantPrice;
        private Label lblRouteID;
        private Label lblOperatingDays;
        private Label lblTotalSeats;
        private Label lblStandardSeats;
        private Label lblSpecialSeats;
        private Label lblSpecialSeatSurcharge;

        public TrainEditForm(Dictionary<string, string> existingData = null)
        {
            InitializeComponent();

            if (existingData != null)
            {
                LoadExistingData(existingData);
            }
        }

        private void InitializeComponent()
        {
            this.Text = "열차 정보 편집";
            this.Size = new Size(600, 650);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoScroll = true;

            int yPos = 20;
            int spacing = 35;

            // 구조 선택 체크박스
            chkComplexStructure = new CheckBox
            {
                Text = "복잡한 구조 사용 (seats, pricing 등 추가 정보)",
                Location = new Point(20, yPos),
                Size = new Size(500, 23),
                Checked = false
            };
            chkComplexStructure.CheckedChanged += ChkComplexStructure_CheckedChanged;
            this.Controls.Add(chkComplexStructure);
            yPos += spacing;

            // 기본 정보
            AddLabelAndTextBox("열차번호:", ref txtTrainNumber, yPos);
            yPos += spacing;

            AddLabelAndTextBox("열차명:", ref txtTrainName, yPos);
            yPos += spacing;

            // 출발지 콤보박스
            Label lblDeparture = new Label { Text = "출발지:", Location = new Point(20, yPos), Size = new Size(100, 23) };
            cmbDeparture = new ComboBox
            {
                Location = new Point(130, yPos),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDeparture.Items.AddRange(new string[] { "서울", "부산", "인천", "대구", "광주", "대전", "울산" });
            this.Controls.Add(lblDeparture);
            this.Controls.Add(cmbDeparture);
            yPos += spacing;

            // 도착지 콤보박스
            Label lblArrival = new Label { Text = "도착지:", Location = new Point(20, yPos), Size = new Size(100, 23) };
            cmbArrival = new ComboBox
            {
                Location = new Point(130, yPos),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbArrival.Items.AddRange(new string[] { "서울", "부산", "인천", "대구", "광주", "대전", "울산" });
            this.Controls.Add(lblArrival);
            this.Controls.Add(cmbArrival);
            yPos += spacing;

            // 출발시간
            Label lblDepartureTime = new Label { Text = "출발시간:", Location = new Point(20, yPos), Size = new Size(100, 23) };
            dtpDepartureTime = new DateTimePicker
            {
                Location = new Point(130, yPos),
                Size = new Size(200, 23),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };
            this.Controls.Add(lblDepartureTime);
            this.Controls.Add(dtpDepartureTime);
            yPos += spacing;

            // 도착시간
            Label lblArrivalTime = new Label { Text = "도착시간:", Location = new Point(20, yPos), Size = new Size(100, 23) };
            dtpArrivalTime = new DateTimePicker
            {
                Location = new Point(130, yPos),
                Size = new Size(200, 23),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };
            this.Controls.Add(lblArrivalTime);
            this.Controls.Add(dtpArrivalTime);
            yPos += spacing;

            AddLabelAndTextBox("소요시간(분):", ref txtDuration, yPos);
            yPos += spacing;

            // 열차종류 콤보박스
            Label lblTrainType = new Label { Text = "열차종류:", Location = new Point(20, yPos), Size = new Size(100, 23) };
            cmbTrainType = new ComboBox
            {
                Location = new Point(130, yPos),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTrainType.Items.AddRange(new string[] { "KTX", "KTX-산천", "ITX-새마을", "무궁화호", "통근열차", "ITX-청춘" });
            this.Controls.Add(lblTrainType);
            this.Controls.Add(cmbTrainType);
            yPos += spacing;

            // 기본 요금 정보
            AddLabelAndTextBox("성인요금:", ref txtAdultPrice, yPos);
            yPos += spacing;

            // 복잡한 구조 필드들 (초기에는 숨김)
            lblChildPrice = new Label { Text = "어린이요금:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtChildPrice = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblChildPrice);
            this.Controls.Add(txtChildPrice);
            yPos += spacing;

            lblInfantPrice = new Label { Text = "유아요금:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtInfantPrice = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblInfantPrice);
            this.Controls.Add(txtInfantPrice);
            yPos += spacing;

            lblRouteID = new Label { Text = "노선ID:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtRouteID = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblRouteID);
            this.Controls.Add(txtRouteID);
            yPos += spacing;

            // 운행일
            lblOperatingDays = new Label { Text = "운행일:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            cmbOperatingDays = new ComboBox
            {
                Location = new Point(130, yPos),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Visible = false
            };
            cmbOperatingDays.Items.AddRange(new string[] { "매일", "평일", "주말", "월~금", "토~일" });
            this.Controls.Add(lblOperatingDays);
            this.Controls.Add(cmbOperatingDays);
            yPos += spacing;

            lblTotalSeats = new Label { Text = "총 좌석수:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtTotalSeats = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblTotalSeats);
            this.Controls.Add(txtTotalSeats);
            yPos += spacing;

            lblStandardSeats = new Label { Text = "일반실 좌석:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtStandardSeats = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblStandardSeats);
            this.Controls.Add(txtStandardSeats);
            yPos += spacing;

            lblSpecialSeats = new Label { Text = "특실 좌석:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtSpecialSeats = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblSpecialSeats);
            this.Controls.Add(txtSpecialSeats);
            yPos += spacing;

            lblSpecialSeatSurcharge = new Label { Text = "특실 추가요금:", Location = new Point(20, yPos), Size = new Size(100, 23), Visible = false };
            txtSpecialSeatSurcharge = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23), Visible = false };
            this.Controls.Add(lblSpecialSeatSurcharge);
            this.Controls.Add(txtSpecialSeatSurcharge);
            yPos += spacing + 20;

            // 버튼
            btnOK = new Button
            {
                Text = "확인",
                Location = new Point(400, yPos),
                Size = new Size(75, 30),
                DialogResult = DialogResult.OK
            };
            btnOK.Click += BtnOK_Click;

            btnCancel = new Button
            {
                Text = "취소",
                Location = new Point(480, yPos),
                Size = new Size(75, 30),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);

            // 열차종류 선택 이벤트 핸들러 추가
            cmbTrainType.SelectedIndexChanged += CmbTrainType_SelectedIndexChanged;
        }

        private void AddLabelAndTextBox(string labelText, ref TextBox textBox, int yPos)
        {
            Label label = new Label { Text = labelText, Location = new Point(20, yPos), Size = new Size(100, 23) };
            textBox = new TextBox { Location = new Point(130, yPos), Size = new Size(200, 23) };

            this.Controls.Add(label);
            this.Controls.Add(textBox);
        }

        private void CmbTrainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // KTX나 고급 열차인 경우 자동으로 복잡한 구조 활성화
            if (cmbTrainType.SelectedItem != null)
            {
                string trainType = cmbTrainType.SelectedItem.ToString();
                if (trainType.Contains("KTX") || trainType.Contains("ITX"))
                {
                    chkComplexStructure.Checked = true;

                    // 기본값 설정
                    if (string.IsNullOrWhiteSpace(txtTotalSeats.Text))
                    {
                        txtTotalSeats.Text = trainType.Contains("KTX") ? "400" : "300";
                    }
                    if (string.IsNullOrWhiteSpace(txtStandardSeats.Text))
                    {
                        txtStandardSeats.Text = trainType.Contains("KTX") ? "300" : "250";
                    }
                    if (string.IsNullOrWhiteSpace(txtSpecialSeats.Text))
                    {
                        txtSpecialSeats.Text = trainType.Contains("KTX") ? "100" : "50";
                    }
                }
            }
        }

        private void ChkComplexStructure_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFieldVisibility();
        }

        private void UpdateFieldVisibility()
        {
            bool isComplex = chkComplexStructure.Checked;

            // 복잡한 구조 필드들과 라벨들 표시/숨김
            txtChildPrice.Visible = isComplex;
            lblChildPrice.Visible = isComplex;

            txtInfantPrice.Visible = isComplex;
            lblInfantPrice.Visible = isComplex;

            txtRouteID.Visible = isComplex;
            lblRouteID.Visible = isComplex;

            cmbOperatingDays.Visible = isComplex;
            lblOperatingDays.Visible = isComplex;

            txtTotalSeats.Visible = isComplex;
            lblTotalSeats.Visible = isComplex;

            txtStandardSeats.Visible = isComplex;
            lblStandardSeats.Visible = isComplex;

            txtSpecialSeats.Visible = isComplex;
            lblSpecialSeats.Visible = isComplex;

            txtSpecialSeatSurcharge.Visible = isComplex;
            lblSpecialSeatSurcharge.Visible = isComplex;
        }

        private void LoadExistingData(Dictionary<string, string> data)
        {
            if (data.ContainsKey("trainNumber")) txtTrainNumber.Text = data["trainNumber"];
            if (data.ContainsKey("trainName")) txtTrainName.Text = data["trainName"];
            if (data.ContainsKey("departure")) cmbDeparture.SelectedItem = data["departure"];
            if (data.ContainsKey("arrival")) cmbArrival.SelectedItem = data["arrival"];

            if (data.ContainsKey("departureTime"))
            {
                if (TimeSpan.TryParse(data["departureTime"], out TimeSpan depTime))
                {
                    dtpDepartureTime.Value = DateTime.Today.Add(depTime);
                }
            }

            if (data.ContainsKey("arrivalTime"))
            {
                if (TimeSpan.TryParse(data["arrivalTime"], out TimeSpan arrTime))
                {
                    dtpArrivalTime.Value = DateTime.Today.Add(arrTime);
                }
            }

            if (data.ContainsKey("duration")) txtDuration.Text = data["duration"];
            if (data.ContainsKey("trainType")) cmbTrainType.SelectedItem = data["trainType"];
            if (data.ContainsKey("adultPrice")) txtAdultPrice.Text = data["adultPrice"];

            // 복잡한 구조 데이터가 있는지 확인
            bool hasComplexData = data.ContainsKey("childPrice") ||
                                  data.ContainsKey("routeID") ||
                                  data.ContainsKey("totalSeats") ||
                                  data.ContainsKey("standardSeats") ||
                                  data.ContainsKey("specialSeats");

            if (hasComplexData)
            {
                chkComplexStructure.Checked = true;

                if (data.ContainsKey("childPrice")) txtChildPrice.Text = data["childPrice"];
                if (data.ContainsKey("infantPrice")) txtInfantPrice.Text = data["infantPrice"];
                if (data.ContainsKey("routeID")) txtRouteID.Text = data["routeID"];
                if (data.ContainsKey("operatingDays")) cmbOperatingDays.SelectedItem = data["operatingDays"];
                if (data.ContainsKey("totalSeats")) txtTotalSeats.Text = data["totalSeats"];
                if (data.ContainsKey("standardSeats")) txtStandardSeats.Text = data["standardSeats"];
                if (data.ContainsKey("specialSeats")) txtSpecialSeats.Text = data["specialSeats"];
                if (data.ContainsKey("specialSeatSurcharge")) txtSpecialSeatSurcharge.Text = data["specialSeatSurcharge"];
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // 필수 필드 검증
            if (string.IsNullOrWhiteSpace(txtTrainNumber.Text))
            {
                MessageBox.Show("열차번호를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrainNumber.Focus();
                return;
            }

            if (cmbDeparture.SelectedItem == null)
            {
                MessageBox.Show("출발지를 선택해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDeparture.Focus();
                return;
            }

            if (cmbArrival.SelectedItem == null)
            {
                MessageBox.Show("도착지를 선택해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbArrival.Focus();
                return;
            }

            if (cmbDeparture.SelectedItem.ToString() == cmbArrival.SelectedItem.ToString())
            {
                MessageBox.Show("출발지와 도착지가 같을 수 없습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTrainType.SelectedItem == null)
            {
                MessageBox.Show("열차종류를 선택해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTrainType.Focus();
                return;
            }

            // 숫자 필드 검증
            if (!string.IsNullOrWhiteSpace(txtDuration.Text) && !int.TryParse(txtDuration.Text, out _))
            {
                MessageBox.Show("소요시간은 숫자로 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuration.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtAdultPrice.Text) && !int.TryParse(txtAdultPrice.Text, out _))
            {
                MessageBox.Show("성인요금은 숫자로 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdultPrice.Focus();
                return;
            }

            // 기본 데이터 구성
            TrainData = new Dictionary<string, string>
            {
                ["trainNumber"] = txtTrainNumber.Text.Trim(),
                ["trainName"] = txtTrainName.Text.Trim(),
                ["departure"] = cmbDeparture.SelectedItem?.ToString() ?? "",
                ["arrival"] = cmbArrival.SelectedItem?.ToString() ?? "",
                ["departureTime"] = dtpDepartureTime.Value.ToString("HH:mm"),
                ["arrivalTime"] = dtpArrivalTime.Value.ToString("HH:mm"),
                ["duration"] = txtDuration.Text.Trim(),
                ["trainType"] = cmbTrainType.SelectedItem?.ToString() ?? "",
                ["adultPrice"] = txtAdultPrice.Text.Trim()
            };

            // 복잡한 구조인 경우 추가 데이터 포함
            if (chkComplexStructure.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtChildPrice.Text))
                    TrainData["childPrice"] = txtChildPrice.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtInfantPrice.Text))
                    TrainData["infantPrice"] = txtInfantPrice.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtRouteID.Text))
                    TrainData["routeID"] = txtRouteID.Text.Trim();
                if (cmbOperatingDays.SelectedItem != null)
                    TrainData["operatingDays"] = cmbOperatingDays.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(txtTotalSeats.Text))
                    TrainData["totalSeats"] = txtTotalSeats.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtStandardSeats.Text))
                    TrainData["standardSeats"] = txtStandardSeats.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtSpecialSeats.Text))
                    TrainData["specialSeats"] = txtSpecialSeats.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtSpecialSeatSurcharge.Text))
                    TrainData["specialSeatSurcharge"] = txtSpecialSeatSurcharge.Text.Trim();

                // 복잡한 구조 플래그
                TrainData["isComplexStructure"] = "true";
            }
            else
            {
                // 단순 구조인 경우에도 totalSeats는 기본값으로 추가
                string trainType = cmbTrainType.SelectedItem?.ToString() ?? "";
                if (trainType.Contains("KTX"))
                    TrainData["totalSeats"] = "400";
                else if (trainType.Contains("ITX"))
                    TrainData["totalSeats"] = "300";
                else
                    TrainData["totalSeats"] = "500";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}