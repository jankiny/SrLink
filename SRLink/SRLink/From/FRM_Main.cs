using Kit.Utils;
using Kit.Win;
using SRLink.Handler;
using SRLink.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SRLink.From
{
    public partial class FRM_Main : BaseForm
    {
        private readonly Queue<HandlerBase> Ready = null;
        private readonly List<Label> Runing = null;
        private readonly LinkProcess LinkProcess;
        private bool Linked = false;

        // 定义委托类型
        private delegate void SetTextCallback(string str);
        public FRM_Main()
        {
            InitializeComponent();
            Ready = new Queue<HandlerBase>();
            Runing = new List<Label>();
            LinkProcess = new LinkProcess();

            Application.ApplicationExit += (sender, args) =>
            {
                Config.HasConfig = true;
                ConfigHandler.SaveConfig(ref Config);
            };
        }

        #region From及其他事件
        private void FRM_Main_Load(object sender, EventArgs e)
        {
            ConfigHandler.LoadConfig(ref Config);
            TSP_SLB_Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            TBX_Board.Text = string.Format("{0}[{1}]" + Environment.NewLine, Global.SoftwareName, Global.Version);
            LBL_Version.Text = Global.Version;
            if (!Config.HasConfig)
            {
                WriteToBoard("第一次使用，请先到设置页输入认证账号等...");
                ChangeStatus(EStatus.Error);
                // 用Linked使软件不进入连接状态
                Linked = true;
            }
            else
            {
                DTP_StartTime.Value = Config.StartTime;

                ConfigUpdate(Config.SettingCertify);
                ChangeStatus(1, (Config.SettingCertify.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                ConfigUpdate(Config.SettingLink);
                ChangeStatus(2, (Config.SettingLink.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                ConfigUpdate(Config.SettingMail);
                ChangeStatus(3, (Config.SettingMail.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                CHK_AutoRun.Checked = Config.AutoRun;

                WriteToBoard("配置文件载入成功");
            }
            Linked = Web.IsConnectInternet(Global.TestConnectionUrl);
            if (Linked)
            {
                WriteToBoard("检测到网络已连接");
                //ChangeStatus(2, EStatus.OK);
            }
        }

        private void FRM_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.SaveLog(TBX_Board.Text);
        }

        #endregion

        #region Timer事件
        private void TMR_UpdateTime_Tick(object sender, EventArgs e)
        {
            TSP_SLB_Time.Text = DateTime.Now.ToString(Global.DateTimeFormatString);
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
            foreach (Label label in Runing)
            {
                label.ForeColor = (LBL_Line1.ForeColor == Color.DimGray ? Color.LimeGreen : Color.DimGray);
            }
            if (!LinkProcess.Busy && Ready.Count != 0)
            {
                WriteToBoard("开始连接...");
                LinkProcess.Busy = true;
                LinkProcess.Thread = new Thread(Func);
                LinkProcess.Thread.Start();
            }
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
            Sys.SetAutoRun(Global.autoRunRegPath, Global.autoRunName, Config.AutoRun);
            // 开机启动的程序用Environment.CurrentDirectory获取到的时system32文件夹
            // WriteToBoard("写入到：" + Environment.CurrentDirectory); 
            Config.StartTime = DTP_StartTime.Value;
            ConfigHandler.SaveConfig(ref Config);
            TSP_SLB_Statu.Text = "保存成功";
            TSP_SLB_Statu.ForeColor = Color.LimeGreen;
        }

        // CerifyConfig弹窗
        private void BTN_CerifyConfig_Click(object sender, EventArgs e)
        {
            FRM_SettingCertify f = new FRM_SettingCertify(Config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                SettingCertify setting_Certify = Config.SettingCertify;
                ConfigUpdate(setting_Certify);
                ChangeStatus(1, (setting_Certify.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            }
        }

        // LinkConfig弹窗
        private void BTN_LinkConfig_Click(object sender, EventArgs e)
        {
            FRM_SettingLink f = new FRM_SettingLink(Config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                SettingLink setting_Link = Config.SettingLink;
                ConfigUpdate(setting_Link);
                ChangeStatus(2, (setting_Link.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            }
        }

        // MailConfig弹窗
        private void BTN_MailConfig_Click(object sender, EventArgs e)
        {
            FRM_SettingMail f = new FRM_SettingMail(Config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                SettingMail setting_Mail = Config.SettingMail;
                ConfigUpdate(setting_Mail);
                ChangeStatus(3, (setting_Mail.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            }
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            if (LinkProcess.Thread == null ||
                LinkProcess.Thread.ThreadState == ThreadState.Stopped ||
                LinkProcess.Thread.ThreadState == ThreadState.Aborted)
            {
                WriteToBoard("(User Command)开始连接...");
                LinkProcess.Busy = true;
                RefreshQueue();
                LinkProcess.Thread = new Thread(Func);
                LinkProcess.Thread.Start();
            }
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            //this.TodayLink = true;
            Ready.Clear();
            if (LinkProcess.Thread != null)
            {
                if (LinkProcess.Thread.ThreadState == ThreadState.WaitSleepJoin ||
                    LinkProcess.Thread.ThreadState == ThreadState.Running)
                {
                    LinkProcess.Busy = false;
                    LinkProcess.Thread.Abort();
                }
                WriteToBoard("(User Command)进程已被终止!");
            }
            else
            {
                WriteToBoard("(User Command)没用在运行的进程!");
            }
        }
        #endregion

        #region 其他控件事件
        private void CHK_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoRun = CHK_AutoRun.Checked;
        }

        private void LBL_DescriptionLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jankiny/SRLink");
        }
        #endregion

        #region Handler辅助函数
        private void RefreshQueue()
        {
            if (Ready.Count != 0)
            {
                Ready.Clear();
            }
            CertifyHandler certifyHandler = new CertifyHandler(Config.SettingCertify, 60, 3000, EHandler.Work);
            certifyHandler.RegisteUI(PBX_Certify);
            if (certifyHandler.Ready())
            {
                Ready.Enqueue(certifyHandler);
            }
            LinkHandler linkHandler = new LinkHandler(Config.SettingLink, 60, 3000, EHandler.Work);
            linkHandler.RegisteUI(PBX_Link, LBL_Line1);
            if (linkHandler.Ready())
            {
                Ready.Enqueue(linkHandler);
            }
            MailHandler mailHandler = new MailHandler(Config.SettingMail, 60, 3000, EHandler.Work);
            mailHandler.RegisteUI(PBX_Mail, LBL_Line2);
            if (mailHandler.Ready())
            {
                Ready.Enqueue(mailHandler);
            }
        }

        // 托管的方法
        private void Func()
        {
            if (Ready.Count == 0)
            {
                WriteToBoard("当前配置不可用");
            }
            while (Ready.Count != 0)
            {
                HandlerBase handler = Ready.Dequeue();
                Runing.Add(handler.Line);
                WriteToBoard("尝试" + handler.HandleName);
                int count = 1;
                while (!handler.Run(out string msg))
                {
                    if (count == handler.Count)
                    {
                        WriteToBoard(string.Format("第{0}次{1}失败[{2}] 停止认证。",
                            count, handler.HandleName, msg));
                        return;
                    }
                    WriteToBoard(string.Format("第{0}次{1}失败[{2}] {3}s后重试。",
                        count, handler.HandleName, msg, handler.Delay / 1000));
                    count++;
                    Thread.Sleep(handler.Delay);
                }
                Runing.Clear();
                ChangeStatus(handler.ID, EStatus.OK);
                Config.LastLinkTime = DateTime.Now; // 暂时没用
                WriteToBoard(handler.HandleName + "成功！");
            }
            TMR_Handle.Enabled = false;
            LinkProcess.Busy = false;
        }
        #endregion

        #region 提示信息
        /// <summary>
        /// 将message显示到Board上
        /// </summary>
        /// <param name="msg">显示的信息</param>
        private void WriteToBoard(string msg)
        {
            if (TBX_Board.InvokeRequired)
            {
                // 解决窗体关闭时出现“访问已释放句柄”异常
                while (TBX_Board.IsHandleCreated == false)
                {
                    if (TBX_Board.Disposing || TBX_Board.IsDisposed) return;
                }
                SetTextCallback d = new SetTextCallback(WriteToBoard);
                label1.Invoke(d, new object[] { msg });
            }
            else
            {
                ShowMsg(msg);
            }
        }
        private void ShowMsg(string msg)
        {
            if (TBX_Board.Lines.Length > 999)
            {
                ClearMsg();
            }
            TBX_Board.AppendText(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), msg));
            if (!msg.EndsWith(Environment.NewLine))
            {
                TBX_Board.AppendText(Environment.NewLine);
            }
        }
        private void ClearMsg()
        {
            TBX_Board.Clear();
        }
        #endregion

        #region UI控制
        /// <summary>
        /// 根据状态值改变所有主界面UI显示
        /// </summary>
        /// <param name="status">状态值</param>
        private void ChangeStatus(EStatus status)
        {
            switch (status)
            {
                case EStatus.Error:
                    LBL_Step1.ForeColor = Color.Red;
                    PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                    LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.Red;
                    PBX_Link.BackgroundImage = Properties.Resources.network_error;
                    LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.Red;
                    PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                    break;
                case EStatus.Normal:
                    LBL_Step1.ForeColor = Color.Gold;
                    PBX_Certify.BackgroundImage = Properties.Resources.check_normal;
                    LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.Gold;
                    PBX_Link.BackgroundImage = Properties.Resources.network_normal;
                    LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.Gold;
                    PBX_Mail.BackgroundImage = Properties.Resources.mail_normal;
                    break;
                case EStatus.OK:
                    LBL_Step1.ForeColor = Color.LimeGreen;
                    PBX_Certify.BackgroundImage = Properties.Resources.check_ok;
                    LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.LimeGreen;
                    PBX_Link.BackgroundImage = Properties.Resources.network_ok;
                    LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.LimeGreen;
                    PBX_Mail.BackgroundImage = Properties.Resources.mail_ok;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据状态值改变主界面UI显示
        /// </summary>
        /// <param name="step">第n步，对应各个habdler的ID</param>
        /// <param name="status">状态值</param>
        private void ChangeStatus(int step, EStatus status)
        {
            if (step == 1)
            {
                switch (status)
                {
                    case EStatus.Error:
                        LBL_Step1.ForeColor = Color.Red;
                        PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                        break;
                    case EStatus.Normal:
                        LBL_Step1.ForeColor = Color.Gold;
                        PBX_Certify.BackgroundImage = Properties.Resources.check_normal;
                        break;
                    case EStatus.OK:
                        LBL_Step1.ForeColor = Color.LimeGreen;
                        PBX_Certify.BackgroundImage = Properties.Resources.check_ok;
                        break;
                    default:
                        break;
                }
            }
            else if (step == 2)
            {
                switch (status)
                {
                    case EStatus.Error:
                        LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.Red;
                        PBX_Link.BackgroundImage = Properties.Resources.network_error;
                        break;
                    case EStatus.Normal:
                        LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.Gold;
                        PBX_Link.BackgroundImage = Properties.Resources.network_normal;
                        break;
                    case EStatus.OK:
                        LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.LimeGreen;
                        PBX_Link.BackgroundImage = Properties.Resources.network_ok;
                        break;
                    default:
                        break;
                }
            }
            else if (step == 3)
            {
                switch (status)
                {
                    case EStatus.Error:
                        LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.Red;
                        PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                        break;
                    case EStatus.Normal:
                        LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.Gold;
                        PBX_Mail.BackgroundImage = Properties.Resources.mail_normal;
                        break;
                    case EStatus.OK:
                        LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.LimeGreen;
                        PBX_Mail.BackgroundImage = Properties.Resources.mail_ok;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 设置页刷新UI
        /// </summary>
        /// <param name="settingCertify"></param>
        private void ConfigUpdate(SettingCertify settingCertify)
        {
            LBL_CertifyInfo.Text = settingCertify.GetConfigInfo();
            LBL_CertifyEnable.Text = (settingCertify.GetConfigReady() ? "就绪" : "未就绪");
            LBL_CertifyEnable.ForeColor = (settingCertify.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        private void ConfigUpdate(SettingLink settingLink)
        {
            LBL_LinkInfo.Text = settingLink.GetConfigInfo();
            LBL_LinkEnable.Text = (settingLink.GetConfigReady() ? "就绪" : "未就绪");
            LBL_LinkEnable.ForeColor = (settingLink.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        private void ConfigUpdate(SettingMail settingMail)
        {
            LBL_MailInfo.Text = settingMail.GetConfigInfo();
            LBL_MailEnable.Text = (settingMail.GetConfigReady() ? "就绪" : "未就绪");
            LBL_MailEnable.ForeColor = (settingMail.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        #endregion

    }
}
