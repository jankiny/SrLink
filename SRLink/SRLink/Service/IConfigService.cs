using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRLink.Model;

namespace SRLink.Service
{
    public interface IConfigService
    {
        //void SetHasConfig(bool has);
        //bool GetHasConfig();
        Config LoadConfig();
        int SaveConfig(Config config);
        bool EnableTryLink();
    }
}
