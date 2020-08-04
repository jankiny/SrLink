﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kit.Utils
{
    public static class Cmd
    {
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
    }
}
