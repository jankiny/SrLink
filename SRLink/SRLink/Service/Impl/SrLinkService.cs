using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using SRLink.Helper;
using SRLink.Model;

namespace SRLink.Service.Impl
{
    public class SrLinkService :  ISrLinkService
    {
        private readonly ConfigModel Config;
        private IVpnService VpnService;
        public bool Linked;
        public bool Running;
        public SrLinkService(ConfigModel config, IConfigService configService)
        {
            Config = config;
            Initialize();
        }

        private async void Initialize()
        {
            //await LinkVpn(1);
            VpnService = new VpnService();
            Linked = await TestInternet();
            Running = false;
        }

        #region 属性方法
        public bool GetLinked()
        {
            return Linked;
        }

        public bool GetRunning()
        {
            return Running;
        }

        public void SetRunning(bool isRunning)
        {
            Running = isRunning;
        }


        #endregion

        public bool SettingEnable(string configName)
        {
            bool res = false;
            switch (configName)
            {
                case "Certify":
                    res = Config.SettingCertify.Enable;
                    break;
                case "Link":
                    res = Config.SettingLink.Enable;
                    break;
                case "Mail":
                    res = Config.SettingMail.Enable;
                    break;
            }
            return res;
        }
        public async Task<bool> RegisterSchoolNet(int times = 30)
        {
            if (string.IsNullOrEmpty(Config.SettingCertify.StudentId) ||
                string.IsNullOrEmpty(Config.SettingCertify.Password))
            {
                return false;
            }
            // 存在Config中的Config.SettingCertify.Password本来就是Base64编码
            string param = string.Format(StringHelper.GetAppString("CertifyUrlParam"), Config.SettingCertify.StudentId, Config.SettingCertify.Password);

            do
            {
                string res = await Task.Run(() =>
                    WebHelper.PostWebRequest(StringHelper.GetAppString("CertifyUrl"), param,  Encoding.UTF8));
                
                if (res.Split(',')[0] == "login_ok")
                {
                    return true;
                }
                Thread.Sleep(1000);
                times--;
            } while (times > 0);

            return false;
        }

        public async Task<bool> TestInternet(int times = 30)
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

        public async Task<bool> LinkVpn(int times = 30)
        {
            if (string.IsNullOrEmpty(Config.SettingLink.ServerIp) ||
                string.IsNullOrEmpty(Config.SettingLink.UserName) ||
                string.IsNullOrEmpty(Config.SettingLink.Password))
            {
                return false;
            }
            VpnService.UpdateVpnModel(new VpnModel()
            {
                ServerIP = Config.SettingLink.ServerIp,
                UserName = Config.SettingLink.UserName,
                PassWord = StringHelper.Base64Decode(Config.SettingLink.Password),
                VpnProtocol = "L2TP"
            });
            do
            {
                await Task.Run(() => VpnService.Connect());
                Linked = await TestInternet();
                if (Linked)
                {
                    return true;
                }
                Thread.Sleep(1000);
                times--;
            } while (times > 0);

            return false;
        }

        public void DisconnectVpn()
        {
            VpnService?.Disconnect();
            Linked = false;
        }

        public async Task<bool> SendIp(int times = 30)
        {
            if (string.IsNullOrEmpty(Config.SettingMail.Address))
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
                        Config.SettingMail.Address,
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

        public string TestMail(string address)
        {
            string code = StringHelper.GenerateRandomString(6);
            WebHelper.SendMail(StringHelper.GetAppString("MailUser"), StringHelper.GetAppString("MailAuthorizationCode"), StringHelper.GetAppString("MailHost"),
                address, "验证邮箱", "请将收到的验证码填入AutoLink中，验证码：\n" + code);
            return code;
        }
        ~SrLinkService()
        {
            VpnService?.Disconnect();
        }
    }
}