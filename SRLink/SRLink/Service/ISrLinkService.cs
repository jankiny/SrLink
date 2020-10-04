using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Service
{
    public interface ISrLinkService
    {
        bool SettingEnable(string configName);
        Task<bool> RegisterSchoolNet(int times = 30);
        Task<bool> TestInternet(int times = 30);
        Task<bool> LinkVpn(int times = 30);
        Task<bool> SendIp(int times = 30);
        string TestMail(string address);
    }
}
