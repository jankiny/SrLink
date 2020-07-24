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
        private readonly Setting_Link config_Link = null;
        private readonly ConfigHandler config = null;
        public FRM_Config_Link()
        {
            InitializeComponent();
        }
        public FRM_Config_Link(ConfigHandler c)
        {
            InitializeComponent();
            config = c;
            config_Link = c.ReadConfig_Link();
            this.CBX_Enable.Checked = (config_Link.Enable == 1);
            this.TBX_Path.Text = config_Link.Path;
            this.DDL_Way.SelectedIndex = config_Link.Way - 1;
        }

        private void BTN_ChoosePath_Click(object sender, EventArgs e)
        {
            this.OFD_Path.InitialDirectory = this.TBX_Path.Text;
            this.OFD_Path.ShowDialog();
            this.TBX_Path.Text = this.OFD_Path.FileName;
            config_Link.Path = this.OFD_Path.FileName;
        }

        private void DDL_Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Way.SelectedIndex == 1)
            {
                this.PNL_Position.Enabled = true;
                this.TBX_X.Text = config_Link.X.ToString();
                this.TBX_Y.Text = config_Link.Y.ToString();
            }
            else
            {
                this.PNL_Position.Enabled = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            config_Link.Enable = (this.CBX_Enable.Checked ? 1 : 0);
            config_Link.Way = this.DDL_Way.SelectedIndex + 1;
            config_Link.X = int.Parse(this.TBX_X.Text.Trim());
            config_Link.Y = int.Parse(this.TBX_Y.Text.Trim());
            config.SaveConfig(config_Link);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            if (LinkHandler.OpenSuiEXing(config_Link.Path))
            {
                LinkHandler.TryClick(int.Parse(this.TBX_X.Text.Trim()), int.Parse(this.TBX_Y.Text.Trim()));
                LinkHandler.IsConnectInternet();
            }
        }
    }
}
