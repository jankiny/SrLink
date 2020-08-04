using System;
using SRLink.Model;
using Kit.Utils;

namespace SRLink.Handler
{
    public class ConfigHandler
    {
        private static string configPath = Global.ConfigFileName;

        /// <summary>
        /// 载入配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int LoadConfig(ref Config config)
        {
            //载入配置文件 
            string result = Json.LoadResource(Json.GetPath(configPath));
            if (!string.IsNullOrEmpty(result))
            {
                //转成Json
                config = Json.FromJson<Config>(result);
            }
            if (config == null)
            {
                config = new Config
                {
                    HasConfig = false,
                    StartTime = DateTime.Parse("08:00"),
                    LastLinkTime = DateTime.Now.AddDays(-1),
                    SettingCertify = new SettingCertify(),
                    SettingLink = new SettingLink(),
                    SettingMail = new SettingMail()
                };
            }
            return 0;
        }

        /// <summary>
        /// 保参数
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int SaveConfig(ref Config config, bool reload = true)
        {
            Json.ToJsonFile(config, Json.GetPath(configPath));

            return 0;
        }
        //private Setting_Certify _Setting_Certify;
        //public Setting_Certify Setting_Certify
        //{
        //    get
        //    {
        //        if (this._Setting_Certify == null)
        //        {
        //            this._Setting_Certify = this.ReadConfig_Certify();
        //            return this._Setting_Certify;
        //        }
        //        return this._Setting_Certify;
        //    }
        //    set
        //    {
        //        this.SaveConfig(value);
        //        this._Setting_Certify = value;
        //    }
        //}
        //private Setting_Link _Setting_Link;
        //public Setting_Link Setting_Link
        //{
        //    get
        //    {
        //        if (this._Setting_Link == null)
        //        {
        //            this._Setting_Link = this.ReadConfig_Link();
        //            return this._Setting_Link;
        //        }
        //        return this._Setting_Link;
        //    }
        //    set
        //    {
        //        this.SaveConfig(value);
        //        this._Setting_Link = value;
        //    }
        //}
        //private Setting_Mail _Setting_Mail;
        //public Setting_Mail Setting_Mail
        //{
        //    get
        //    {
        //        if (this._Setting_Mail == null)
        //        {
        //            this._Setting_Mail = this.ReadConfig_Mail();
        //            return this._Setting_Mail;
        //        }
        //        return this._Setting_Mail;
        //    }
        //    set
        //    {
        //        this.SaveConfig(value);
        //        this._Setting_Mail = value;
        //    }
        //}
        //private DateTime _Start_Time;
        //public DateTime Start_Time
        //{
        //    get
        //    {
        //        //if (this._Start_Time == null)
        //        //{
        //        //    this._Start_Time = this.ReadConfig_Time();
        //        //    return this._Start_Time;
        //        //}
        //        this._Start_Time = this.ReadConfig_Time();
        //        return this._Start_Time;
        //    }
        //    set
        //    {
        //        this.SaveConfig(value);
        //        this._Start_Time = value;
        //    }
        //}

        //private readonly Config appConfig = null;
        //public ConfigHandler(string appExecPath)
        //{
        //    appConfig = new Config(appExecPath);
        //}
        //public bool HasConfig()
        //{
        //    return appConfig.ExistInAppConfig("has_config");
        //}
        //public void NewConfig(Setting_Certify config_Certify, Setting_Link config_Link, Setting_Mail config_Mail, DateTime time)
        //{
        //    appConfig.NewAppConfig("has_config", "1");
        //    appConfig.NewAppConfig("start_time", time.ToString("hh:mm"));

        //    appConfig.NewAppConfig("certify_enable", ((int)config_Certify.Enable).ToString());
        //    appConfig.NewAppConfig("certify_status", ((int)config_Certify.Status).ToString());
        //    appConfig.NewAppConfig("certify_student", config_Certify.StudentID);
        //    appConfig.NewAppConfig("certify_password", config_Certify.Password);

        //    appConfig.NewAppConfig("link_enable", ((int)config_Link.Enable).ToString());
        //    appConfig.NewAppConfig("link_path", config_Link.Path);
        //    appConfig.NewAppConfig("link_way", config_Link.Way.ToString());
        //    appConfig.NewAppConfig("link_x", config_Link.X.ToString());
        //    appConfig.NewAppConfig("link_y", config_Link.Y.ToString());

        //    appConfig.NewAppConfig("mail_enable", ((int)config_Mail.Enable).ToString());
        //    appConfig.NewAppConfig("mail_status", ((int)config_Mail.Status).ToString());
        //    appConfig.NewAppConfig("mail_address", config_Mail.Address);
        //}
        //#region 辅助函数（待优化）
        //private void SaveConfig(Setting_Certify config_Certify)
        //{
        //    appConfig.UpdateAppConfig("certify_enable", ((int)config_Certify.Enable).ToString());
        //    appConfig.UpdateAppConfig("certify_status", ((int)config_Certify.Status).ToString());
        //    appConfig.UpdateAppConfig("certify_student", config_Certify.StudentID);
        //    appConfig.UpdateAppConfig("certify_password", config_Certify.Password);
        //}
        //private void SaveConfig(Setting_Link config_Link)
        //{
        //    appConfig.UpdateAppConfig("link_enable", ((int)config_Link.Enable).ToString());
        //    appConfig.UpdateAppConfig("link_path", config_Link.Path);
        //    appConfig.UpdateAppConfig("link_way", config_Link.Way.ToString());
        //    appConfig.UpdateAppConfig("link_x", config_Link.X.ToString());
        //    appConfig.UpdateAppConfig("link_y", config_Link.Y.ToString());
        //}
        //private void SaveConfig(Setting_Mail config_Mail)
        //{
        //    appConfig.UpdateAppConfig("mail_enable", ((int)config_Mail.Enable).ToString());
        //    appConfig.UpdateAppConfig("mail_status", ((int)config_Mail.Status).ToString());
        //    appConfig.UpdateAppConfig("mail_address", config_Mail.Address);
        //}
        //private void SaveConfig(DateTime time)
        //{
        //    appConfig.UpdateAppConfig("start_time", time.ToString("hh:mm"));
        //}
        //private DateTime ReadConfig_Time()
        //{
        //    string time = appConfig.GetAppConfig("start_time");
        //    return DateTime.Parse(time);
        //}
        //private Setting_Certify ReadConfig_Certify()
        //{
        //    return new Setting_Certify(
        //        (EEnable)int.Parse(appConfig.GetAppConfig("certify_enable")),
        //        (EStatus)int.Parse(appConfig.GetAppConfig("certify_status")),
        //        appConfig.GetAppConfig("certify_student"),
        //        appConfig.GetAppConfig("certify_password")
        //        );
        //}
        //private Setting_Link ReadConfig_Link()
        //{
        //    return new Setting_Link(
        //        (EEnable)int.Parse(appConfig.GetAppConfig("link_enable")),
        //        appConfig.GetAppConfig("link_path"),
        //        int.Parse(appConfig.GetAppConfig("link_way")),
        //        int.Parse(appConfig.GetAppConfig("link_x")),
        //        int.Parse(appConfig.GetAppConfig("link_y"))
        //        );
        //}
        //private Setting_Mail ReadConfig_Mail()
        //{
        //    return new Setting_Mail(
        //        (EEnable)int.Parse(appConfig.GetAppConfig("mail_enable")),
        //        (EStatus)int.Parse(appConfig.GetAppConfig("mail_status")),
        //        appConfig.GetAppConfig("mail_address")
        //        );
        //}
        //#endregion

    }
}
