using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace SRLink.Helper
{
    public class ExeHelper
    {
        public const int BM_CLICK = 0xF5;
        /// <summary>
        /// 找到窗口
        /// </summary>
        /// <param name="lpClassName">窗口类名(例：Button)</param>
        /// <param name="lpWindowName">窗口标题</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 找到子窗口
        /// </summary>
        /// <param name="hwndParent">父窗口句柄（如果为空，则为桌面窗口）</param>
        /// <param name="hwndChildAfter">子窗口句柄（从该子窗口之后查找）</param>
        /// <param name="lpszClass">窗口类名(例：Button</param>
        /// <param name="lpszWindow">窗口标题</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        // 获取窗口大小及位置:需要调用方法GetWindowRect(IntPtr hWnd, ref RECT lpRect)
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }
        /// <summary>    
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的
        /// 窗口调用窗口程序，直到窗口程序处理完消息再返回。
        /// </summary>    
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>  
        /// <param name="msg">指定被发送的消息</param>    
        /// <param name="wParam">指定附加的消息指定信息</param>  
        /// <param name="lParam">指定附加的消息指定信息</param> 
        /// <returns></returns>  
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        [DllImport("User32")]
        public extern static bool GetCursorPos(out POINT p);

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        public enum MouseEventFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Wheel = 0x0800,
            Absolute = 0x8000
        }
        public static bool Run(string path)
        {
            ProcessStartInfo startinfo = new ProcessStartInfo(path);
            Process p = Process.Start(startinfo);
            if (p == null)
                //throw new Exception("Warning:process may already exist");
                return false;
            return true;
        }

        public static bool PerformClick(string title, string button_text)
        {
            IntPtr mainWindows = FindMainWindowHandle(title, 100, 25);

            //Console.WriteLine("Findding handle to button1");
            IntPtr butt = FindWindowEx(mainWindows, IntPtr.Zero, null, button_text);
            if (butt == IntPtr.Zero)
                //throw new Exception("Unable to find button1");
                return false;
            SendMessage(butt, BM_CLICK, 0, 0);
            SendMessage(butt, BM_CLICK, 0, 0);
            return true;
        }
        
        // 模拟鼠标点击屏幕的某个位置
        public static void PerformClick(string title, int x, int y)
        {
            IntPtr mainWindows = FindMainWindowHandle(title, 100, 25);
            RECT rect = new RECT();
            GetWindowRect(mainWindows, ref rect);
            x += rect.Left;
            y += rect.Top;
            POINT p = new POINT();
            GetCursorPos(out p);
            try
            {
                SetCursorPos(x, y);
                mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
            }
            finally
            {
                SetCursorPos(p.X, p.Y);
            }
        }
        //获得待测程序主窗体句柄
        public static IntPtr FindMainWindowHandle(string caption, int delay, int maxTries)
        {
            IntPtr mwh = IntPtr.Zero;
            bool formFound = false;
            int attempts = 0;
            while (!formFound && attempts < maxTries)
            {
                if (mwh == IntPtr.Zero)
                {
                    Thread.Sleep(delay);
                    ++attempts;
                    mwh = FindWindow(null, caption);
                }
                else
                {
                    formFound = true;
                }
            }

            if (mwh == IntPtr.Zero)
                //throw new Exception("Could not find main window");
                return mwh;
            else
                return mwh;
        }
    }
}
