using SRLink.Model;

namespace SRLink.Service
{
    interface IVpnService
    {
        void UpdateVpnModel(VpnModel vpnModel);
        void Connect();
        void Disconnect();
    }
}
