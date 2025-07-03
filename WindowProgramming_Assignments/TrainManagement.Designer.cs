using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{
    partial class TrainManagement
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

        public static void SetLoginStatus(bool isLoggedIn, string username = "")
        {
            IsLoggedIn = isLoggedIn;
            CurrentUser = username;
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.groupBoxTrainList = new GroupBox();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.lblStatus = new Label();
            this.groupBoxControls = new GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            this.SuspendLayout();

            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Properties.Resources.Logo;
            this.pictureBox1.Location = new Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(139, 28);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;

            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = Properties.Resources.Logo;
            this.pictureBox2.Location = new Point(400, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(350, 80);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;

            // 
            // groupBoxTrainList
            // 
            this.groupBoxTrainList.BackColor = Color.White;
            this.groupBoxTrainList.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            this.groupBoxTrainList.ForeColor = Color.FromArgb(0, 37, 84);
            this.groupBoxTrainList.Location = new Point(30, 120);
            this.groupBoxTrainList.Name = "groupBoxTrainList";
            this.groupBoxTrainList.Size = new Size(780, 400);
            this.groupBoxTrainList.TabIndex = 0;
            this.groupBoxTrainList.TabStop = false;
            this.groupBoxTrainList.Text = "열차 정보 목록";

            // 
            // groupBoxControls
            // 
            this.groupBoxControls.BackColor = Color.White;
            this.groupBoxControls.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            this.groupBoxControls.ForeColor = Color.FromArgb(0, 37, 84);
            this.groupBoxControls.Location = new Point(830, 120);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new Size(200, 400);
            this.groupBoxControls.TabIndex = 5;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "관리 기능";
            this.groupBoxControls.Controls.Add(this.panelButtons);

            // 
            // panelButtons
            // 
            this.panelButtons.Location = new Point(15, 30);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(170, 350);
            this.panelButtons.TabIndex = 0;

            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(10, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(150, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "열차 추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += (s, e) => this.btnAdd.BackColor = Color.FromArgb(41, 128, 185);
            this.btnAdd.MouseLeave += (s, e) => this.btnAdd.BackColor = Color.FromArgb(52, 152, 219);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(10, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(150, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "열차 삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += (s, e) => this.btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            this.btnDelete.MouseLeave += (s, e) => this.btnDelete.BackColor = Color.FromArgb(231, 76, 60);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.FromArgb(155, 89, 182);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(10, 140);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(150, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += (s, e) => this.btnRefresh.BackColor = Color.FromArgb(142, 68, 173);
            this.btnRefresh.MouseLeave += (s, e) => this.btnRefresh.BackColor = Color.FromArgb(155, 89, 182);

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = Color.Transparent;
            this.lblStatus.Font = new Font("맑은 고딕", 10F);
            this.lblStatus.ForeColor = Color.White;
            this.lblStatus.Location = new Point(30, 540);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(200, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "데이터를 로드하는 중...";

            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnRefresh);

            // 
            // TrainManagement
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0, 37, 84);
            this.ClientSize = new Size(1060, 580);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.groupBoxTrainList);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TrainManagement";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "KTX 열차 관리 시스템";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.groupBoxControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1, pictureBox2;
        private GroupBox groupBoxTrainList;
        private GroupBox groupBoxControls;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblStatus;
    }
}