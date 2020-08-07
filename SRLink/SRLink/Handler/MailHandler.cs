using Kit.Utils;
using SRLink.Model;
using System.Windows.Forms;

namespace SRLink.Handler
{
    public class MailHandler : HandlerBase
    {
        private readonly SettingMail Setting;
        public MailHandler(SettingMail setting_Mail, int count = 60, int delay = 3000, EHandler mode = EHandler.Test)
        {
            ID = 3;
            HandleName = "发送邮件";
            Setting = setting_Mail;
            Count = count;
            Delay = delay;
            Mode = mode;
        }
        public bool SendIP(out string msg)
        {
            if (!Web.SendMail(Global.Mail_User, Global.Mail_AuthorizationCode, Global.Mail_Host,
                Setting.Address, "IP地址", Cmd.ExecuteCommand("ipconfig")))
            {
                msg = "等待超时";
                return false;
            }
            msg = "发送成功";
            return true;
        }
        public static string TestMail(string address)
        {
            string code = MathHelper.GenerateRandomString(6);
            Web.SendMail(Global.Mail_User, Global.Mail_AuthorizationCode, Global.Mail_Host,
                address, "验证邮箱", "请将收到的验证码填入AutoLink中，验证码：\n" + code);
            return code;
        }
        public override void RegisteUI(PictureBox picture, Label label)
        {
            base.RegisteUI(picture, label);
        }
        public override bool Run(out string msg)
        {
            return SendIP(out msg);
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
