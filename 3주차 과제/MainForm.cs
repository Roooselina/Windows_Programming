namespace _3주차_과제
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 약관 동의 체크
            if (!chkAgreement.Checked)
            {
                MessageBox.Show("개인정보 수집 및 이용에 동의해주세요.");
                return;
            }

            // 이메일, 이름, 비밀번호 유효성 검사
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordConfirm.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("필수 항목을 모두 입력해주세요.");
                return;
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("비밀번호와 비밀번호 확인이 일치하지 않습니다.");
                return;
            }

            // 입력된 정보를 요약 폼에 전달
            SideForm summary = new SideForm(
                txtName.Text,
                txtEmail.Text,
                txtPhone.Text
            );

            summary.Show();
        }
    }
}
