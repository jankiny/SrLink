using System;
using System.Windows.Forms;
using SRLink.Helper;
using SRLink.Service;

namespace SRLink.From
{
    public partial class FrmCertify : BaseForm
    {
        public FrmCertify()
        {
            InitializeComponent();
        }

        private void BTN_Certify_Click(object sender, EventArgs e)
        {
            var id = UInput_CertifyId.Content;
            var pwd = UInput_CertifyPassword.Content;

            if (SrLinkService.RegisterSchoolNet(id, StringHelper.Base64Encode(pwd)))
            {
                MessageBox.Show(id + "登录成功", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Config.StudentNet.SettingCertify.Enable = true;
                Config.StudentNet.SettingCertify.UserId = UInput_CertifyId.Content;
                Config.StudentNet.SettingCertify.Password = StringHelper.Base64Encode(UInput_CertifyPassword.Content);
                ConfigService.SaveConfig(ref Config);
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                MessageBox.Show("用户名/密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCertify_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
