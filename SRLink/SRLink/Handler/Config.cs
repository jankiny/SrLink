using System;
using SRLink.Model;
using SRLink.Helper;

namespace SRLink.Handler
{
    public class Config
    {
        ConfigHelper appConfig = null;
        public Config(string appExecPath)
        {
            appConfig = new ConfigHelper(appExecPath);
        }
        public bool HasConfig()
        {
            return appConfig.ExistInAppConfig("has_config");
        }
        public void NewConfig(Config_Certify config_Certify, Config_Link config_Link, Config_Mail config_Mail, DateTime time)
        {
            appConfig.NewAppConfig("has_config", "1");
            appConfig.NewAppConfig("start_time", time.ToString("hh:mm"));

            appConfig.NewAppConfig("certify_enable", config_Certify.Enable.ToString());
            appConfig.NewAppConfig("certify_status", config_Certify.Status.ToString());
            appConfig.NewAppConfig("certify_student", config_Certify.Student);
            appConfig.NewAppConfig("certify_password", config_Certify.Password);

            appConfig.NewAppConfig("link_enable", config_Link.Enable.ToString());
            appConfig.NewAppConfig("link_path", config_Link.Path);
            appConfig.NewAppConfig("link_way", config_Link.Way.ToString());
            appConfig.NewAppConfig("link_x", config_Link.X.ToString());
            appConfig.NewAppConfig("link_y", config_Link.Y.ToString());

            appConfig.NewAppConfig("mail_enable", config_Mail.Enable.ToString());
            appConfig.NewAppConfig("mail_status", config_Mail.Status.ToString());
            appConfig.NewAppConfig("mail_address", config_Mail.Address);
        }
        public void SaveConfig(Config_Certify config_Certify)
        {
            appConfig.UpdateAppConfig("certify_enable", config_Certify.Enable.ToString());
            appConfig.UpdateAppConfig("certify_status", config_Certify.Status.ToString());
            appConfig.UpdateAppConfig("certify_student", config_Certify.Student);
            appConfig.UpdateAppConfig("certify_password", config_Certify.Password);
        }
        public void SaveConfig(Config_Link config_Link)
        {
            appConfig.UpdateAppConfig("link_enable", config_Link.Enable.ToString());
            appConfig.UpdateAppConfig("link_path", config_Link.Path);
            appConfig.UpdateAppConfig("link_way", config_Link.Way.ToString());
            appConfig.UpdateAppConfig("link_x", config_Link.X.ToString());
            appConfig.UpdateAppConfig("link_y", config_Link.Y.ToString());
        }
        public void SaveConfig(Config_Mail config_Mail)
        {
            appConfig.UpdateAppConfig("mail_enable", config_Mail.Enable.ToString());
            appConfig.UpdateAppConfig("mail_status", config_Mail.Status.ToString());
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
        public Config_Certify ReadConfig_Certify()
        {
            return new Config_Certify(
                int.Parse(appConfig.GetAppConfig("certify_enable")),
                int.Parse(appConfig.GetAppConfig("certify_status")),
                appConfig.GetAppConfig("certify_student"),
                appConfig.GetAppConfig("certify_password")
                );
        }
        public Config_Link ReadConfig_Link()
        {
            return new Config_Link(
                int.Parse(appConfig.GetAppConfig("link_enable")),
                appConfig.GetAppConfig("link_path"),
                int.Parse(appConfig.GetAppConfig("link_way")),
                int.Parse(appConfig.GetAppConfig("link_x")),
                int.Parse(appConfig.GetAppConfig("link_y"))
                );
        }
        public Config_Mail ReadConfig_Mail()
        {
            return new Config_Mail(
                int.Parse(appConfig.GetAppConfig("mail_enable")),
                int.Parse(appConfig.GetAppConfig("mail_status")),
                appConfig.GetAppConfig("mail_address")
                );
        }
    }
}
