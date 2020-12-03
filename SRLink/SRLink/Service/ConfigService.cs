using System;
using SRLink.Helper;
using SRLink.Model;

namespace SRLink.Service
{
    class ConfigService
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
            int now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return config.StudentNet.AutoLink && now >= config.StudentNet.StartTime.Hour * 60 + config.StudentNet.StartTime.Minute && now < NightNotLink;
        }
    }
}