using System;
using System.Drawing;
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
            if (Config == null)
            {
                ShowTip(ToolTipIcon.Info, "欢迎使用SrLink", "第一次启动请先到配置页面设置连接信息。");
                Config = new Config
                {
                    //HasConfig = false,
                    StartTime = DateTime.Parse("08:00"),
                    LastLinkTime = DateTime.Now.AddDays(-1),
                    SettingCertify = new SettingCertify(),
                    SettingLink = new SettingLink(),
                    SettingMail = new SettingMail(),
                    RunAtStartup = false
                };
            }

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
                        if (!res) ShowTip(ToolTipIcon.Error, "连接失败", "网络认证失败");
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

        #region Timer事件

        private void TMR_SrLink_Tick(object sender, EventArgs e)
        {
            try
            {
                断开连接ToolStripMenuItem.Visible = SrLinkService.Linked;
                立即连接ToolStripMenuItem.Visible = !SrLinkService.Linked;
                TryLink();
            }
            catch (Exception err)
            {
                Logger.SaveLog("TMR_SrLink_Tick", err);
            }
        }

        #endregion

        #region From事件

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
                ShowScreen(new SubFrmNormal());

                // TODO: Linked判断以到TryAutoLink()中
                TryLink();
            }
            catch (Exception err)
            {
                Logger.SaveLog("FRM_Main_Load", err);
            }
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Minimized) ShowInTaskbar = false;
            }
            catch (Exception err)
            {
                Logger.SaveLog("FrmMain_SizeChanged", err);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    WindowState = FormWindowState.Minimized;
                }
            }
            catch (Exception err)
            {
                Logger.SaveLog("FrmMain_SizeChanged", err);
            }
        }

        #endregion

        #region 状态栏

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                    Activate();
                    ShowInTaskbar = true;
                }
            }
            catch (Exception err)
            {
                Logger.SaveLog("NotifyIcon_DoubleClick", err);
            }
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SrLinkService.Linked)
                    SrLinkService.DisconnectVpn();
                else
                    ShowTip(ToolTipIcon.Warning, "无效操作", "网络还未连接");
            }
            catch (Exception err)
            {
                Logger.SaveLog("断开连接ToolStripMenuItem_Click", err);
            }
        }

        private void 立即连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SrLinkService.Linked)
                    ShowTip(ToolTipIcon.Warning, "无效操作", "网络已连接");
                else
                    TryLink(true);
            }
            catch (Exception err)
            {
                Logger.SaveLog("立即连接ToolStripMenuItem_Click", err);
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                    Activate();
                    ShowInTaskbar = true;
                }
            }
            catch (Exception err)
            {
                Logger.SaveLog("显示ToolStripMenuItem_Click", err);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception err)
            {
                Logger.SaveLog("退出ToolStripMenuItem_Click", err);
                Environment.Exit(0);
            }
        }

        private void ShowTip(ToolTipIcon icon, string title, string text)
        {
            NotifyIcon.ShowBalloonTip(3000, title, text, icon);
        }

        #endregion

        #region ListView事件

        private void LVW_Menu_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in LVW_Menu.Items) item.BackColor = Color.WhiteSmoke; //遍历每个菜单栏的颜色

                if (e.Button == MouseButtons.Left)
                    if (LVW_Menu.SelectedItems.Count > 0)
                    {
                        LVW_Menu.Items[LVW_Menu.FocusedItem.Index].BackColor = Color.LightGray; //设置选中菜单栏的颜色
                        var choose = LVW_Menu.Items[LVW_Menu.FocusedItem.Index].Text; //选中菜单栏的文本
                        ChangePanel(choose.Trim()); //根据文本名称进行相应的展示
                    }
            }
            catch (Exception err)
            {
                Logger.SaveLog("LVW_Menu_MouseClick", err);
            }
        }

        private void ChangePanel(string name)
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
    }

    #endregion
}