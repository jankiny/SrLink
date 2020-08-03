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
        readonly Queue<HandlerBase> ready;
        private readonly ConfigHandler config = null;
        Thread thread_autolink = null;
        bool TodayLink = false;
        int flash = 0;
        bool Busy = false;
        // 定义委托类型
        delegate void SetTextCallback(String str);
        #region WindowsFrom事件
        public FRM_Main()
        {
            InitializeComponent();
            ready = new Queue<HandlerBase>();
            this.TSP_SLB_Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.TBX_Board.Text = "欢迎使用AutoLink";
            config = new ConfigHandler(Application.ExecutablePath);
            if (!config.HasConfig())
            {
                WriteToBoard("第一次使用，请先到设置页输入认证账号等...");
                this.TodayLink = true;
                Setting_Certify config_Certify = new Setting_Certify();
                Setting_Link config_Link = new Setting_Link();
                Setting_Mail config_Mail = new Setting_Mail();
                config.NewConfig(config_Certify, config_Link, config_Mail, DateTime.Parse("08:00"));
                this.PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                this.PBX_Link.BackgroundImage = Properties.Resources.network_error;
                this.PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                
            }
            else
            {
                WriteToBoard("载入配置文件...");
                this.DTP_StartTime.Value = config.ReadConfig_Time();
                Setting_Certify config_Certify = config.ReadConfig_Certify();
                UpdateConfig(config_Certify);
                this.PBX_Certify.BackgroundImage = (config_Certify.GetConfigReady() ? Properties.Resources.check_normal : Properties.Resources.check_error);
                ChangeStatus(1, (config_Certify.GetConfigReady() ? 0 : -1));

                Setting_Link config_Link = config.ReadConfig_Link();
                UpdateConfig(config_Link);
                this.PBX_Link.BackgroundImage = (config_Link.GetConfigReady() ? Properties.Resources.network_normal : Properties.Resources.network_error);
                ChangeStatus(2, (config_Link.GetConfigReady() ? 0 : -1));

                Setting_Mail config_Mail = config.ReadConfig_Mail();
                UpdateConfig(config_Mail);
                this.PBX_Mail.BackgroundImage = (config_Mail.GetConfigReady() ? Properties.Resources.mail_normal : Properties.Resources.mail_error);
                ChangeStatus(3, (config_Mail.GetConfigReady() ? 0 : -1));
                WriteToBoard("配置文件载入成功");
            }
        }

        private void BTN_Set_Click(object sender, EventArgs e)
        {
            config.SaveConfig(this.DTP_StartTime.Value);
        }

        // CerifyConfig弹窗
        private void BTN_CerifyConfig_Click(object sender, EventArgs e)
        {
            FRM_Config_Certify f = new FRM_Config_Certify(config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Setting_Certify config_Certify = config.ReadConfig_Certify();
                UpdateConfig(config_Certify);
                this.PBX_Certify.BackgroundImage = (config_Certify.GetConfigReady() ? Properties.Resources.check_normal : Properties.Resources.check_error);
            }
        }

        // LinkConfig弹窗
        private void BTN_LinkConfig_Click(object sender, EventArgs e)
        {
            FRM_Config_Link f = new FRM_Config_Link(config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Setting_Link config_Link = config.ReadConfig_Link();
                UpdateConfig(config_Link);
                this.PBX_Link.BackgroundImage = (config_Link.GetConfigReady() ? Properties.Resources.network_normal : Properties.Resources.network_error);
            }
        }

        // MailConfig弹窗
        private void BTN_MailConfig_Click(object sender, EventArgs e)
        {
            FRM_Config_Mail f = new FRM_Config_Mail(config);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Setting_Mail config_Mail = config.ReadConfig_Mail();
                UpdateConfig(config_Mail);
                this.PBX_Mail.BackgroundImage = (config_Mail.GetConfigReady() ? Properties.Resources.mail_normal : Properties.Resources.mail_error);
            }
        }


        private void TMR_Now_Tick(object sender, EventArgs e)
        {
            this.TSP_SLB_Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (flash == 1)
            {
                this.LBL_Line1.ForeColor = (this.LBL_Line1.ForeColor == Color.DimGray ? Color.LimeGreen : Color.DimGray);
            }
            if (flash == 2)
            {
                this.LBL_Line2.ForeColor = (this.LBL_Line2.ForeColor == Color.DimGray ? Color.LimeGreen : Color.DimGray);
            }
            //DateTime t = config.ReadConfig_Time();
            if (!this.TodayLink && 
                DateTime.Now.Hour <=  23 &&
                DateTime.Now.Hour >= 7 && 
                DateTime.Now.Hour * 60 + DateTime.Now.Minute >= 
                this.DTP_StartTime.Value.Hour * 60 + this.DTP_StartTime.Value.Minute &&
                ready.Count == 0 )
            {
                RefreshQueue();
                this.TodayLink = true;
            }
            if (!this.Busy &&
                ready.Count != 0)
            {
                WriteToBoard("开始连接...");
                this.Busy = true;
                thread_autolink = new Thread(Func);
                thread_autolink.Start();
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
            flash = 0;
            if (thread_autolink.ThreadState == ThreadState.WaitSleepJoin || 
                thread_autolink.ThreadState == ThreadState.Running)
            {
                WriteToBoard("进程已被终止！");
                thread_autolink.Abort();
            }
        }
        #endregion
        #region UI控制
        void ChangeStatus(int step, int status)
        {
            Color c;
            switch (status)
            {
                case -1:
                    c = Color.Red;
                    break;
                case 0:
                    c = Color.Gold;
                    break;
                case 1:
                    c = Color.LimeGreen;
                    break;
                default:
                    c = Color.Gold;
                    break;
            }
            if (step == 1)
            {
                this.LBL_Step1.ForeColor = c;
            }
            else if (step == 2)
            {
                this.LBL_Step2.ForeColor = c;
                this.LBL_Line1.ForeColor = c;
            }
            else if (step == 3)
            {
                this.LBL_Step3.ForeColor = c;

            }
        }
        #endregion

        #region 辅助函数
        void RefreshQueue()
        {
            if (ready.Count != 0)
            {
                ready.Clear();
            }
            CertifyHandler certifyHandler = new CertifyHandler(config.ReadConfig_Certify(), 60, 3000, EHandler.Work);
            if (certifyHandler.Ready())
            {
                ready.Enqueue(certifyHandler);
            }
            LinkHandler linkHandler = new LinkHandler(config.ReadConfig_Link(), 60, 3000, EHandler.Work);
            if (linkHandler.Ready())
            {
                ready.Enqueue(linkHandler);
            }
            MailHandler mailHandler = new MailHandler(config.ReadConfig_Mail(), 60, 3000, EHandler.Work);
            if (mailHandler.Ready())
            {
                ready.Enqueue(mailHandler);
            }
        }

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
                this.TBX_Board.Text += string.Format(Environment.NewLine + "{0}: {1}", this.TSP_SLB_Time.Text, msg);
            }
        }
        //void Finish(Label label)
        //{
        //    flash = 0;
        //    label.ForeColor = Color.LimeGreen;
        //}
        // 托管的方法
        void Func()
        {
            while (ready.Count != 0)
            {
                HandlerBase handler = ready.Dequeue();
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
                WriteToBoard(handler.HandleName + "成功！");
            }
            this.Busy = false;
            //int flag = 0;
            //Setting_Certify config_Certify = config.ReadConfig_Certify();
            //if (config_Certify.GetConfigReady())
            //{
            //    Step1(config_Certify, 60, 60000);
            //    flag++;
            //}
            //Setting_Link config_Link = config.ReadConfig_Link();
            //if (config_Link.GetConfigReady())
            //{
            //    Step2(config_Link, 30, 3000);
            //    flag++;
            //}
            //Setting_Mail config_Mail = config.ReadConfig_Mail();
            //if (config_Mail.GetConfigReady())
            //{
            //    Step3(config_Mail, 15, 3000);
            //    flag++;
            //}
            //if (flag == 0)
            //{
            //    this.TodayLink = true;
            //    WriteToBoard("获取不到认证账号...");
            //    WriteToBoard("（Notice）请到设置页面进行设置,然后手动连接。");
            //}
        }

        // 连接随e行
        //void Step2(Setting_Link config_Link, int round, int delay)
        //{
        //    if (config_Link.GetConfigReady())
        //    {
        //        int count = 1;
        //        do
        //        {
        //            if (count != 1)
        //            {
        //                WriteToBoard(string.Format("第{0}次连接失败！重新尝试连接。", count, delay / 1000));
        //            }
        //            else if (count == round)
        //            {
        //                WriteToBoard("第" + count + "次连接失败！停止连接。");
        //                return;
        //            }
        //            WriteToBoard("正在打开随e行...");
        //            flash = 1;
        //            LinkHandler.OpenSuiEXing(config_Link.Path);
        //            Thread.Sleep(delay); // 等待随e行打开

        //            WriteToBoard("正在连接网络...");
        //            LinkHandler.LinkSuiEXing(config_Link.X, config_Link.Y);
        //            Thread.Sleep(delay);
        //            count++;
        //        } while (LinkHandler.IsConnectInternet() != true);

        //        WriteToBoard("网络连接成功！");
        //        Finish(LBL_Line1);
        //        Finish(LBL_Step2);
        //        Thread.Sleep(1000);
        //    }
        //}
        // 发送IP信息
        //void Step3(Setting_Mail config_Mail, int round, int delay)
        //{
        //    WriteToBoard("正在发送IP地址...");
        //    flash = 2;
        //    int count = 1;
        //    while (MailHandler.SendIP(config_Mail.Address) != true)
        //    {
        //        if (count == round)
        //        {
        //            WriteToBoard("第" + count + "次发送IP失败！停止发送。");
        //            return;
        //        }
        //        WriteToBoard(string.Format("第{0}次认证失败！{1}s后重试。", count, delay / 1000));
        //        count++;
        //        Thread.Sleep(delay);
        //    }
        //    this.TodayLink = true;
        //    WriteToBoard("IP地址发送成功！");
        //    Finish(LBL_Line2);
        //    Finish(LBL_Step3);
        //}
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
