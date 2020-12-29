using System;
using System.Windows.Forms;
using SRLink.Helper;
using SRLink.Service;

namespace SRLink.From
{
    public partial class SubFrmSLink : BaseForm
    {
        private int _count;

        public SubFrmSLink()
        {
            InitializeComponent();
        }

        #region 函数

        void ReFreshUi()
        {
            // 学生配置
            //// 自动连接
            CHK_AutoLink.Checked = Config.StudentNet.AutoLink;
            DTP_StartTime.Value = Config.StudentNet.StartTime;
            //// 校园网认证
            CHK_EnableCertify.Checked = Config.StudentNet.SettingCertify.Enable;
            UInput_CertifyId.Content = Config.StudentNet.SettingCertify.UserId;
            UInput_CertifyPassword.Content = StringHelper.Base64Decode(Config.StudentNet.SettingCertify.Password);
            //// 网络连接
            CHK_EnableLink.Checked = Config.StudentNet.SettingLink.Enable;
            UInput_LinkServer.Content = Config.StudentNet.SettingLink.ServerIp;
            UInput_LinkUserName.Content = Config.StudentNet.SettingLink.UserId;
            UInput_LinkPassword.Content = StringHelper.Base64Decode(Config.StudentNet.SettingLink.Password);
            //// 发送IP地址
            CHK_EnableMail.Checked = Config.StudentNet.SettingMail.Enable;
            UInput_MailAddress.Content = Config.StudentNet.SettingMail.Address;
            // 教师配置
            //// 校园网认证
            UInput_Teacher_CertifyId.Content = Config.TeacherNet.SettingCertify.UserId;
            UInput_Teacher_CertifyPassword.Content = StringHelper.Base64Decode(Config.TeacherNet.SettingCertify.Password);
            // 显示连接类型
            switch (Config.NetType)
            {
                case 0:
                    RBT_Student.Checked = true;
                    break;
                case 1:
                    RBT_Teacher.Checked = true;
                    break;
            }
        }

        #endregion
        private void SubFrmSLink_Load(object sender, EventArgs e)
        {
            // 初始化UI
            PNL_Certify.Visible = false;
            PNL_Link.Visible = false;
            PNL_Mail.Visible = false;
            ReFreshUi();
        }

        private void DTP_StartTime_ValueChanged(object sender, EventArgs e)
        {
            Config.StudentNet.StartTime = DTP_StartTime.Value;
        }

        private void CHK_AutoLink_CheckedChanged(object sender, EventArgs e)
        {
            DTP_StartTime.Enabled = CHK_AutoLink.Checked;
            Config.StudentNet.AutoLink = CHK_AutoLink.Checked;
            LBL_Tip_AutoLink.Visible = CHK_AutoLink.Checked;
            ConfigService.SaveConfig(ref Config);
        }

        private void CHK_EnableCertify_CheckedChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingCertify.Enable = CHK_EnableCertify.Checked;
            LBL_Tip_Certify.Visible = CHK_EnableCertify.Checked;
            PNL_Certify.Visible = CHK_EnableCertify.Checked;
            ConfigService.SaveConfig(ref Config);
        }

        private void UInput_CertifyId_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingCertify.UserId = UInput_CertifyId.Content;
        }

        private void UInput_CertifyPassword_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingCertify.Password = StringHelper.Base64Encode(UInput_CertifyPassword.Content);
        }

        private void CHK_EnableLink_CheckedChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingLink.Enable = CHK_EnableLink.Checked;
            LBL_Tip_Link.Visible = CHK_EnableLink.Checked;
            PNL_Link.Visible = CHK_EnableLink.Checked;
            ConfigService.SaveConfig(ref Config);
        }

        private void UInput_LinkServer_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingLink.ServerIp = UInput_LinkServer.Content;
        }

        private void BTN_SetDefault_Click(object sender, EventArgs e)
        {
            UInput_LinkServer.Content = StringHelper.GetAppString("IpServerDefault");
        }

        private void UInput_LinkUserName_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingLink.UserId = UInput_LinkUserName.Content;
        }

        private void UInput_LinkPassword_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingLink.Password = StringHelper.Base64Encode(UInput_LinkPassword.Content);
        }

        private void CHK_EnableMail_CheckedChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingMail.Enable = CHK_EnableMail.Checked;
            PNL_Mail.Visible = CHK_EnableMail.Checked;
            ConfigService.SaveConfig(ref Config);
        }

        private void UInput_MailAddress_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.StudentNet.SettingMail.Address = UInput_MailAddress.Content;
        }

        private void BTN_TestMail_Click(object sender, EventArgs e)
        {
            //TODO: (功能还不可用)注入SrLinkService
            BTN_TestMail.Enabled = false;
            BTN_TestMail.Text = "15s";
            _count = 15;
            //.TestMail(UInput_MailAddress.Content);
            TMR_ReSent.Enabled = true;
        }
        private void TMR_ReSent_Tick(object sender, EventArgs e)
        {
            if (_count == 1)
            {
                BTN_TestMail.Enabled = true;
                TMR_ReSent.Enabled = false;
                BTN_TestMail.Text = "发送";
            }
            else
            {
                _count--;
                BTN_TestMail.Text = _count.ToString() + "s";
            }
        }

        private async void RBT_Student_CheckedChangedAsync(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                // 保存配置
                Config.NetType = 0;
                // 判断切换是否合法
                PNL_Student.Visible = RBT_Student.Checked;
                PNL_Teacher.Visible = RBT_Teacher.Checked;
                if (Config.StudentNet.SettingCertify.Enable == false ||
                    string.IsNullOrEmpty(Config.StudentNet.SettingCertify.UserId) ||
                    string.IsNullOrEmpty(Config.StudentNet.SettingCertify.Password))
                {
                    var f = new FrmCertify();
                    if (f.ShowDialog() != DialogResult.Yes)
                    {
                        RBT_Teacher.Checked = true;
                        Config.NetType = 1;
                    }
                }
                else
                {
                    await SrLinkService.RegisterSchoolNetAsync(Config.StudentNet.SettingCertify.UserId,
                        Config.StudentNet.SettingCertify.Password, 1);
                }

                ConfigService.SaveConfig(ref Config);
                ReFreshUi();
            }
        }

        private void RBT_Teacher_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                // 保存配置
                Config.NetType = 1;
                // 判断切换是否合法
                PNL_Student.Visible = RBT_Student.Checked;
                PNL_Teacher.Visible = RBT_Teacher.Checked;
                // TODO: 由于断网，下面的代码没有经过测试
                if (VpnService.Worked())
                {
                    if (MessageBox.Show("警告：如果切换网络类型，会断开当前网络。是否切换？", "当前网络正在使用", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        VpnService.Abort();
                    }
                    else
                    {
                        RBT_Student.Checked = true;
                        Config.NetType = 0;
                    }
                }
                ConfigService.SaveConfig(ref Config);
                ReFreshUi();
            }
        }

        private void BTN_Certify_Click(object sender, EventArgs e)
        {
            var id = UInput_CertifyId.Content;
            var pwd = UInput_CertifyPassword.Content;
            if (SrLinkService.RegisterSchoolNet(id, StringHelper.Base64Encode(pwd)))
            {
                MessageBox.Show(id + "登录成功", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConfigService.SaveConfig(ref Config);
            }
            else
            {
                MessageBox.Show("用户名/密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UInput_Teacher_CertifyId_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.TeacherNet.SettingCertify.UserId = UInput_Teacher_CertifyId.Content;
        }

        private void UInput_Teacher_CertifyPassword_UcContentTextChanged(object sender, EventArgs e)
        {
            Config.TeacherNet.SettingCertify.Password = StringHelper.Base64Encode(UInput_Teacher_CertifyPassword.Content);
        }

        private void BTN_Teacher_Certify_Click(object sender, EventArgs e)
        {
            var id = UInput_Teacher_CertifyId.Content;
            var pwd = UInput_Teacher_CertifyPassword.Content;
            if (SrLinkService.RegisterSchoolNet(id, StringHelper.Base64Encode(pwd)))
            {
                MessageBox.Show(id + "登录成功", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConfigService.SaveConfig(ref Config);
            }
            else
            {
                MessageBox.Show("用户名/密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
