using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Helper;

namespace SRLink.From
{
    public partial class FrmDebug : BaseForm
    {
        // 定义委托类型
        private delegate void SetTextCallback(string str);
        public FrmDebug()
        {
            InitializeComponent();
            WriteToBoard(string.Format("{0}[{1}] " + Environment.NewLine, StringHelper.GetAppString("SoftwareName"), StringHelper.GetAppString("Version")));
            WriteToBoard("当前配置：");
            WriteToBoard($"RunAtStartup(开机启动) - {Config.RunAtStartup}");
            WriteToBoard($"Debug(调试) - {Config.Debug}");
            WriteToBoard($"AutoLink(自动连接) - {Config.AutoLink}");
            WriteToBoard($"SettingCertify.Enable(启用认证) - {Config.SettingCertify.Enable}");
            WriteToBoard($"SettingLink.Enable(启用连接网络) - {Config.SettingLink.Enable}");
            WriteToBoard($"SettingMail.Enable(启用发送Ip) - {Config.SettingMail.Enable}" + Environment.NewLine + Environment.NewLine);
        }

        #region 窗口事件

        private void FrmDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }


        #endregion

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

            TBX_Board.AppendText($"{DateTime.Now:yyyy-MM-dd hh:mm:ss}: {msg}");
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
    }
}
