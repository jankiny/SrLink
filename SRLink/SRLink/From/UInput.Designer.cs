namespace SRLink.From
{
    partial class UInput
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
            this.LBL_Title = new System.Windows.Forms.Label();
            this.TBX_Content = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(4, 5);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(35, 12);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "Title";
            // 
            // TBX_Content
            // 
            this.TBX_Content.Location = new System.Drawing.Point(4, 23);
            this.TBX_Content.Name = "TBX_Content";
            this.TBX_Content.Size = new System.Drawing.Size(159, 21);
            this.TBX_Content.TabIndex = 1;
            // 
            // UInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TBX_Content);
            this.Controls.Add(this.LBL_Title);
            this.Name = "UInput";
            this.Size = new System.Drawing.Size(176, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.TextBox TBX_Content;
    }
}
