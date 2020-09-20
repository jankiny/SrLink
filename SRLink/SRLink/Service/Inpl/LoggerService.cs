using System;
using System.IO;
using System.Windows.Forms; // 引用了Forms; Application需要

namespace SRLink.Service.Inpl
{
    public class LoggerService : ILogger
    {
        private readonly string LogDirectory;
        public LoggerService()
        {
            LogDirectory = Path.Combine(Application.StartupPath, "Logs");
        }
        public void SaveLog(string strContent)
        {
            try
            {
                var path = Path.Combine(LogDirectory, DateTime.Now.ToString("yyyyMM") + ".txt");
                //string path = Path.Combine(Environment.CurrentDirectory, "Logs");
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }
                if (!File.Exists(path))
                {
                    FileStream FsCreate = new FileStream(path, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                using (StreamWriter sWrite = new StreamWriter(fileStream))
                {
                    sWrite.WriteLine(
                        $"{"----------------------"}{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{"----------------------"}");
                    sWrite.Write(strContent);
                    sWrite.WriteLine(Environment.NewLine);
                    sWrite.Flush();
                    sWrite.Close();
                }
            }
            catch { }
        }
        public void SaveLog(string strTitle, Exception exc)
        {
            try
            {
                //string path = Path.Combine(Environment.CurrentDirectory, "Logs");
                string path = Path.Combine(LogDirectory, DateTime.Now.ToString("@yyyyMMdd-Exception") + ".txt");
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }
                if (!File.Exists(path))
                {
                    FileStream FsCreate = new FileStream(path, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                using (StreamWriter sWrite = new StreamWriter(fileStream))
                {
                    string strContent = exc.ToString();

                    sWrite.WriteLine(string.Format("{0}{1}[{2}]{3}", "----------------------", strTitle, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "----------------------"));
                    sWrite.Write(strContent);
                    sWrite.WriteLine(Environment.NewLine);
                    sWrite.WriteLine(" ");
                    sWrite.Flush();
                    sWrite.Close();
                }
            }
            catch { }
        }
    }
}
