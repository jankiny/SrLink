using System.Text;
using System.Threading;
using Kit.Utils;
using SRLink.Model;

namespace SRLink.Service.Impl
{
    public class SrLinkService :  ISrLinkService
    {
        private readonly Config Config;
        private VpnService VpnService;
        public SrLinkService(Config config)
        {
            Config = config;
        }
        public bool RegisterSchoolNet(out string msg)
        {
            if (Config.SettingCertify.Enable == false ||
                string.IsNullOrEmpty(Config.SettingCertify.StudentId) ||
                string.IsNullOrEmpty(Config.SettingCertify.Password))
            {
                msg = "校园认证配置出错";
                return false;
            }
            string param = string.Format(
                Global.Certify_UrlParam,
                Config.SettingCertify.StudentId, 
                Encrypt.Base64Encode(Config.SettingCertify.Password));

            string res = Web.PostWebRequest(Global.Certify_Url, param, 107, Encoding.UTF8);
            if (res.Split(',')[0] == "login_ok")
            {
                msg = "认证成功";
                return true;
            }

            if (res == "操作超时")
            {
                // "请求无响应，可能的原因：1、已经完成认证，并连接了随e行；2、不在校园内网中。"
                msg = "请求无响应";
                return false;
            }
            else
            {
                msg = "请检查网线是否接好";
                return false;
            }
        }

        public bool IsConnectInternet()
        {
            return Web.IsConnectInternet(Global.TestConnectionUrl);
        }

        public bool LinkVpn(out string msg)
        {
            if (Config.SettingLink.Enable == false ||
                string.IsNullOrEmpty(Config.SettingLink.IpServer) ||
                string.IsNullOrEmpty(Config.SettingLink.UserName) ||
            string.IsNullOrEmpty(Config.SettingLink.Password))
            {
                msg = "网络连接配置出错";
                return false;
            }
            VpnService = new VpnService(
                Config.SettingLink.IpServer,
                Global.AdapterName,
                Config.SettingLink.UserName,
                Config.SettingLink.Password,
                "L2TP");
            VpnService.Connect();
            Thread.Sleep(5000);
            if (IsConnectInternet())
            {
                msg = "连接L2TP网络成功";
                return true;
            }
            else
            {
                msg = "连接失败";
                return false;
            }
        }

        public void DisconnectVpn()
        {
            VpnService?.Disconnect();
        }

        public bool SendIp(out string msg)
        {
            if (Config.SettingMail.Enable == false ||
                string.IsNullOrEmpty(Config.SettingMail.Address))
            {
                msg = "邮箱配置出错";
                return false;
            }
            if (!Web.SendMail(Global.Mail_User, Global.Mail_AuthorizationCode, Global.Mail_Host,
                Config.SettingMail.Address, "IP地址", Cmd.ExecuteCommand("ipconfig")))
            {
                msg = "等待超时";
                return false;
            }
            msg = "发送成功";
            return true;
        }

        public string TestMail(string address)
        {
            string code = MathHelper.GenerateRandomString(6);
            Web.SendMail(Global.Mail_User, Global.Mail_AuthorizationCode, Global.Mail_Host,
                address, "验证邮箱", "请将收到的验证码填入AutoLink中，验证码：\n" + code);
            return code;
        }
        ~SrLinkService()
        {
            VpnService?.Disconnect();
        }
    }
}