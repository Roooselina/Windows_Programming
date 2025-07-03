using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowProgramming_Assignments
{
    public partial class UserInfo : Form
    {
        private string currentUserID;

        public UserInfo()
        {
            InitializeComponent();

            // 폼 설정
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // 이벤트 핸들러 연결
            btnSignUp.Click += BtnLogout_Click; // 로그아웃 버튼
            button2.Click += BtnUpdate_Click;   // 업데이트 버튼
            btnUploadPhoto.Click += BtnUploadPhoto_Click; // 사진 업로드

            // 폼 활성화 시 예매 정보 새로고침
            this.Activated += UserInfo_Activated;

            // 현재 로그인한 사용자 정보 로드
            LoadCurrentUserInfo();

            // 읽기 전용 필드 설정
            SetReadOnlyFields();
        }

        // 폼이 활성화될 때마다 예매 정보 새로고침
        private void UserInfo_Activated(object sender, EventArgs e)
        {
            RefreshBookingInfo();
        }

        // 읽기 전용 필드 설정
        private void SetReadOnlyFields()
        {
            txtName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtID.ReadOnly = true;

            // 수정 가능한 필드 배경색 변경
            txtEmail.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            textBox1.BackColor = Color.White; // PW 확인

            // 읽기 전용 필드 배경색 변경
            txtName.BackColor = Color.LightGray;
            txtPhone.BackColor = Color.LightGray;
            txtID.BackColor = Color.LightGray;

            // PlaceholderText 설정
            txtPassword.PlaceholderText = "새 비밀번호 입력";
            textBox1.PlaceholderText = "새 비밀번호 확인";
        }

        // 현재 로그인한 사용자 정보 로드
        private void LoadCurrentUserInfo()
        {
            if (!MainScreen.IsLoggedIn)
            {
                MessageBox.Show("로그인 정보가 없습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CustomerInfo.xml");

                // 현재 로그인한 사용자의 ID로 사용자 정보 찾기
                string loginUserID = MainScreen.CurrentUser; // 실제 ID

                System.Diagnostics.Debug.WriteLine($"UserInfo - 현재 로그인된 사용자 ID: {loginUserID}");
                System.Diagnostics.Debug.WriteLine($"UserInfo - 현재 로그인된 사용자 이름: {MainScreen.CurrentName}");

                // ID로 사용자 찾기
                XmlNode userNode = xmlDoc.SelectSingleNode($"//user[ID='{loginUserID}']");

                if (userNode != null)
                {
                    // 사용자 정보 텍스트박스에 표시
                    XmlNode nameNode = userNode.SelectSingleNode("name");
                    if (nameNode != null)
                        txtName.Text = nameNode.InnerText.Trim();

                    XmlNode emailNode = userNode.SelectSingleNode("email");
                    if (emailNode != null)
                        txtEmail.Text = emailNode.InnerText.Trim();

                    XmlNode phoneNode = userNode.SelectSingleNode("phoneNum");
                    if (phoneNode != null)
                        txtPhone.Text = phoneNode.InnerText.Trim();

                    XmlNode idNode = userNode.SelectSingleNode("ID");
                    if (idNode != null)
                    {
                        txtID.Text = idNode.InnerText.Trim();
                        currentUserID = idNode.InnerText.Trim(); // 현재 사용자 ID 저장
                    }

                    XmlNode passNode = userNode.SelectSingleNode("Pass");
                    if (passNode != null)
                        txtPassword.Text = passNode.InnerText.Trim();
                }
                else
                {
                    MessageBox.Show("사용자 정보를 찾을 수 없습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // 예매 정보 로드 feat.trainBook.xml
                LoadBookingInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("사용자 정보를 불러오는 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 예매 정보 로드 (trainBook.xml)
        private void LoadBookingInfo()
        {
            try
            {
                if (!System.IO.File.Exists("trainBook.xml"))
                {
                    // 예매 정보가 없으면 groupBox2에 안내 메시지 표시
                    Label noBookingLabel = new Label();
                    noBookingLabel.Text = "예매 정보가 없습니다.";
                    noBookingLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
                    noBookingLabel.Location = new Point(20, 30);
                    noBookingLabel.Size = new Size(200, 23);
                    groupBox2.Controls.Add(noBookingLabel);
                    return;
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("trainBook.xml");

                // 현재 사용자의 예매 정보 찾기
                XmlNodeList bookingNodes = xmlDoc.SelectNodes($"//booking[userID='{currentUserID}']");

                System.Diagnostics.Debug.WriteLine($"UserInfo - 예매 정보 검색 ID: {currentUserID}");
                System.Diagnostics.Debug.WriteLine($"UserInfo - 찾은 예매 수: {bookingNodes.Count}");

                if (bookingNodes.Count == 0)
                {
                    Label noBookingLabel = new Label();
                    noBookingLabel.Text = "예매 정보가 없습니다.";
                    noBookingLabel.Font = new Font("한컴 고딕", 12F, FontStyle.Regular);
                    noBookingLabel.Location = new Point(20, 30);
                    noBookingLabel.Size = new Size(200, 23);
                    groupBox2.Controls.Add(noBookingLabel);
                }
                else
                {
                    // DataGridView; 테이블 형태로 표시
                    DataGridView bookingTable = new DataGridView();
                    bookingTable.Location = new Point(10, 30);
                    bookingTable.Size = new Size(610, 180);
                    bookingTable.ReadOnly = true;
                    bookingTable.AllowUserToAddRows = false;
                    bookingTable.AllowUserToDeleteRows = false;
                    bookingTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    bookingTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bookingTable.Font = new Font("한컴 고딕", 9F, FontStyle.Regular);

                    // 컬럼 설정
                    bookingTable.Columns.Add("BookingID", "예매번호");
                    bookingTable.Columns.Add("Route", "구간");
                    bookingTable.Columns.Add("Date", "날짜");
                    bookingTable.Columns.Add("Time", "시간");
                    bookingTable.Columns.Add("Train", "열차");
                    bookingTable.Columns.Add("Seat", "좌석");
                    bookingTable.Columns.Add("Status", "상태");

                    bookingTable.Columns["BookingID"].Width = 100;
                    bookingTable.Columns["Route"].Width = 80;
                    bookingTable.Columns["Date"].Width = 80;
                    bookingTable.Columns["Time"].Width = 60;
                    bookingTable.Columns["Train"].Width = 70;
                    bookingTable.Columns["Seat"].Width = 50;
                    bookingTable.Columns["Status"].Width = 70;

                    // 데이터 추가
                    foreach (XmlNode booking in bookingNodes)
                    {
                        string bookingID = booking.SelectSingleNode("bookingID")?.InnerText ?? "-";
                        string departure = booking.SelectSingleNode("departure")?.InnerText ?? "-";
                        string arrival = booking.SelectSingleNode("arrival")?.InnerText ?? "-";
                        string route = $"{departure}→{arrival}";
                        string date = booking.SelectSingleNode("departureDate")?.InnerText ?? "-";
                        string time = booking.SelectSingleNode("departureTime")?.InnerText ?? "-";
                        string train = booking.SelectSingleNode("trainNumber")?.InnerText ?? "-";
                        string seat = booking.SelectSingleNode("seatNumber")?.InnerText ?? "-";
                        string status = booking.SelectSingleNode("status")?.InnerText ?? "-";

                        bookingTable.Rows.Add(bookingID, route, date, time, train, seat, status);
                    }

                    // 헤더
                    bookingTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                    bookingTable.ColumnHeadersDefaultCellStyle.Font = new Font("한컴 고딕", 9F, FontStyle.Bold);
                    bookingTable.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // 셀
                    bookingTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bookingTable.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                    // 더블클릭 이벤트
                    bookingTable.CellDoubleClick += BookingTable_CellDoubleClick;

                    groupBox2.Controls.Add(bookingTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예매 정보를 불러오는 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 업데이트 버튼 클릭
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string newEmail = txtEmail.Text.Trim();
            string newPassword = txtPassword.Text.Trim();
            string confirmPassword = textBox1.Text.Trim();

            // 이메일 형식 검증
            if (!string.IsNullOrEmpty(newEmail) && !IsValidEmail(newEmail))
            {
                MessageBox.Show("이메일 형식이 올바르지 않습니다.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // 비밀번호 확인
            if (!string.IsNullOrEmpty(newPassword))
            {
                if (string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("비밀번호 확인을 입력해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("비밀번호와 비밀번호 확인이 일치하지 않습니다.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
            }

            // 정보 업데이트
            if (UpdateUserInfo(newEmail, newPassword))
            {
                MessageBox.Show("정보가 성공적으로 업데이트되었습니다.", "업데이트 성공",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear(); // 비밀번호 확인 필드 초기화
            }
        }

        // 사용자 정보 업데이트
        private bool UpdateUserInfo(string newEmail, string newPassword)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CustomerInfo.xml");

                XmlNodeList userNodes = xmlDoc.SelectNodes("//user");

                foreach (XmlNode userNode in userNodes)
                {
                    XmlNode idNode = userNode.SelectSingleNode("ID");
                    if (idNode != null && idNode.InnerText.Trim() == currentUserID)
                    {
                        // 이메일 업데이트
                        if (!string.IsNullOrEmpty(newEmail))
                        {
                            XmlNode emailNode = userNode.SelectSingleNode("email");
                            if (emailNode != null)
                                emailNode.InnerText = newEmail;
                        }

                        // 비밀번호 업데이트
                        if (!string.IsNullOrEmpty(newPassword))
                        {
                            XmlNode passNode = userNode.SelectSingleNode("Pass");
                            if (passNode != null)
                                passNode.InnerText = newPassword;
                        }

                        break;
                    }
                }

                xmlDoc.Save("CustomerInfo.xml");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("정보 업데이트 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 이메일 형식 검증
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // 로그아웃 버튼 클릭
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "정말 로그아웃 하시겠습니까?",
                "로그아웃 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 로그인 상태 초기화
                MainScreen.SetLoginStatus(false, "", "");

                MessageBox.Show("로그아웃되었습니다.", "로그아웃",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        // 예매 테이블 더블클릭 
        private void BookingTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView table = sender as DataGridView;
                string bookingID = table.Rows[e.RowIndex].Cells["BookingID"].Value.ToString();

                // 상세 정보 창 열기
                BookingDetail detailForm = new BookingDetail(bookingID);
                detailForm.ShowDialog();

                // 상세 창이 닫힌 후 예매 정보 새로고침
                RefreshBookingInfo();
            }
        }

        // 예매 정보 새로고침
        private void RefreshBookingInfo()
        {
            // 기존 예매 정보 컨트롤들 제거
            groupBox2.Controls.Clear();

            // 예매 정보 다시 로드
            LoadBookingInfo();
        }

        // 사진 업로드 버튼 클릭 (추후 구현)
        // xml에서 사진 자체 업로드가 되지 않아서, 나중에 noSQL등을 배우면 추후 기능 업데이트를 해보려고 합니다.
        private void BtnUploadPhoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("사진 업로드 기능은 추후 구현됩니다.", "알림",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "정말 회원 탈퇴하시겠습니까?\n탈퇴 시 계정 정보와 예매 기록이 모두 삭제됩니다.",
                "회원 탈퇴 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (DeleteUserAccount(currentUserID))
                {
                    MessageBox.Show("회원 탈퇴가 완료되었습니다.", "탈퇴 완료",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 로그아웃 처리
                    MainScreen.SetLoginStatus(false, "", "");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("회원 탈퇴 중 문제가 발생했습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool DeleteUserAccount(string userId)
        {
            try
            {
                // 사용자 정보 삭제
                XmlDocument userDoc = new XmlDocument();
                userDoc.Load("CustomerInfo.xml");

                XmlNode userNode = userDoc.SelectSingleNode($"//user[ID='{userId}']");
                if (userNode != null)
                {
                    userNode.ParentNode.RemoveChild(userNode);
                    userDoc.Save("CustomerInfo.xml");
                }
                else
                {
                    return false; // 사용자 정보 없음
                }

                // 예매 정보 삭제
                if (System.IO.File.Exists("trainBook.xml"))
                {
                    XmlDocument bookDoc = new XmlDocument();
                    bookDoc.Load("trainBook.xml");

                    XmlNodeList bookingNodes = bookDoc.SelectNodes($"//booking[userID='{userId}']");
                    foreach (XmlNode bookingNode in bookingNodes)
                    {
                        bookingNode.ParentNode.RemoveChild(bookingNode);
                    }

                    bookDoc.Save("trainBook.xml");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원 정보 삭제 중 오류 발생: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}