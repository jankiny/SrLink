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

    }
}