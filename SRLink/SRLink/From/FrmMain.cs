using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Kit.Utils;
using Kit.Win;
using SRLink.Model;
using SRLink.Service;
using SRLink.Service.Impl;

namespace SRLink.From
{
    public partial class FrmMain : BaseForm
    {
        private readonly LinkProcess LinkProcess;
        public static FrmLinkInfo FrmLinkInfo;
        public SrLinkService SrLinkService;
        private bool Linked;
        private bool Running;

        public FrmMain()
        {
            InitializeComponent();
            Config = ConfigService.LoadConfig();
            Linked = true;
            Running = false;
            FrmLinkInfo = new FrmLinkInfo();
            SrLinkService = new SrLinkService(Config);

            LinkProcess = new LinkProcess();

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
            ShowScreen(new SubFrmNormal());
            if (Config.ShowLinkInfo)
            {
                FrmLinkInfo.Show();
            }
            if (!Linked)
            {
                TryAutoLink();
            }
            Linked = await Task.Run(() => SrLinkService.IsConnectInternet());
        }

        #endregion

        #region Timer事件

        private void TMR_SrLink_Tick(object sender, EventArgs e)
        {
            if (!Linked)
            {
                TryAutoLink();
            }
        }
        private void TMR_Handle_Tick(object sender, EventArgs e)
        {
            //foreach (Label label in Running)
            //{
            //    label.ForeColor = (LBL_Line1.ForeColor == Color.DimGray ? Color.LimeGreen : Color.DimGray);
            //}

            //if (!LinkProcess.Busy && Ready.Count != 0)
            //{
            //    WriteToBoard("开始连接...");
            //    LinkProcess.Busy = true;
            //    LinkProcess.Thread = new Thread(Func);
            //    LinkProcess.Thread.Start();
            //}
        }

        #endregion

        #region Button事件
        
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            //if (LinkProcess.Thread == null ||
            //    LinkProcess.Thread.ThreadState == ThreadState.Stopped ||
            //    LinkProcess.Thread.ThreadState == ThreadState.Aborted)
            //{
            //    WriteToBoard("(User Command)开始连接...");
            //    LinkProcess.Busy = true;
            //    RefreshQueue();
            //    LinkProcess.Thread = new Thread(Func);
            //    LinkProcess.Thread.Start();
            //}
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            //this.TodayLink = true;
            //if (LinkProcess.Thread != null)
            //{
            //    if (LinkProcess.Thread.ThreadState == ThreadState.WaitSleepJoin ||
            //        LinkProcess.Thread.ThreadState == ThreadState.Running)
            //    {
            //        LinkProcess.Busy = false;
            //        LinkProcess.Thread.Abort();
            //    }

            //    WriteToBoard("(User Command)进程已被终止!");
            //}
            //else
            //{
            //    WriteToBoard("(User Command)没用在运行的进程!");
            //}
        }

        #endregion

        #region 连接事务辅助函数

        private async void TryAutoLink()
        {
            if (!Running)
            {
                Running = true;
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
                        do {
                            Linked = SrLinkService.LinkVpn(out var msg);
                            FrmLinkInfo.WriteToBoard(msg);
                            Thread.Sleep(1000);
                            count--;
                        }
                        while (count > 0 && !Linked) ;
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
                Running = false;
            }
        }


        // 托管的方法
        private void Func()
        {
            //if (Ready.Count == 0)
            //{
            //    WriteToBoard("当前配置不可用");
            //}

            //while (Ready.Count != 0)
            //{
            //    HandlerBase handler = Ready.Dequeue();
            //    Running.Add(handler.Line);
            //    WriteToBoard("尝试" + handler.HandleName);
            //    int count = 1;
            //    while (!handler.Run(out string msg))
            //    {
            //        if (count == handler.Count)
            //        {
            //            WriteToBoard(string.Format("第{0}次{1}失败[{2}] 停止认证。",
            //                count, handler.HandleName, msg));
            //            return;
            //        }

            //        WriteToBoard(string.Format("第{0}次{1}失败[{2}] {3}s后重试。",
            //            count, handler.HandleName, msg, handler.Delay / 1000));
            //        count++;
            //        Thread.Sleep(handler.Delay);
            //    }

            //    Running.Clear();
            //    ChangeStatus(handler.ID, EStatus.Ok);
            //    Config.LastLinkTime = DateTime.Now; // 暂时没用
            //    WriteToBoard(handler.HandleName + "成功！");
            //}

            TMR_SrLink.Enabled = false;
            LinkProcess.Busy = false;
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
                frm.Visible = true;
            }
            //ctl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ctl);
        }
    }
}
#endregion