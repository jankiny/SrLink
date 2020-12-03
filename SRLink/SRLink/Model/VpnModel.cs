namespace SRLink.Model
{
    public class VpnModel
    {
        /// <summary>
        ///     服务器IP地址
        /// </summary>
        public string ServerIp { get; set; }

        /// <summary>
        ///     登录用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        ///     VPN协议
        /// </summary>
        public string VpnProtocol { get; set; }

        /// <summary>
        ///     预共享密钥
        /// </summary>
        public string PreSharedKey { get; set; }
    }
}