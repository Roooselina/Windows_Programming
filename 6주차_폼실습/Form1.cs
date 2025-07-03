using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace _6주차_폼실습
{
    public partial class Form1 : Form
    {
        Button button = new Button();
        public Form1()
        {

            InitializeComponent();
            button.Controls.Add(button);
            button += saveFileDialog1_FileOk();
            Controls.Add(this); // 자식 객체인 buttonA가 여기에서 사용 가능함
        }

        class custom : Form
        {
            public custom()
            {
                Text = "new Text Type";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void custom_Loada(object sender, EventArgs e)
        {
            custom form = new custom();
            form.Show();    //모덜리스(Modeless); 내가 떠 있음에도 다른 창에 포커스 전이 가능

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
