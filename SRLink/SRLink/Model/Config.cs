using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLink.Model
{
    [Serializable]
    public class Config
    {
        public bool HasConfig
        { 
            get; set; 
        }

        public DateTime StartTime
        {
            get; set;
        }

        public DateTime LastLinkTime
        {
            get; set;
        }

        public SettingCertify SettingCertify
        {
            get; set;
        }
        public SettingLink SettingLink
        {
            get; set;
        }

        public SettingMail SettingMail
        {
            get; set;
        }
    }

    [Serializable]
    public class SettingCertify : SettingBase
    {
        public string StudentID; // 学号
        public string Password; // 认证密码（一般为身份证后6位）

        // 用于第一次创建
        public SettingCertify()
        {
            base.Enable = 0;
            this.Status = 0;
            this.StudentID = "未配置";
            this.Password = "未配置";
        }

        // 用于读取保存的config
        public SettingCertify(EEnable able, EStatus status, string id, string pwd)
        {
            this.Enable = able;
            this.Status = status;
            this.StudentID = id;
            this.Password = pwd;
        }

        public string ShowStatus()
        {
            switch (this.Status)
            {
                case EStatus.Error:
                    return "验证失败";
                case EStatus.Normal:
                    return "待验证";
                case EStatus.OK:
                    return "验证成功";
                default:
                    return "status错误";
            }
        }

        public override string GetConfigInfo()
        {
            if (!string.IsNullOrEmpty(this.StudentID))
            {
                return string.Format("{0}({1})", this.StudentID, this.ShowStatus());
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

    [Serializable]
    public class SettingLink : SettingBase
    {
        public string Path;
        // TODO: 改成枚举类型
        private int _Way;
        public int Way
        {
            get
            {
                return _Way;
            }
            set
            {
                // 两种方式：使用windows窗体抓取；鼠标模拟点击；
                if (value == 1 || value == 2) this._Way = value;
                else
                {
                    this._Way = 1;
                    throw new Exception("状态不合法");
                }
            }
        }
        public int X;
        public int Y;

        public SettingLink()
        {
            this.Enable = 0;
            this.Path = @"C:\Program Files (x86)\cmclient\bin\CMClient.exe";
            this._Way = 2;
            this.X = 400;
            this.Y = 150;
        }
        public SettingLink(EEnable able, string path, int way, int x, int y)
        {
            this.Enable = able;
            this.Path = path;
            this.Way = way;
            this.X = x;
            this.Y = y;
        }
        // 返回配置信息
        public override string GetConfigInfo()
        {
            if (this._Way == 1)
            {
                return "抓取Windows窗体";
            }
            else
            {
                return string.Format("模拟鼠标点击（{0},{1}）", this.X, this.Y);
            }
        }

        // 返回配置状态
        public override bool GetConfigReady()
        {
            return base.GetConfigReady();
        }
    }

    [Serializable]
    public class SettingMail : SettingBase
    {
        public string Address;
        public SettingMail()
        {
            this.Enable = 0;
            this.Status = 0;
            this.Address = "未配置邮箱";
        }

        public SettingMail(EEnable able, EStatus status, string address)
        {
            this.Enable = able;
            this.Status = status;
            this.Address = address;
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
