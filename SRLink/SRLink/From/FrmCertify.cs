using System;
using System.Text;
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
            var param = string.Format(StringHelper.GetAppString("CertifyUrlParam"), id, StringHelper.Base64Encode(pwd));
            var res = WebHelper.PostWebRequest(StringHelper.GetAppString("CertifyUrl"), param, Encoding.UTF8);
            Console.WriteLine(id + " : " + res);
            if (res.Split(',')[0] == "login_ok")
            {
                MessageBox.Show(id + " : " + res, "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Config.StudentNet.SettingCertify.Enable = true;
                Config.StudentNet.SettingCertify.UserId = UInput_CertifyId.Content;
                Config.StudentNet.SettingCertify.Password = UInput_CertifyPassword.Content;
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
