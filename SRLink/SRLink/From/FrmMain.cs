using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Model;
using SRLink.Service.Impl;

namespace SRLink.From
{
    public partial class FrmMain : BaseForm
    {
        public SrLinkService SrLinkService;

        public FrmMain()
        {
            InitializeComponent();
            Config = ConfigService.LoadConfig();
            SrLinkService = new SrLinkService(Config, ConfigService);

            Application.ApplicationExit += (sender, args) =>
            {
                //Config.HasConfig = true;
                SrLinkService.DisconnectVpn();
                ConfigService.SaveConfig(Config);
                //await Task.Run(() => );
            };
        }

        #region 连接事件


        public async void TryLink(bool force = false)
        {
            if (SrLinkService.Linked) return;
            if (SrLinkService.Running) return;
            await Task.Run(async () =>
            {
                SrLinkService.Running = true;
                if (ConfigService.EnableTryLink() || force)
                {
                    if (SrLinkService.SettingEnable("Certify"))
                    {
                        var res = await SrLinkService.RegisterSchoolNet();
                        if(!res) ShowTip(ToolTipIcon.Error, "连接失败", "网络认证失败");
                    }

                    if (SrLinkService.SettingEnable("Link"))
                    {
                        var res = await SrLinkService.LinkVpn();
                        var resTitle = res ? "连接成功" : "连接失败";
                        var resText = res ? $"{Global.AdapterName}已连接" : "连接失败";

                        ShowTip(ToolTipIcon.Info, resTitle, resText);
                    }

                    if (SrLinkService.SettingEnable("Mail"))
                    {
                        var res = await SrLinkService.SendIp();
                        if (!res) ShowTip(ToolTipIcon.Error, "Ip发送失败", "响应超时");
                    }
                }
                SrLinkService.Running = false;
            });
        }

        #endregion

        #region From事件

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowScreen(new SubFrmNormal());

            // TODO: Linked判断以到TryAutoLink()中
            TryLink();
        }
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        #endregion

        #region 状态栏
        
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
        }
        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SrLinkService.Linked)
            {
                SrLinkService.DisconnectVpn();
            }
            else
            {
                ShowTip(ToolTipIcon.Warning, "无效操作", "网络还未连接");
            }
        }
        private void 立即连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SrLinkService.Linked)
            {
                ShowTip(ToolTipIcon.Warning, "无效操作", "网络已连接");
            }
            else
            {
                TryLink(true);
            }
        }
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
            //Environment.Exit(0);
        }

        private void ShowTip(ToolTipIcon icon, string title, string text)
        {
            NotifyIcon.ShowBalloonTip(3000, title, text, icon);
        }
        #endregion

        #region Timer事件

        private void TMR_SrLink_Tick(object sender, EventArgs e)
        {
            断开连接ToolStripMenuItem.Visible = SrLinkService.Linked;
            立即连接ToolStripMenuItem.Visible = !SrLinkService.Linked;
            TryLink();
        }

        #endregion

        #region ListView事件

        private void LVW_Menu_MouseClick(object sender, MouseEventArgs e)
        {
            {
                foreach (ListViewItem item in LVW_Menu.Items)
                {
                    item.BackColor = Color.WhiteSmoke; //遍历每个菜单栏的颜色
                }

                if (e.Button == MouseButtons.Left)
                {
                    if (LVW_Menu.SelectedItems.Count > 0)
                    {
                        LVW_Menu.Items[LVW_Menu.FocusedItem.Index].BackColor = Color.LightGray; //设置选中菜单栏的颜色
                        string choose = LVW_Menu.Items[LVW_Menu.FocusedItem.Index].Text; //选中菜单栏的文本
                        ChangePlanel(choose.Trim()); //根据文本名称进行相应的展示
                    }

                }
            }
        }

        private void ChangePlanel(string name)
        {
            switch (name)
            {
                case "常规":
                    ShowScreen(new SubFrmNormal());
                    break;
                case "连接器":
                    ShowScreen(new SubFrmSLink());
                    break;
                case "关于":
                    ShowScreen(new SubFrmAbout());
                    break;
            }

        }

        private void ShowScreen(Control ctl)
        {
            while (splitContainer1.Panel2.Controls.Count > 0)
                splitContainer1.Panel2.Controls[0].Dispose();
            // Support forms too:
            if (ctl is Form frm)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.BackColor = Color.White;
                frm.Visible = true;
            }

            //ctl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ctl);
        }
        #endregion

    }
}