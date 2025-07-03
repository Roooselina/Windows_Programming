namespace _3주차_과제
{
    public partial class SideForm : Form
    {
        public SideForm(string name, string email, string phone)
        {
            InitializeComponent();

            lblName.Text = $"이름: {name}";
            lblEmail.Text = $"이메일: {email}";
            lblPhone.Text = $"전화번호: {phone}";
        }
    }
}