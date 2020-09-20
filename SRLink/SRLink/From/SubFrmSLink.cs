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

namespace SRLink.From
{
    public partial class SubFrmSLink : BaseForm
    {
        private int Count = 0;

        public SubFrmSLink()
        {
            InitializeComponent();
        }
        private void SubFrmSLink_Load(object sender, EventArgs e)
        {
            if (!Config.HasConfig) return;
            CHK_AutoLink.Checked = Config.AutoLink;
            DTP_StartTime.Value = Config.StartTime;

            CHK_EnableCertify.Checked = Config.SettingCertify.Enable;
            UInput_CertifyId.Content = Config.SettingCertify.StudentId;
            UInput_CertifyPassword.Content = Config.SettingCertify.Password;

            CHK_EnableLink.Checked = Config.SettingLink.Enable;
            UInput_LinkServer.Content = Config.SettingLink.IpServer;
            UInput_LinkUserName.Content = Config.SettingLink.UserName;
            UInput_LinkPassword.Content = Config.SettingLink.Password;

            CHK_EnableMail.Checked = Config.SettingMail.Enable;
            UInput_MailAddress.Content = Config.SettingMail.Address;
        }

        private void CHK_AutoLink_CheckedChanged(object sender, EventArgs e)
        {
            DTP_StartTime.Enabled = CHK_AutoLink.Checked;
        }

        private void BTN_SetDefault_Click(object sender, EventArgs e)
        {
            UInput_LinkServer.Content = Global.IPServerDefault;
        }

        private void BTN_TestMail_Click(object sender, EventArgs e)
        {
            BTN_TestMail.Enabled = false;
            BTN_TestMail.Text = "15s";
            Count = 15;
            MailHandler.TestMail(UInput_MailAddress.Content);
            TMR_ReSent.Enabled = true;
        }

        private void TMR_ReSent_Tick(object sender, EventArgs e)
        {
            if (Count == 1)
            {
                BTN_TestMail.Enabled = true;
                TMR_ReSent.Enabled = false;
                BTN_TestMail.Text = "发送";
            }
            else
            {
                Count--;
                BTN_TestMail.Text = Count.ToString() + "s";
            }
        }

        private void BTN_OpenInfoForm_Click(object sender, EventArgs e)
        {
            FrmLinkInfo.Show();
        }
    }
}
