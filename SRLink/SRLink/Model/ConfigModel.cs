using System;

namespace SRLink.Model
{
    [Serializable]
    public class ConfigModel
    {
        /// <summary>
        ///     开机启动
        /// </summary>
        public bool RunAtStartup { get; set; } = false;

        /// <summary>
        ///     网络类型(0：学生  1：教师)
        /// </summary>
        public int NetType { get; set; } = 0;

        /// <summary>
        ///     学生网配置
        /// </summary>
        public StudentNet StudentNet { get; set; }

        /// <summary>
        ///     教师网配置
        /// </summary>
        public TeacherNet TeacherNet { get; set; }
    }

    [Serializable]
    public class StudentNet
    {

        /// <summary>
        ///     自动连接
        /// </summary>
        public bool AutoLink { get; set; } = false;

        /// <summary>
        ///     开发连接时间
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     上次连接时间
        /// </summary>
        public DateTime LastLinkTime { get; set; } = DateTime.UtcNow;
        /// <summary>
        ///     认证用户配置
        /// </summary>
        public SettingCertify SettingCertify { get; set; }

        /// <summary>
        ///     用户连接配置
        /// </summary>
        public SettingLink SettingLink { get; set; }

        /// <summary>
        ///     用户邮箱配置
        /// </summary>
        public SettingMail SettingMail { get; set; }
    }

    [Serializable]
    public class TeacherNet
    {
        /// <summary>
        ///     认证用户配置
        /// </summary>
        public SettingCertify SettingCertify { get; set; }
    }

    [Serializable]
    public class SettingCertify
    {
        /// <summary>
        ///     是否启用
        /// </summary>
        public bool Enable { get; set; } = false;

        /// <summary>
        ///     用户账号（学生为学号、老师为工号）
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; } = string.Empty; // 认证密码（一般为身份证后6位）
    }

    [Serializable]
    public class SettingLink
    {
        /// <summary>
        ///     是否启用
        /// </summary>
        public bool Enable { get; set; } = false;

        /// <summary>
        ///     服务器地址
        /// </summary>
        public string ServerIp { get; set; } = string.Empty;

        /// <summary>
        ///     账号
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }

    [Serializable]
    public class SettingMail
    {
        /// <summary>
        ///     是否启用
        /// </summary>
        public bool Enable { get; set; } = false;

        /// <summary>
        ///     目标地址
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}