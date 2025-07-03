using System;
using System.Linq;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Text = "사용자 관리";

            // 데이터 그리드 설정
            dataGridViewUsers.DataSource = DataManager.Users;
            dataGridViewUsers.CurrentCellChanged += DataGridViewUsers_CurrentCellChanged;

            // 버튼 설정
            btnUserAdd.Click += (sender, e) =>
            {
                try
                {
                    if (DataManager.Users.Exists(x => x.Id == int.Parse(textBoxUserId.Text)))
                    {
                        MessageBox.Show("사용자 ID가 중복됩니다.");
                    }
                    else
                    {
                        User user = new User()
                        {
                            Id = int.Parse(textBoxUserId.Text),
                            Name = textBoxUserName.Text
                        };
                        DataManager.Users.Add(user);
                        RefreshUserGrid();
                        DataManager.Save();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("입력 오류: " + ex.Message);
                }
            };

            btnUserUpdate.Click += (sender, e) =>
            {
                try
                {
                    User user = DataManager.Users.Single(x => x.Id == int.Parse(textBoxUserId.Text));
                    user.Name = textBoxUserName.Text;
                    RefreshUserGrid();
                    DataManager.Save();
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 사용자입니다.");
                }
            };

            btnUserDelete.Click += (sender, e) =>
            {
                try
                {
                    User user = DataManager.Users.Single(x => x.Id == int.Parse(textBoxUserId.Text));
                    DataManager.Users.Remove(user);
                    RefreshUserGrid();
                    DataManager.Save();
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 사용자입니다.");
                }
            };
        }

        private void RefreshUserGrid()
        {
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = DataManager.Users;
        }

        private void DataGridViewUsers_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.CurrentRow != null && dataGridViewUsers.CurrentRow.Index > -1)
                {
                    User user = dataGridViewUsers.CurrentRow.DataBoundItem as User;
                    if (user != null)
                    {
                        textBoxUserId.Text = user.Id.ToString();
                        textBoxUserName.Text = user.Name;
                    }
                }
            }
            catch (Exception) { }
        }

    }

}
