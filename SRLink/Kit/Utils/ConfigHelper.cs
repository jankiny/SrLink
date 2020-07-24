using System.Configuration;

namespace SRLink.Helper
{
    public class ConfigHelper
    {
        public string AppExecPath;

        public ConfigHelper(string appExecPath)
        {
            // 外界传入，参考语句：System.Windows.Forms.Application.ExecutablePath
            AppExecPath = appExecPath;
        }

        public string GetAppConfig(string strKey)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(this.AppExecPath);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value.ToString();
                }
            }
            return null;
        }

        public bool ExistInAppConfig(string strKey)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(this.AppExecPath);
            foreach (string k in config.AppSettings.Settings.AllKeys)
            {
                if (k == strKey)
                {
                    return true;
                }
            }
            return false;
        }

        public void NewAppConfig(string newKey, string newValue)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(this.AppExecPath);
                config.AppSettings.Settings.Add(newKey, newValue);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return;
            }
            catch
            {
                UpdateAppConfig(newKey, newValue);
            }
        }

        public bool UpdateAppConfig(string key, string newValue)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(this.AppExecPath);
                if (ExistInAppConfig(key))
                {
                    config.AppSettings.Settings.Remove(key);
                }
                config.AppSettings.Settings.Add(key, newValue);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
