using System;

namespace SRLink.Model
{
    public abstract class SettingBase
    {
        public EEnable Enable
        {
            get; set;
        }

        public EStatus Status
        {
            get; set;
        }

        // 返回配置信息
        public virtual string GetConfigInfo()
        {
            return "";
        }

        // 返回配置状态
        public virtual bool GetConfigReady()
        {
            return this.Enable == EEnable.True;
        }
    }
}
