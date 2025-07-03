using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;

namespace WindowProgramming_Assignments
{


    partial class MainScreen
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
        public static string CurrentName { get; set; } = "";
        public static bool IsManager { get; set; } = false;

        // 로그인 상태에 따라 UI 업데이트
        public void UpdateLoginStatus()
        {
            if (IsLoggedIn && !IsManager)
            {
                // 로그인된 상태 (일반 사용자): UserInfo 표시, Login/SignUp 숨김
                labelUserInfo.Visible = true;
                labelLogin.Visible = false;
                labelSignUp.Visible = false;
                label6.Visible = false;
            }
            else if (!IsLoggedIn && !IsManager)
            {
                // 로그아웃된 상태 (일반 사용자): Login/SignUp 표시, UserInfo 숨김
                labelUserInfo.Visible = false;
                labelLogin.Visible = true;
                labelSignUp.Visible = true;
                label6.Visible = false;
            }
            else if (IsManager)
            {
                // 관리자 계정: 관리자 전용 label6 표시, 나머지 숨김
                labelUserInfo.Visible = false;
                labelLogin.Visible = false;
                labelSignUp.Visible = false;
                label6.Visible = true;
            }
        }

        // Train Management 라벨 클릭 이벤트
        private void labelTrain_Management_Click(object sender, EventArgs e)
        {
            try
            {

                TrainManagement trainManagement = new TrainManagement();
                trainManagement.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("기차 관리 폼을 열 수 없습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Login 라벨 클릭 이벤트
        private void labelLogin_Click(object sender, EventArgs e)
        {
            try
            {

                LogIn loginForm = new LogIn();
                loginForm.ShowDialog();
                UpdateLoginStatus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 폼을 열 수 없습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        // UserInfo 라벨 클릭 이벤트
        private void labelUserInfo_Click(object sender, EventArgs e)
        {
            // UserInfo 폼을 열기
            try
            {
                UserInfo userInfoForm = new UserInfo();
                userInfoForm.ShowDialog();

                // UserInfo 폼이 닫힌 후 상태 업데이트
                UpdateLoginStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("사용자 정보 폼을 열 수 없습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 폼이 활성화될 때마다 로그인 상태 확인
        private void MainScreen_Activated(object sender, EventArgs e)
        {
            UpdateLoginStatus();
        }

        public static void SetLoginStatus(bool isLoggedIn, string userID = "", string username="")
        {
            IsLoggedIn = isLoggedIn;
            CurrentUser = userID;
            CurrentName = username;
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            labelLogin = new Label();
            labelSignUp = new Label();
            labelUserInfo = new Label();
            groupBox1 = new GroupBox();
            radioRoundTrip = new RadioButton();
            radioOneWay = new RadioButton();
            comboFrom = new ComboBox();
            comboTo = new ComboBox();
            labelArrow = new Label();
            dateStart = new DateTimePicker();
            dateReturn = new DateTimePicker();
            comboAdult = new ComboBox();
            comboChild = new ComboBox();
            comboInfant = new ComboBox();
            btnSearchFlights = new Button();
            txtSearchID = new TextBox();
            btnSearchID = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(230, 98);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(495, 120);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Cursor = Cursors.Hand;
            labelLogin.Font = new Font("한컴 고딕", 15.75F, FontStyle.Bold);
            labelLogin.ForeColor = Color.White;
            labelLogin.Location = new Point(775, 13);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(79, 27);
            labelLogin.TabIndex = 3;
            labelLogin.Text = "LogIn /";
            labelLogin.Click += labelLogin_Click;
            // 
            // labelSignUp
            // 
            labelSignUp.AutoSize = true;
            labelSignUp.Cursor = Cursors.Hand;
            labelSignUp.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            labelSignUp.ForeColor = Color.White;
            labelSignUp.Location = new Point(869, 13);
            labelSignUp.Name = "labelSignUp";
            labelSignUp.Size = new Size(88, 25);
            labelSignUp.TabIndex = 2;
            labelSignUp.Text = "SignUp";
            labelSignUp.Click += labelSignUp_Click;
            // 
            // labelUserInfo
            // 
            labelUserInfo.AutoSize = true;
            labelUserInfo.Cursor = Cursors.Hand;
            labelUserInfo.Font = new Font("한컴 고딕", 15.75F, FontStyle.Bold);
            labelUserInfo.ForeColor = Color.White;
            labelUserInfo.Location = new Point(820, 13);
            labelUserInfo.Name = "labelUserInfo";
            labelUserInfo.Size = new Size(93, 27);
            labelUserInfo.TabIndex = 22;
            labelUserInfo.Text = "UserInfo";
            labelUserInfo.Visible = false;
            labelUserInfo.Click += labelUserInfo_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(radioRoundTrip);
            groupBox1.Controls.Add(radioOneWay);
            groupBox1.Controls.Add(comboFrom);
            groupBox1.Controls.Add(comboTo);
            groupBox1.Controls.Add(labelArrow);
            groupBox1.Controls.Add(dateStart);
            groupBox1.Controls.Add(dateReturn);
            groupBox1.Controls.Add(comboAdult);
            groupBox1.Controls.Add(comboChild);
            groupBox1.Controls.Add(comboInfant);
            groupBox1.Controls.Add(btnSearchFlights);
            groupBox1.Controls.Add(txtSearchID);
            groupBox1.Controls.Add(btnSearchID);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Font = new Font("한컴 고딕", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox1.Location = new Point(115, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(758, 311);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // radioRoundTrip
            // 
            radioRoundTrip.AutoSize = true;
            radioRoundTrip.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            radioRoundTrip.Location = new Point(20, 20);
            radioRoundTrip.Name = "radioRoundTrip";
            radioRoundTrip.Size = new Size(66, 29);
            radioRoundTrip.TabIndex = 0;
            radioRoundTrip.Text = "왕복";
            // 
            // radioOneWay
            // 
            radioOneWay.AutoSize = true;
            radioOneWay.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            radioOneWay.Location = new Point(90, 20);
            radioOneWay.Name = "radioOneWay";
            radioOneWay.Size = new Size(66, 29);
            radioOneWay.TabIndex = 1;
            radioOneWay.Text = "편도";
            // 
            // comboFrom
            // 
            comboFrom.Items.AddRange(new object[] { "서울", "부산", "인천" });
            comboFrom.Location = new Point(130, 57);
            comboFrom.Name = "comboFrom";
            comboFrom.Size = new Size(150, 33);
            comboFrom.TabIndex = 2;
            // 
            // comboTo
            // 
            comboTo.Items.AddRange(new object[] { "서울", "부산", "인천" });
            comboTo.Location = new Point(547, 62);
            comboTo.Name = "comboTo";
            comboTo.Size = new Size(150, 33);
            comboTo.TabIndex = 3;
            // 
            // labelArrow
            // 
            labelArrow.AutoSize = true;
            labelArrow.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelArrow.Location = new Point(360, 60);
            labelArrow.Name = "labelArrow";
            labelArrow.Size = new Size(24, 21);
            labelArrow.TabIndex = 4;
            labelArrow.Text = "↔";
            // 
            // dateStart
            // 
            dateStart.Location = new Point(130, 100);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(237, 32);
            dateStart.TabIndex = 5;
            // 
            // dateReturn
            // 
            dateReturn.Location = new Point(447, 100);
            dateReturn.Name = "dateReturn";
            dateReturn.Size = new Size(250, 32);
            dateReturn.TabIndex = 6;
            // 
            // comboAdult
            // 
            comboAdult.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            comboAdult.Location = new Point(130, 183);
            comboAdult.Name = "comboAdult";
            comboAdult.Size = new Size(50, 33);
            comboAdult.TabIndex = 7;
            // 
            // comboChild
            // 
            comboChild.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            comboChild.Location = new Point(363, 181);
            comboChild.Name = "comboChild";
            comboChild.Size = new Size(50, 33);
            comboChild.TabIndex = 8;
            // 
            // comboInfant
            // 
            comboInfant.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            comboInfant.Location = new Point(592, 179);
            comboInfant.Name = "comboInfant";
            comboInfant.Size = new Size(50, 33);
            comboInfant.TabIndex = 9;
            // 
            // btnSearchFlights
            // 
            btnSearchFlights.BackColor = Color.Orange;
            btnSearchFlights.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            btnSearchFlights.Location = new Point(311, 222);
            btnSearchFlights.Name = "btnSearchFlights";
            btnSearchFlights.Size = new Size(144, 35);
            btnSearchFlights.TabIndex = 10;
            btnSearchFlights.Text = "좌석 조회";
            btnSearchFlights.UseVisualStyleBackColor = false;
            // 
            // txtSearchID
            // 
            txtSearchID.Location = new Point(291, 270);
            txtSearchID.Name = "txtSearchID";
            txtSearchID.Size = new Size(180, 32);
            txtSearchID.TabIndex = 11;
            // 
            // btnSearchID
            // 
            btnSearchID.BackColor = Color.Orange;
            btnSearchID.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            btnSearchID.Location = new Point(517, 266);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(80, 33);
            btnSearchID.TabIndex = 12;
            btnSearchID.Text = "조회";
            btnSearchID.UseVisualStyleBackColor = false;
            btnSearchID.Click += BtnSearchID_Click;
            // 
            // label1
            // 
            label1.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label1.Location = new Point(447, 62);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 13;
            label1.Text = "도착지";
            // 
            // label2
            // 
            label2.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label2.Location = new Point(39, 56);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 14;
            label2.Text = "출발지";
            // 
            // label3
            // 
            label3.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label3.Location = new Point(39, 98);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 15;
            label3.Text = "날짜";
            // 
            // label4
            // 
            label4.Font = new Font("한컴 고딕", 12F, FontStyle.Bold);
            label4.Location = new Point(364, 101);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 16;
            label4.Text = "-";
            // 
            // label5
            // 
            label5.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label5.Location = new Point(39, 140);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 17;
            label5.Text = "인원";
            // 
            // label8
            // 
            label8.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label8.Location = new Point(219, 270);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 18;
            label8.Text = "아이디";
            // 
            // label9
            // 
            label9.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label9.Location = new Point(39, 183);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 19;
            label9.Text = "성인";
            // 
            // label10
            // 
            label10.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label10.Location = new Point(291, 179);
            label10.Name = "label10";
            label10.Size = new Size(100, 23);
            label10.TabIndex = 20;
            label10.Text = "소아";
            // 
            // label11
            // 
            label11.Font = new Font("한컴 고딕", 14.25F, FontStyle.Bold);
            label11.Location = new Point(516, 179);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 21;
            label11.Text = "유아";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("한컴 고딕", 15.75F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(759, 13);
            label6.Name = "label6";
            label6.Size = new Size(198, 27);
            label6.TabIndex = 23;
            label6.Text = "Train Management";
            label6.Visible = false;
            label6.Click += labelTrain_Management_Click;
            // 
            // MainScreen
            // 
            BackColor = Color.FromArgb(0, 37, 84);
            ClientSize = new Size(974, 614);
            Controls.Add(label6);
            Controls.Add(labelUserInfo);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox2);
            Controls.Add(labelSignUp);
            Controls.Add(labelLogin);
            Controls.Add(pictureBox1);
            Name = "MainScreen";
            Text = "    ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private PictureBox pictureBox1, pictureBox2;
        private GroupBox groupBox1;
        private RadioButton radioRoundTrip, radioOneWay;
        private ComboBox comboFrom, comboTo, comboAdult, comboChild, comboInfant;
        private DateTimePicker dateStart, dateReturn;
        private Button btnSearchFlights, btnSearchID;
        private TextBox txtSearchID;
        private Label label1, label2, label3, label4, label5, label8, label9, label10, label11, labelArrow;
        private Label labelLogin, labelSignUp, labelUserInfo;
        private Label label6;
    }
}