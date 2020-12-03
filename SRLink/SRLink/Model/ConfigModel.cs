using System;
using SRLink.Helper;
using SRLink.Service.Impl;

namespace SRLink.Model
{
    public abstract class SettingBase
    {
        public bool Enable
        {
            get; set;
        }
    }
    [Serializable]
    public class ConfigModel
    {
        #region 自动添加
        
        //public bool HasConfig
        //{
        //    get; set;
        //}

        public DateTime StartTime
        {
            get; set;
        }

        public DateTime LastLinkTime
        {
            get; set;
        }

        #endregion
        public bool RunAtStartup
        {
            get; set;
        }


        public bool Debug { get; set; }
        public bool AutoLink { get; set; }

        public SettingCertify SettingCertify
        {
            get; set;
        }
        public SettingLink SettingLink
        {
            get; set;
        }

        public SettingMail SettingMail
        {
            get; set;
        }

        public ConfigModel GetAllAsync()
        {
            var path = SystemHelper.Combine(Global.StartupPath, StringHelper.GetAppString("ConfigFileName")); 
            string result = StringHelper.LoadResource(path);
            var config = StringHelper.FromJson<ConfigModel>(result);
            return config;
        }

        public int UpdateAsync(ConfigModel config)
        {
            var path = SystemHelper.Combine(Global.StartupPath, StringHelper.GetAppString("ConfigFileName"));
            return StringHelper.ToJsonFile(config, path);
        }

        public bool EnableTryLink()
        {
            int now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return AutoLink && now >= StartTime.Hour * 60 + StartTime.Minute && now < int.Parse(StringHelper.GetAppString("NightNotLink"));
        }
    }

    [Serializable]
    public class SettingCertify : SettingBase
    {
        public string StudentId { get; set; }
        public string Password { get; set; } // 认证密码（一般为身份证后6位）

        // 用于第一次创建
        public SettingCertify()
        {
            base.Enable = false;
            StudentId = "";
            Password = "";
        }

        // 用于读取保存的config
        public SettingCertify(bool able, string id, string pwd)
        {
            Enable = able;
            StudentId = id;
            Password = pwd;
        }
    }

    [Serializable]
    public class SettingLink : SettingBase
    {
        public string ServerIp { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public SettingLink()
        {
            Enable = false;
            ServerIp = "";
            UserName = "";
            Password = "";
        }
        public SettingLink(bool able, string serverIp, string userName, string password)
        {
            Enable = able;
            ServerIp = serverIp;
            UserName = userName;
            Password = password;
        }
    }

    [Serializable]
    public class SettingMail : SettingBase
    {
        public string Address;
        public SettingMail()
        {
            Enable = false;
            Address = "";
        }

        public SettingMail(bool able, string address)
        {
            Enable = able;
            Address = address;
        }
    }
}
