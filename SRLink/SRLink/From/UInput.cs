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
    public partial class UInput : UserControl
    {

        public string Title
        {
            get => LBL_Title.Text;
            set => LBL_Title.Text = value;
        }

        public string Content
        {
            get => TBX_Content.Text;
            set => TBX_Content.Text = value;
        }

        public bool Password
        {
            get => TBX_Content.UseSystemPasswordChar;
            set => TBX_Content.UseSystemPasswordChar = value;
        }

        public UInput()
        {
            InitializeComponent();
        }
        //定义委托
        public delegate void ContentTextChanged(object sender, EventArgs e);
        //定义事件
        public event ContentTextChanged UcContentTextChanged;

        private void TBX_Content_TextChanged(object sender, EventArgs e)
        {
            UcContentTextChanged?.Invoke(sender, new EventArgs());//把按钮自身作为参数传递
        }
    }
}
