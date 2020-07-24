using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Helper
{
    public class MailHelper
    {
        public static bool SendMail(string address, string title, string context)
        {
            try
            {
                string user = "yzll995@163.com";//替换成你的hotmail用户名
                string password = "54yangzl1999";//替换成你的hotmail密码   这个密码是：你设置的客户端授权密码
                string host = "smtp.163.com";//设置邮件的服务器
                string mailAddress = "yzll995@163.com"; //替换成你的hotmail账户

                SmtpClient smtp = new SmtpClient(host);
                smtp.EnableSsl = true; //开启安全连接。
                smtp.Credentials = new NetworkCredential(user, password); //创建用户凭证
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //使用网络传送
                MailMessage message = new MailMessage(mailAddress, address, title, context); //创建邮件
                smtp.Send(message); //发送邮件
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
