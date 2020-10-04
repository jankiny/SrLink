namespace SRLink.From
{
    partial class SubFrmNormal
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
            this.CHK_AutoRun = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CHK_Help = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CHK_AutoRun
            // 
            this.CHK_AutoRun.AutoSize = true;
            this.CHK_AutoRun.Location = new System.Drawing.Point(19, 32);
            this.CHK_AutoRun.Name = "CHK_AutoRun";
            this.CHK_AutoRun.Size = new System.Drawing.Size(48, 16);
            this.CHK_AutoRun.TabIndex = 25;
            this.CHK_AutoRun.Text = "启用";
            this.CHK_AutoRun.UseVisualStyleBackColor = true;
            this.CHK_AutoRun.CheckedChanged += new System.EventHandler(this.CHK_AutoRun_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 12F);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "开机启动";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "帮助提示";
            // 
            // CHK_Help
            // 
            this.CHK_Help.AutoSize = true;
            this.CHK_Help.Location = new System.Drawing.Point(19, 83);
            this.CHK_Help.Name = "CHK_Help";
            this.CHK_Help.Size = new System.Drawing.Size(48, 16);
            this.CHK_Help.TabIndex = 25;
            this.CHK_Help.Text = "启用";
            this.CHK_Help.UseVisualStyleBackColor = true;
            this.CHK_Help.CheckedChanged += new System.EventHandler(this.CHK_AutoRun_CheckedChanged);
            // 
            // SubFrmNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 308);
            this.Controls.Add(this.CHK_Help);
            this.Controls.Add(this.CHK_AutoRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "SubFrmNormal";
            this.Text = "SubFRM_Normal";
            this.Load += new System.EventHandler(this.SubFrmNormal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CHK_AutoRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CHK_Help;
    }
}