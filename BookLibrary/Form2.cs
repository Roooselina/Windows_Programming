using System;
using System.Linq;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Text = "도서 관리";

            // 데이터 바인딩
            dataGridViewBooks.DataSource = DataManager.Books;

            // 셀 변경 이벤트
            dataGridViewBooks.CurrentCellChanged += DataGridViewBooks_CurrentCellChanged;

            // 버튼 이벤트 연결
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void DataGridViewBooks_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Book book = dataGridViewBooks.CurrentRow?.DataBoundItem as Book;
                if (book != null)
                {
                    textBoxIsbnEdit.Text = book.Isbn;
                    textBoxNameEdit.Text = book.Name;
                    textBoxPublisherEdit.Text = book.Publisher;
                    textBoxPageEdit.Text = book.Page.ToString();
                }
            }
            catch { }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataManager.Books.Exists(x => x.Isbn == textBoxIsbnEdit.Text))
                {
                    MessageBox.Show("이미 존재하는 도서입니다.");
                }
                else
                {
                    Book book = new Book
                    {
                        Isbn = textBoxIsbnEdit.Text,
                        Name = textBoxNameEdit.Text,
                        Publisher = textBoxPublisherEdit.Text,
                        Page = int.Parse(textBoxPageEdit.Text)
                    };

                    DataManager.Books.Add(book);
                    RefreshGrid();
                    DataManager.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"추가 실패: {ex.Message}");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = DataManager.Books.Single(x => x.Isbn == textBoxIsbnEdit.Text);
                book.Name = textBoxNameEdit.Text;
                book.Publisher = textBoxPublisherEdit.Text;
                book.Page = int.Parse(textBoxPageEdit.Text);

                RefreshGrid();
                DataManager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"수정 실패: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = DataManager.Books.Single(x => x.Isbn == textBoxIsbnEdit.Text);
                DataManager.Books.Remove(book);

                RefreshGrid();
                DataManager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"삭제 실패: {ex.Message}");
            }
        }

        private void RefreshGrid()
        {
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = DataManager.Books;
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
