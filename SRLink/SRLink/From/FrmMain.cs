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
        public static FrmLinkInfo FrmLinkInfo;
        public SrLinkService SrLinkService;

        public FrmMain()
        {
            InitializeComponent();
            Config = ConfigService.LoadConfig();
            FrmLinkInfo = new FrmLinkInfo();
            SrLinkService = new SrLinkService(Config);

            Application.ApplicationExit += (sender, args) =>
            {
                //Config.HasConfig = true;
                SrLinkService.DisconnectVpn();
                ConfigService.SaveConfig(Config);
                //await Task.Run(() => );
            };
        }

        #region From及其他事件

        private async void FRM_Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowScreen(new SubFrmNormal());

            // TODO: Linked判断以到TryAutoLink()中
            if (!Global.Linked)
            {
                TryAutoLink();
            }

            Global.Linked = await Task.Run(() => SrLinkService.IsConnectInternet());
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
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
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
        }

        #endregion

        #region Timer事件

        private void TMR_SrLink_Tick(object sender, EventArgs e)
        {
            if (!Global.Linked)
            {
                TryAutoLink();
            }
        }

        #endregion


        #region 连接事务辅助函数

        private async void TryAutoLink()
        {
            if (!Global.Running)
            {
                Global.Running = true;
                await Task.Run(() =>
                {
                    if (!Config.AutoLink || !Config.EnableLink()) return;
                    if (Config.SettingCertify.Enable)
                    {
                        var count = 30;
                        bool reg = false;
                        FrmLinkInfo.WriteToBoard("开始认证校园网...");
                        do
                        {
                            reg = SrLinkService.RegisterSchoolNet(out var msg);
                            FrmLinkInfo.WriteToBoard(msg);
                            Thread.Sleep(1000);
                            count--;
                        } while (count > 0 && !reg);
                    }

                    if (Config.SettingLink.Enable)
                    {
                        var count = 30;
                        FrmLinkInfo.WriteToBoard("开始连接网络...");
                        do
                        {
                            Global.Linked = SrLinkService.LinkVpn(out var msg);
                            FrmLinkInfo.WriteToBoard(msg);
                            Thread.Sleep(1000);
                            count--;
                        } while (count > 0 && !Global.Linked);
                    }

                    if (Config.SettingMail.Enable)
                    {
                        var count = 30;
                        bool send = false;
                        FrmLinkInfo.WriteToBoard("正在发送邮件...");
                        do
                        {
                            send = SrLinkService.SendIp(out var msg);
                            FrmLinkInfo.WriteToBoard(msg);
                            Thread.Sleep(1000);
                            count--;
                        } while (count > 0 && !send);
                    }
                });
                Global.Running = false;
            }
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
                    ShowScreen(new SubFrmSLink(FrmLinkInfo));
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