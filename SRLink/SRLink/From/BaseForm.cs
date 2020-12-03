using System;
using System.Windows.Forms;
using SRLink.Helper;
using SRLink.Model;
using SRLink.Service;

namespace SRLink.From
{
    public partial class BaseForm : Form
    {
        protected static ConfigModel Config;
        protected new static System.Drawing.Icon Icon;
        public BaseForm()
        {
            InitializeComponent();
            LoadCustomIcon();
        }
        private void LoadCustomIcon()
        {
            try
            {
                if (Icon == null)
                {
                    string file = SystemHelper.GetPath(StringHelper.GetAppString("CustomIconName"));
                    if (!System.IO.File.Exists(file))
                    {
                        return;
                    }
                    Icon = new System.Drawing.Icon(file);
                }
                base.Icon = Icon;
            }
            catch (Exception e)
            {
                LoggerService.SaveLog($"Loading custom icon failed: {e.Message}");
            }
        }
    }
}
