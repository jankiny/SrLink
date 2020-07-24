using System;

namespace SRLink.Model
{
    public class Setting_Link : SettingBase
    {
        public string Path;
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

        public Setting_Link()
        {
            this.Enable = 0;
            this.Path = @"C:\Program Files (x86)\cmclient\bin\CMClient.exe";
            this._Way = 2;
            this.X = 400;
            this.Y = 150;
        }
        public Setting_Link(int able, string path, int way, int x, int y)
        {
            this.Enable = able;
            this.Path = path;
            this._Way = way;
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
}
