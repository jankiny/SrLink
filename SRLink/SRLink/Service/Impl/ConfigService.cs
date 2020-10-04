using System;
using SRLink.Model;

namespace SRLink.Service.Impl
{
    class ConfigService : IConfigService
    {
        public Config Config;
        public ConfigService()
        {
            Config = new Config();
        }

        /// <summary>
        /// 载入配置文件
        /// </summary>
        public Config LoadConfig()
        {
            return Config.GetAllAsync();
        }


        /// <summary>
        /// 保存参数
        /// </summary>
        /// <returns></returns>
        public int SaveConfig(Config config)
        {
            return Config.UpdateAsync(config);
        }

        public bool EnableTryLink()
        {
            int now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return (Config.AutoLink && now >= Config.StartTime.Hour * 60 + Config.StartTime.Minute && now < Global.NightNotLink);
        }

    }
}