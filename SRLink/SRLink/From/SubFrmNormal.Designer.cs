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
            this.SuspendLayout();
            // 
            // CHK_AutoRun
            // 
            this.CHK_AutoRun.AutoSize = true;
            this.CHK_AutoRun.Location = new System.Drawing.Point(25, 12);
            this.CHK_AutoRun.Name = "CHK_AutoRun";
            this.CHK_AutoRun.Size = new System.Drawing.Size(96, 16);
            this.CHK_AutoRun.TabIndex = 1;
            this.CHK_AutoRun.Text = "开机自动启动";
            this.CHK_AutoRun.UseVisualStyleBackColor = true;
            this.CHK_AutoRun.CheckedChanged += new System.EventHandler(this.CHK_AutoRun_CheckedChanged);
            // 
            // SubFrmNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 308);
            this.Controls.Add(this.CHK_AutoRun);
            this.Name = "SubFrmNormal";
            this.Text = "SubFRM_Normal";
            this.Load += new System.EventHandler(this.SubFrmNormal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CHK_AutoRun;
    }
}