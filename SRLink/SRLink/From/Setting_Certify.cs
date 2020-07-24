using System;
using System.Drawing;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink
{
    public partial class FRM_Config_Certify : Form
    {
        private readonly Setting_Certify setting = null;
        private readonly ConfigHandler config = null;
        #region 刷新窗体数据
        private void BindData()
        {
            this.CBX_Enable.Checked = (setting.Enable == EEnable.True);
            if (setting.Status == EStatus.Error)
            {
                this.LBL_Status.Text = "验证失败";
                this.LBL_Status.ForeColor = Color.Red;
            }
            else if (setting.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            if (setting.Student != "未配置")
            {
                this.TBX_ID.Text = setting.Student;
            }
            if (setting.Password != "未配置")
            {
                this.TBX_Password.Text = setting.Password;
            }
        }
        #endregion
        public FRM_Config_Certify()
        {
            InitializeComponent();
        }
        public FRM_Config_Certify(ConfigHandler c)
        {
            InitializeComponent();
            config = c;
            setting = config.ReadConfig_Certify();
            BindData();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            setting.Enable = this.CBX_Enable.Checked ? EEnable.True : EEnable.False;
            setting.Student = this.TBX_ID.Text.Trim();
            setting.Password = this.TBX_Password.Text.Trim();
            config.SaveConfig(setting);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            setting.Student = this.TBX_ID.Text.Trim();
            setting.Password = this.TBX_Password.Text.Trim();
            CertifyHandler test_handler = new CertifyHandler(setting);
            setting.Status = (test_handler.RegisterSchoolNet(out _) ? EStatus.OK : EStatus.Error);
            BindData();
        }
    }
}
