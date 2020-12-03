using System;
using SRLink.Helper;

namespace SRLink.From
{
    public partial class SubFrmNormal : BaseForm
    {
        public FrmDebug FrmDebug { get; set; }
        public SubFrmNormal(FrmDebug frmDebug)
        {
            InitializeComponent();
            FrmDebug = frmDebug;
        }

        private void SubFrmNormal_Load(object sender, EventArgs e)
        {
            CHK_AutoRun.Checked = Config.RunAtStartup;
        }

        private void CHK_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Config.RunAtStartup = CHK_AutoRun.Checked;
            SystemHelper.SetAutoRun(StringHelper.GetAppString("AutoRunRegPath"), StringHelper.GetAppString("AutoRunName"), Config.RunAtStartup);
        }

        private void BTN_Debug_Click(object sender, EventArgs e)
        {
            LBL_Tip_Debug.Visible = true;
            FrmDebug.Show();
        }
    }
}
