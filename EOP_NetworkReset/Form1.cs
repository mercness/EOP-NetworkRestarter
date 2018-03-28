using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;

namespace EOP_NetworkReset
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();

        }

            private void FrmMain_Load(object sender, EventArgs e)
            {
                IPAddress gatewayip;

                gatewayip = GetDefaultGateway();
                textBox1.Text = gatewayip.ToString();
                StaticValues.Error_count = 0;
                StaticValues.Pingnumber = 0;
                StaticValues.WarningCount = 0;

                textBox1.Enabled = false;
                toolStripStatusLabel1.Text = "Error Count: 0";
                toolStripStatusLabel4.Text = "Warning Count: 0";
                toolStripStatusLabel5.Text = "Version: "+Application.ProductVersion.ToString();

                timer1.Interval = StaticValues.PollingTimeMs;

            List<string> list = new List<string>();
                        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                        foreach (NetworkInterface adapter in adapters)
                            {
                                if (adapter.Description != "Software Loopback Interface 1" & adapter.Description != "Teredo Tunneling Pseudo-Interface")
                                {
                                    list.Add(adapter.Description);
                                }
                                
                            }

            comboBox1.DataSource = list;
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "ms Response";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ping #";
        }

        public static class StaticValues
        {
            public static int Error_count { get; set; }
            public static int Pingnumber { get; set; }
            public static int WarningCount { get; set; }
            public static List<string> Warnings = new List<string>();

            public static int PollingTimeMs = Convert.ToInt32(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\NetworkReset", "PollingTimeMs", "1000"));
            public static int WarningLowerLimitMs = Convert.ToInt32(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\NetworkReset", "WarningLowerLimitMs", "50"));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "Error Count: "+StaticValues.Error_count.ToString();

            try
                    {
                        Ping p = new Ping();
                        PingReply r;
                        string s;

                        s = textBox1.Text;
                        r = p.Send(s);

                        label1.Text = "Ping to " + s.ToString() + " Successful"
                                        + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";
                        // trigger a warning
                        if (r.RoundtripTime > StaticValues.WarningLowerLimitMs)
                {
                    StaticValues.WarningCount = StaticValues.WarningCount + 1;
                    toolStripStatusLabel4.Text = "Warning Count: " + StaticValues.WarningCount;
                    StaticValues.Warnings.Add("Ping #: "+StaticValues.Pingnumber.ToString() +" - " + r.RoundtripTime.ToString()+ " ms");
                }

                // Add ping values to chart
                chart1.Series["Ping"].Points.AddXY(StaticValues.Pingnumber.ToString(), r.RoundtripTime.ToString());
                StaticValues.Pingnumber = StaticValues.Pingnumber + 1;

            }
                catch (PingException)
                    {

                // increase error count by 1, update the count on screen, show  message, stop the timer
                        StaticValues.Error_count = StaticValues.Error_count + 1;
                        timer1.Enabled = false;
                        checkBox1.Checked = false;
                        toolStripStatusLabel1.Text = "Error Count: " + StaticValues.Error_count.ToString();
                        DialogResult pingerror = MessageBox.Show("Should we restart NIC?","Unable to ping "+textBox1.Text, MessageBoxButtons.YesNo);

                            if (pingerror == DialogResult.Yes)
                                {
                                // Do something
                                MessageBox.Show("Okay restarting NIC");
                                }
                            else if (pingerror == DialogResult.No)
                                {
                                    MessageBox.Show("Okay I won't restart the NIC");
                                }
                    }
            }
            

        

        private void timer1_Tick(object sender, EventArgs e)
        {

                button1_Click(sender, e);

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = false;
                textBox1.Update();
                label1.Text = "Starting";
                timer1.Enabled = true;
            }

            if (checkBox1.Checked == false)
            {
                textBox1.Enabled = true;
                textBox1.Update();
                label1.Text = "Stopped";
                timer1.Enabled = false;
            }
        }

        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            FrmWarningsLog frmWarnings = new FrmWarningsLog();
            frmWarnings.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.Show();
        }
    }

}
