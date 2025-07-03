namespace WindowProgramming_Assignments
{
    partial class UserInfo
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox profileBox;
        private Button btnUploadPhoto;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Button btnSignUp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private TextBox txtID;
        private TextBox txtPassword;
        private PictureBox logoBox;

        private void InitializeComponent()
        {
            profileBox = new PictureBox();
            btnUploadPhoto = new Button();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            txtID = new TextBox();
            txtPassword = new TextBox();
            btnSignUp = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            label6 = new Label();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            logoBox = new PictureBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)profileBox).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // profileBox
            // 
            profileBox.BorderStyle = BorderStyle.FixedSingle;
            profileBox.Location = new Point(20, 30);
            profileBox.Name = "profileBox";
            profileBox.Size = new Size(120, 120);
            profileBox.SizeMode = PictureBoxSizeMode.StretchImage;
            profileBox.TabIndex = 0;
            profileBox.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.Location = new Point(21, 160);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(119, 37);
            btnUploadPhoto.TabIndex = 1;
            btnUploadPhoto.Text = "사진 업로드";
            // 
            // txtName
            // 
            txtName.Location = new Point(240, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(373, 32);
            txtName.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(240, 57);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(373, 32);
            txtPhone.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(240, 87);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(373, 32);
            txtEmail.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(0, 0);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 0;
            // 
            // txtID
            // 
            txtID.Location = new Point(240, 117);
            txtID.Name = "txtID";
            txtID.Size = new Size(373, 32);
            txtID.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(240, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(373, 32);
            txtPassword.TabIndex = 11;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.Orange;
            btnSignUp.Font = new Font("한컴산뜻돋움", 14.2499981F, FontStyle.Bold);
            btnSignUp.Location = new Point(369, 236);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(115, 30);
            btnSignUp.TabIndex = 2;
            btnSignUp.Text = "로그아웃";
            btnSignUp.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(profileBox);
            groupBox1.Controls.Add(btnUploadPhoto);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnSignUp);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Font = new Font("한컴 고딕", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox1.Location = new Point(12, 101);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(630, 287);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Information";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(240, 178);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 32);
            textBox1.TabIndex = 13;
            // 
            // label6
            // 
            label6.Location = new Point(160, 179);
            label6.Name = "label6";
            label6.Size = new Size(95, 23);
            label6.TabIndex = 12;
            label6.Text = "PW확인:";
            // 
            // button2
            // 
            button2.BackColor = Color.Orange;
            button2.Font = new Font("한컴산뜻돋움", 14.2499981F, FontStyle.Bold);
            button2.Location = new Point(500, 236);
            button2.Name = "button2";
            button2.Size = new Size(113, 30);
            button2.TabIndex = 2;
            button2.Text = "업데이트";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Location = new Point(160, 30);
            label1.Name = "label1";
            label1.Size = new Size(68, 23);
            label1.TabIndex = 2;
            label1.Text = "이름:";
            // 
            // label2
            // 
            label2.Location = new Point(160, 120);
            label2.Name = "label2";
            label2.Size = new Size(60, 23);
            label2.TabIndex = 3;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.Location = new Point(160, 90);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 4;
            label3.Text = "이메일:";
            // 
            // label4
            // 
            label4.Location = new Point(160, 60);
            label4.Name = "label4";
            label4.Size = new Size(60, 23);
            label4.TabIndex = 5;
            label4.Text = "전화:";
            // 
            // label5
            // 
            label5.Location = new Point(160, 150);
            label5.Name = "label5";
            label5.Size = new Size(68, 23);
            label5.TabIndex = 6;
            label5.Text = "PW:";
            // 
            // logoBox
            // 
            logoBox.Image = Properties.Resources.Logo;
            logoBox.Location = new Point(105, 12);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(480, 60);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Font = new Font("한컴 고딕", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox2.Location = new Point(12, 415);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(630, 222);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "예메 정보";
            // 
            // button1
            // 
            button1.BackColor = Color.Orange;
            button1.Font = new Font("한컴산뜻돋움", 14.2499981F, FontStyle.Bold);
            button1.Location = new Point(240, 236);
            button1.Name = "button1";
            button1.Size = new Size(110, 30);
            button1.TabIndex = 14;
            button1.Text = "회원 탈퇴";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnDeleteUser_Click;
            // 
            // UserInfo
            // 
            BackColor = Color.FromArgb(0, 37, 80);
            ClientSize = new Size(654, 649);
            Controls.Add(groupBox2);
            Controls.Add(logoBox);
            Controls.Add(groupBox1);
            Name = "UserInfo";
            Text = "Sign Up";
            ((System.ComponentModel.ISupportInitialize)profileBox).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        private void AddLabeledTextBox(string labelText, TextBox textBox, int y)
        {
            Label lbl = new Label();
            lbl.Text = labelText;
            lbl.Location = new Point(150, y);
            lbl.Size = new Size(70, 23);
            this.Controls.Add(lbl);

            textBox.Location = new Point(230, y);
            textBox.Size = new Size(200, 23);
            this.Controls.Add(textBox);
        }

        private GroupBox groupBox1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button2;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Label label6;
        private Button button1;
    }
}