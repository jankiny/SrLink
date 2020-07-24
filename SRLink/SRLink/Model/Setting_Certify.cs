using System;

namespace SRLink.Model
{
    public class Setting_Certify : SettingBase
    {
        public string Student; // 学号
        public string Password; // 认证密码（一般为身份证后6位）
        
        // 用于第一次创建
        public Setting_Certify()
        {
            base.Enable = 0;
            this.Status = 0;
            this.Student = "未配置";
            this.Password = "未配置";
        }

        // 用于读取保存的config
        public Setting_Certify(EEnable able, EStatus status, string id, string pwd)
        {
            this.Enable = able;
            this.Status = status;
            this.Student = id;
            this.Password = pwd;
        }

        private string Convert(EStatus status)
        {
            switch(status)
            {
                case EStatus.Error:
                    return "验证失败";
                case EStatus.Notmal:
                    return "待验证";
                case EStatus.OK:
                    return "验证成功";
                default:
                    return "status错误";
            }
        }

        public override string GetConfigInfo()
        {
            if (!string.IsNullOrEmpty(this.Student))
            {
                return string.Format("{0}({1})", this.Student, Convert(this.Status));
            }
            else
            {
                return "无配置信息";
            }
        }

        public override bool GetConfigReady()
        {
            return (this.Enable == EEnable.True && this.Status == EStatus.OK);
        }
    }
}
