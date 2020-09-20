using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using DotRas;

namespace SRLink.Handler
{
    public class VPN
    {
        //RasAutoDialManager- 此组件与 Windows RAS 自动Dial 管理器进行交互。
        //RasConnectionWatcher - 此组件监视计算机上处于活动状态的连接，这是此项目的独特功能。您不会在其他地方找到此组件！
        //RasDialDialog - 此组件显示用于拨号连接的用户界面。
        //RasDialer - 此组件旨在拨打 Windows 可以自行拨号的任何类型的连接。但是，自定义 VPN 连接（如思科 VPN 系统）不使用 Windows 来拨号连接，因此无法从该项目拨打。
        //RasEntryDialog - 此组件显示用于创建或修改电话簿条目的用户界面。
        //RasPhoneBook - 此组件旨在操作 Windows 电话簿。通过此类完成添加、删除和修改条目。您还可以修改与条目一起存储的凭据。
        //RasPhoneBookDialog - 此组件显示主拨号网络对话框。

        private readonly RasDialer Dialer;
        private RasHandle Handle;

        #region 属性
        /// <summary>
        /// 连接器名
        /// </summary>
        private string AdapterName
        {
            get; set;
        }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        private string ServerIP
        {
            get; set;
        }
        /// <summary>
        /// 登录用户名
        /// </summary>
        private string UserName
        {
            get; set;
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        private string PassWord
        {
            get; set;
        }
        /// <summary>
        /// VPN协议
        /// </summary>
        private string VpnProtocol
        {
            get; set;
        }
        /// <summary>
        /// 预共享密钥
        /// </summary>
        private string PreSharedKey
        {
            get; set;
        }
        #endregion
        public VPN(string serverIP, string adapterName, string userName, string passWord, string vpnProtocol)
        {
            Dialer = new RasDialer();
            ServerIP = serverIP;
            AdapterName = adapterName;
            UserName = userName;
            PassWord = passWord;
            VpnProtocol = vpnProtocol;
        }

        public VPN(string serverIP, string adapterName, string userName, string passWord, string vpnProtocol, string preSharedKey)
        {
            Dialer = new RasDialer();
            ServerIP = serverIP;
            AdapterName = adapterName;
            UserName = userName;
            PassWord = passWord;
            VpnProtocol = vpnProtocol;
            PreSharedKey = preSharedKey;
        }

        public void Connect()
        {
            using (RasPhoneBook PhoneBook = new RasPhoneBook())
            {
                PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers));
                RasEntry Entry;

                if (PhoneBook.Entries.Contains(AdapterName))
                {
                    PhoneBook.Entries.Remove(AdapterName);
                }
                if (VpnProtocol.Contains("PPTP"))
                {
                    Entry = RasEntry.CreateVpnEntry(
                        AdapterName, 
                        ServerIP, 
                        RasVpnStrategy.PptpOnly,
                        RasDevice.GetDevices().First(o => o.DeviceType == RasDeviceType.Vpn));
                }
                else
                {
                    Entry = RasEntry.CreateVpnEntry(
                        AdapterName, 
                        ServerIP, 
                        RasVpnStrategy.L2tpOnly,
                        RasDevice.GetDevices().First(o => o.DeviceType == RasDeviceType.Vpn));
                }

                PhoneBook.Entries.Add(Entry);
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
                Dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
                Dialer.Credentials = new NetworkCredential(UserName, PassWord);
            }
            Handle = Dialer.DialAsync();
        }

        public void Disconnect()
        {
            if (Dialer.IsBusy)
            {
                Dialer.DialAsyncCancel();
            }
            else
            {
                if (Handle != null)
                {
                    ReadOnlyCollection<RasConnection> connections = RasConnection.GetActiveConnections();
                    foreach(RasConnection connection in connections)
                    {
                        if (connection != null)
                        {
                            connection.HangUp();
                        }
                    }
                }
            }

            using (RasPhoneBook PhoneBook = new RasPhoneBook())
            {
                PhoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers));

                if (PhoneBook.Entries.Contains(AdapterName))
                {
                    PhoneBook.Entries.Remove(AdapterName);
                }
            }
        }
    }
}
