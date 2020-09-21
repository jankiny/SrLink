using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLink.From
{
    public partial class SubFrmAbout : Form
    {
        public SubFrmAbout()
        {
            InitializeComponent();
            UDisplay_Version.Content = Global.Version;
        }

        private void UDisplay_Note_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jankiny/SRLink");
        }
    }
}
