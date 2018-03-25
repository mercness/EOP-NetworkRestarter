using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

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
                textBox1.Enabled = false;
                toolStripStatusLabel1.Text = "Error Count: 0";
            }


        private void button1_Click(object sender, EventArgs e)
        {
            int error_count;
            error_count = 0;
            toolStripStatusLabel1.Text = "Error Count: "+error_count.ToString();

                try
                    {
                        Ping p = new Ping();
                        PingReply r;
                        string s;

                        s = textBox1.Text;
                        r = p.Send(s);
                        label1.Text = "Ping to " + s.ToString() + "[" + r.Address.ToString() + "]" + " Successful"
                                         + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";
                    }
                catch (PingException)
                    {

                        // increase error count by 1, update the count on screen, show  message, stop the timer
                        error_count = error_count + 1;
                        timer1.Enabled = false;
                        checkBox1.Checked = false;
                        toolStripStatusLabel1.Text = "Error Count: " + error_count.ToString();
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
                timer1.Enabled = true;
            }

            if (checkBox1.Checked == false)
            {
                textBox1.Enabled = true;
                textBox1.Update();
                timer1.Enabled = false;
            }
        }
    }

}
