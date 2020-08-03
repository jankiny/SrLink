using System;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink
{
    public partial class FRM_Config_Certify : Form
    {
        private readonly Setting_Certify Setting_Certify = null;
        private readonly ConfigHandler Config = null;
        #region 刷新窗体数据
        private void BindData()
        {
            this.CBX_Enable.Checked = (Setting_Certify.Enable == EEnable.True);
            if (Setting_Certify.Status == EStatus.Error)
            {
                this.LBL_Status.Text = "验证失败";
                this.LBL_Status.ForeColor = Color.Red;
            }
            else if (Setting_Certify.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            if (Setting_Certify.StudentID != "未配置")
            {
                this.TBX_ID.Text = Setting_Certify.StudentID;
            }
            if (Setting_Certify.Password != "未配置")
            {
                this.TBX_Password.Text = Setting_Certify.Password;
            }
        }
        #endregion
        public FRM_Config_Certify()
        {
            InitializeComponent();
        }
        public FRM_Config_Certify(ConfigHandler config)
        {
            InitializeComponent();
            Config = config;
            this.Setting_Certify = Config.Setting_Certify;
            BindData();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            this.Setting_Certify.Enable = this.CBX_Enable.Checked ? EEnable.True : EEnable.False;
            this.Setting_Certify.StudentID = this.TBX_ID.Text.Trim();
            this.Setting_Certify.Password = this.TBX_Password.Text.Trim();
            this.Config.Setting_Certify = this.Setting_Certify;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            this.Setting_Certify.StudentID = this.TBX_ID.Text.Trim();
            this.Setting_Certify.Password = this.TBX_Password.Text.Trim();
            CertifyHandler test_handler = new CertifyHandler(this.Setting_Certify);
            this.Setting_Certify.Status = (test_handler.RegisterSchoolNet(out _) ? EStatus.OK : EStatus.Error);
            BindData();
        }
    }
}
