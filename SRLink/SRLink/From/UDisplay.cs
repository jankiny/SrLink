using System.Drawing;
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

                    this.LBL_Content.Font = new Font("宋体", 9F, FontStyle.Underline, GraphicsUnit.Point, 134);
                }
            }
        }

        public UDisplay()
        {
            InitializeComponent();
        }
    }
}
