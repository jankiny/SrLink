using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Model
{
    public class Setting_Mail : SettingBase
    {
        public string Address;
        public Setting_Mail()
        {
            this.Enable = 0;
            this.Status = 0;
            this.Address = "未配置邮箱";
        }

        public Setting_Mail(EEnable able, EStatus status, string mail)
        {
            this.Enable = able;
            this.Status = status;
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
            if (this.Enable == EEnable.True && this.Status == EStatus.OK)
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
