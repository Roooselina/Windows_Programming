using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{
    partial class LogIn
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblID;
        private Label lblPassword;
        private TextBox txtID;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private PictureBox logoBox;
        private GroupBox groupBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            lblID = new Label();
            lblPassword = new Label();
            txtID = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            logoBox = new PictureBox();
            groupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.Location = new Point(40, 30);
            lblID.Name = "lblID";
            lblID.Size = new Size(60, 23);
            lblID.TabIndex = 0;
            lblID.Text = "ID:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(25, 65);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(75, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtID
            // 
            txtID.Location = new Point(110, 30);
            txtID.Name = "txtID";
            txtID.RightToLeft = RightToLeft.No;
            txtID.Size = new Size(240, 32);
            txtID.TabIndex = 1;
            txtID.TextChanged += txtID_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(110, 65);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.Size = new Size(240, 32);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Orange;
            btnLogin.Location = new Point(110, 107);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Orange;
            btnCancel.Location = new Point(250, 107);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // logoBox
            // 
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(40, 46);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(400, 60);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // groupBox
            // 
            groupBox.BackColor = Color.White;
            groupBox.Controls.Add(lblID);
            groupBox.Controls.Add(txtID);
            groupBox.Controls.Add(lblPassword);
            groupBox.Controls.Add(txtPassword);
            groupBox.Controls.Add(btnLogin);
            groupBox.Controls.Add(btnCancel);
            groupBox.Font = new Font("한컴 고딕", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox.Location = new Point(40, 136);
            groupBox.Name = "groupBox";
            groupBox.RightToLeft = RightToLeft.Yes;
            groupBox.Size = new Size(400, 154);
            groupBox.TabIndex = 1;
            groupBox.TabStop = false;
            // 
            // LogIn
            // 
            BackColor = Color.FromArgb(0, 37, 84);
            ClientSize = new Size(480, 318);
            Controls.Add(logoBox);
            Controls.Add(groupBox);
            Name = "LogIn";
            Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
        }
    }
}
