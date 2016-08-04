using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stocker
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void BtnAddSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void BtnCloseSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBTemplateSettings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
