using System.Windows.Forms;

namespace SRLink
{
    internal class Global
    {
        #region 全局变量
        public static string StartupPath { get => Application.StartupPath; }
        //public static bool Linked { get; set; } = true;
        //public static bool Running { get; set; } = false;
        #endregion

        #region 常量
        /// <summary>
        /// info
        /// </summary>
        public const string SoftwareName = "SRLink";
        public const string Version = "v2.2.7_beta";

        /// <summary>
        /// 校园认证地址
        /// </summary>
        public const string Certify_Url = @"http://172.8.231.22:802/include/auth_action.php";

        /// <summary>
        /// 认证地址Query参数格式（配合string.format()使用，需要输入用户名和密码）
        /// </summary>
        public const string Certify_UrlParam = @"action=login&username={0}&password={{B}}{1}&ac_id=2&user_ip=&nas_ip=&user_mac=&save_me=1&ajax=1";

        /// <summary>
        /// 发送邮件使用的账号
        /// </summary>
        public const string Mail_User = "srlink@yeah.net";
        public const string Mail_AuthorizationCode = "XRDCVAVKHGXICICQ";
        public const string Mail_Host = "smtp.yeah.net";

        /// <summary>
        /// 软件配置文件名
        /// </summary>
        public const string ConfigFileName = "SRLinkConfig.json";

        /// <summary>
        /// 时间格式
        /// </summary>
        public const string DateTimeFormatString = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 一天最晚连接时间（23:00）
        /// </summary>
        public const int NightNotLink = 23 * 60;

        /// <summary>
        /// 测试网络是否连通的测试网址
        /// </summary>
        public const string TestConnectionUrl = "www.baidu.com";

        /// <summary>
        /// 注册表开机启动名称
        /// </summary>
        public const string autoRunName = "SRLinkAutoRun";

        /// <summary>
        /// 注册表设置开机启动路径
        /// </summary>
        public const string autoRunRegPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// 默认服务器
        /// </summary>
        public const string IpServerDefault = "192.168.200.1";
        /// <summary>
        /// 连接器名
        /// </summary>
        public const string AdapterName = "SLINK_L2TP";

        #endregion
    }
}
