using System;
using System.Configuration;
using SRLink.Model;

namespace SRLink.Service.Impl
{
    class ConfigService : IConfigService
    {
        public ConfigModel Config;
        public ConfigService()
        {
            Config = new ConfigModel();
        }

        /// <summary>
        /// 载入配置文件
        /// </summary>
        public ConfigModel LoadConfig()
        {
            return Config.GetAllAsync();
        }


        /// <summary>
        /// 保存参数
        /// </summary>
        /// <returns></returns>
        public int SaveConfig(ConfigModel config)
        {
            return Config.UpdateAsync(config);
        }

    }
}