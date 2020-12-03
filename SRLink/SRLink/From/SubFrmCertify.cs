using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Helper;

namespace SRLink.From
{
    public partial class SubFrmCertify : Form
    {
        public SubFrmCertify()
        {
            InitializeComponent();
        }

        private void BTN_Certify_Click(object sender, EventArgs e)
        {
            var id = UInput_CertifyId.Content;
            var pwd = UInput_CertifyPassword.Content;
            var param = string.Format(SRLink.Global.Certify_UrlParam, id, StringHelper.Base64Encode(pwd));
            var res = WebHelper.PostWebRequest(Global.Certify_Url, param, Encoding.UTF8);
            Console.WriteLine(id + " : " + res);
            if (res.Split(',')[0] == "login_ok")
            {
                MessageBox.Show(id + " : " + res, "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("用户名/密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
