using System;
using System.IO;

namespace Kit.Utils
{
    public class Log
    {
        public static void SaveLog(string strContent)
        {
            SaveLog("info", new Exception(strContent));
        }
        public static void SaveLog(string strTitle, Exception exc)
        {
            try
            {
                //string path = Path.Combine(Application.StartupPath, "guiLogs");
                string path = Path.Combine(Environment.CurrentDirectory, "guiLogs");
                string filePath = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");
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

                    sWrite.WriteLine(string.Format("{0}{1}[{2}]{3}", "--------------------------------", strTitle, DateTime.Now.ToString("HH:mm:ss"), "--------------------------------"));
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
