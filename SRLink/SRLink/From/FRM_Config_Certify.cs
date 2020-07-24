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
        Config_Certify config_Certify = null;
        Config config = null;
        public FRM_Config_Certify()
        {
            InitializeComponent();
        }
        public FRM_Config_Certify(Config c)
        {
            InitializeComponent();
            config = c;
            config_Certify = c.ReadConfig_Certify();
            this.CBX_Enable.Checked = ( config_Certify.Enable == 1 ? true : false );
            if (config_Certify.Status == -1)
            {
                this.LBL_Status.Text = "验证失败";
                this.LBL_Status.ForeColor = Color.Red;
            }
            else if (config_Certify.Status == 0)
            {
                this.LBL_Status.Text = "待验证";
                this.LBL_Status.ForeColor = Color.DimGray;
            }
            else
            {
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            if (config_Certify.Student != "未配置")
            {
                this.TBX_ID.Text = config_Certify.Student;
            }
            if (config_Certify.Password != "未配置")
            {
                this.TBX_Password.Text = config_Certify.Password;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            config_Certify.Enable = (this.CBX_Enable.Checked ? 1 : 0);
            config_Certify.Student = this.TBX_ID.Text.Trim();
            config_Certify.Password = this.TBX_Password.Text.Trim();
            config.SaveConfig(config_Certify);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            if (Certify.Login(this.TBX_ID.Text.Trim(), this.TBX_Password.Text.Trim()) == "认证成功")
            {
                config_Certify.Status = 1;
                this.LBL_Status.Text = "验证成功";
                this.LBL_Status.ForeColor = Color.LimeGreen;
            }
            else
            {
                config_Certify.Status = -1;
                this.LBL_Status.Text = "验证失败";
                this.LBL_Status.ForeColor = Color.Red;
            }
        }
    }
}
