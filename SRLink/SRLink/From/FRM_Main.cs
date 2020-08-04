using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Kit.Utils;
using Kit.Win;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink.From
{
    public partial class FRM_Main : BaseForm
    {
        readonly Queue<HandlerBase> Ready = null;
        readonly List<Label> Runing = null;
        readonly LinkProcess LinkProcess;
        bool Linked = false;
        // 定义委托类型
        delegate void SetTextCallback(String str);

        #region WindowsFrom事件
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

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            ConfigHandler.LoadConfig(ref Config);
            this.TSP_SLB_Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.TBX_Board.Text = string.Format("{0}[{1}]" + Environment.NewLine,  Global.SoftwareName, Global.Version);
            this.LBL_Version.Text = Global.Version;
            if (!Config.HasConfig)
            {
                WriteToBoard("第一次使用，请先到设置页输入认证账号等...");
                ChangeStatus(EStatus.Error);
                // 用Linked使软件不进入连接状态
                this.Linked = true;
            }
            else
            {
                this.DTP_StartTime.Value = Config.StartTime;

                ConfigUpdate(Config.SettingCertify);
                ChangeStatus(1, (Config.SettingCertify.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                ConfigUpdate(Config.SettingLink);
                ChangeStatus(2, (Config.SettingLink.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                ConfigUpdate(Config.SettingMail);
                ChangeStatus(3, (Config.SettingMail.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                this.CHK_AutoRun.Checked = Config.AutoRun;

                WriteToBoard("配置文件载入成功");
            }
            this.Linked = Web.IsConnectInternet(Global.TestConnectionUrl);
            if (this.Linked)
            {
                WriteToBoard("检测到网络已连接");
                ChangeStatus(2, EStatus.OK);
            }
        }

        private void FRM_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.SaveLog(this.TBX_Board.Text);
        }

        // Config页面时间设置按钮
        private void BTN_Set_Click(object sender, EventArgs e)
        {
            Sys.SetAutoRun(Global.autoRunRegPath, Global.autoRunName, Config.AutoRun);
            // 开机启动的程序用Environment.CurrentDirectory获取到的时system32文件夹
            // WriteToBoard("写入到：" + Environment.CurrentDirectory); 
            Config.StartTime = this.DTP_StartTime.Value;
            ConfigHandler.SaveConfig(ref Config);
            this.TSP_SLB_Statu.Text = "保存成功";
            this.TSP_SLB_Statu.ForeColor = Color.LimeGreen;
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

        private void TMR_UpdateTime_Tick(object sender, EventArgs e)
        {
            this.TSP_SLB_Time.Text = DateTime.Now.ToString(Global.DateTimeFormatString);
            if (!this.LinkProcess.Busy && this.TSP_SLB_Statu.Text != "欢迎使用")
            {
                this.TMR_ToolBarRetain.Enabled = true;
            }
            if (!this.Linked &&
                Config.EnableLink() &&
                Ready.Count == 0)
            {
                RefreshQueue();
                this.Linked = true;
                this.TMR_Handle.Enabled = true;
            }
            // ToolBar状态显示
            if (this.LinkProcess.Thread != null)
            {
                if (this.LinkProcess.Thread.ThreadState == ThreadState.Aborted)
                {
                    this.TSP_SLB_Statu.Text = "连接中断";
                }
                else if (this.LinkProcess.Thread.ThreadState == ThreadState.Running ||
                    this.LinkProcess.Thread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    this.TSP_SLB_Statu.Text = "连接中";
                }
                else if (this.LinkProcess.Thread.ThreadState == ThreadState.Stopped)
                {
                    this.TSP_SLB_Statu.Text = "欢迎使用";
                }
                else
                {
                    this.TSP_SLB_Statu.Text = "欢迎使用";
                }
            }
        }

        private void TMR_Handle_Tick(object sender, EventArgs e)
        {
            foreach (Label label in Runing)
            {
                label.ForeColor = (this.LBL_Line1.ForeColor == Color.DimGray ? Color.LimeGreen : Color.DimGray);
            }
            if (!this.LinkProcess.Busy && Ready.Count != 0)
            {
                WriteToBoard("开始连接...");
                this.LinkProcess.Busy = true;
                this.LinkProcess.Thread = new Thread(Func);
                this.LinkProcess.Thread.Start();
            }
        }
        private void TMR_ToolBarRetain_Tick(object sender, EventArgs e)
        {
            this.TSP_SLB_Statu.Text = "欢迎使用";
            this.TSP_SLB_Statu.ForeColor = Color.Black;
            this.TMR_ToolBarRetain.Enabled = false;
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            if (this.LinkProcess.Thread == null ||
                this.LinkProcess.Thread.ThreadState == ThreadState.Stopped ||
                this.LinkProcess.Thread.ThreadState == ThreadState.Aborted)
            {
                WriteToBoard("(User Command)开始连接...");
                this.LinkProcess.Busy = true;
                RefreshQueue();
                this.LinkProcess.Thread = new Thread(Func);
                this.LinkProcess.Thread.Start();
            }
        }  

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            //this.TodayLink = true;
            Ready.Clear();
            if (this.LinkProcess.Thread != null)
            {
                if (this.LinkProcess.Thread.ThreadState == ThreadState.WaitSleepJoin ||
                    this.LinkProcess.Thread.ThreadState == ThreadState.Running)
                {
                    this.LinkProcess.Busy = false;
                    this.LinkProcess.Thread.Abort();
                }
                WriteToBoard("(User Command)进程已被终止!");
            }
            else
            {
                WriteToBoard("(User Command)没用在运行的进程!");
            }
        }
        #endregion

        #region Handler辅助函数
        void RefreshQueue()
        {
            if (Ready.Count != 0)
            {
                Ready.Clear();
            }
            CertifyHandler certifyHandler = new CertifyHandler(Config.SettingCertify, 60, 3000, EHandler.Work);
            certifyHandler.RegisteUI(this.PBX_Certify);
            if (certifyHandler.Ready())
            {
                Ready.Enqueue(certifyHandler);
            }
            LinkHandler linkHandler = new LinkHandler(Config.SettingLink, 60, 3000, EHandler.Work);
            linkHandler.RegisteUI(this.PBX_Link, this.LBL_Line1);
            if (linkHandler.Ready())
            {
                Ready.Enqueue(linkHandler);
            }
            MailHandler mailHandler = new MailHandler(Config.SettingMail, 60, 3000, EHandler.Work);
            mailHandler.RegisteUI(this.PBX_Mail, this.LBL_Line2);
            if (mailHandler.Ready())
            {
                Ready.Enqueue(mailHandler);
            }
        }
        // 托管的方法
        void Func()
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
            this.TMR_Handle.Enabled = false;
            this.LinkProcess.Busy = false;
        }
        #endregion

        #region 提示信息
        /// <summary>
        /// 将message显示到Board上
        /// </summary>
        /// <param name="msg">显示的信息</param>
        void WriteToBoard(string msg)
        {
            if (this.TBX_Board.InvokeRequired)
            {
                // 解决窗体关闭时出现“访问已释放句柄”异常
                while (this.TBX_Board.IsHandleCreated == false)
                {
                    if (this.TBX_Board.Disposing || this.TBX_Board.IsDisposed) return;
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
            if (this.TBX_Board.Lines.Length > 999)
            {
                ClearMsg();
            }
            this.TBX_Board.AppendText(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), msg));
            if (!msg.EndsWith(Environment.NewLine))
            {
                this.TBX_Board.AppendText(Environment.NewLine);
            }
        }
        private void ClearMsg()
        {
            this.TBX_Board.Clear();
        }
        #endregion

        #region UI控制
        /// <summary>
        /// 根据状态值改变所有主界面UI显示
        /// </summary>
        /// <param name="status">状态值</param>
        void ChangeStatus(EStatus status)
        {
            switch (status)
            {
                case EStatus.Error:
                    this.LBL_Step1.ForeColor = Color.Red;
                    this.PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                    this.LBL_Step2.ForeColor = this.LBL_Line1.ForeColor = Color.Red;
                    this.PBX_Link.BackgroundImage = Properties.Resources.network_error;
                    this.LBL_Step3.ForeColor = this.LBL_Line2.ForeColor = Color.Red;
                    this.PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                    break;
                case EStatus.Normal:
                    this.LBL_Step1.ForeColor = Color.Gold;
                    this.PBX_Certify.BackgroundImage = Properties.Resources.check_normal;
                    this.LBL_Step2.ForeColor = this.LBL_Line1.ForeColor = Color.Gold;
                    this.PBX_Link.BackgroundImage = Properties.Resources.network_normal;
                    this.LBL_Step3.ForeColor = this.LBL_Line2.ForeColor = Color.Gold;
                    this.PBX_Mail.BackgroundImage = Properties.Resources.mail_normal;
                    break;
                case EStatus.OK:
                    this.LBL_Step1.ForeColor = Color.LimeGreen;
                    this.PBX_Certify.BackgroundImage = Properties.Resources.check_ok;
                    this.LBL_Step2.ForeColor = this.LBL_Line1.ForeColor = Color.LimeGreen;
                    this.PBX_Link.BackgroundImage = Properties.Resources.network_ok;
                    this.LBL_Step3.ForeColor = this.LBL_Line2.ForeColor = Color.LimeGreen;
                    this.PBX_Mail.BackgroundImage = Properties.Resources.mail_ok;
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
        void ChangeStatus(int step, EStatus status)
        {
            if (step == 1)
            {
                switch (status)
                {
                    case EStatus.Error:
                        this.LBL_Step1.ForeColor = Color.Red;
                        this.PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                        break;
                    case EStatus.Normal:
                        this.LBL_Step1.ForeColor = Color.Gold;
                        this.PBX_Certify.BackgroundImage = Properties.Resources.check_normal;
                        break;
                    case EStatus.OK:
                        this.LBL_Step1.ForeColor = Color.LimeGreen;
                        this.PBX_Certify.BackgroundImage = Properties.Resources.check_ok;
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
                        this.LBL_Step2.ForeColor = this.LBL_Line1.ForeColor = Color.Red;
                        this.PBX_Link.BackgroundImage = Properties.Resources.network_error;
                        break;
                    case EStatus.Normal:
                        this.LBL_Step2.ForeColor = this.LBL_Line1.ForeColor = Color.Gold;
                        this.PBX_Link.BackgroundImage = Properties.Resources.network_normal;
                        break;
                    case EStatus.OK:
                        this.LBL_Step2.ForeColor = this.LBL_Line1.ForeColor = Color.LimeGreen;
                        this.PBX_Link.BackgroundImage = Properties.Resources.network_ok;
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
                        this.LBL_Step3.ForeColor = this.LBL_Line2.ForeColor = Color.Red;
                        this.PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                        break;
                    case EStatus.Normal:
                        this.LBL_Step3.ForeColor = this.LBL_Line2.ForeColor = Color.Gold;
                        this.PBX_Mail.BackgroundImage = Properties.Resources.mail_normal;
                        break;
                    case EStatus.OK:
                        this.LBL_Step3.ForeColor = this.LBL_Line2.ForeColor = Color.LimeGreen;
                        this.PBX_Mail.BackgroundImage = Properties.Resources.mail_ok;
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
            this.LBL_CertifyInfo.Text = settingCertify.GetConfigInfo();
            this.LBL_CertifyEnable.Text = (settingCertify.GetConfigReady() ? "就绪" : "未就绪");
            this.LBL_CertifyEnable.ForeColor = (settingCertify.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        private void ConfigUpdate(SettingLink settingLink)
        {
            this.LBL_LinkInfo.Text = settingLink.GetConfigInfo();
            this.LBL_LinkEnable.Text = (settingLink.GetConfigReady() ? "就绪" : "未就绪");
            this.LBL_LinkEnable.ForeColor = (settingLink.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        private void ConfigUpdate(SettingMail settingMail)
        {
            this.LBL_MailInfo.Text = settingMail.GetConfigInfo();
            this.LBL_MailEnable.Text = (settingMail.GetConfigReady() ? "就绪" : "未就绪");
            this.LBL_MailEnable.ForeColor = (settingMail.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        #endregion

        private void CHK_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoRun = this.CHK_AutoRun.Checked;
        }
    }
}
