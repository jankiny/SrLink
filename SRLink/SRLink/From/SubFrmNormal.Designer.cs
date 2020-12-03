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
            this.LBL_Tip_Debug = new System.Windows.Forms.Label();
            this.BTN_Debug = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "调试";
            // 
            // LBL_Tip_Debug
            // 
            this.LBL_Tip_Debug.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Tip_Debug.Location = new System.Drawing.Point(192, 88);
            this.LBL_Tip_Debug.Name = "LBL_Tip_Debug";
            this.LBL_Tip_Debug.Size = new System.Drawing.Size(228, 36);
            this.LBL_Tip_Debug.TabIndex = 43;
            this.LBL_Tip_Debug.Text = "Tip：主要用于调试程序，正常使用时没必要开启。";
            this.LBL_Tip_Debug.Visible = false;
            // 
            // BTN_Debug
            // 
            this.BTN_Debug.Location = new System.Drawing.Point(19, 88);
            this.BTN_Debug.Name = "BTN_Debug";
            this.BTN_Debug.Size = new System.Drawing.Size(75, 23);
            this.BTN_Debug.TabIndex = 44;
            this.BTN_Debug.Text = "调试窗口";
            this.BTN_Debug.UseVisualStyleBackColor = true;
            this.BTN_Debug.Click += new System.EventHandler(this.BTN_Debug_Click);
            // 
            // SubFrmNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 308);
            this.Controls.Add(this.BTN_Debug);
            this.Controls.Add(this.LBL_Tip_Debug);
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
        private System.Windows.Forms.Label LBL_Tip_Debug;
        private System.Windows.Forms.Button BTN_Debug;
    }
}