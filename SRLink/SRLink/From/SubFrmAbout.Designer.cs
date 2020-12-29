namespace SRLink.From
{
    partial class SubFrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.uDisplay1 = new SRLink.From.UDisplay();
            this.UDisplay_Version = new SRLink.From.UDisplay();
            this.UDisplay_Author = new SRLink.From.UDisplay();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uDisplay1
            // 
            this.uDisplay1.Content = "Github主页(https://github.com/jankiny/SrLink)";
            this.uDisplay1.Key = "主页：";
            this.uDisplay1.Location = new System.Drawing.Point(28, 145);
            this.uDisplay1.Name = "uDisplay1";
            this.uDisplay1.Size = new System.Drawing.Size(364, 23);
            this.uDisplay1.TabIndex = 8;
            this.uDisplay1.UnderLine = true;
            this.uDisplay1.Click += new System.EventHandler(this.UDisplay_Note_Click);
            // 
            // UDisplay_Version
            // 
            this.UDisplay_Version.Content = "vX.X.X_yymmdd_alpha";
            this.UDisplay_Version.Key = "版本：";
            this.UDisplay_Version.Location = new System.Drawing.Point(28, 43);
            this.UDisplay_Version.Name = "UDisplay_Version";
            this.UDisplay_Version.Size = new System.Drawing.Size(286, 23);
            this.UDisplay_Version.TabIndex = 8;
            this.UDisplay_Version.UnderLine = false;
            // 
            // UDisplay_Author
            // 
            this.UDisplay_Author.Content = "Jankiny";
            this.UDisplay_Author.Key = "作者：";
            this.UDisplay_Author.Location = new System.Drawing.Point(28, 14);
            this.UDisplay_Author.Name = "UDisplay_Author";
            this.UDisplay_Author.Size = new System.Drawing.Size(286, 23);
            this.UDisplay_Author.TabIndex = 8;
            this.UDisplay_Author.UnderLine = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(364, 67);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "说明：本程序基于GPL-2.0协议开源，如果在使用中出现问题或有更好的建议，请到GitHub页面提交。";
            // 
            // SubFrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 209);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uDisplay1);
            this.Controls.Add(this.UDisplay_Version);
            this.Controls.Add(this.UDisplay_Author);
            this.Name = "SubFrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于SrLink";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UDisplay UDisplay_Author;
        private UDisplay UDisplay_Version;
        private System.Windows.Forms.Button button1;
        private UDisplay uDisplay1;
        private System.Windows.Forms.TextBox textBox1;
    }
}