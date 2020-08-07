using Kit.Utils;
using Kit.Win;
using SRLink.Model;
using System;
using System.Windows.Forms;

namespace SRLink.Handler
{
    public class ConfigHandler
    {
        private static readonly string configPath = Global.ConfigFileName;

        /// <summary>
        /// 载入配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int LoadConfig(ref Config config)
        {
            //载入配置文件 
            //string result = Json.LoadResource(Sys.GetPath(configPath)); 问题见Sys.GetPaht
            string result = Json.LoadResource(Sys.Combine(Application.StartupPath, configPath));
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
                    SettingMail = new SettingMail(),
                    AutoRun = false
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
            //Json.ToJsonFile(config, Sys.GetPath(configPath));
            Json.ToJsonFile(config, Sys.Combine(Application.StartupPath, configPath));

            return 0;
        }
    }
}
