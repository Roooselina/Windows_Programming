using System;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace WindowProgramming_Assignments
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();

            // 폼 설정
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // PlaceholderText 설정
            SetPlaceholderTexts();
        }

        // PlaceholderText 설정
        private void SetPlaceholderTexts()
        {
            txtName.PlaceholderText = "예) 홍길동";
            txtPhone.PlaceholderText = "예) 010-1234-5678";
            txtEmail.PlaceholderText = "예) example@gmail.com";
            txtID.PlaceholderText = "예) user123";
            txtPassword.PlaceholderText = "예) password123";

            // 실시간 입력 검증 이벤트 연결
            txtPhone.Leave += TxtPhone_Leave;
            txtEmail.Leave += TxtEmail_Leave;
        }

        // 전화번호 필드에서 포커스가 벗어날 때 검증
        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            if (!string.IsNullOrEmpty(phone) && !IsValidPhoneNumber(phone))
            {
                txtPhone.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("전화번호 형식이 올바르지 않습니다.\n형식: 010-1234-5678", "형식 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
            }
            else
            {
                txtPhone.BackColor = System.Drawing.Color.White;
            }
        }

        // 이메일 필드에서 포커스가 벗어날 때 검증
        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                txtEmail.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("이메일 형식이 올바르지 않습니다.\n형식: example@domain.com", "형식 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            else
            {
                txtEmail.BackColor = System.Drawing.Color.White;
            }
        }

        // 사진 업로드 버튼 클릭 (일단 구현하지 않음)
        private void BtnUploadPhoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("사진 업로드 기능은 추후 구현됩니다.", "알림",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 회원가입 버튼 클릭
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            // 입력값 가져오기
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string id = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 입력 검증
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("이름을 입력해주세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("전화번호를 입력해주세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // 전화번호 형식 검증 (010-1234-5678)
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("전화번호를 올바른 형식으로 입력해주세요.\n형식: 010-1234-5678", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("이메일을 입력해주세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // 이메일 형식 검증
            if (!IsValidEmail(email))
            {
                MessageBox.Show("이메일을 올바른 형식으로 입력해주세요.\n형식: example@domain.com", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID를 입력해주세요.", "입력 오류",
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

            // ID 중복 검사
            if (IsIdExists(id))
            {
                MessageBox.Show("이미 존재하는 ID입니다.", "ID 중복",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Clear();
                txtID.Focus();
                return;
            }

            // 회원 정보 추가
            if (AddNewUser(name, phone, email, id, password))
            {
                MessageBox.Show("회원가입이 완료되었습니다!", "회원가입 성공",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("회원가입 처리 중 오류가 발생했습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 취소 버튼 클릭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 전화번호 형식 검증 (010-1234-5678)
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // 정규식 패턴: 010-숫자4자리-숫자4자리
            string pattern = @"^010-\d{4}-\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        // 이메일 형식 검증
        private bool IsValidEmail(string email)
        {
            // 기본적인 이메일 형식 검증 (@ 포함 여부)
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // ID 중복 검사
        private bool IsIdExists(string id)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CustomerInfo.xml");

                // 모든 user 노드에서 ID 검색
                XmlNodeList userNodes = xmlDoc.SelectNodes("//user");

                foreach (XmlNode userNode in userNodes)
                {
                    XmlNode idNode = userNode.SelectSingleNode("ID");
                    if (idNode != null && idNode.InnerText.Trim() == id)
                    {
                        return true; // ID가 이미 존재함
                    }
                }

                return false; // ID가 존재하지 않음
            }
            catch (System.IO.FileNotFoundException)
            {
                // 파일이 없으면 첫 번째 사용자이므로 중복이 아님
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID 중복 검사 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // 안전을 위해 중복으로 처리
            }
        }

        // 새로운 사용자 추가
        private bool AddNewUser(string name, string phone, string email, string id, string password)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                // XML 파일이 존재하는지 확인
                if (System.IO.File.Exists("CustomerInfo.xml"))
                {
                    xmlDoc.Load("CustomerInfo.xml");
                }
                else
                {
                    // 새로운 XML 파일 생성
                    XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                    xmlDoc.AppendChild(xmlDeclaration);

                    XmlElement rootElement = xmlDoc.CreateElement("customers");
                    xmlDoc.AppendChild(rootElement);
                }

                // 루트 요소 가져오기
                XmlElement root = xmlDoc.DocumentElement;

                // 새로운 user 요소 생성
                XmlElement userElement = xmlDoc.CreateElement("user");

                // 각 정보 요소 생성 및 추가
                XmlElement nameElement = xmlDoc.CreateElement("name");
                nameElement.InnerText = name;
                userElement.AppendChild(nameElement);

                XmlElement emailElement = xmlDoc.CreateElement("email");
                emailElement.InnerText = email;
                userElement.AppendChild(emailElement);

                XmlElement phoneElement = xmlDoc.CreateElement("phoneNum");
                phoneElement.InnerText = phone;
                userElement.AppendChild(phoneElement);

                XmlElement idElement = xmlDoc.CreateElement("ID");
                idElement.InnerText = id;
                userElement.AppendChild(idElement);

                XmlElement passElement = xmlDoc.CreateElement("Pass");
                passElement.InnerText = password;
                userElement.AppendChild(passElement);

                // 루트에 user 요소 추가
                root.AppendChild(userElement);

                // XML 파일 저장
                xmlDoc.Save("CustomerInfo.xml");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("사용자 추가 중 오류가 발생했습니다: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // label4 클릭 이벤트 (Designer에서 연결되어 있음)
        private void label4_Click(object sender, EventArgs e)
        {
            // 특별한 동작 없음
        }
    }
}