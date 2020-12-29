using System;
using SRLink.Helper;

namespace SRLink.From
{
    public partial class SubFrmAbout : BaseForm
    {
        public SubFrmAbout()
        {
            InitializeComponent();
            UDisplay_Version.Content = StringHelper.GetAppString("Version");
        }

        private void UDisplay_Note_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jankiny/SRLink");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
