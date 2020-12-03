using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace SRLink.Helper
{
    public class SystemHelper
    {

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
            catch (Exception)
            {
                // ignored
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
            string startupPath = Global.StartupPath;
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

        /// <summary>
        /// 开机自动启动
        /// </summary>
        /// <param name="autoRunName"></param>
        /// <param name="run"></param>
        /// <param name="autoRunRegPath"></param>
        /// <returns></returns>
        public static void SetAutoRun(string autoRunRegPath, string autoRunName, bool run)
        {
            try
            {
                var processModule = Process.GetCurrentProcess().MainModule;
                if (processModule != null)
                {
                    string exePath = processModule.FileName;
                    RegWriteValue(autoRunRegPath, autoRunName, run ? exePath : "");
                }
            }
            catch (Exception)
            {
                // ignored
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
                var processModule = Process.GetCurrentProcess().MainModule;
                if (processModule != null)
                {
                    string exePath = processModule.FileName;
                    if (value?.Equals(exePath) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
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
            catch (Exception)
            {
                // ignored
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
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                regKey?.Close();
            }
            return def;
        }
        #endregion

        #region Cmd

        public static string ExecuteCommand(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //由调用程序获取输出信息
            p.StartInfo.RedirectStandardOutput = true;
            //重定向标准错误输出
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(cmd + "&exit");

            p.StandardInput.AutoFlush = true;

            string output = p.StandardOutput.ReadToEnd();

            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            return output;
        }

        #endregion

    }
}
