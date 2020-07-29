using SRLink.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Handler
{
    public class HandlerBase
    {
        public int ID;
        protected EHandler Mode;
        public string HandleName;
        public int Delay;
        public int Count;

        public virtual bool Run(out string msg)
        {
            msg = "";
            return false;
        }


        public virtual bool Ready()
        {
            return false;
        }
    }
}
