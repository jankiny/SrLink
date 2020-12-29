namespace SRLink.From
{
    partial class UDisplay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_Key = new System.Windows.Forms.Label();
            this.LBL_Content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBL_Key
            // 
            this.LBL_Key.Location = new System.Drawing.Point(5, 5);
            this.LBL_Key.Name = "LBL_Key";
            this.LBL_Key.Size = new System.Drawing.Size(61, 12);
            this.LBL_Key.TabIndex = 0;
            this.LBL_Key.Text = "Key";
            // 
            // LBL_Content
            // 
            this.LBL_Content.AutoSize = true;
            this.LBL_Content.Location = new System.Drawing.Point(89, 5);
            this.LBL_Content.Name = "LBL_Content";
            this.LBL_Content.Size = new System.Drawing.Size(47, 12);
            this.LBL_Content.TabIndex = 1;
            this.LBL_Content.Text = "Content";
            // 
            // UDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LBL_Content);
            this.Controls.Add(this.LBL_Key);
            this.Name = "UDisplay";
            this.Size = new System.Drawing.Size(286, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Key;
        private System.Windows.Forms.Label LBL_Content;
    }
}
