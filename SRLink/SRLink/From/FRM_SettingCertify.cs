using System;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink.From
{
    public partial class FRM_SettingCertify : BaseForm
    {
        private readonly SettingCertify SettingCertify = null;
        #region 刷新窗体数据
        private void BindData()
        {
            this.CBX_Enable.Checked = (SettingCertify.Enable == EEnable.True);
            switch (this.SettingCertify.Status)
            {
                case EStatus.Error:
                    this.LBL_Status.Text = "验证失败";
                    this.LBL_Status.ForeColor = Color.Red;
                    break;
                case EStatus.Normal:
                    this.LBL_Status.Text = "待验证";
                    this.LBL_Status.ForeColor = Color.DimGray;
                    break;
                case EStatus.OK:
                    this.LBL_Status.Text = "验证成功";
                    this.LBL_Status.ForeColor = Color.LimeGreen;
                    break;
                default:
                    break;
            }

            this.TBX_ID.Text = SettingCertify.StudentID;
            this.TBX_Password.Text = SettingCertify.Password;
            //if (SettingCertify.StudentID != "未配置")
            //{
            //    this.TBX_ID.Text = SettingCertify.StudentID;
            //}
            //if (SettingCertify.Password != "未配置")
            //{
            //    this.TBX_Password.Text = SettingCertify.Password;
            //}
        }
        #endregion
        public FRM_SettingCertify()
        {
            InitializeComponent();
        }
        public FRM_SettingCertify(Config config)
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
            Config.SettingCertify = this.SettingCertify;
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
