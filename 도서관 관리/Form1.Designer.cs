namespace 도서관_관리
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.TextBox textBoxIsbn;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label labelTotalBooks;
        private System.Windows.Forms.Label labelTotalUsers;
        private System.Windows.Forms.Label labelBorrowed;
        private System.Windows.Forms.Label labelOverdue;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.textBoxIsbn = new System.Windows.Forms.TextBox();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.labelTotalBooks = new System.Windows.Forms.Label();
            this.labelTotalUsers = new System.Windows.Forms.Label();
            this.labelBorrowed = new System.Windows.Forms.Label();
            this.labelOverdue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 100);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(760, 150);

            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 300);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(300, 120);

            // 
            // textBoxIsbn
            // 
            this.textBoxIsbn.Location = new System.Drawing.Point(450, 280);
            this.textBoxIsbn.Name = "textBoxIsbn";
            this.textBoxIsbn.Size = new System.Drawing.Size(200, 23);

            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(450, 310);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(200, 23);

            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(670, 280);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(75, 23);
            this.btnBorrow.Text = "대여";
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);

            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(670, 310);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.Text = "반납";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            // 
            // Labels
            // 
            this.labelTotalBooks.Location = new System.Drawing.Point(12, 10);
            this.labelTotalBooks.Size = new System.Drawing.Size(300, 23);

            this.labelTotalUsers.Location = new System.Drawing.Point(12, 30);
            this.labelTotalUsers.Size = new System.Drawing.Size(300, 23);

            this.labelBorrowed.Location = new System.Drawing.Point(12, 50);
            this.labelBorrowed.Size = new System.Drawing.Size(300, 23);

            this.labelOverdue.Location = new System.Drawing.Point(12, 70);
            this.labelOverdue.Size = new System.Drawing.Size(300, 23);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.textBoxIsbn);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.labelTotalBooks);
            this.Controls.Add(this.labelTotalUsers);
            this.Controls.Add(this.labelBorrowed);
            this.Controls.Add(this.labelOverdue);
            this.Name = "Form1";
            this.Text = "도서관 관리";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
