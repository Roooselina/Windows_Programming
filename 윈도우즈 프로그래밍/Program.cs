using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SampleWinFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // 기본적인 윈도우폼 환경 설정
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // MainForm 실행
            Application.Run(new MainForm());
        }
    }
}
