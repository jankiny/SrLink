using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using DotRas;
using SRLink.Helper;
using SRLink.Model;

namespace SRLink.Service
{ public class VpnService
    {
        private static readonly string AdapterName = StringHelper.GetAppString("AdapterName");
        private static readonly string PhoneBookPath = SystemHelper.Combine(Global.StartupPath, "SrLinkPhoneBook.pbk");


        public static void Connect(ref VpnModel vpnModel)
        {
            if (vpnModel == null)
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
                    phoneBook.Entries.Remove(AdapterName);
                }
                if (vpnModel.VpnProtocol.Contains("PPTP"))
                {
                    Entry = RasEntry.CreateVpnEntry(
                        AdapterName,
                        vpnModel.ServerIp,
                        RasVpnStrategy.PptpOnly,
                        RasDevice.GetDevices().First(o => o.DeviceType == RasDeviceType.Vpn));
                }
                else
                {
                    Entry = RasEntry.CreateVpnEntry(
                        AdapterName,
                        vpnModel.ServerIp,
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
                Global.Dialer.EntryName = AdapterName;
                //Dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
                Global.Dialer.PhoneBookPath = PhoneBookPath;
                Global.Dialer.Credentials = new NetworkCredential(vpnModel.UserName, vpnModel.PassWord);
            }
            Global.Handle = Global.Dialer.DialAsync();
        }

        public static bool Worked()
        {
            using (var phoneBook = new RasPhoneBook())
            {
                //PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers));
                phoneBook.Open(PhoneBookPath);

                if (phoneBook.Entries.Contains(AdapterName))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Disconnect()
        {
            if (Global.Dialer.IsBusy)
            {
                Global.Dialer.DialAsyncCancel();
            }
            else
            {
                if (Global.Handle != null)
                {
                    ReadOnlyCollection<RasConnection> connections = RasConnection.GetActiveConnections();
                    foreach (RasConnection connection in connections)
                    {
                        connection?.HangUp();
                    }
                }
            }

        }

        public static void Abort()
        {
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