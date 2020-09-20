using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Service.Impl;

namespace SRLink.From
{
    public partial class SubFrmSLink : BaseForm
    {
        private int Count = 0;
        public static FrmLinkInfo FrmLinkInfo;
        public SrLinkService SrLinkService;

        public SubFrmSLink(FrmLinkInfo frmLinkInfo)
        {
            FrmLinkInfo = frmLinkInfo;
            InitializeComponent();
        }
        private void SubFrmSLink_Load(object sender, EventArgs e)
        {
            //if (!Config.HasConfig) return;
            CHK_ShowLinkInfo.Checked = Config.ShowLinkInfo;

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
            Config.AutoLink = CHK_AutoLink.Checked;
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
        private void CHK_ShowLinkInfo_CheckedChanged(object sender, EventArgs e)
        {
            Config.ShowLinkInfo = CHK_ShowLinkInfo.Checked;
        }

        private void BTN_OpenInfoForm_Click(object sender, EventArgs e)
        {
            FrmLinkInfo.Show();
        }

        private void CHK_EnableCertify_CheckedChanged(object sender, EventArgs e)
        {
            Config.SettingCertify.Enable = CHK_EnableCertify.Checked;
        }

        private void UInput_CertifyId_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.SettingCertify.StudentId = UInput_CertifyId.Content;
        }

        private void UInput_CertifyPassword_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.SettingCertify.Password = UInput_CertifyPassword.Content;
        }

        private void CHK_EnableLink_CheckedChanged(object sender, EventArgs e)
        {
            Config.SettingLink.Enable = CHK_EnableLink.Checked;
        }

        private void UInput_LinkServer_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.SettingLink.IpServer = UInput_LinkServer.Content;
        }

        private void BTN_SetDefault_Click(object sender, EventArgs e)
        {
            UInput_LinkServer.Content = Global.IPServerDefault;
        }

        private void UInput_LinkUserName_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.SettingLink.UserName = UInput_LinkUserName.Content;
        }

        private void UInput_LinkPassword_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.SettingLink.Password = UInput_LinkPassword.Content;
        }

        private void CHK_EnableMail_CheckedChanged(object sender, EventArgs e)
        {
            Config.SettingMail.Enable = CHK_EnableMail.Checked;
        }

        private void UInput_MailAddress_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.SettingMail.Address = UInput_MailAddress.Content;
        }

        private void BTN_TestMail_Click(object sender, EventArgs e)
        {
            //TODO: 注入SrLinkService
            BTN_TestMail.Enabled = false;
            BTN_TestMail.Text = "15s";
            Count = 15;
            //.TestMail(UInput_MailAddress.Content);
            TMR_ReSent.Enabled = true;
        }

    }
}
