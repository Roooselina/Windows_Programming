using System;
using System.Linq;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "도서관 관리";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataManager.Books;
            dataGridView2.DataSource = DataManager.Users;

            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            dataGridView2.CurrentCellChanged += DataGridView2_CurrentCellChanged;

            // 라벨 초기화
            label4.Text = DataManager.Books.Count.ToString();
            label9.Text = DataManager.Users.Count.ToString();
            label10.Text = DataManager.Books.Count(b => b.IsBorrowed).ToString();
            label11.Text = DataManager.Books.Count(b => b.IsBorrowed && b.BorrowedAt.AddDays(7) < DateTime.Now).ToString();

            btnBorrow.Click += Button1_Click;
            btnReturn.Click += Button2_Click;
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Book book = dataGridView1.CurrentRow?.DataBoundItem as Book;
                if (book != null)
                {
                    textBoxIsbn.Text = book.Isbn;
                    textBoxName.Text = book.Name;
                    textBoxUserId.Text = book.UserId.ToString();
                }
            }
            catch { }
        }

        private void DataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                User user = dataGridView2.CurrentRow?.DataBoundItem as User;
                if (user != null)
                {
                    textBoxUserId.Text = user.Id.ToString();
                }
            }
            catch { }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBoxIsbn.Text.Trim() == "")
            {
                MessageBox.Show("Isbn을 입력해주세요!");
            }
            else if (textBoxUserId.Text.Trim() == "")
            {
                MessageBox.Show("사용자 ID를 입력해주세요!");
            }
            else
            {
                try
                {
                    Book book = DataManager.Books.Single(x => x.Isbn == textBoxIsbn.Text);
                    if (book.IsBorrowed)
                    {
                        MessageBox.Show("이미 대여 중인 도서입니다.");
                    }
                    else
                    {
                        User user = DataManager.Users.Single(x => x.Id.ToString() == textBoxUserId.Text);
                        book.UserId = user.Id;
                        book.UserName = user.Name;
                        book.IsBorrowed = true;
                        book.BorrowedAt = DateTime.Now;

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Books;
                        DataManager.Save();

                        MessageBox.Show($"\"{book.Name}\"가 \"{user.Name}\"에게 대여되었습니다.");
                    }
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 도서 또는 사용자입니다.");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBoxIsbn.Text.Trim() == "")
            {
                MessageBox.Show("Isbn을 입력해주세요.");
            }
            else
            {
                try
                {
                    Book book = DataManager.Books.Single(x => x.Isbn == textBoxIsbn.Text);
                    if (!book.IsBorrowed)
                    {
                        MessageBox.Show("이 도서는 대여 중이 아닙니다.");
                    }
                    else
                    {
                        book.UserId = 0;
                        book.UserName = "";
                        book.IsBorrowed = false;
                        book.BorrowedAt = new DateTime();

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Books;
                        DataManager.Save();

                        MessageBox.Show($"\"{book.Name}\"가 반납되었습니다.");
                    }
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 도서입니다.");
                }
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DataManager.Books;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = DataManager.Users;
        }
    }
}
