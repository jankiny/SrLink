using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using DotRas;
using SRLink.Helper;
using SRLink.Model;

namespace SRLink.Service.Impl
{
    class VpnService : IVpnService
    {
        private readonly string AdapterName;
        private readonly string PhoneBookPath;

        private VpnModel VpnModel;
        // 连接VPN需要
        private readonly RasDialer Dialer;
        private RasHandle Handle;
        public VpnService()
        {
            Dialer = new RasDialer();
            AdapterName = Global.AdapterName;
            PhoneBookPath = StringHelper.Combine(Global.StartupPath, "SrLinkPhoneBook.pbk");
        }

        public void UpdateVpnModel(VpnModel vpnModel)
        {
            VpnModel = vpnModel;
        }
        //public VpnService(string serverIP, string adapterName, string userName, string passWord, string vpnProtocol, string preSharedKey)
        //{
        //    Dialer = new RasDialer();
        //    ServerIP = serverIP;
        //    AdapterName = adapterName;
        //    UserName = userName;
        //    PassWord = passWord;
        //    VpnProtocol = vpnProtocol;
        //    PreSharedKey = preSharedKey;
        //}

        public void Connect()
        {
            if (VpnModel == null)
            {
                return;
            }
            using (var phoneBook = new RasPhoneBook())
            {
                //PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers));
                phoneBook.Open(PhoneBookPath);
                RasEntry Entry;

                if (phoneBook.Entries.Contains(AdapterName))
                {
                    Disconnect();
                }
                if (VpnModel.VpnProtocol.Contains("PPTP"))
                {
                    Entry = RasEntry.CreateVpnEntry(
                        AdapterName,
                        VpnModel.ServerIP,
                        RasVpnStrategy.PptpOnly,
                        RasDevice.GetDevices().First(o => o.DeviceType == RasDeviceType.Vpn));
                }
                else
                {
                    Entry = RasEntry.CreateVpnEntry(
                        AdapterName,
                        VpnModel.ServerIP,
                        RasVpnStrategy.L2tpOnly,
                        RasDevice.GetDevices().First(o => o.DeviceType == RasDeviceType.Vpn));
                }

                phoneBook.Entries.Add(Entry);
                Entry.Options.PreviewDomain = false;
                Entry.Options.ShowDialingProgress = false;
                Entry.Options.PromoteAlternates = false;
                Entry.Options.DoNotNegotiateMultilink = false;

                //if (VpnProtocol.Equals("L2TP"))
                //{
                //    Entry.Options.UsePreSharedKey = true;
                //    Entry.UpdateCredentials(RasPreSharedKey.Client, PreSharedKey);
                //    Entry.Update();
                //}

                Dialer.EntryName = AdapterName;
                //Dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
                Dialer.PhoneBookPath = PhoneBookPath;
                Dialer.Credentials = new NetworkCredential(VpnModel.UserName, VpnModel.PassWord);
            }
            Handle = Dialer.DialAsync();
        }

        public void Disconnect()
        {
            //if (Dialer.IsBusy)
            //{
            //    Dialer.DialAsyncCancel();
            //}
            //else
            //{
            //    if (Handle != null)
            //    {
            //        ReadOnlyCollection<RasConnection> connections = RasConnection.GetActiveConnections();
            //        foreach (RasConnection connection in connections)
            //        {
            //            connection?.HangUp();
            //        }
            //    }
            //}

            var connections = RasConnection.GetActiveConnections();
            foreach (var connection in connections)
            {
                if (connection.EntryName == AdapterName)
                {
                    connection?.HangUp();
                }
            }

            using (var phoneBook = new RasPhoneBook())
            {
                //PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers));
                phoneBook.Open(PhoneBookPath);

                if (phoneBook.Entries.Contains(AdapterName))
                {
                    phoneBook.Entries.Remove(AdapterName);
                }
            }
        }
    }
}