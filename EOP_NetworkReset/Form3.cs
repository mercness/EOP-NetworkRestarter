using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EOP_NetworkReset
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            TextWarningLowerLimitMs.Text = Convert.ToString(Convert.ToInt32(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\NetworkReset", "WarningLowerLimitMs", "50")));
            PollingTimeMs.Text = Convert.ToString(Convert.ToInt32(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\NetworkReset", "PollingTimeMs", "1000")));
        }

        private void ButtonSettingsSave_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\NetworkReset", "PollingTimeMs", PollingTimeMs.Text.ToString());
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\NetworkReset", "WarningLowerLimitMs", TextWarningLowerLimitMs.Text.ToString());

            Close();
        }
    }
}
