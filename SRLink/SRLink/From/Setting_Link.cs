using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink
{
    public partial class FRM_Config_Link : Form
    {
        private readonly Setting_Link Setting_Link = null;
        private readonly ConfigHandler Config = null;
        public FRM_Config_Link()
        {
            InitializeComponent();
        }
        public FRM_Config_Link(ConfigHandler config)
        {
            InitializeComponent();
            Config = config;
            this.Setting_Link = config.Setting_Link;
            this.CBX_Enable.Checked = (this.Setting_Link.Enable == EEnable.True);
            this.TBX_Path.Text = this.Setting_Link.Path;
            this.DDL_Way.SelectedIndex = this.Setting_Link.Way - 1;
        }

        private void BTN_ChoosePath_Click(object sender, EventArgs e)
        {
            this.OFD_Path.InitialDirectory = this.TBX_Path.Text;
            this.OFD_Path.ShowDialog();
            this.TBX_Path.Text = this.OFD_Path.FileName;
            this.Setting_Link.Path = this.OFD_Path.FileName;
        }

        private void DDL_Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Way.SelectedIndex == 1)
            {
                this.PNL_Position.Enabled = true;
                this.TBX_X.Text = this.Setting_Link.X.ToString();
                this.TBX_Y.Text = this.Setting_Link.Y.ToString();
            }
            else
            {
                this.PNL_Position.Enabled = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            this.Setting_Link.Enable = (this.CBX_Enable.Checked ? EEnable.True : EEnable.False);
            this.Setting_Link.Way = this.DDL_Way.SelectedIndex + 1;
            this.Setting_Link.X = int.Parse(this.TBX_X.Text.Trim());
            this.Setting_Link.Y = int.Parse(this.TBX_Y.Text.Trim());
            Config.Setting_Link = this.Setting_Link;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            LinkHandler test_handler = new LinkHandler(this.Setting_Link);
            if (test_handler.OpenSuiEXing())
            {
                test_handler.TryClick(int.Parse(this.TBX_X.Text.Trim()), int.Parse(this.TBX_Y.Text.Trim()));
                test_handler.IsConnectInternet();
            }
        }
    }
}
