using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Service
{
    public interface ISrLinkService
    {
        bool RegisterSchoolNet(out string msg);
        bool IsConnectInternet();
        bool LinkVpn(out string msg);
        bool SendIp(out string msg);
        string TestMail(string address);
    }
}
