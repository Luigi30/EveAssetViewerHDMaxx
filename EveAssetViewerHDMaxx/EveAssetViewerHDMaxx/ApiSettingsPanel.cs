using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveAssetViewerHDMaxx
{
    public partial class ApiSettingsPanel : Form
    {
        public ApiSettingsPanel()
        {
            InitializeComponent();
            tbCharID.Text = Properties.Settings.Default.apiCharId;
            tbKeyID.Text = Properties.Settings.Default.apiKeyId;
            tbVcode.Text = Properties.Settings.Default.apiVcode;
        }

        private void btnSubmitApi_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.apiCharId = tbCharID.Text;
            Properties.Settings.Default.apiKeyId = tbKeyID.Text;
            Properties.Settings.Default.apiVcode = tbVcode.Text;
            this.Hide();
        }
    }
}
