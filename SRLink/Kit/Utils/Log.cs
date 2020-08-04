using System;
using System.IO;

namespace Kit.Utils
{
    public class Log
    {
        public static void SaveLog(string strContent)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Logs");
                string filePath = Path.Combine(path, DateTime.Now.ToString("yyyyMM") + ".txt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(filePath))
                {
                    FileStream FsCreate = new FileStream(filePath, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                using (StreamWriter sWrite = new StreamWriter(fileStream))
                {
                    sWrite.WriteLine(string.Format("{0}{1}{2}", "----------------------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "----------------------"));
                    sWrite.Write(strContent);
                    sWrite.WriteLine(Environment.NewLine);
                    sWrite.Flush();
                    sWrite.Close();
                }
            }
            catch { }
        }
        public static void SaveLog(string strTitle, Exception exc)
        {
            try
            {
                //string path = Path.Combine(Application.StartupPath, "Logs");
                string path = Path.Combine(Environment.CurrentDirectory, "Logs");
                string filePath = Path.Combine(path, DateTime.Now.ToString("@yyyyMMdd-Exception") + ".txt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(filePath))
                {
                    FileStream FsCreate = new FileStream(filePath, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
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
