namespace SRLink.From
{
    partial class FRM_SettingMail
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
            this.components = new System.ComponentModel.Container();
            this.TBX_Address = new System.Windows.Forms.TextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_Test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CBX_Enable = new System.Windows.Forms.CheckBox();
            this.LBL_Status = new System.Windows.Forms.Label();
            this.TBX_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_Sent = new System.Windows.Forms.Button();
            this.TMR_ReSent = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TBX_Address
            // 
            this.TBX_Address.Location = new System.Drawing.Point(80, 39);
            this.TBX_Address.Name = "TBX_Address";
            this.TBX_Address.Size = new System.Drawing.Size(147, 21);
            this.TBX_Address.TabIndex = 8;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(30, 111);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 13;
            this.BTN_Save.Text = "应用";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_Test
            // 
            this.BTN_Test.Location = new System.Drawing.Point(134, 111);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(75, 23);
            this.BTN_Test.TabIndex = 12;
            this.BTN_Test.Text = "测试邮箱";
            this.BTN_Test.UseVisualStyleBackColor = true;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "邮  箱：";
            // 
            // CBX_Enable
            // 
            this.CBX_Enable.AutoSize = true;
            this.CBX_Enable.Location = new System.Drawing.Point(18, 14);
            this.CBX_Enable.Name = "CBX_Enable";
            this.CBX_Enable.Size = new System.Drawing.Size(48, 16);
            this.CBX_Enable.TabIndex = 6;
            this.CBX_Enable.Text = "启用";
            this.CBX_Enable.UseVisualStyleBackColor = true;
            // 
            // LBL_Status
            // 
            this.LBL_Status.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Status.Location = new System.Drawing.Point(164, 11);
            this.LBL_Status.Name = "LBL_Status";
            this.LBL_Status.Size = new System.Drawing.Size(63, 23);
            this.LBL_Status.TabIndex = 7;
            this.LBL_Status.Text = "待测试";
            this.LBL_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TBX_Code
            // 
            this.TBX_Code.Location = new System.Drawing.Point(80, 72);
            this.TBX_Code.Name = "TBX_Code";
            this.TBX_Code.Size = new System.Drawing.Size(85, 21);
            this.TBX_Code.TabIndex = 9;
            this.TBX_Code.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "验证码：";
            // 
            // BTN_Sent
            // 
            this.BTN_Sent.Location = new System.Drawing.Point(171, 71);
            this.BTN_Sent.Name = "BTN_Sent";
            this.BTN_Sent.Size = new System.Drawing.Size(56, 23);
            this.BTN_Sent.TabIndex = 14;
            this.BTN_Sent.Text = "发送";
            this.BTN_Sent.UseVisualStyleBackColor = true;
            this.BTN_Sent.Click += new System.EventHandler(this.BTN_Sent_Click);
            // 
            // TMR_ReSent
            // 
            this.TMR_ReSent.Interval = 1000;
            this.TMR_ReSent.Tick += new System.EventHandler(this.TMR_ReSent_Tick);
            // 
            // FRM_SettingMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 150);
            this.Controls.Add(this.BTN_Sent);
            this.Controls.Add(this.TBX_Code);
            this.Controls.Add(this.TBX_Address);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_Test);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBX_Enable);
            this.Controls.Add(this.LBL_Status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_SettingMail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置邮箱";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBX_Address;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBX_Enable;
        private System.Windows.Forms.Label LBL_Status;
        private System.Windows.Forms.TextBox TBX_Code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_Sent;
        private System.Windows.Forms.Timer TMR_ReSent;
    }
}