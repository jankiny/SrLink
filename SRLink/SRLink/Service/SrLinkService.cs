using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SRLink.Helper;
using SRLink.Model;

namespace SRLink.Service
{
    public class SrLinkService
    {
        public static bool SettingEnable(ref ConfigModel config, string configName)
        {
            var res = false;
            switch (configName)
            {
                case "Certify":
                    res = config.StudentNet.SettingCertify.Enable;
                    break;
                case "Link":
                    res = config.StudentNet.SettingLink.Enable;
                    break;
                case "Mail":
                    res = config.StudentNet.SettingMail.Enable;
                    break;
            }

            return res;
        }

        public static async Task<bool> RegisterSchoolNetAsync(string userId, string decodePassword, int times = 30)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(decodePassword))
            {
                return false;
            }
            // 存在Config中的Config.SettingCertify.Password本来就是Base64编码
            string param = string.Format(StringHelper.GetAppString("CertifyUrlParam"), userId, decodePassword);

            do
            {
                string res = await Task.Run(() =>
                    WebHelper.PostWebRequest(StringHelper.GetAppString("CertifyUrl"), param, Encoding.UTF8));

                if (res.Split(',')[0] == "login_ok")
                {
                    return true;
                }
                Thread.Sleep(1000);
                times--;
            } while (times > 0);

            return false;
        }
        public static bool RegisterSchoolNet(string userId, string decodePassword)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(decodePassword))
            {
                return false;
            }
            // 存在Config中的Config.SettingCertify.Password本来就是Base64编码
            string param = string.Format(StringHelper.GetAppString("CertifyUrlParam"), userId, decodePassword);

            string res = WebHelper.PostWebRequest(StringHelper.GetAppString("CertifyUrl"), param, Encoding.UTF8);
            if (res.Split(',')[0] == "login_ok")
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> TestInternet(int times = 30)
        {
            do
            {
                var res = await Task.Run(() => WebHelper.IsConnectInternet(StringHelper.GetAppString("TestConnectionUrl")));
                if (res)
                {
                    return true;
                }
                times--;
            } while (times > 0);

            return false;
        }

        public static async Task<bool> LinkVpnAsync(string serverIp, string userId, string password, int times = 30)
        {
            if (string.IsNullOrEmpty(serverIp) ||
                string.IsNullOrEmpty(userId) ||
                string.IsNullOrEmpty(password))
            {
                return false;
            }
            var vpnModel = new VpnModel()
            {
                ServerIp = serverIp,
                UserName = userId,
                PassWord = StringHelper.Base64Decode(password),
                VpnProtocol = "L2TP"
            };
            do
            {
                VpnService.Connect(ref vpnModel);
                Global.Linked = await TestInternet();
                if (Global.Linked)
                {
                    return true;
                }
                Thread.Sleep(1000);
                times--;
            } while (times > 0);

            return false;
        }

        public static void DisconnectVpn()
        {
            VpnService.Abort();
            Global.Linked = false;
        }

        public static async Task<bool> SendIpAsync(string address, int times = 30)
        {
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }
            do
            {
                bool res = await Task.Run(() =>
                    WebHelper.SendMail(
                        StringHelper.GetAppString("MailUser"),
                        StringHelper.GetAppString("MailAuthorizationCode"),
                        StringHelper.GetAppString("MailHost"),
                        address,
                        "IP地址",
                        SystemHelper.ExecuteCommand("ipconfig")));

                if (res)
                {
                    return true;
                }
                Thread.Sleep(1000);
                times--;
            } while (times > 0);
            return false;
        }

        public static string TestMail(string address)
        {
            var code = StringHelper.GenerateRandomString(6);
            WebHelper.SendMail(StringHelper.GetAppString("MailUser"),
                StringHelper.GetAppString("MailAuthorizationCode"), StringHelper.GetAppString("MailHost"),
                address, "验证邮箱", "请将收到的验证码填入AutoLink中，验证码：\n" + code);
            return code;
        }
    }
}