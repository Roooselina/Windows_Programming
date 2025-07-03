using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{
    partial class SignUp
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
        private Button btnCancel;
        private PictureBox logoBox;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            profileBox = new PictureBox();
            btnUploadPhoto = new Button();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            txtID = new TextBox();
            txtPassword = new TextBox();
            btnSignUp = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            logoBox = new PictureBox();
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
            txtName.Size = new Size(359, 32);
            txtName.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(240, 57);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(359, 32);
            txtPhone.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(240, 87);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(359, 32);
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
            txtID.Size = new Size(359, 32);
            txtID.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(240, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(359, 32);
            txtPassword.TabIndex = 11;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.Orange;
            btnSignUp.Font = new Font("한컴산뜻돋움", 14.2499981F, FontStyle.Bold);
            btnSignUp.Location = new Point(349, 328);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(127, 30);
            btnSignUp.TabIndex = 2;
            btnSignUp.Text = "회원가입";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += BtnSignUp_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Orange;
            btnCancel.Font = new Font("한컴산뜻돋움", 14.2499981F, FontStyle.Bold);
            btnCancel.Location = new Point(195, 328);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(profileBox);
            groupBox1.Controls.Add(btnUploadPhoto);
            groupBox1.Controls.Add(label1);
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
            groupBox1.Size = new Size(631, 203);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Information";
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
            label4.Click += label4_Click;
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
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(93, 12);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(480, 60);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // SignUp
            // 
            BackColor = Color.FromArgb(0, 37, 80);
            ClientSize = new Size(654, 371);
            Controls.Add(logoBox);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnSignUp);
            Name = "SignUp";
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
        private TextBox textBox1;
        private Button button1;
        private Label label1;
        private TextBox textBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
