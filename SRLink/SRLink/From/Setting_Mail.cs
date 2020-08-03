﻿using SRLink.Handler;
using SRLink.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SRLink
{
    public partial class FRM_Config_Mail : Form
    {
        private readonly Setting_Mail Setting_Mail = null;
        private readonly ConfigHandler Config = null;
        string code;
        int Count = 0;
        public FRM_Config_Mail()
        {
            InitializeComponent();
        }
        public FRM_Config_Mail(ConfigHandler config)
        {
            InitializeComponent();
            Config = config;
            this.Setting_Mail = Config.Setting_Mail;
            this.CBX_Enable.Checked = (this.Setting_Mail.Enable == EEnable.True);
            if (this.Setting_Mail.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            this.TBX_Address.Text = this.Setting_Mail.Address;
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            if (this.TBX_Code.Text == code)
            {
                this.Setting_Mail.Status = EStatus.OK;
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            this.Setting_Mail.Enable = (this.CBX_Enable.Checked ? EEnable.True : EEnable.False);
            this.Setting_Mail.Address = this.TBX_Address.Text.Trim();
            Config.Setting_Mail = this.Setting_Mail;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Sent_Click(object sender, EventArgs e)
        {
            this.LBL_Status.Text = "待验证";
            this.LBL_Status.ForeColor = Color.DimGray;
            this.TMR_ReSent.Enabled = true;
            Count = 15;
            this.BTN_Sent.Enabled = false;
            this.BTN_Sent.Text = "15s";            
            code = MailHandler.TestMail(this.TBX_Address.Text);
        }

        private void TMR_ReSent_Tick(object sender, EventArgs e)
        {
            if (this.Count == 1)
            {
                this.BTN_Sent.Enabled = true;
                this.TMR_ReSent.Enabled = false;
                this.BTN_Sent.Text = "发送";
            }
            else
            {
                this.Count--;
                this.BTN_Sent.Text = this.Count.ToString() + "s";
            }
        }
    }
}
