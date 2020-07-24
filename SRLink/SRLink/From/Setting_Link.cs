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
        private readonly Setting_Link setting = null;
        private readonly ConfigHandler config = null;
        public FRM_Config_Link()
        {
            InitializeComponent();
        }
        public FRM_Config_Link(ConfigHandler c)
        {
            InitializeComponent();
            config = c;
            setting = c.ReadConfig_Link();
            this.CBX_Enable.Checked = (setting.Enable == EEnable.True);
            this.TBX_Path.Text = setting.Path;
            this.DDL_Way.SelectedIndex = setting.Way - 1;
        }

        private void BTN_ChoosePath_Click(object sender, EventArgs e)
        {
            this.OFD_Path.InitialDirectory = this.TBX_Path.Text;
            this.OFD_Path.ShowDialog();
            this.TBX_Path.Text = this.OFD_Path.FileName;
            setting.Path = this.OFD_Path.FileName;
        }

        private void DDL_Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Way.SelectedIndex == 1)
            {
                this.PNL_Position.Enabled = true;
                this.TBX_X.Text = setting.X.ToString();
                this.TBX_Y.Text = setting.Y.ToString();
            }
            else
            {
                this.PNL_Position.Enabled = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            setting.Enable = (this.CBX_Enable.Checked ? EEnable.True : EEnable.False);
            setting.Way = this.DDL_Way.SelectedIndex + 1;
            setting.X = int.Parse(this.TBX_X.Text.Trim());
            setting.Y = int.Parse(this.TBX_Y.Text.Trim());
            config.SaveConfig(setting);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            LinkHandler test_handler = new LinkHandler(setting);
            if (test_handler.OpenSuiEXing())
            {
                test_handler.TryClick(int.Parse(this.TBX_X.Text.Trim()), int.Parse(this.TBX_Y.Text.Trim()));
                test_handler.IsConnectInternet();
            }
        }
    }
}
