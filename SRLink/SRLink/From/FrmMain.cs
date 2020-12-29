using System;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Helper;
using SRLink.Model;
using SRLink.Service;

namespace SRLink.From
{
    public partial class FrmMain : BaseForm
    {
        private readonly FrmDebug _frmDebug;

        public FrmMain()
        {
            InitializeComponent();
            Config = new ConfigModel();
            ConfigService.LoadConfig(ref Config);
            if (ConfigService.IsEmpty(ref Config))
            {
                ShowTip(ToolTipIcon.Info, "欢迎使用SrLink", "检测到当前配置为空，请先到配置页面设置连接信息。", false);
                ConfigService.InitialConfig(ref Config);
            }

            _frmDebug = new FrmDebug();

            //TMR_SrLink.Enabled = Config.AutoLink;

            Application.ApplicationExit += (sender, args) =>
            {
                SrLinkService.DisconnectVpn();
                _frmDebug.Dispose();
                ConfigService.SaveConfig(ref Config);
            };
        }

        #region 连接事件

        private void TryLinkTeacher()
        {
            if (VpnService.Worked())
            {
                if (MessageBox.Show("警告：如果切换网络类型，会断开当前网络。是否切换？", "当前网络正在使用", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;
                VpnService.Abort();
            }
            if (SrLinkService.RegisterSchoolNet(Config.TeacherNet.SettingCertify.UserId,
                Config.TeacherNet.SettingCertify.Password))
            {
                Config.NetType = 1;
                ShowTip(ToolTipIcon.Info, "切换到教师网", $"{Config.TeacherNet.SettingCertify.UserId}登录成功",
                    false);
            }
            else
            {
                Config.NetType = 0;
                ShowTip(ToolTipIcon.Error, "切换到教师网", "登录失败：用户名/密码错误。请进入配置页面手动尝试。", false);
            }
            ConfigService.SaveConfig(ref Config);
        }

        private async void TryLinkStudent(bool force = false)
        {
            //if (Global.Linked)
            //{
            //    _frmDebug.WriteToBoard($"Linked = {Global.Linked} 检测到网络已连接，停止计时器事件，结束");
            //    TMR_SrLink.Enabled = false;
            //    return;
            //}

            //_frmDebug.WriteToBoard($"Linked = {Global.Linked} 网络未连接 - 可连接");
            //if (Global.Running)
            //{
            //    _frmDebug.WriteToBoard($"Running = {Global.Running} 检测到线程忙，结束");
            //    return;
            //}
            // TODO: 可能会出现问题，Vpn虽然忙但并不是在连接，可能导致永远不会进入连接
            if (VpnService.Worked())
            {
                _frmDebug.WriteToBoard($"检测到线程忙，结束");
                return;
            }

            //_frmDebug.WriteToBoard($"Running = {Global.Running} 线程空闲 - 可连接");

            if (!ConfigService.EnableTryLink(ref Config) && !force)
            {
                // 这句提示不应该出现
                _frmDebug.WriteToBoard($"EnableTryLink = {ConfigService.EnableTryLink(ref Config)} 未启用自动连接，结束");
                return;
            }


            _frmDebug.WriteToBoard(
                $"EnableTryLink = {ConfigService.EnableTryLink(ref Config)}, force = {force} 开始执行连接");

            //Global.Running = true;
            ShowTip(ToolTipIcon.None, "L2TP连接中", "请耐心等待");

            if (SrLinkService.SettingEnable(ref Config, "Certify"))
            {
                var res = await SrLinkService.RegisterSchoolNetAsync(Config.StudentNet.SettingCertify.UserId,
                    Config.StudentNet.SettingCertify.Password);
                if (res)
                    _frmDebug.WriteToBoard("认证成功");
                else
                    ShowTip(ToolTipIcon.Error, "认证失败", "内网认证失败");
            }

            if (SrLinkService.SettingEnable(ref Config, "Link"))
            {
                var res = SrLinkService.LinkVpnAsync(Config.StudentNet.SettingLink.ServerIp,
                    Config.StudentNet.SettingLink.UserId, Config.StudentNet.SettingLink.Password);
                if (res)
                {
                    // 调整TMR至第二天的设定时间启动
                    var nextTime = DateTime.Now.AddDays(1).Date + Config.StudentNet.StartTime.TimeOfDay;
                    TMR_SrLink.Interval = (int)nextTime.Subtract(DateTime.Now).TotalMilliseconds;
                    ShowTip(ToolTipIcon.Info, "连接成功", $"{StringHelper.GetAppString("AdapterName")}已连接");
                }
                else
                {
                    Config.StudentNet.AutoLink = false;
                    ShowTip(ToolTipIcon.Info, "连接失败", "已取消自动连接。请检查配置信息，并使用手动连接测试配置，连接成功后再重新开启自动连接。");
                }
            }

            if (SrLinkService.SettingEnable(ref Config, "Mail"))
            {
                var res = await SrLinkService.SendIpAsync(Config.StudentNet.SettingMail.Address);
                if (res)
                    _frmDebug.WriteToBoard("Ip发送成功");
                else
                    ShowTip(ToolTipIcon.Error, "Ip发送失败", "响应超时");
            }

            // Global.Running = false;
            _frmDebug.WriteToBoard("连接结束");
        }

        #endregion

        #region Timer事件

        private void TMR_SrLink_Tick(object sender, EventArgs e)
        {
            try
            {
                TryLinkStudent();
            }
            catch (Exception err)
            {
                LoggerService.SaveLog("TMR_SrLink_Tick", err);
            }
        }

        #endregion

        #region From事件

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            try
            {
                版本ToolStripMenuItem.Text = StringHelper.GetAppString("Version");
                WindowState = FormWindowState.Minimized;
                ShowScreen(new SubFrmNormal(_frmDebug));
                VpnService.Abort();
                TMR_SrLink.Enabled = (Config.NetType == 0 && Config.StudentNet.AutoLink);
            }
            catch (Exception err)
            {
                LoggerService.SaveLog("FRM_Main_Load", err);
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
                LoggerService.SaveLog("FrmMain_SizeChanged", err);
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
                else
                {
                    e.Cancel = true;
                    Application.Exit();
                }
            }
            catch (Exception err)
            {
                LoggerService.SaveLog("FrmMain_SizeChanged", err);
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
                LoggerService.SaveLog("NotifyIcon_DoubleClick", err);
            }
        }

        private void 断开连接ToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            _frmDebug.WriteToBoard("(用户操作)执行断开连接");
            try
            {
                if (Config.NetType == 1)
                {
                    ShowTip(ToolTipIcon.Warning, "无效操作", "教师网暂时无法断开连接");
                }
                else
                {
                    SrLinkService.DisconnectVpn();
                    ShowTip(ToolTipIcon.Warning, "断开网络", "网络已断开");
                    //if (await SrLinkService.TestInternetAsync())
                    //    SrLinkService.DisconnectVpn();
                    //else
                    //    ShowTip(ToolTipIcon.Warning, "无效操作", "网络还未连接");
                }
            }
            catch (Exception err)
            {
                LoggerService.SaveLog("断开连接ToolStripMenuItem_Click", err);
            }
        }

        private void 立即连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmDebug.WriteToBoard("(用户操作)执行立即连接");
            TMR_SrLink.Enabled = (Config.NetType == 0 && Config.StudentNet.AutoLink);
            try
            {
                if (Config.NetType == 1)
                {
                    TryLinkTeacher();
                }
                else
                {
                    if (VpnService.Worked())
                        ShowTip(ToolTipIcon.Warning, "无效操作", "网络已连接");
                    else
                        TryLinkStudent(true);
                }
                //if (SrLinkService.TestInternet(1))
                //    ShowTip(ToolTipIcon.Warning, "无效操作", "网络已连接");
                //else
                //    TryLinkStudent(true);
                //if (Global.Linked)
                //    ShowTip(ToolTipIcon.Warning, "无效操作", "网络已连接");
                //else
                //    TryLinkL2tp(true);
            }
            catch (Exception err)
            {
                LoggerService.SaveLog("立即连接ToolStripMenuItem_Click", err);
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
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
                LoggerService.SaveLog("显示ToolStripMenuItem_Click", err);
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
                LoggerService.SaveLog("退出ToolStripMenuItem_Click", err);
                Environment.Exit(0);
            }
        }

        private void 切换网络ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Config.NetType)
            {
                case 0:
                    TryLinkTeacher();
                    break;
                case 1:
                    Config.NetType = 0;
                    if (Config.StudentNet.SettingCertify.Enable == false ||
                        string.IsNullOrEmpty(Config.StudentNet.SettingCertify.UserId) ||
                        string.IsNullOrEmpty(Config.StudentNet.SettingCertify.Password))
                    {
                        var f = new FrmCertify();
                        if (f.ShowDialog() != DialogResult.Yes) Config.NetType = 1;
                    }
                    else
                    {
                        //SrLinkService.RegisterSchoolNet(Config.StudentNet.SettingCertify.UserId,
                        //    Config.StudentNet.SettingCertify.Password);
                        TryLinkStudent(true);
                    }
                    break;
            }

            TMR_SrLink.Enabled = (Config.NetType == 0 && Config.StudentNet.AutoLink);
            ConfigService.SaveConfig(ref Config);
        }
        private void ShowTip(ToolTipIcon icon, string title, string text, bool debug = true)
        {
            NotifyIcon.ShowBalloonTip(3000, title, text, icon);
            if (debug) _frmDebug.WriteToBoard($"显示提示：{text}");
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
                LoggerService.SaveLog("LVW_Menu_MouseClick", err);
            }
        }

        private void ChangePanel(string name)
        {
            switch (name)
            {
                case "常规":
                    ShowScreen(new SubFrmNormal(_frmDebug));
                    break;
                case "连接器":
                    ShowScreen(new SubFrmSLink());
                    break;
                //case "关于":
                //    ShowScreen(new SubFrmAbout());
                //    break;
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

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new SubFrmAbout();
            f.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new SubFrmWorking();
            f.ShowDialog();
        }
    }

    #endregion
}