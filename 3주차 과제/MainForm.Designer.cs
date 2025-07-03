using System;
using System.Drawing;
using System.Windows.Forms;

namespace _3주차_과제
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtPasswordConfirm;
        private TextBox txtName;
        private TextBox txtPhone;
        private CheckBox chkAgreement;
        private Button btnSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtPasswordConfirm = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            chkAgreement = new CheckBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(114, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "회원가입 폼";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "이메일";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 90);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "비밀번호";
            txtPassword.Size = new Size(300, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.Location = new Point(20, 120);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.PlaceholderText = "비밀번호 확인";
            txtPasswordConfirm.Size = new Size(300, 23);
            txtPasswordConfirm.TabIndex = 3;
            txtPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 150);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "이름";
            txtName.Size = new Size(300, 23);
            txtName.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(20, 180);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "전화번호 (선택)";
            txtPhone.Size = new Size(300, 23);
            txtPhone.TabIndex = 5;
            // 
            // chkAgreement
            // 
            chkAgreement.AutoSize = true;
            chkAgreement.Location = new Point(20, 210);
            chkAgreement.Name = "chkAgreement";
            chkAgreement.Size = new Size(225, 19);
            chkAgreement.TabIndex = 6;
            chkAgreement.Text = "개인정보 수집 및 이용에 동의합니다.";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(20, 250);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(300, 30);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "가입하기";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(350, 320);
            Controls.Add(lblTitle);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtPasswordConfirm);
            Controls.Add(txtName);
            Controls.Add(txtPhone);
            Controls.Add(chkAgreement);
            Controls.Add(btnSubmit);
            Name = "MainForm";
            Text = "회원 가입";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
