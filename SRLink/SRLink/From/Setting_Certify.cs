﻿using System;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink
{
    public partial class FRM_Config_Certify : Form
    {
        private readonly SettingCertify SettingCertify = null;
        private readonly Config Config = null;
        #region 刷新窗体数据
        private void BindData()
        {
            this.CBX_Enable.Checked = (SettingCertify.Enable == EEnable.True);
            if (SettingCertify.Status == EStatus.Error)
            {
                this.LBL_Status.Text = "验证失败";
                this.LBL_Status.ForeColor = Color.Red;
            }
            else if (SettingCertify.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            if (SettingCertify.StudentID != "未配置")
            {
                this.TBX_ID.Text = SettingCertify.StudentID;
            }
            if (SettingCertify.Password != "未配置")
            {
                this.TBX_Password.Text = SettingCertify.Password;
            }
        }
        #endregion
        public FRM_Config_Certify()
        {
            InitializeComponent();
        }
        public FRM_Config_Certify(Config config)
        {
            InitializeComponent();
            Config = config;
            this.SettingCertify = Config.SettingCertify;
            BindData();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            this.SettingCertify.Enable = this.CBX_Enable.Checked ? EEnable.True : EEnable.False;
            this.SettingCertify.StudentID = this.TBX_ID.Text.Trim();
            this.SettingCertify.Password = this.TBX_Password.Text.Trim();
            this.Config.SettingCertify = this.SettingCertify;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            this.SettingCertify.StudentID = this.TBX_ID.Text.Trim();
            this.SettingCertify.Password = this.TBX_Password.Text.Trim();
            CertifyHandler test_handler = new CertifyHandler(this.SettingCertify);
            this.SettingCertify.Status = (test_handler.RegisterSchoolNet(out _) ? EStatus.OK : EStatus.Error);
            BindData();
        }
    }
}
