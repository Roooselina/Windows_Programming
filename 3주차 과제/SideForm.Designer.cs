namespace _3주차_과제
{
    partial class SideForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblIntro;

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
            lblName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblIntro = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(300, 23);
            lblName.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(20, 50);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(300, 23);
            lblEmail.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(20, 80);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(300, 23);
            lblPhone.TabIndex = 2;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(20, 110);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(300, 23);
            lblAddress.TabIndex = 3;
            // 
            // lblIntro
            // 
            lblIntro.Location = new Point(20, 140);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(300, 100);
            lblIntro.TabIndex = 4;
            // 
            // SideForm
            // 
            ClientSize = new Size(400, 300);
            Controls.Add(lblName);
            Controls.Add(lblEmail);
            Controls.Add(lblPhone);
            Controls.Add(lblAddress);
            Controls.Add(lblIntro);
            Name = "SideForm";
            Text = "입력 정보 요약";
            ResumeLayout(false);
        }
    }
}