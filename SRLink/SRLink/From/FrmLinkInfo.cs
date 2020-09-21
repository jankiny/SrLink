using SRLink.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Service;

namespace SRLink.From
{
    public partial class FrmLinkInfo : BaseForm
    {
        // 定义委托类型
        private delegate void SetTextCallback(string str);
        public FrmLinkInfo()
        {
            InitializeComponent();
        }

        private void FRM_LinkInfo_Load(object sender, EventArgs e)
        {
            WriteToBoard(string.Format("{0}[{1}]" + Environment.NewLine, Global.SoftwareName, Global.Version));


            //ConfigUpdate(Config.SettingCertify);
            ChangeStatus(1, Config.SettingCertify.Enable);

            //ConfigUpdate(Config.SettingLink);
            ChangeStatus(2, Config.SettingLink.Enable);

            //ConfigUpdate(Config.SettingMail);
            ChangeStatus(3, Config.SettingMail.Enable);

            WriteToBoard("配置文件载入成功");

            //Linked = Web.IsConnectInternet(Global.TestConnectionUrl);
            //if (Linked)
            //{
            //    WriteToBoard("检测到网络已连接");
            //    ////ChangeStatus(2, EStatus.OK);
            //}
        }
        #region 显示信息

        /// <summary>
        /// 将message显示到Board上
        /// </summary>
        /// <param name="msg">显示的信息</param>
        public void WriteToBoard(string msg)
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

        #region 修改UI

        /// <summary>
        /// 根据状态值改变所有主界面UI显示
        /// </summary>
        /// <param name="status">状态值</param>
        public void ChangeStatus(bool status)
        {
            switch (status)
            {
                case false:
                    LBL_Step1.ForeColor = Color.Red;
                    PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                    LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.Red;
                    PBX_Link.BackgroundImage = Properties.Resources.network_error;
                    LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.Red;
                    PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                    break;
                case true:
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
        public void ChangeStatus(int step, bool status)
        {
            switch (step)
            {
                case 1:
                    switch (status)
                    {
                        case false:
                            LBL_Step1.ForeColor = Color.Red;
                            PBX_Certify.BackgroundImage = Properties.Resources.check_error;
                            break;
                        case true:
                            LBL_Step1.ForeColor = Color.LimeGreen;
                            PBX_Certify.BackgroundImage = Properties.Resources.check_ok;
                            break;
                        default:
                            break;
                    }

                    break;
                case 2:
                    switch (status)
                    {
                        case false:
                            LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.Red;
                            PBX_Link.BackgroundImage = Properties.Resources.network_error;
                            break;
                        case true:
                            LBL_Step2.ForeColor = LBL_Line1.ForeColor = Color.LimeGreen;
                            PBX_Link.BackgroundImage = Properties.Resources.network_ok;
                            break;
                        default:
                            break;
                    }

                    break;
                case 3:
                    switch (status)
                    {
                        case false:
                            LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.Red;
                            PBX_Mail.BackgroundImage = Properties.Resources.mail_error;
                            break;
                        case true:
                            LBL_Step3.ForeColor = LBL_Line2.ForeColor = Color.LimeGreen;
                            PBX_Mail.BackgroundImage = Properties.Resources.mail_ok;
                            break;
                        default:
                            break;
                    }

                    break;
            }
        }

        /// <summary>
        /// 设置页刷新UI
        /// </summary>
        /// <param name="settingCertify"></param>
        //private void ConfigUpdate(SettingCertify settingCertify)
        //{
        //    LBL_CertifyInfo.Text = settingCertify.GetConfigInfo();
        //    LBL_CertifyEnable.Text = (settingCertify.GetConfigReady() ? "就绪" : "未就绪");
        //    LBL_CertifyEnable.ForeColor = (settingCertify.GetConfigReady() ? Color.LimeGreen : Color.Red);
        //}

        //private void ConfigUpdate(SettingLink settingLink)
        //{
        //    LBL_LinkInfo.Text = settingLink.GetConfigInfo();
        //    LBL_LinkEnable.Text = (settingLink.GetConfigReady() ? "就绪" : "未就绪");
        //    LBL_LinkEnable.ForeColor = (settingLink.GetConfigReady() ? Color.LimeGreen : Color.Red);
        //}

        //private void ConfigUpdate(SettingMail settingMail)
        //{
        //    LBL_MailInfo.Text = settingMail.GetConfigInfo();
        //    LBL_MailEnable.Text = (settingMail.GetConfigReady() ? "就绪" : "未就绪");
        //    LBL_MailEnable.ForeColor = (settingMail.GetConfigReady() ? Color.LimeGreen : Color.Red);
        //}

        #endregion

        private void FrmLinkInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            //ShowInTaskbar = false;
        }
    }
}
