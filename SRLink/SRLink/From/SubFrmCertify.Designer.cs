namespace SRLink.From
{
    partial class SubFrmCertify
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
            this.SuspendLayout();
            // 
            // UInput_CertifyId
            // 
            this.UInput_CertifyId.Content = "";
            this.UInput_CertifyId.Location = new System.Drawing.Point(12, 13);
            this.UInput_CertifyId.Name = "UInput_CertifyId";
            this.UInput_CertifyId.Password = false;
            this.UInput_CertifyId.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyId.TabIndex = 36;
            this.UInput_CertifyId.Title = "学号";
            // 
            // UInput_CertifyPassword
            // 
            this.UInput_CertifyPassword.Content = "";
            this.UInput_CertifyPassword.Location = new System.Drawing.Point(12, 63);
            this.UInput_CertifyPassword.Name = "UInput_CertifyPassword";
            this.UInput_CertifyPassword.Password = true;
            this.UInput_CertifyPassword.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyPassword.TabIndex = 37;
            this.UInput_CertifyPassword.Title = "密码（参考：身份证后6位）";
            // 
            // BTN_Certify
            // 
            this.BTN_Certify.Location = new System.Drawing.Point(104, 125);
            this.BTN_Certify.Name = "BTN_Certify";
            this.BTN_Certify.Size = new System.Drawing.Size(75, 23);
            this.BTN_Certify.TabIndex = 38;
            this.BTN_Certify.Text = "手动认证";
            this.BTN_Certify.UseVisualStyleBackColor = true;
            this.BTN_Certify.Click += new System.EventHandler(this.BTN_Certify_Click);
            // 
            // FrmCertify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 170);
            this.Controls.Add(this.BTN_Certify);
            this.Controls.Add(this.UInput_CertifyId);
            this.Controls.Add(this.UInput_CertifyPassword);
            this.Name = "FrmCertify";
            this.Text = "FrmCertify";
            this.ResumeLayout(false);

        }

        #endregion

        private UInput UInput_CertifyId;
        private UInput UInput_CertifyPassword;
        private System.Windows.Forms.Button BTN_Certify;
    }
}