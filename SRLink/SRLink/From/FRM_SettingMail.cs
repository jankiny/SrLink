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
        private string code;
        private int Count = 0;
        public FRM_SettingMail()
        {
            InitializeComponent();
        }
        public FRM_SettingMail(Config config)
        {
            InitializeComponent();
            Config = config;
            SettingMail = Config.SettingMail;
            CBX_Enable.Checked = (SettingMail.Enable == EEnable.True);
            if (SettingMail.Status == EStatus.Normal)
            {
                LBL_Status.Text = "待验证";
                LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                LBL_Status.Text = "验证成功";
                LBL_Status.ForeColor = Color.LimeGreen;
            }
            TBX_Address.Text = SettingMail.Address;
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            if (TBX_Code.Text == code)
            {
                SettingMail.Status = EStatus.OK;
                LBL_Status.Text = "验证成功";
                LBL_Status.ForeColor = Color.LimeGreen;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            SettingMail.Enable = (CBX_Enable.Checked ? EEnable.True : EEnable.False);
            SettingMail.Address = TBX_Address.Text.Trim();
            Config.SettingMail = SettingMail;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BTN_Sent_Click(object sender, EventArgs e)
        {
            LBL_Status.Text = "待验证";
            LBL_Status.ForeColor = Color.DimGray;
            BTN_Sent.Enabled = false;
            BTN_Sent.Text = "15s";
            Count = 15;
            code = MailHandler.TestMail(TBX_Address.Text);
            TMR_ReSent.Enabled = true;
        }

        private void TMR_ReSent_Tick(object sender, EventArgs e)
        {
            if (Count == 1)
            {
                BTN_Sent.Enabled = true;
                TMR_ReSent.Enabled = false;
                BTN_Sent.Text = "发送";
            }
            else
            {
                Count--;
                BTN_Sent.Text = Count.ToString() + "s";
            }
        }
    }
}
