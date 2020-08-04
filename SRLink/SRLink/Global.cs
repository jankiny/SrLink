namespace SRLink
{
    class Global
    {
        #region 常量
        /// <summary>
        /// info
        /// </summary>
        public const string SoftwareName = "SRLink";
        public const string Version = "v2.1.0_200804_alpha";

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

        public const string DateTimeFormatString = "yyyy-MM-dd hh:mm:ss";
        #endregion
    }
}
