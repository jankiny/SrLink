using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRLink.Handler;
using SRLink.Model;

namespace SRLink
{
    public partial class FRM_Config_Certify : Form
    {
        private readonly Setting_Certify setting = null;
        private readonly ConfigHandler config = null;
        public FRM_Config_Certify()
        {
            InitializeComponent();
        }
        public FRM_Config_Certify(ConfigHandler c)
        {
            InitializeComponent();
            config = c;
            setting = c.ReadConfig_Certify();
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
            if (CertifyHandler.Login(this.TBX_ID.Text.Trim(), this.TBX_Password.Text.Trim()) == "认证成功")
            {
                setting.Status = EStatus.OK;
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            else
            {
                setting.Status = EStatus.Error;
                this.LBL_Status.Text = "验证失败";
                this.LBL_Status.ForeColor = Color.Red;
            }
        }
    }
}
