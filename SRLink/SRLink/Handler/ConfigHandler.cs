using System;
using SRLink.Model;

namespace SRLink.Handler
{
    public class ConfigHandler
    {
        private readonly Config appConfig = null;
        public ConfigHandler(string appExecPath)
        {
            appConfig = new Config(appExecPath);
        }
        public bool HasConfig()
        {
            return appConfig.ExistInAppConfig("has_config");
        }
        public void NewConfig(Setting_Certify config_Certify, Setting_Link config_Link, Setting_Mail config_Mail, DateTime time)
        {
            appConfig.NewAppConfig("has_config", "1");
            appConfig.NewAppConfig("start_time", time.ToString("hh:mm"));

            appConfig.NewAppConfig("certify_enable", ((int)config_Certify.Enable).ToString());
            appConfig.NewAppConfig("certify_status", ((int)config_Certify.Status).ToString());
            appConfig.NewAppConfig("certify_student", config_Certify.Student);
            appConfig.NewAppConfig("certify_password", config_Certify.Password);

            appConfig.NewAppConfig("link_enable", ((int)config_Link.Enable).ToString());
            appConfig.NewAppConfig("link_path", config_Link.Path);
            appConfig.NewAppConfig("link_way", config_Link.Way.ToString());
            appConfig.NewAppConfig("link_x", config_Link.X.ToString());
            appConfig.NewAppConfig("link_y", config_Link.Y.ToString());

            appConfig.NewAppConfig("mail_enable", ((int)config_Mail.Enable).ToString());
            appConfig.NewAppConfig("mail_status", ((int)config_Mail.Status).ToString());
            appConfig.NewAppConfig("mail_address", config_Mail.Address);
        }
        public void SaveConfig(Setting_Certify config_Certify)
        {
            appConfig.UpdateAppConfig("certify_enable", ((int)config_Certify.Enable).ToString());
            appConfig.UpdateAppConfig("certify_status", ((int)config_Certify.Status).ToString());
            appConfig.UpdateAppConfig("certify_student", config_Certify.Student);
            appConfig.UpdateAppConfig("certify_password", config_Certify.Password);
        }
        public void SaveConfig(Setting_Link config_Link)
        {
            appConfig.UpdateAppConfig("link_enable", ((int)config_Link.Enable).ToString());
            appConfig.UpdateAppConfig("link_path", config_Link.Path);
            appConfig.UpdateAppConfig("link_way", config_Link.Way.ToString());
            appConfig.UpdateAppConfig("link_x", config_Link.X.ToString());
            appConfig.UpdateAppConfig("link_y", config_Link.Y.ToString());
        }
        public void SaveConfig(Setting_Mail config_Mail)
        {
            appConfig.UpdateAppConfig("mail_enable", ((int)config_Mail.Enable).ToString());
            appConfig.UpdateAppConfig("mail_status", ((int)config_Mail.Status).ToString());
            appConfig.UpdateAppConfig("mail_address", config_Mail.Address);
        }
        public void SaveConfig(DateTime time)
        {
            appConfig.UpdateAppConfig("start_time", time.ToString("hh:mm"));
        }
        public DateTime ReadConfig_Time()
        {
            string time = appConfig.GetAppConfig("start_time");
            return DateTime.Parse(time);
        }
        public Setting_Certify ReadConfig_Certify()
        {
            return new Setting_Certify(
                (EEnable)int.Parse(appConfig.GetAppConfig("certify_enable")),
                (EStatus)int.Parse(appConfig.GetAppConfig("certify_status")),
                appConfig.GetAppConfig("certify_student"),
                appConfig.GetAppConfig("certify_password")
                );
        }
        public Setting_Link ReadConfig_Link()
        {
            return new Setting_Link(
                (EEnable)int.Parse(appConfig.GetAppConfig("link_enable")),
                appConfig.GetAppConfig("link_path"),
                int.Parse(appConfig.GetAppConfig("link_way")),
                int.Parse(appConfig.GetAppConfig("link_x")),
                int.Parse(appConfig.GetAppConfig("link_y"))
                );
        }
        public Setting_Mail ReadConfig_Mail()
        {
            return new Setting_Mail(
                (EEnable)int.Parse(appConfig.GetAppConfig("mail_enable")),
                (EStatus)int.Parse(appConfig.GetAppConfig("mail_status")),
                appConfig.GetAppConfig("mail_address")
                );
        }
    }
}
