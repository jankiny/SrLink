using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kit.Win
{
    public class ExeFile
    {
        public static bool Run(string path)
        {
            ProcessStartInfo startinfo = new ProcessStartInfo(path);
            Process p = Process.Start(startinfo);
            if (p == null)
                //throw new Exception("Warning:process may already exist");
                return false;
            return true;
        }
    }
}
