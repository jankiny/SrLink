using SRLink.Model;
using System.Windows.Forms;

namespace SRLink.Handler
{
    public class HandlerBase
    {
        public int ID;
        protected EHandler Mode;
        public string HandleName;
        public int Delay;
        public int Count;


        public PictureBox Picture;
        public Label Line;

        public virtual bool Run(out string msg)
        {
            msg = "";
            return false;
        }


        public virtual bool Ready()
        {
            return false;
        }

        public virtual void RegisteUI(PictureBox picture)
        {
            // 备注：实际上注册的PictureBox没有被用到
            Picture = picture;
        }
        public virtual void RegisteUI(PictureBox picture, Label label)
        {
            Picture = picture;
            Line = label;
        }
    }
}
