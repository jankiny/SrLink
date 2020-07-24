using System.Threading;
using Kit.Win;
using Kit.Utils;
using SRLink.Model;

namespace SRLink.Handler
{
    public class LinkHandler : HandlerBase
    {
        readonly Setting_Link Setting;
        public LinkHandler(Setting_Link setting_Link, int count = 60, int delay = 3000, EHandler mode = EHandler.Test)
        {
            HandleName = "连接网络";
            Setting = setting_Link;
            Count = count;
            Delay = delay;
            Mode = mode;
        }
        public bool OpenSuiEXing()
        {
            if (ExeFile.Run(Setting.Path))
            {
                // 关闭非管理员启动的提示
                Mouses.PerformClick("提示", "确定");
                return true;
            }
            return false;
        }
        public bool LinkSuiEXing(out string msg)
        {
            if (!Ready())
            {
                msg = "配置出错";
                return false;
            }
            if (!OpenSuiEXing())
            {
                msg = "程序打开失败";
                return false;
            }
            Thread.Sleep(3000);
            TryClick(Setting.X, Setting.Y);
            Thread.Sleep(7000);
            if (!IsConnectInternet())
            {
                msg = "无法连接到网络";
                return false;
            }
            else
            {
                msg = "连接成功";
                return true;
            }
        }
        public void TryClick(int x, int y)
        {
            Mouses.PerformClick("哈哈哈哈哈", x, y);
        }
        public bool IsConnectInternet()
        {
            return Web.IsConnectInternet();
        }
        public override bool Run(out string msg)
        {
            return LinkSuiEXing(out msg);
        }
        public override bool Ready()
        {
            if (Mode == EHandler.Work && Setting.GetConfigReady())
            {
                return true;
            }
            else if (Mode == EHandler.Test)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
