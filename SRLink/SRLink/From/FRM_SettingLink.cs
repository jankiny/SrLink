using System;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink.From
{
    public partial class FRM_SettingLink : BaseForm
    {
        private readonly SettingLink SettingLink = null;
        public FRM_SettingLink()
        {
            InitializeComponent();
        }
        public FRM_SettingLink(Config config)
        {
            InitializeComponent();
            Config = config;
            this.SettingLink = Config.SettingLink;
            this.CBX_Enable.Checked = (this.SettingLink.Enable == EEnable.True);
            this.TBX_Path.Text = this.SettingLink.Path;
            this.DDL_Way.SelectedIndex = this.SettingLink.Way - 1;
        }

        private void BTN_ChoosePath_Click(object sender, EventArgs e)
        {
            this.OFD_Path.InitialDirectory = this.TBX_Path.Text;
            this.OFD_Path.ShowDialog();
            this.TBX_Path.Text = this.OFD_Path.FileName;
            this.SettingLink.Path = this.OFD_Path.FileName;
        }

        private void DDL_Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Way.SelectedIndex == 1)
            {
                this.PNL_Position.Enabled = true;
                this.TBX_X.Text = this.SettingLink.X.ToString();
                this.TBX_Y.Text = this.SettingLink.Y.ToString();
            }
            else
            {
                this.PNL_Position.Enabled = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            this.SettingLink.Enable = (this.CBX_Enable.Checked ? EEnable.True : EEnable.False);
            this.SettingLink.Way = this.DDL_Way.SelectedIndex + 1;
            this.SettingLink.X = int.Parse(this.TBX_X.Text.Trim());
            this.SettingLink.Y = int.Parse(this.TBX_Y.Text.Trim());
            Config.SettingLink = this.SettingLink;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            LinkHandler test_handler = new LinkHandler(this.SettingLink);
            if (test_handler.OpenSuiEXing())
            {
                test_handler.TryClick(int.Parse(this.TBX_X.Text.Trim()), int.Parse(this.TBX_Y.Text.Trim()));
                test_handler.IsConnectInternet();
            }
        }
    }
}
