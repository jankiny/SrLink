using SRLink.Helper;

namespace SRLink.Handler
{
    public static class MailHandler
    {
        public static bool SendIP(string address)
        {
            return MailHelper.SendMail(address, "IP地址", CmdHelper.ExecuteCommand("ipconfig"));
        }
        public static string TestMail(string address)
        {
            string code = MathHelper.GenerateRandomString(6);
            MailHelper.SendMail(address, "验证邮箱", "请将收到的验证码填入AutoLink中，验证码：\n\t\t" + code);
            return code;
        }
    }
}
