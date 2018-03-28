using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
