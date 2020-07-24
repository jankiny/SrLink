using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Model
{
    public abstract class ConfigBase
    {
        protected bool _Enable; // 是否启用
        public int Enable
        {
            get
            {
                if (this._Enable) return 1;
                else return 0;
            }
            set
            {
                if (value == 1) this._Enable = true;
                else this._Enable = false;
            }
        }

        // 返回配置信息
        public virtual string GetConfigInfo()
        {
            return "";
        }

        // 返回配置状态
        public virtual bool GetConfigReady()
        {
            if (this._Enable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
