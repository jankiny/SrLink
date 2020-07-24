namespace SRLink
{
    partial class FRM_Config_Certify
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
            this.LBL_Status = new System.Windows.Forms.Label();
            this.CBX_Enable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_Test = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.TBX_ID = new System.Windows.Forms.TextBox();
            this.TBX_Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBL_Status
            // 
            this.LBL_Status.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Status.Location = new System.Drawing.Point(152, 9);
            this.LBL_Status.Name = "LBL_Status";
            this.LBL_Status.Size = new System.Drawing.Size(63, 23);
            this.LBL_Status.TabIndex = 1;
            this.LBL_Status.Text = "待测试";
            this.LBL_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CBX_Enable
            // 
            this.CBX_Enable.AutoSize = true;
            this.CBX_Enable.Location = new System.Drawing.Point(18, 12);
            this.CBX_Enable.Name = "CBX_Enable";
            this.CBX_Enable.Size = new System.Drawing.Size(48, 16);
            this.CBX_Enable.TabIndex = 1;
            this.CBX_Enable.Text = "启用";
            this.CBX_Enable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "账号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "密码：";
            // 
            // BTN_Test
            // 
            this.BTN_Test.Location = new System.Drawing.Point(131, 109);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(75, 23);
            this.BTN_Test.TabIndex = 4;
            this.BTN_Test.Text = "测试";
            this.BTN_Test.UseVisualStyleBackColor = true;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(30, 109);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 5;
            this.BTN_Save.Text = "保存";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // TBX_ID
            // 
            this.TBX_ID.Location = new System.Drawing.Point(68, 37);
            this.TBX_ID.Name = "TBX_ID";
            this.TBX_ID.Size = new System.Drawing.Size(147, 21);
            this.TBX_ID.TabIndex = 2;
            // 
            // TBX_Password
            // 
            this.TBX_Password.Location = new System.Drawing.Point(68, 70);
            this.TBX_Password.Name = "TBX_Password";
            this.TBX_Password.Size = new System.Drawing.Size(147, 21);
            this.TBX_Password.TabIndex = 3;
            this.TBX_Password.UseSystemPasswordChar = true;
            // 
            // FRM_Config_Certify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 144);
            this.Controls.Add(this.TBX_Password);
            this.Controls.Add(this.TBX_ID);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_Test);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBX_Enable);
            this.Controls.Add(this.LBL_Status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Config_Certify";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置认证";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBL_Status;
        private System.Windows.Forms.CheckBox CBX_Enable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_Test;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.TextBox TBX_ID;
        private System.Windows.Forms.TextBox TBX_Password;
    }
}