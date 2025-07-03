namespace BookLibrary
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.groupBoxBookEdit = new System.Windows.Forms.GroupBox();
            this.textBoxIsbnEdit = new System.Windows.Forms.TextBox();
            this.textBoxNameEdit = new System.Windows.Forms.TextBox();
            this.textBoxPublisherEdit = new System.Windows.Forms.TextBox();
            this.textBoxPageEdit = new System.Windows.Forms.TextBox();
            this.labelIsbn = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBoxBookList = new System.Windows.Forms.GroupBox();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.groupBoxBookEdit.SuspendLayout();
            this.groupBoxBookList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBookEdit
            // 
            this.groupBoxBookEdit.Controls.Add(this.textBoxIsbnEdit);
            this.groupBoxBookEdit.Controls.Add(this.textBoxNameEdit);
            this.groupBoxBookEdit.Controls.Add(this.textBoxPublisherEdit);
            this.groupBoxBookEdit.Controls.Add(this.textBoxPageEdit);
            this.groupBoxBookEdit.Controls.Add(this.labelIsbn);
            this.groupBoxBookEdit.Controls.Add(this.labelName);
            this.groupBoxBookEdit.Controls.Add(this.labelPublisher);
            this.groupBoxBookEdit.Controls.Add(this.labelPage);
            this.groupBoxBookEdit.Controls.Add(this.btnAdd);
            this.groupBoxBookEdit.Controls.Add(this.btnUpdate);
            this.groupBoxBookEdit.Controls.Add(this.btnDelete);
            this.groupBoxBookEdit.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBookEdit.Name = "groupBoxBookEdit";
            this.groupBoxBookEdit.Size = new System.Drawing.Size(350, 200);
            this.groupBoxBookEdit.TabIndex = 0;
            this.groupBoxBookEdit.TabStop = false;
            this.groupBoxBookEdit.Text = "도서 추가/수정/삭제";
            // 
            // textBoxIsbnEdit
            // 
            this.textBoxIsbnEdit.Location = new System.Drawing.Point(100, 22);
            this.textBoxIsbnEdit.Name = "textBoxIsbnEdit";
            this.textBoxIsbnEdit.Size = new System.Drawing.Size(200, 21);
            this.textBoxIsbnEdit.TabIndex = 0;
            // 
            // textBoxNameEdit
            // 
            this.textBoxNameEdit.Location = new System.Drawing.Point(100, 52);
            this.textBoxNameEdit.Name = "textBoxNameEdit";
            this.textBoxNameEdit.Size = new System.Drawing.Size(200, 21);
            this.textBoxNameEdit.TabIndex = 1;
            // 
            // textBoxPublisherEdit
            // 
            this.textBoxPublisherEdit.Location = new System.Drawing.Point(100, 82);
            this.textBoxPublisherEdit.Name = "textBoxPublisherEdit";
            this.textBoxPublisherEdit.Size = new System.Drawing.Size(200, 21);
            this.textBoxPublisherEdit.TabIndex = 2;
            // 
            // textBoxPageEdit
            // 
            this.textBoxPageEdit.Location = new System.Drawing.Point(100, 112);
            this.textBoxPageEdit.Name = "textBoxPageEdit";
            this.textBoxPageEdit.Size = new System.Drawing.Size(200, 21);
            this.textBoxPageEdit.TabIndex = 3;
            // 
            // labelIsbn
            // 
            this.labelIsbn.Location = new System.Drawing.Point(20, 25);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(100, 23);
            this.labelIsbn.TabIndex = 4;
            this.labelIsbn.Text = "Isbn";
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(20, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 23);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "도서 이름";
            // 
            // labelPublisher
            // 
            this.labelPublisher.Location = new System.Drawing.Point(20, 85);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(100, 23);
            this.labelPublisher.TabIndex = 6;
            this.labelPublisher.Text = "출판사";
            // 
            // labelPage
            // 
            this.labelPage.Location = new System.Drawing.Point(20, 115);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(100, 23);
            this.labelPage.TabIndex = 7;
            this.labelPage.Text = "페이지";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "추가";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(130, 150);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "수정";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(230, 150);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "삭제";
            // 
            // groupBoxBookList
            // 
            this.groupBoxBookList.Controls.Add(this.dataGridViewBooks);
            this.groupBoxBookList.Location = new System.Drawing.Point(12, 220);
            this.groupBoxBookList.Name = "groupBoxBookList";
            this.groupBoxBookList.Size = new System.Drawing.Size(350, 200);
            this.groupBoxBookList.TabIndex = 1;
            this.groupBoxBookList.TabStop = false;
            this.groupBoxBookList.Text = "도서 현황";
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(6, 29);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(338, 165);
            this.dataGridViewBooks.TabIndex = 0;
            this.dataGridViewBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellContentClick);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(380, 440);
            this.Controls.Add(this.groupBoxBookEdit);
            this.Controls.Add(this.groupBoxBookList);
            this.Name = "Form2";
            this.Text = "도서 관리";
            this.groupBoxBookEdit.ResumeLayout(false);
            this.groupBoxBookEdit.PerformLayout();
            this.groupBoxBookList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBookEdit;
        private System.Windows.Forms.TextBox textBoxIsbnEdit;
        private System.Windows.Forms.TextBox textBoxNameEdit;
        private System.Windows.Forms.TextBox textBoxPublisherEdit;
        private System.Windows.Forms.TextBox textBoxPageEdit;
        private System.Windows.Forms.Label labelIsbn;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBoxBookList;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
    }
}