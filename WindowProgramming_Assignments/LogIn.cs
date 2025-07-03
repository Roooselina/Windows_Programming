using System.Windows.Forms;
using System.Xml;

namespace WindowProgramming_Assignments
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

            // 이벤트 핸들러 연결
            btnLogin.Click += btnLogin_Click;
            btnCancel.Click += btnCancel_Click;

            // Enter 키로 로그인 가능하도록 설정
            txtPassword.KeyPress += txtPassword_KeyPress;

            // 폼 설정
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        // 로그인 버튼 클릭
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtID.Text.Trim();
            string password = txtPassword.Text;

            // 입력 검증
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("아이디를 입력해주세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("비밀번호를 입력해주세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // 로그인 검증
            if (ValidateLogin(userId, password))
            {
                // 로그인 성공 |  ValidateLogin에서 설정된 ID와 이름을 사용
                // CustomerInfo.xml에 있는 정보 사용
                string userID = MainScreen.CurrentUser;    // 실제 ID (123, admin, user01)
                string userName = MainScreen.CurrentName;  // 실제 이름 (이은정, 김철수, 박영희)

                // MainScreen의 로그인 상태 설정 (userID, userName 순서로 전달)
                MainScreen.SetLoginStatus(true, userID, userName);

                // 이름을 사용한 환영 메시지
                if (MainScreen.IsManager == true)
                {
                    userName = "매니저";
                }
                MessageBox.Show($"{userName}님, 환영합니다!", "로그인 성공",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 로그인 폼 닫기
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // 로그인 실패
                MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.", "로그인 실패",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 비밀번호 초기화 및 포커스
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // 취소 버튼 클릭 이벤트
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 비밀번호 텍스트박스에서 Enter 키 처리
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        // 로그인 검증 메서드; CustomerInfo.xml 파일에서 확인
        private bool ValidateLogin(string userId, string password)
        {
            try
            {
                // XML 파일 로드
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CustomerInfo.xml");

                // 모든 user 노드 검색
                XmlNodeList userNodes = xmlDoc.SelectNodes("//user");

                foreach (XmlNode userNode in userNodes)
                {
                    // ID와 Pass 노드 찾기
                    XmlNode idNode = userNode.SelectSingleNode("ID");
                    XmlNode passNode = userNode.SelectSingleNode("Pass");

                    if (idNode != null && passNode != null)
                    {
                        string xmlUserId = idNode.InnerText.Trim();
                        string xmlPassword = passNode.InnerText.Trim();

                        // 관리자 로그인
                        if (userId == "Manager" && password == "Manager")
                        {
                            MainScreen.IsManager = true;

                            return true;
                        }

                        // 입력된 ID, Password와 비교
                        if (xmlUserId == userId && xmlPassword == password)
                        {
                            // 로그인 성공 - 사용자 ID와 이름 모두 저장
                            XmlNode nameNode = userNode.SelectSingleNode("name");

                            MainScreen.CurrentUser = xmlUserId; // ID 저장 (123, admin, user01 등)
                            MainScreen.CurrentName = nameNode?.InnerText?.Trim() ?? ""; // 이름 저장 (이은정, 김철수, 박영희 등)

                            return true;
                        }
                    }
                }
                return false; // 일치하는 계정이 없음
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 처리 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 사용자 ID로 이름 가져오기
        private string GetUserName(string userId)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CustomerInfo.xml");

                XmlNode userNode = xmlDoc.SelectSingleNode($"//user[ID='{userId}']");
                if (userNode != null)
                {
                    XmlNode nameNode = userNode.SelectSingleNode("name");
                    if (nameNode != null)
                    {
                        return nameNode.InnerText.Trim();
                    }
                }
                return userId; // 이름을 찾을 수 없으면 ID 반환
            }
            catch
            {
                return userId; // 오류 시 ID 반환
            }
        }

        // 폼이 로드될 때 초기화
        private void LogIn_Load(object sender, EventArgs e)
        {
            txtID.Focus(); // ID 텍스트박스에 포커스
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}