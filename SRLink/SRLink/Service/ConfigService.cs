using System;
using SRLink.Helper;
using SRLink.Model;

namespace SRLink.Service
{
    internal class ConfigService
    {
        private static readonly string ConfigFileName = StringHelper.GetAppString("ConfigFileName");
        private static readonly string StartupPath = Global.StartupPath;

        private static readonly int NightNotLink = int.Parse(StringHelper.GetAppString("NightNotLink"));
        //public ConfigModel Config;
        //public ConfigService()
        //{
        //    Config = new ConfigModel();
        //}

        ///// <summary>
        ///// 载入配置文件
        ///// </summary>
        //public ConfigModel LoadConfig()
        //{
        //    return Config.GetAllAsync();
        //}


        ///// <summary>
        ///// 保存参数
        ///// </summary>
        ///// <returns></returns>
        //public int SaveConfig(ConfigModel config)
        //{
        //    return Config.UpdateAsync(config);
        //}


        public static int LoadConfig(ref ConfigModel config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            var path = SystemHelper.Combine(StartupPath, ConfigFileName);
            var result = StringHelper.LoadResource(path);
            config = StringHelper.FromJson<ConfigModel>(result);
            return 0;
        }

        public static int SaveConfig(ref ConfigModel config)
        {
            var path = SystemHelper.Combine(StartupPath, ConfigFileName);
            return StringHelper.ToJsonFile(config, path);
        }

        public static bool EnableTryLink(ref ConfigModel config)
        {
            var now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return config.StudentNet.AutoLink &&
                   now >= config.StudentNet.StartTime.Hour * 60 + config.StudentNet.StartTime.Minute &&
                   now < NightNotLink;
        }

        public static bool IsEmpty(ref ConfigModel config)
        {
            if (config == null) return true;
            if (config.NetType == 0 && config.RunAtStartup == false &&
                config.StudentNet.SettingCertify.Enable == false && config.StudentNet.SettingCertify.UserId == "" &&
                config.StudentNet.SettingCertify.Password == "" && config.StudentNet.SettingLink.Enable == false &&
                config.StudentNet.SettingLink.ServerIp == "" && config.StudentNet.SettingLink.UserId == "" &&
                config.StudentNet.SettingLink.Password == "" && config.StudentNet.SettingMail.Enable == false &&
                config.StudentNet.SettingMail.Address == "" && config.TeacherNet.SettingCertify.Enable == false &&
                config.TeacherNet.SettingCertify.UserId == "" &&
                config.TeacherNet.SettingCertify.Password == "") return true;

            return false;
        }

        public static void InitialConfig(ref ConfigModel config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            config = new ConfigModel
            {
                RunAtStartup = false,
                NetType = 0,
                StudentNet = new StudentNet
                {
                    StartTime = DateTime.Parse("08:00"),
                    LastLinkTime = DateTime.Now.AddDays(-1),
                    SettingCertify = new SettingCertify(),
                    SettingLink = new SettingLink(),
                    SettingMail = new SettingMail(),
                    AutoLink = false
                },
                TeacherNet = new TeacherNet
                {
                    SettingCertify = new SettingCertify()
                }
                //HasConfig = false,
            };
        }
    }
}