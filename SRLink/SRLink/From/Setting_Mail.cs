using SRLink.Handler;
using SRLink.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SRLink
{
    public partial class FRM_Config_Mail : Form
    {
        private readonly Setting_Mail config_Mail = null;
        private readonly ConfigHandler config = null;
        string code;
        int Count = 0;
        public FRM_Config_Mail()
        {
            InitializeComponent();
        }
        public FRM_Config_Mail(ConfigHandler c)
        {
            InitializeComponent();
            config = c;
            config_Mail = c.ReadConfig_Mail();
            this.CBX_Enable.Checked = (config_Mail.Enable == EEnable.True);
            if (config_Mail.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            this.TBX_Address.Text = config_Mail.Address;
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            if (this.TBX_Code.Text == code)
            {
                config_Mail.Status = EStatus.OK;
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            config_Mail.Enable = (this.CBX_Enable.Checked ? EEnable.True : EEnable.False);
            config_Mail.Address = this.TBX_Address.Text.Trim();
            config.SaveConfig(config_Mail);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Sent_Click(object sender, EventArgs e)
        {
            this.LBL_Status.Text = "待验证";
            this.LBL_Status.ForeColor = Color.DimGray;
            this.TMR_ReSent.Enabled = true;
            Count = 15;
            this.BTN_Sent.Enabled = false;
            this.BTN_Sent.Text = "15s";            
            code = MailHandler.TestMail(this.TBX_Address.Text);
        }

        private void TMR_ReSent_Tick(object sender, EventArgs e)
        {
            if (this.Count == 1)
            {
                this.BTN_Sent.Enabled = true;
                this.TMR_ReSent.Enabled = false;
                this.BTN_Sent.Text = "发送";
            }
            else
            {
                this.Count--;
                this.BTN_Sent.Text = this.Count.ToString() + "s";
            }
        }
    }
}
