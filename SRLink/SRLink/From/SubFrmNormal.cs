using System;
using SRLink.Helper;

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
            StringHelper.SetAutoRun(Global.autoRunRegPath, Global.autoRunName, Config.RunAtStartup);
        }
    }
}
