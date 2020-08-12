using SRLink.Handler;
using SRLink.Model;
using System;
using System.Windows.Forms;

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
            SettingLink = Config.SettingLink;
            CBX_Enable.Checked = (SettingLink.Enable == EEnable.True);
            TBX_Path.Text = SettingLink.Path;
            DDL_Way.SelectedIndex = SettingLink.Way - 1;
        }

        private void BTN_ChoosePath_Click(object sender, EventArgs e)
        {
            OFD_Path.InitialDirectory = TBX_Path.Text;
            OFD_Path.ShowDialog();
            TBX_Path.Text = OFD_Path.FileName;
            SettingLink.Path = OFD_Path.FileName;
        }

        private void DDL_Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_Way.SelectedIndex == 1)
            {
                PNL_Position.Enabled = true;
                TBX_X.Text = SettingLink.X.ToString();
                TBX_Y.Text = SettingLink.Y.ToString();
            }
            else
            {
                PNL_Position.Enabled = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            SettingLink.Enable = (CBX_Enable.Checked ? EEnable.True : EEnable.False);
            SettingLink.Way = DDL_Way.SelectedIndex + 1;
            SettingLink.X = int.Parse(TBX_X.Text.Trim());
            SettingLink.Y = int.Parse(TBX_Y.Text.Trim());
            Config.SettingLink = SettingLink;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            //LinkHandler test_handler = new LinkHandler(SettingLink);
            //if (test_handler.OpenSuiEXing())
            //{
            //    test_handler.TryClick(int.Parse(TBX_X.Text.Trim()), int.Parse(TBX_Y.Text.Trim()));
            //    test_handler.IsConnectInternet();
            //}
        }
    }
}
