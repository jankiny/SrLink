using Kit.Utils;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace Kit.Win
{
    public class Sys
    {
        /// <summary>
        /// 开机自动启动
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>
        public static void SetAutoRun(string autoRunRegPath, string autoRunName, bool run)
        {
            try
            {
                string exePath = Process.GetCurrentProcess().MainModule.FileName;
                RegWriteValue(autoRunRegPath, autoRunName, run ? exePath : "");
            }
            catch (Exception e)
            {
                Log.SaveLog("SetAutoRun", e);
            }
        }

        /// <summary>
        /// 是否已经设置开机自动启动
        /// </summary>
        /// <returns></returns>
        public static bool IsAutoRun(string autoRunRegPath, string autoRunName)
        {
            try
            {
                string value = RegReadValue(autoRunRegPath, autoRunName, "");
                string exePath = Process.GetCurrentProcess().MainModule.FileName;
                if (value?.Equals(exePath) == true)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.SaveLog("IsAutoRun", e);
            }
            return false;
        }

        /// <summary>
        /// 运行程序
        /// </summary>
        /// <param name="path">程序位置</param>
        /// <returns></returns>
        public static bool RunExeFile(string path)
        {
            try
            {
                ProcessStartInfo startinfo = new ProcessStartInfo(path);
                Process p = Process.Start(startinfo);
                if (p == null)
                    //throw new Exception("Warning:process may already exist");
                    return false;
                return true;
            }
            catch (Exception e)
            {
                Log.SaveLog("RunExeFile", e);
                return false;
            }
        }

        /// <summary>
        /// 获取启动了应用程序的可执行文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetPath(string fileName)
        {
            // 问题：开机启动时，Environment.CurrentDirectory不能获取到应用程序的目录。
            // 先直接在窗体应用里使用 Application
            string startupPath = Environment.CurrentDirectory;
            if (string.IsNullOrEmpty(fileName))
            {
                return startupPath;
            }
            return Path.Combine(startupPath, fileName);
        }

        public static string Combine(string filePath, string fileName)
        {
            return Path.Combine(filePath, fileName);
        }
        #region 注册表
        public static void RegWriteValue(string path, string name, string value)
        {
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.CurrentUser.CreateSubKey(path);
                if (string.IsNullOrEmpty(value))
                {
                    regKey?.DeleteValue(name, false);
                }
                else
                {
                    regKey?.SetValue(name, value);
                }
            }
            catch (Exception e)
            {
                Log.SaveLog("RegWriteValue", e);
            }
            finally
            {
                regKey?.Close();
            }
        }
        public static string RegReadValue(string path, string name, string def)
        {
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.CurrentUser.OpenSubKey(path, false);
                string value = regKey?.GetValue(name) as string;
                if (string.IsNullOrEmpty(value))
                {
                    return def;
                }
                else
                {
                    return value;
                }
            }
            catch (Exception e)
            {
                Log.SaveLog("RegReadValue", e);
            }
            finally
            {
                regKey?.Close();
            }
            return def;
        }
        #endregion
    }
}
