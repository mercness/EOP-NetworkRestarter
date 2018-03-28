using System;
using System.Linq;
using System.Windows.Forms;

namespace EOP_NetworkReset
{
    public partial class FrmWarningsLog : Form
    {
        public FrmWarningsLog()
        {
            InitializeComponent();
        }

        private void FrmWarningsLog_Load(object sender, EventArgs e)
        {
            ListBoxWarnings.DataSource = FrmMain.StaticValues.Warnings.ToList();
        }

        public static DateTime get_UTCNow()
        {
            DateTime UTCNow = DateTime.UtcNow;
            int year = UTCNow.Year;
            int month = UTCNow.Month;
            int day = UTCNow.Day;
            int hour = UTCNow.Hour;
            int min = UTCNow.Minute;
            int sec = UTCNow.Second;
            DateTime datetime = new DateTime(year, month, day, hour, min, sec);
            return datetime;
        }

        private void ButtonSaveToFile_Click(object sender, EventArgs e)
        {
            DateTime datetime = get_UTCNow();
            string sPath = "PingLog" + DateTime.Now.ToString("yyyyMMddhhmmssss") + ".txt";

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
                foreach (var item in ListBoxWarnings.Items)
                {
                    SaveFile.WriteLine(item);
                }

                SaveFile.Close();

                MessageBox.Show("Programs saved!");
        }
    }
}
