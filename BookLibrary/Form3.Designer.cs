namespace BookLibrary
{
    partial class Form3
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
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.groupBoxUserEdit = new System.Windows.Forms.GroupBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.btnUserUpdate = new System.Windows.Forms.Button();
            this.btnUserDelete = new System.Windows.Forms.Button();
            this.groupBoxUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.groupBoxUserEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.dataGridViewUsers);
            this.groupBoxUserList.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(220, 400);
            this.groupBoxUserList.TabIndex = 0;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "사용자 현황";
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUsers.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(214, 380);
            this.dataGridViewUsers.TabIndex = 0;
            // 
            // groupBoxUserEdit
            // 
            this.groupBoxUserEdit.Controls.Add(this.labelUserId);
            this.groupBoxUserEdit.Controls.Add(this.labelUserName);
            this.groupBoxUserEdit.Controls.Add(this.textBoxUserId);
            this.groupBoxUserEdit.Controls.Add(this.textBoxUserName);
            this.groupBoxUserEdit.Controls.Add(this.btnUserAdd);
            this.groupBoxUserEdit.Controls.Add(this.btnUserUpdate);
            this.groupBoxUserEdit.Controls.Add(this.btnUserDelete);
            this.groupBoxUserEdit.Location = new System.Drawing.Point(250, 12);
            this.groupBoxUserEdit.Name = "groupBoxUserEdit";
            this.groupBoxUserEdit.Size = new System.Drawing.Size(250, 180);
            this.groupBoxUserEdit.TabIndex = 1;
            this.groupBoxUserEdit.TabStop = false;
            this.groupBoxUserEdit.Text = "사용자 추가/수정/삭제";
            // 
            // labelUserId
            // 
            this.labelUserId.Location = new System.Drawing.Point(10, 25);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(64, 23);
            this.labelUserId.TabIndex = 0;
            this.labelUserId.Text = "사용자 ID";
            // 
            // labelUserName
            // 
            this.labelUserName.Location = new System.Drawing.Point(10, 57);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(64, 23);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "이름";
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(90, 27);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(140, 21);
            this.textBoxUserId.TabIndex = 2;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(90, 57);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(140, 21);
            this.textBoxUserName.TabIndex = 3;
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Location = new System.Drawing.Point(9, 140);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(75, 23);
            this.btnUserAdd.TabIndex = 4;
            this.btnUserAdd.Text = "추가";
            // 
            // btnUserUpdate
            // 
            this.btnUserUpdate.Location = new System.Drawing.Point(89, 140);
            this.btnUserUpdate.Name = "btnUserUpdate";
            this.btnUserUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUserUpdate.TabIndex = 5;
            this.btnUserUpdate.Text = "수정";
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.Location = new System.Drawing.Point(169, 140);
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Size = new System.Drawing.Size(75, 23);
            this.btnUserDelete.TabIndex = 6;
            this.btnUserDelete.Text = "삭제";
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(520, 430);
            this.Controls.Add(this.groupBoxUserList);
            this.Controls.Add(this.groupBoxUserEdit);
            this.Name = "Form3";
            this.Text = "사용자 관리";
            this.groupBoxUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.groupBoxUserEdit.ResumeLayout(false);
            this.groupBoxUserEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUserList;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.GroupBox groupBoxUserEdit;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.Button btnUserUpdate;
        private System.Windows.Forms.Button btnUserDelete;
    }
}