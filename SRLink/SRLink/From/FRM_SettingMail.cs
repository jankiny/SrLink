using SRLink.Handler;
using SRLink.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SRLink.From
{
    public partial class FRM_SettingMail : BaseForm
    {
        private readonly SettingMail SettingMail = null;
        string code;
        int Count = 0;
        public FRM_SettingMail()
        {
            InitializeComponent();
        }
        public FRM_SettingMail(Config config)
        {
            InitializeComponent();
            Config = config;
            this.SettingMail = Config.SettingMail;
            this.CBX_Enable.Checked = (this.SettingMail.Enable == EEnable.True);
            if (this.SettingMail.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            this.TBX_Address.Text = this.SettingMail.Address;
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            if (this.TBX_Code.Text == code)
            {
                this.SettingMail.Status = EStatus.OK;
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            this.SettingMail.Enable = (this.CBX_Enable.Checked ? EEnable.True : EEnable.False);
            this.SettingMail.Address = this.TBX_Address.Text.Trim();
            Config.SettingMail = this.SettingMail;
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
