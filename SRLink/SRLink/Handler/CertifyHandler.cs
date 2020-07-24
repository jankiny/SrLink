using System.Text;
using SRLink.Helper;

namespace SRLink.Handler
{
    public static class CertifyHandler
    {
        public static bool RegisterSchoolNet(string uid, string pwd)
        {
            if (Login(uid, pwd) != "认证成功")
            {
                return false;
            }
            return true;
        }

        public static string Login(string uid, string pwd)
        {
            //string username = "201705021331";
            //string passwd = "MTgxMDE4";

            string param = "action=login&username=" + uid + "&password={B}" + WebHelper.ToBase64String(pwd) + "&ac_id=2&user_ip=&nas_ip=&user_mac=&save_me=1&ajax=1";

            string res = WebHelper.PostWebRequest("http://172.8.231.22:802/include/auth_action.php", param, 107, Encoding.UTF8);

            if (res == "操作超时")
            {
                return "请求无响应";
                // "请求无响应，可能的原因：1、已经完成认证，并连接了随e行；2、不在校园内网中。"
            }
            else if (res.Split(',')[0] == "login_ok")
            {
                return "认证成功";
            }
            else
            {
                return "请检查网线是否接好！";
                //this.tss_lbl_info.Text = this.tss_lbl_time + ": " + "认证页面接口改变！！！";
            }
        }
    }
}
