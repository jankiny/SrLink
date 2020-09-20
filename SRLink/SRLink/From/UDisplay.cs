using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLink.From
{
    public partial class UDisplay : UserControl
    {
        public string Key
        {
            get => LBL_Key.Text;
            set => LBL_Key.Text = value;
        }

        public string Content
        {
            get => LBL_Content.Text;
            set
            {
                if (value.Length > 20)
                {
                    // LBL_Content改变宽度
                }
                LBL_Content.Text = value;
            }
        }

        public bool UnderLine
        {
            get => LBL_Content.Font.Underline;
            set
            {
                if (value)
                {

                    this.LBL_Content.Font = new Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }
        }

        public UDisplay()
        {
            InitializeComponent();
        }
    }
}
