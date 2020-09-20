using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Service
{
    public interface ILogger
    {
        void SaveLog(string strContent);
        void SaveLog(string strTitle, Exception exc);
    }
}
