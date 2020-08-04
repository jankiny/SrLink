using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink
{
    public partial class FRM_Main : Form
    {
        readonly Queue<HandlerBase> Ready = null;
        readonly ConfigHandler Config = null;
        readonly List<Label> Runing = null;
        Thread thread_autolink = null;
        bool TodayLink = false;
        bool Busy = false;
        // 定义委托类型
        delegate void SetTextCallback(String str);
        #region WindowsFrom事件
        public FRM_Main()
        {
            InitializeComponent();
            Ready = new Queue<HandlerBase>();
            Config = new ConfigHandler(Application.ExecutablePath);
            Runing = new List<Label>();
        }

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            this.TSP_SLB_Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.TBX_Board.Text = string.Format("{0}[{1}]" + Environment.NewLine,  Global.SoftwareName, Global.Version);
            this.LBL_Version.Text = Global.Version;
            if (!Config.HasConfig())
            {
                WriteToBoard("第一次使用，请先到设置页输入认证账号等...");
                this.TodayLink = true;
                Setting_Certify config_Certify = new Setting_Certify();
                Setting_Link config_Link = new Setting_Link();
                Setting_Mail config_Mail = new Setting_Mail();
                Config.NewConfig(config_Certify, config_Link, config_Mail, DateTime.Parse("08:00"));
                ChangeStatus(1, EStatus.Error);
                ChangeStatus(2, EStatus.Error);
                ChangeStatus(3, EStatus.Error);

            }
            else
            {
                this.DTP_StartTime.Value = Config.Start_Time;
                Setting_Certify Setting_Certify = Config.Setting_Certify;
                UpdateConfig(Setting_Certify);
                ChangeStatus(1, (Setting_Certify.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                Setting_Link Setting_Link = Config.Setting_Link;
                UpdateConfig(Setting_Link);
                ChangeStatus(2, (Setting_Link.GetConfigReady() ? EStatus.Normal : EStatus.Error));

                Setting_Mail Setting_Mail = Config.Setting_Mail;
                UpdateConfig(Setting_Mail);
                ChangeStatus(3, (Setting_Mail.GetConfigReady() ? EStatus.Normal : EStatus.Error));
                WriteToBoard("配置文件载入成功");
            }
        }
        // Config页面时间设置按钮
        private void BTN_Set_Click(object sender, EventArgs e)
        {
            Config.Start_Time = this.DTP_StartTime.Value;
        }

        // CerifyConfig弹窗
        private void BTN_CerifyConfig_Click(object sender, EventArgs e)
        {
            FRM_Config_Certify f = new FRM_Config_Certify(Config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Setting_Certify setting_Certify = Config.Setting_Certify;
                UpdateConfig(setting_Certify);
                ChangeStatus(1, (setting_Certify.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            }
        }

        // LinkConfig弹窗
        private void BTN_LinkConfig_Click(object sender, EventArgs e)
        {
            FRM_Config_Link f = new FRM_Config_Link(Config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Setting_Link setting_Link = Config.Setting_Link;
                UpdateConfig(setting_Link);
                ChangeStatus(2, (setting_Link.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            }
        }

        // MailConfig弹窗
        private void BTN_MailConfig_Click(object sender, EventArgs e)
        {
            FRM_Config_Mail f = new FRM_Config_Mail(Config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Setting_Mail setting_Mail = Config.Setting_Mail;
                UpdateConfig(setting_Mail);
                ChangeStatus(3, (setting_Mail.GetConfigReady() ? EStatus.Normal : EStatus.Error));
            }
        }

        private void TMR_UpdateTime_Tick(object sender, EventArgs e)
        {
            this.TSP_SLB_Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (!this.TodayLink &&
                DateTime.Now.Hour <= 23 &&
                DateTime.Now.Hour >= 7 &&
                DateTime.Now.Hour * 60 + DateTime.Now.Minute >=
                this.DTP_StartTime.Value.Hour * 60 + this.DTP_StartTime.Value.Minute &&
                Ready.Count == 0)
            {
                RefreshQueue();
                this.TodayLink = true;
                this.TMR_Handle.Enabled = true;
            }
            // ToolBar状态显示
            if (thread_autolink != null)
            {
                if (thread_autolink.ThreadState == ThreadState.Aborted)
                {
                    this.TSP_SLB_Statu.Text = "连接中断";
                }
                else if (thread_autolink.ThreadState == ThreadState.Running ||
                    thread_autolink.ThreadState == ThreadState.WaitSleepJoin)
                {
                    this.TSP_SLB_Statu.Text = "连接中";
                }
                else if (thread_autolink.ThreadState == ThreadState.Stopped)
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
            if (!this.Busy && Ready.Count != 0)
            {
                WriteToBoard("开始连接...");
                this.Busy = true;
                thread_autolink = new Thread(Func);
                thread_autolink.Start();
            }
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            if (thread_autolink == null ||
                thread_autolink.ThreadState == ThreadState.Stopped ||
                thread_autolink.ThreadState == ThreadState.Aborted)
            {
                WriteToBoard("开始连接...");
                this.Busy = true;
                RefreshQueue();
                thread_autolink = new Thread(Func);
                thread_autolink.Start();
            }
        }  

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            //this.TodayLink = true;
            WriteToBoard("(User Command)停止连接...");
            Ready.Clear();
            if (thread_autolink.ThreadState == ThreadState.WaitSleepJoin || 
                thread_autolink.ThreadState == ThreadState.Running)
            {
                WriteToBoard("进程已被终止！");
                thread_autolink.Abort();
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
            CertifyHandler certifyHandler = new CertifyHandler(Config.Setting_Certify, 60, 3000, EHandler.Work);
            certifyHandler.RegisteUI(this.PBX_Certify);
            if (certifyHandler.Ready())
            {
                Ready.Enqueue(certifyHandler);
            }
            LinkHandler linkHandler = new LinkHandler(Config.Setting_Link, 60, 3000, EHandler.Work);
            linkHandler.RegisteUI(this.PBX_Link, this.LBL_Line1);
            if (linkHandler.Ready())
            {
                Ready.Enqueue(linkHandler);
            }
            MailHandler mailHandler = new MailHandler(Config.Setting_Mail, 60, 3000, EHandler.Work);
            mailHandler.RegisteUI(this.PBX_Mail, this.LBL_Line2);
            if (mailHandler.Ready())
            {
                Ready.Enqueue(mailHandler);
            }
        }
        // 托管的方法
        void Func()
        {
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
                        WriteToBoard("第" + count + "次认证失败[" + msg + "] 停止认证。");
                        return;
                    }
                    WriteToBoard(string.Format("第{0}次{1}失败[{2}] {3}s后重试。",
                        count, handler.HandleName, msg, handler.Delay / 1000));
                    count++;
                    Thread.Sleep(handler.Delay);
                }
                Runing.Clear();
                ChangeStatus(handler.ID, EStatus.OK);
                WriteToBoard(handler.HandleName + "成功！");
            }
            this.TMR_Handle.Enabled = false;
            this.Busy = false;
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

        // "设置"页更新配置信息
        private void UpdateConfig(Setting_Certify config_Certify)
        {
            this.LBL_CertifyInfo.Text = config_Certify.GetConfigInfo();
            this.LBL_CertifyEnable.Text = (config_Certify.GetConfigReady() ? "就绪" : "未就绪");
            this.LBL_CertifyEnable.ForeColor = (config_Certify.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        private void UpdateConfig(Setting_Link config_Link)
        {
            this.LBL_LinkInfo.Text = config_Link.GetConfigInfo();
            this.LBL_LinkEnable.Text = (config_Link.GetConfigReady() ? "就绪" : "未就绪");
            this.LBL_LinkEnable.ForeColor = (config_Link.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        private void UpdateConfig(Setting_Mail config_Mail)
        {
            this.LBL_MailInfo.Text = config_Mail.GetConfigInfo();
            this.LBL_MailEnable.Text = (config_Mail.GetConfigReady() ? "就绪" : "未就绪");
            this.LBL_MailEnable.ForeColor = (config_Mail.GetConfigReady() ? Color.LimeGreen : Color.Red);
        }
        #endregion

    }
}
