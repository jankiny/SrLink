namespace SRLink.Model
{
    public abstract class SettingBase
    {
        public int Enable
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
            return this.Enable == 1;
        }
    }
}
