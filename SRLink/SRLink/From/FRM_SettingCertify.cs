using SRLink.Handler;
using SRLink.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SRLink.From
{
    public partial class FRM_SettingCertify : BaseForm
    {
        private readonly SettingCertify SettingCertify = null;
        #region 刷新窗体数据
        private void BindData()
        {
            CBX_Enable.Checked = (SettingCertify.Enable == EEnable.True);
            switch (SettingCertify.Status)
            {
                case EStatus.Error:
                    LBL_Status.Text = "验证失败";
                    LBL_Status.ForeColor = Color.Red;
                    break;
                case EStatus.Normal:
                    LBL_Status.Text = "待验证";
                    LBL_Status.ForeColor = Color.DimGray;
                    break;
                case EStatus.OK:
                    LBL_Status.Text = "验证成功";
                    LBL_Status.ForeColor = Color.LimeGreen;
                    break;
                default:
                    break;
            }

            TBX_ID.Text = SettingCertify.StudentID;
            TBX_Password.Text = SettingCertify.Password;
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
            SettingCertify = Config.SettingCertify;
            BindData();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            SettingCertify.Enable = CBX_Enable.Checked ? EEnable.True : EEnable.False;
            SettingCertify.StudentID = TBX_ID.Text.Trim();
            SettingCertify.Password = TBX_Password.Text.Trim();
            Config.SettingCertify = SettingCertify;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            SettingCertify.StudentID = TBX_ID.Text.Trim();
            SettingCertify.Password = TBX_Password.Text.Trim();
            CertifyHandler test_handler = new CertifyHandler(SettingCertify);
            SettingCertify.Status = (test_handler.RegisterSchoolNet(out _) ? EStatus.OK : EStatus.Error);
            BindData();
        }
    }
}
