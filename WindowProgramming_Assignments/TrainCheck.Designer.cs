using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{


    partial class TrainCheck
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

        public static bool IsLoggedIn { get; set; } = false;
        public static string CurrentUser { get; set; } = "";
        

        // SignUp 라벨 클릭 이벤트
        private void labelSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                SignUp signUpForm = new SignUp();
                signUpForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("회원가입 폼을 열 수 없습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SetLoginStatus(bool isLoggedIn, string username = "")
        {
            IsLoggedIn = isLoggedIn;
            CurrentUser = username;
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(23, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Logo;
            pictureBox2.Location = new Point(345, 31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(495, 120);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Font = new Font("한컴 고딕", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox1.Location = new Point(42, 178);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1056, 397);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Train List";
            // 
            // TrainCheck
            // 
            BackColor = Color.FromArgb(0, 37, 84);
            ClientSize = new Size(1143, 614);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "TrainCheck";
            Text = "    ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private PictureBox pictureBox1, pictureBox2;
        private GroupBox groupBox1;
    }
}