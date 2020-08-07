using Kit.Utils;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Kit.Win
{
    public class Mouses
    {
        public const int BM_CLICK = 0xF5;
        /// <summary>
        /// 找到窗口
        /// </summary>
        /// <param name="lpClassName">窗口类名(例：Button)</param>
        /// <param name="lpWindowName">窗口标题</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 找到子窗口
        /// </summary>
        /// <param name="hwndParent">父窗口句柄（如果为空，则为桌面窗口）</param>
        /// <param name="hwndChildAfter">子窗口句柄（从该子窗口之后查找）</param>
        /// <param name="lpszClass">窗口类名(例：Button</param>
        /// <param name="lpszWindow">窗口标题</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        /// <summary>
        /// 获得待测程序主窗体句柄
        /// </summary>
        /// <param name="caption">窗体名</param>
        /// <param name="delay">检查下一个窗体的延迟</param>
        /// <param name="maxTries">最大尝试次数</param>
        /// <returns></returns>
        public static IntPtr FindMainWindowHandle(string caption, int delay, int maxTries)
        {
            IntPtr mwh = IntPtr.Zero;
            bool formFound = false;
            int attempts = 0;
            try
            {
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
                    throw new Exception("Could not find main window");
            }
            catch (Exception e)
            {
                Log.SaveLog("FindMainWindowHandle", e);
            }
            return mwh;
        }

        /// <summary>
        /// 获取窗口大小及位置
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="lpRect">返回窗体左上角的位置信息</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

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

        /// <summary>
        /// 鼠标事件
        /// </summary>
        /// <param name="dwFlags">鼠标事件<see cref="MouseEventFlags"/>之一或它们的组合</param>
        /// <param name="dx">根据MOUSEEVENTF_ABSOLUTE标志，指定x方向的绝对位置或相对位置</param>
        /// <param name="dy">根据MOUSEEVENTF_ABSOLUTE标志，指定y方向的绝对位置或相对位置</param>
        /// <param name="dwData"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        /// <summary>
        /// 该函数把光标移到屏幕的指定位置
        /// </summary>
        /// <param name="x">指定光标的新的X坐标，以屏幕坐标表示</param>
        /// <param name="y">指定光标的新的Y坐标，以屏幕坐标表示</param>
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        /// <summary>
        /// 获取鼠标指针的当前位置
        /// </summary>
        /// <param name="p">返回的鼠标指针位置</param>
        /// <returns></returns>
        [DllImport("User32")]
        public extern static bool GetCursorPos(out POINT p);

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

        /// <summary>
        /// 鼠标通过消息点击按钮
        /// </summary>
        /// <param name="title">窗体名</param>
        /// <param name="button_text">按钮的text值</param>
        /// <returns></returns>
        public static bool PerformClick(string title, string button_text)
        {
            try
            {
                IntPtr mainWindows = FindMainWindowHandle(title, 100, 25);

                //Console.WriteLine("Findding handle to button1");
                IntPtr butt = FindWindowEx(mainWindows, IntPtr.Zero, null, button_text);
                if (butt == IntPtr.Zero)
                    throw new Exception("Unable to find button");
                SendMessage(butt, BM_CLICK, 0, 0);
                SendMessage(butt, BM_CLICK, 0, 0);
                return true;
            }
            catch (Exception e)
            {
                Log.SaveLog("PerformClick", e);
                return false;
            }
        }

        /// <summary>
        /// 鼠标点击一次窗体的某个位置
        /// </summary>
        /// <param name="title">窗体名</param>
        /// <param name="x">相对于左上角，点击的x坐标</param>
        /// <param name="y">相对于左上角，点击的y坐标</param>
        public static bool PerformClick(string title, int x, int y)
        {
            try
            {
                IntPtr mainWindows = FindMainWindowHandle(title, 100, 25);
                RECT rect = new RECT();
                GetWindowRect(mainWindows, ref rect);
                x += rect.Left;
                y += rect.Top;
                GetCursorPos(out POINT p);
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
                return true;
            }
            catch (Exception e)
            {
                Log.SaveLog("PerformClick", e);
                return false;
            }
        }
    }
}
