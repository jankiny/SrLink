using System.Windows.Forms;
using DotRas;

namespace SRLink
{
    public class Global
    {
        #region 全局变量
        /// <summary>
        /// 启动程序所在位置
        /// </summary>
        public static string StartupPath { get => Application.StartupPath; }

        public static System.Threading.Mutex MutexObj { get; set; }
        //public static bool Linked { get; set; } = true;
        //public static bool Running { get; set; } = false;
        //public static bool Linked { get; set; } = false;
        //public static bool Running { get; set; } = false;
        public static RasDialer Dialer { get; set; } = new RasDialer();
        public static RasHandle Handle { get; set; }
        #endregion

    }

}
