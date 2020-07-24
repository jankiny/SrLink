using System;

namespace SRLink.Model
{
    public class Setting_Certify : SettingBase
    {
        private int _Status; // 当前状态 
        public int Status
        {
            get { return _Status; }
            set
            {
                // 三种状态：验证失败；待验证；验证成功
                if (value == -1 || value == 0 || value == 1) this._Status = value;
                else
                {
                    this._Status = 0;
                    throw new Exception("状态不合法");

                }
            }
        }
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
        public Setting_Certify(int able, int status, string id, string pwd)
        {
            this.Enable = able;
            this.Status = status;
            this.Student = id;
            this.Password = pwd;
        }

        private string Convert(int status)
        {
            switch(status)
            {
                case -1:
                    return "验证失败";
                case 0:
                    return "待验证";
                case 1:
                    return "验证成功";
                default:
                    return "status错误";
            }
        }

        public override string GetConfigInfo()
        {
            if (!string.IsNullOrEmpty(this.Student))
            {
                return string.Format("{0}({1})", this.Student, Convert(this._Status));
            }
            else
            {
                return "无配置信息";
            }
        }

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
