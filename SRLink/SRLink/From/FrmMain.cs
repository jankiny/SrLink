using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kit.Utils;
using Kit.Win;
using SRLink.Handler;
using SRLink.Model;
using SRLink.Service;
using SRLink.Service.Inpl;

namespace SRLink.From
{
    public partial class FrmMain : BaseForm
    {
        private readonly Queue<HandlerBase> Ready = null;
        private readonly List<Label> Runing = null;
        private readonly LinkProcess LinkProcess;
        private bool Linked = false;


        public FrmMain()
        {
            InitializeComponent();
            Ready = new Queue<HandlerBase>();
            Runing = new List<Label>();
            LinkProcess = new LinkProcess();

            Application.ApplicationExit += async (sender, args) =>
            {

                Config.HasConfig = true;
                await SaveConfigAsync();
            };
        }

        #region From及其他事件

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            ShowScreen(new SubFrmNormal());
        }

        private void FRM_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Logger.SaveLog(TBX_Board.Text);
        }

        #endregion

        #region Timer事件

        private void TMR_UpdateTime_Tick(object sender, EventArgs e)
        {
            if (!LinkProcess.Busy && TSP_SLB_Statu.Text != "欢迎使用")
            {
                TMR_ToolBarRetain.Enabled = true;
            }

            if (!Linked &&
                Config.EnableLink() &&
                Ready.Count == 0)
            {
                RefreshQueue();
                Linked = true;
                TMR_Handle.Enabled = true;
            }

            // ToolBar状态显示
            if (LinkProcess.Thread != null)
            {
                if (LinkProcess.Thread.ThreadState == ThreadState.Aborted)
                {
                    TSP_SLB_Statu.Text = "连接中断";
                }
                else if (LinkProcess.Thread.ThreadState == ThreadState.Running ||
                         LinkProcess.Thread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    TSP_SLB_Statu.Text = "连接中";
                }
                else if (LinkProcess.Thread.ThreadState == ThreadState.Stopped)
                {
                    TSP_SLB_Statu.Text = "欢迎使用";
                }
                else
                {
                    TSP_SLB_Statu.Text = "欢迎使用";
                }
            }
        }

        private void TMR_Handle_Tick(object sender, EventArgs e)
        {
            //foreach (Label label in Runing)
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

        private void TMR_ToolBarRetain_Tick(object sender, EventArgs e)
        {
            TSP_SLB_Statu.Text = "欢迎使用";
            TSP_SLB_Statu.ForeColor = Color.Black;
            TMR_ToolBarRetain.Enabled = false;
        }

        #endregion

        #region Button事件

        // Config页面保存按钮
        private void BTN_Set_Click(object sender, EventArgs e)
        {
            //Sys.SetAutoRun(Global.autoRunRegPath, Global.autoRunName, Config.RunAtStartup);
            //// 开机启动的程序用Environment.CurrentDirectory获取到的时system32文件夹
            //// WriteToBoard("写入到：" + Environment.CurrentDirectory); 
            //Config.RunAtStartup = DTP_StartTime.Value;
            //ConfigHandler.SaveConfig(ref Config);
            //TSP_SLB_Statu.Text = "保存成功";
            //TSP_SLB_Statu.ForeColor = Color.LimeGreen;
        }

        // CerifyConfig弹窗
        private void BTN_CerifyConfig_Click(object sender, EventArgs e)
        {
            //FRM_SettingCertify f = new FRM_SettingCertify(Config);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    SettingCertify setting_Certify = Config.SettingCertify;
            //    ConfigUpdate(setting_Certify);
            //    ChangeStatus(1, (setting_Certify.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            //}
        }

        // LinkConfig弹窗
        private void BTN_LinkConfig_Click(object sender, EventArgs e)
        {
            //FRM_SettingLink f = new FRM_SettingLink(Config);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    SettingLink setting_Link = Config.SettingLink;
            //    ConfigUpdate(setting_Link);
            //    ChangeStatus(2, (setting_Link.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            //}
        }

        // MailConfig弹窗
        private void BTN_MailConfig_Click(object sender, EventArgs e)
        {
            //FRM_SettingMail f = new FRM_SettingMail(Config);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    SettingMail setting_Mail = Config.SettingMail;
            //    ConfigUpdate(setting_Mail);
            //    ChangeStatus(3, (setting_Mail.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            //}
        }

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
            Ready.Clear();
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

        #region Handler辅助函数

        private void RefreshQueue()
        {
            if (Ready.Count != 0)
            {
                Ready.Clear();
            }

            //CertifyHandler certifyHandler = new CertifyHandler(Config.SettingCertify, 60, 3000, EHandler.Work);
            //certifyHandler.RegisteUI(PBX_Certify);
            //if (certifyHandler.Ready())
            //{
            //    Ready.Enqueue(certifyHandler);
            //}

            //LinkHandler linkHandler = new LinkHandler(Config.SettingLink, 60, 3000, EHandler.Work);
            //linkHandler.RegisteUI(PBX_Link, LBL_Line1);
            //if (linkHandler.Ready())
            //{
            //    Ready.Enqueue(linkHandler);
            //}

            //MailHandler mailHandler = new MailHandler(Config.SettingMail, 60, 3000, EHandler.Work);
            //mailHandler.RegisteUI(PBX_Mail, LBL_Line2);
            //if (mailHandler.Ready())
            //{
            //    Ready.Enqueue(mailHandler);
            //}
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
            //    Runing.Add(handler.Line);
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

            //    Runing.Clear();
            //    ChangeStatus(handler.ID, EStatus.Ok);
            //    Config.LastLinkTime = DateTime.Now; // 暂时没用
            //    WriteToBoard(handler.HandleName + "成功！");
            //}

            TMR_Handle.Enabled = false;
            LinkProcess.Busy = false;
        }


        VPN vpn = new VPN("192.168.200.1", "SLINK_L2TP", "hzgsd57336599", "336599", "L2TP");

        private void BTN_Link_Click(object sender, EventArgs e)
        {
            vpn.Connect();
        }

        private void BTN_Disconnect_Click(object sender, EventArgs e)
        {
            vpn.Disconnect();
        }

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
            if (ctl is Form)
            {
                var frm = ctl as Form;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
            }
            ctl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ctl);
        }
    }
}
#endregion