using Kit.Utils;
using System;

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

        public bool AutoRun
        {
            get; set;
        }

        public bool EnableLink()
        {
            int now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return now >= StartTime.Hour * 60 + StartTime.Minute && now < Global.NightNotLink;
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
            Status = 0;
            //this.StudentID = "未配置";
            //this.Password = "未配置";
            StudentID = "";
            Password = "";
        }

        // 用于读取保存的config
        public SettingCertify(EEnable able, EStatus status, string id, string pwd)
        {
            Enable = able;
            Status = status;
            StudentID = id;
            Password = pwd;
        }

        public string ShowStatus()
        {
            switch (Status)
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
            if (!string.IsNullOrEmpty(StudentID))
            {
                return string.Format("{0}({1})", StudentID, ShowStatus());
            }
            else
            {
                return "无配置信息";
            }
        }

        public override bool GetConfigReady()
        {
            return (Enable == EEnable.True && Status == EStatus.OK);
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
                if (value == 1 || value == 2) _Way = value;
                else
                {
                    _Way = 1;
                    Log.SaveLog("SettingLink.Way赋值不合法");
                }
            }
        }
        public int X;
        public int Y;

        public SettingLink()
        {
            Enable = 0;
            //this.Path = @"C:\Program Files (x86)\cmclient\bin\CMClient.exe";
            Path = "";
            _Way = 2;
            X = 400;
            Y = 150;
        }
        public SettingLink(EEnable able, string path, int way, int x, int y)
        {
            Enable = able;
            Path = path;
            Way = way;
            X = x;
            Y = y;
        }
        // 返回配置信息
        public override string GetConfigInfo()
        {
            if (_Way == 1)
            {
                return "抓取Windows窗体";
            }
            else
            {
                return string.Format("模拟鼠标点击（{0},{1}）", X, Y);
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
            Enable = 0;
            Status = 0;
            //this.Address = "未配置邮箱";
            Address = "";
        }

        public SettingMail(EEnable able, EStatus status, string address)
        {
            Enable = able;
            Status = status;
            Address = address;
        }

        // 返回配置信息
        public override string GetConfigInfo()
        {
            if (!string.IsNullOrEmpty(Address))
            {
                return Address;
            }
            else
            {
                return "无配置信息";
            }
        }

        // 返回配置状态
        public override bool GetConfigReady()
        {
            if (Enable == EEnable.True && Status == EStatus.OK)
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
