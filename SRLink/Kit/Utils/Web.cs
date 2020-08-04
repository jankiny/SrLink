using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
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
        /// <returns>是否发送成功</returns>
        public static bool SendMail(string user, string pwd, string host, string address, string title, string context)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(host)
                {
                    //开启安全连接
                    EnableSsl = true,
                    //创建用户凭证
                    Credentials = new NetworkCredential(user, pwd),
                    //使用网络传送
                    DeliveryMethod = SmtpDeliveryMethod.Network 
                };
                //创建邮件
                MailMessage message = new MailMessage(user, address, title, context);
                //发送邮件
                smtp.Send(message); 
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
            catch (Exception e)
            {
                return e.Message;
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


        #region 检测网络状态
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        /// <summary>
        ///  返回本地系统的网络连接状态
        /// </summary>
        /// <param name="dwFlag">指向一个变量，该变量接收连接描述内容</param>
        /// <param name="dwReserved"></param>
        /// <returns></returns>
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);
        
        /// <summary>
        /// 判断本地的连接状态
        /// </summary>
        /// <returns></returns>
        private static bool LocalConnectionStatus()
        {
            System.Int32 dwFlag = new Int32();
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                //Console.WriteLine("LocalConnectionStatus--未连网!");
                return false;
            }
            else
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                {
                    //Console.WriteLine("LocalConnectionStatus--采用调制解调器上网。");
                    return true;
                }
                else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                {
                    //Console.WriteLine("LocalConnectionStatus--采用网卡上网。");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Ping命令检测网络是否畅通
        /// </summary>
        /// <param name="urls">URL数据</param>
        /// <param name="errorCount">ping时连接失败个数</param>
        /// <returns></returns>
        public static bool IsConnectInternet(string[] urls, out int errorCount)
        {
            bool isconn = true;
            Ping ping = new Ping();
            errorCount = 0;
            try
            {
                PingReply pr;
                for (int i = 0; i < urls.Length; i++)
                {
                    pr = ping.Send(urls[i]);
                    if (pr.Status != IPStatus.Success)
                    {
                        isconn = false;
                        errorCount++;
                    }
                    Console.WriteLine("Ping " + urls[i] + "    " + pr.Status.ToString());
                }
            }
            catch
            {
                isconn = false;
                errorCount = urls.Length;
            }
            //if (errorCount > 0 && errorCount < 3)
            //  isconn = true;
            return isconn;
        }
        /// <summary>
        /// 判断是否有网
        /// </summary>
        /// <returns>true为有网，false为无网</returns>
        public static bool IsConnectInternet(string url)
        {
            bool isconn = true;
            Ping ping = new Ping();
            try
            {
                PingReply pr;
                pr = ping.Send(url);
                if (pr.Status != IPStatus.Success)
                {
                    isconn = false;
                }
            }
            catch
            {
                // 如果没有联网，直接ping网页的Url会出现异常：不知道这样的主机
                isconn = false;
            }
            return isconn;
        }
        #endregion
    }
}
