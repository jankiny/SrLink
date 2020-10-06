﻿using System;
using SRLink.Helper;

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
    public class Config
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

        public Config GetAllAsync()
        {
            var path = StringHelper.Combine(Global.StartupPath, Global.ConfigFileName); 
            string result = TextHelper.LoadResource(path);
            var config = TextHelper.FromJson<Config>(result);
            return config;
        }

        public int UpdateAsync(Config config)
        {
            var path = StringHelper.Combine(Global.StartupPath, Global.ConfigFileName);
            return TextHelper.ToJsonFile(config, path);
        }

        public bool EnableTryLink()
        {
            int now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return (AutoLink && now >= StartTime.Hour * 60 + StartTime.Minute && now < Global.NightNotLink);
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
        public string IpServer { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public SettingLink()
        {
            Enable = false;
            IpServer = "";
            UserName = "";
            Password = "";
        }
        public SettingLink(bool able, string ipServer, string userName, string password)
        {
            Enable = able;
            IpServer = ipServer;
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
