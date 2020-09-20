using System;
using System.Threading.Tasks;
using SRLink.Model;
using System.Windows.Forms;
using Kit.Utils;
using Kit.Win;
using SRLink.Service;
using SRLink.Service.Inpl;

namespace SRLink.From
{
    public partial class BaseForm : Form
    {
        private readonly string _configPath;
        public readonly ILogger Logger;
        public Config Config;
        public readonly FrmLinkInfo FrmLinkInfo;
        public BaseForm()
        {
            _configPath = Sys.Combine(Application.StartupPath, Global.ConfigFileName);
            Logger = new LoggerService();
            FrmLinkInfo = new FrmLinkInfo();
            LoadConfig();
            InitializeComponent();
        }
        /// <summary>
        /// 载入配置文件
        /// </summary>
        public void LoadConfig()
        {
            //载入配置文件 
            //string result = Json.LoadResource(Sys.GetPath(configPath)); 问题见Sys.GetPaht
            string result = Json.LoadResource(_configPath);
            if (!string.IsNullOrEmpty(result))
            {
                //转成Json
                Config = Json.FromJson<Config>(result);
            }
            if (Config == null)
            {
                Config = new Config
                {
                    HasConfig = false,
                    StartTime = DateTime.Parse("08:00"),
                    LastLinkTime = DateTime.Now.AddDays(-1),
                    SettingCertify = new SettingCertify(),
                    SettingLink = new SettingLink(),
                    SettingMail = new SettingMail(),
                    RunAtStartup = false
                };
            }
        }

        /// <summary>
        /// 保参数
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveConfigAsync()
        {
            //Json.ToJsonFile(config, Sys.GetPath(configPath));
            return await Task.Run(() => Json.ToJsonFile(Config, _configPath));
        }
    }
}
