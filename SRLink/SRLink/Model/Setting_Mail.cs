using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Model
{
    public class Setting_Mail : SettingBase
    {
        private int _Status; // 当前状态 
        public int Status
        {
            get { return _Status; }
            set
            {
                // 状态：待验证；验证成功
                if (value == 0 || value == 1) this._Status = value;
                else
                {
                    this._Status = 0;
                    throw new Exception("状态不合法");

                }
            }
        }
        public string Address;
        public Setting_Mail()
        {
            this.Enable = 0;
            this.Status = 0;
            this.Address = "未配置邮箱";
        }

        public Setting_Mail(int able, int status, string mail)
        {
            this.Enable = able;
            this._Status = status;
            this.Address = mail;
        }

        // 返回配置信息
        public override string GetConfigInfo()
        {
            if (!string.IsNullOrEmpty(this.Address))
            {
                return this.Address;
            }
            else
            {
                return "无配置信息";
            }
        }

        // 返回配置状态
        public override bool GetConfigReady()
        {
            if (this.Enable == 1 && this._Status == 1)
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
