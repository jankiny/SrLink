namespace SRLink.From
{
    partial class FrmCertify
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
            this.UInput_CertifyId = new SRLink.From.UInput();
            this.UInput_CertifyPassword = new SRLink.From.UInput();
            this.BTN_Certify = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UInput_CertifyId
            // 
            this.UInput_CertifyId.Content = "";
            this.UInput_CertifyId.Location = new System.Drawing.Point(14, 50);
            this.UInput_CertifyId.Name = "UInput_CertifyId";
            this.UInput_CertifyId.Password = false;
            this.UInput_CertifyId.Size = new System.Drawing.Size(184, 47);
            this.UInput_CertifyId.TabIndex = 36;
            this.UInput_CertifyId.Title = "学号";
            // 
            // UInput_CertifyPassword
            // 
            this.UInput_CertifyPassword.Content = "";
            this.UInput_CertifyPassword.Location = new System.Drawing.Point(14, 103);
            this.UInput_CertifyPassword.Name = "UInput_CertifyPassword";
            this.UInput_CertifyPassword.Password = true;
            this.UInput_CertifyPassword.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyPassword.TabIndex = 37;
            this.UInput_CertifyPassword.Title = "密码（参考：身份证后6位）";
            // 
            // BTN_Certify
            // 
            this.BTN_Certify.Location = new System.Drawing.Point(203, 127);
            this.BTN_Certify.Name = "BTN_Certify";
            this.BTN_Certify.Size = new System.Drawing.Size(75, 23);
            this.BTN_Certify.TabIndex = 38;
            this.BTN_Certify.Text = "认证";
            this.BTN_Certify.UseVisualStyleBackColor = true;
            this.BTN_Certify.Click += new System.EventHandler(this.BTN_Certify_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 40);
            this.label7.TabIndex = 44;
            this.label7.Text = "Tip：检测到您未正确配置学生网账号密码，请在下方输入学生网的学号和密码，认证成功后即可切换到学生网。也可以关闭窗口继续使用教师网。";
            // 
            // FrmCertify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 163);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BTN_Certify);
            this.Controls.Add(this.UInput_CertifyId);
            this.Controls.Add(this.UInput_CertifyPassword);
            this.Name = "FrmCertify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "切换到学生网";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCertify_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private UInput UInput_CertifyId;
        private UInput UInput_CertifyPassword;
        private System.Windows.Forms.Button BTN_Certify;
        private System.Windows.Forms.Label label7;
    }
}