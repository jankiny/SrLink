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
            CHK_Debug.Checked = Config.Debug;
        }

        private void CHK_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            Config.RunAtStartup = CHK_AutoRun.Checked;
            SystemHelper.SetAutoRun(StringHelper.GetAppString("AutoRunRegPath"), StringHelper.GetAppString("AutoRunName"), Config.RunAtStartup);
        }

        private void CHK_Debug_CheckedChanged(object sender, EventArgs e)
        {
            Config.Debug = CHK_Debug.Checked;
            LBL_Tip_Debug.Visible = CHK_Debug.Checked;
            if (CHK_Debug.Checked)
            {
                FrmDebug.Show();
            }
            else
            {
                FrmDebug.Hide();
            }
        }
    }
}
