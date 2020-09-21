using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kit.Win;

namespace SRLink.From
{
    public partial class SubFrmNormal : BaseForm
    {
        public SubFrmNormal()
        {
            InitializeComponent();
        }

        private void SubFrmNormal_Load(object sender, EventArgs e)
        {
            CHK_AutoRun.Checked = Config.RunAtStartup;
        }

        private void CHK_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Config.RunAtStartup = CHK_AutoRun.Checked;
            Sys.SetAutoRun(Global.autoRunRegPath, Global.autoRunName, Config.RunAtStartup);
        }
    }
}
