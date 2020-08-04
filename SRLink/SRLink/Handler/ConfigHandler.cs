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
    }
}
