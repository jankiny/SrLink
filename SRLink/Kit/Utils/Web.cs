using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Kit.Utils
{
    public class Web
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="address">目标邮箱</param>
        /// <param name="title">邮件标题</param>
        /// <param name="context">邮件内容</param>
        /// <returns></returns>
        public static bool SendMail(string user, string pwd, string host, string address, string title, string context)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(host)
                {
                    EnableSsl = true, //开启安全连接。
                    Credentials = new NetworkCredential(user, pwd), //创建用户凭证
                    DeliveryMethod = SmtpDeliveryMethod.Network //使用网络传送
                };
                MailMessage message = new MailMessage(user, address, title, context); //创建邮件
                smtp.Send(message); //发送邮件
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Post数据接口(用json传递参数)
        /// </summary>
        /// <param name="postUrl">接口地址</param>
        /// <param name="paramData">提交json数据</param>
        /// <param name="dataEncode">编码方式</param>
        /// <returns></returns>
        public static string PostWebRequestByJson(string postUrl, string paramData, Encoding dataEncode)
        {
            string responseContent = string.Empty;
            try
            {
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.ContentType = "application/json; charset=UTF-8";
                //webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.Method = "POST";
                webReq.Timeout = 20000;

                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                webReq.Accept = "application/json, text/javascript, */*; q=0.01"; //注：调试的过程中，报415，这里可能需要修改下
                webReq.ContentLength = byteArray.Length;
                using (Stream reqStream = webReq.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);//写入参数
                    //reqStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                {
                    using (Stream myResponseStream = response.GetResponseStream())
                    {
                        using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8))
                        {
                            responseContent = myStreamReader.ReadToEnd().ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return responseContent;
        }
        /// <summary>
        /// Post数据接口(用www-form格式传递参数)
        /// </summary>
        /// <param name="postUrl">接口地址</param>
        /// <param name="paramData">提交的参数</param>
        /// <param name="dataEncode">编码方式</param>
        /// <returns></returns>
        public static string PostWebRequest(string postUrl, string paramData, long contentLength, Encoding dataEncode)
        {
            string responseContent = string.Empty;
            try
            {
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));

                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.Method = "POST";
                webReq.Timeout = 3000;

                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                webReq.Accept = "application/json, text/javascript, */*; q=0.01"; 
                webReq.ContentLength = contentLength;

                using (Stream reqStream = webReq.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);//写入参数
                    //reqStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                {
                    using (Stream myResponseStream = response.GetResponseStream())
                    {
                        using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8))
                        {
                            responseContent = myStreamReader.ReadToEnd().ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return responseContent;
        }

        // Base64编码
        public static string ToBase64String(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        // Base64解码
        public static string UnBase64String(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }
        /// <summary>
        /// 判断是否有网
        /// </summary>
        /// <returns>true为有网，false为无网</returns>
        public static bool IsConnectInternet()
        {
            Ping p = new Ping();
            PingReply pr2 = p.Send("www.baidu.com");
            if (pr2.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }
    }
}
