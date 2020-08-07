using Kit.Utils;
using SRLink.Model;
using System.Text;
using System.Windows.Forms;

namespace SRLink.Handler
{
    public class CertifyHandler : HandlerBase
    {
        private readonly SettingCertify Setting;

        public CertifyHandler(SettingCertify setting_Certify, int count = 60, int delay = 3000, EHandler mode = EHandler.Test)
        {
            ID = 1;
            HandleName = "认证";
            Setting = setting_Certify;
            Count = count;
            Delay = delay;
            Mode = mode;
        }

        public bool RegisterSchoolNet(out string msg)
        {
            if (!Ready())
            {
                msg = "配置出错";
                return false;
            }
            string param = string.Format(Global.Certify_UrlParam,
                Setting.StudentID, Encrypt.Base64Encode(Setting.Password));

            string res = Web.PostWebRequest(Global.Certify_Url, param, 107, Encoding.UTF8);

            if (res == "操作超时")
            {
                // "请求无响应，可能的原因：1、已经完成认证，并连接了随e行；2、不在校园内网中。"
                msg = "请求无响应";
                return false;
            }
            else if (res.Split(',')[0] == "login_ok")
            {
                msg = "认证成功";
                return true;
            }
            else
            {
                msg = "请检查网线是否接好";
                return false;
            }
        }
        public override void RegisteUI(PictureBox picture)
        {
            base.RegisteUI(picture);
        }
        public override bool Run(out string msg)
        {
            return RegisterSchoolNet(out msg);
        }
        public override bool Ready()
        {
            if (Mode == EHandler.Work && Setting.GetConfigReady())
            {
                return true;
            }
            else if (Mode == EHandler.Test)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
