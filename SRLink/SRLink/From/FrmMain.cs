using System;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Model;
using SRLink.Service;
using SRLink.Service.Impl;

namespace SRLink.From
{
    public partial class FrmMain : BaseForm
    {
        public FrmDebug FrmDebug;
        public ISrLinkService SrLinkService;

        public FrmMain()
        {
            InitializeComponent();

            Config = ConfigService.LoadConfig();
            if (Config == null)
            {
                ShowTip(ToolTipIcon.Info, "欢迎使用SrLink", "第一次启动请先到配置页面设置连接信息。", false);
                Config = new ConfigModel
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
            FrmDebug = new FrmDebug();

            //TMR_SrLink.Enabled = Config.AutoLink;


            //Application.ApplicationExit += (sender, args) =>
            //{
            //    //Config.HasConfig = true;
            //    SrLinkService.DisconnectVpn();
            //    FrmDebug.Dispose();
            //    ConfigService.SaveConfig(Config);
            //    //await Task.Run(() => );
            //};
        }

        #region 连接事件

        public async void TryLink(bool force = false)
        {
            if (SrLinkService.GetLinked())
            {
                FrmDebug.WriteToBoard($"Linked = {SrLinkService.GetLinked()} 检测到网络已连接，停止计时器事件，结束");
                // Todo: 停用TMR计时器后，之后无法开启
                TMR_SrLink.Enabled = false;
                return;
            }
            FrmDebug.WriteToBoard($"Linked = {SrLinkService.GetLinked()} 网络未连接 - 可连接");
            if (SrLinkService.GetRunning())
            {
                FrmDebug.WriteToBoard($"Running = {SrLinkService.GetRunning()} 检测到线程忙，结束");
                return;
            }
            FrmDebug.WriteToBoard($"Running = {SrLinkService.GetRunning()} 线程空闲 - 可连接");

            if (!Config.EnableTryLink() && !force)
            {
                FrmDebug.WriteToBoard($"EnableTryLink = {Config.EnableTryLink()} 未启用自动连接，结束");
                return;
            }
            FrmDebug.WriteToBoard($"EnableTryLink = {Config.EnableTryLink()}, force = {force} 开始执行连接");

            //await Task.Run(async () =>
            //{
            //});

            SrLinkService.SetRunning(true);

            if (SrLinkService.SettingEnable("Certify"))
            {
                var res = await SrLinkService.RegisterSchoolNet();
                if (res)
                    FrmDebug.WriteToBoard("认证成功");
                else
                    ShowTip(ToolTipIcon.Error, "认证失败", "内网认证失败");
            }

            if (SrLinkService.SettingEnable("Link"))
            {
                var res = await SrLinkService.LinkVpn();
                // Todo: 考虑一下是否添加自动重连功能
                //if (res) TMR_SrLink.Enabled = false; // 连接成功后关闭定时器，否则手动断开连接后会自动重连（转移到在Timer事件中控制）
                if (res)
                {
                    ShowTip(ToolTipIcon.Info, "连接成功", $"{Global.AdapterName}已连接");
                }
                else
                {
                    Config.AutoLink = false;
                    ShowTip(ToolTipIcon.Info, "连接失败", "已取消自动连接。请检查配置信息，并使用手动连接测试配置，连接成功后再重新开启自动连接。");
                }
            }

            if (SrLinkService.SettingEnable("Mail"))
            {
                var res = await SrLinkService.SendIp();
                if (res)
                    FrmDebug.WriteToBoard("Ip发送成功");
                else
                    ShowTip(ToolTipIcon.Error, "Ip发送失败", "响应超时");
            }


            SrLinkService.SetRunning(false);
            FrmDebug.WriteToBoard("连接结束");
        }

        #endregion

        #region Timer事件

        private void TMR_SrLink_Tick(object sender, EventArgs e)
        {
            try
            {
                断开连接ToolStripMenuItem.Visible = SrLinkService.GetLinked();
                立即连接ToolStripMenuItem.Visible = !SrLinkService.GetLinked();
                if (Config.AutoLink)
                {
                    TryLink();
                }
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
                ShowScreen(new SubFrmNormal(FrmDebug));
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
            FrmDebug.WriteToBoard("(用户操作)执行断开连接");
            try
            {
                if (SrLinkService.GetLinked())
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
            FrmDebug.WriteToBoard("(用户操作)执行立即连接");
            try
            {
                if (SrLinkService.GetLinked())
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
                SrLinkService.DisconnectVpn();
                FrmDebug.Dispose();
                ConfigService.SaveConfig(Config);
                Application.Exit();
            }
            catch (Exception err)
            {
                Logger.SaveLog("退出ToolStripMenuItem_Click", err);
                Environment.Exit(0);
            }
        }

        private void ShowTip(ToolTipIcon icon, string title, string text, bool debug = true)
        {
            NotifyIcon.ShowBalloonTip(3000, title, text, icon);
            if (debug) FrmDebug.WriteToBoard($"显示提示：{text}");
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
                    ShowScreen(new SubFrmNormal(FrmDebug));
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