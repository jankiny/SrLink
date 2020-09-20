namespace SRLink.From
{
    partial class SubFrmSLink
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
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CHK_EnableCertify = new System.Windows.Forms.CheckBox();
            this.BTN_SetDefault = new System.Windows.Forms.Button();
            this.CHK_EnableLink = new System.Windows.Forms.CheckBox();
            this.CHK_EnableMail = new System.Windows.Forms.CheckBox();
            this.BTN_TestMail = new System.Windows.Forms.Button();
            this.CHK_AutoLink = new System.Windows.Forms.CheckBox();
            this.UInput_MailAddress = new SRLink.From.UInput();
            this.UInput_LinkPassword = new SRLink.From.UInput();
            this.UInput_LinkUserName = new SRLink.From.UInput();
            this.UInput_LinkServer = new SRLink.From.UInput();
            this.UInput_CertifyPassword = new SRLink.From.UInput();
            this.UInput_CertifyId = new SRLink.From.UInput();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_OpenInfoForm = new System.Windows.Forms.Button();
            this.TMR_ReSent = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(14, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "自动连接";
            // 
            // DTP_StartTime
            // 
            this.DTP_StartTime.CustomFormat = "HH:mm";
            this.DTP_StartTime.Enabled = false;
            this.DTP_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_StartTime.Location = new System.Drawing.Point(99, 93);
            this.DTP_StartTime.Name = "DTP_StartTime";
            this.DTP_StartTime.ShowUpDown = true;
            this.DTP_StartTime.Size = new System.Drawing.Size(66, 21);
            this.DTP_StartTime.TabIndex = 12;
            this.DTP_StartTime.Value = new System.DateTime(2020, 6, 29, 8, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F);
            this.label2.Location = new System.Drawing.Point(14, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "校园网认证";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F);
            this.label3.Location = new System.Drawing.Point(14, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "网络连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F);
            this.label4.Location = new System.Drawing.Point(14, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "发送IP地址";
            // 
            // CHK_EnableCertify
            // 
            this.CHK_EnableCertify.AutoSize = true;
            this.CHK_EnableCertify.Location = new System.Drawing.Point(21, 153);
            this.CHK_EnableCertify.Name = "CHK_EnableCertify";
            this.CHK_EnableCertify.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableCertify.TabIndex = 23;
            this.CHK_EnableCertify.Text = "启用";
            this.CHK_EnableCertify.UseVisualStyleBackColor = true;
            // 
            // BTN_SetDefault
            // 
            this.BTN_SetDefault.Location = new System.Drawing.Point(199, 350);
            this.BTN_SetDefault.Name = "BTN_SetDefault";
            this.BTN_SetDefault.Size = new System.Drawing.Size(47, 23);
            this.BTN_SetDefault.TabIndex = 33;
            this.BTN_SetDefault.Text = "默认服务器";
            this.BTN_SetDefault.UseVisualStyleBackColor = true;
            this.BTN_SetDefault.Click += new System.EventHandler(this.BTN_SetDefault_Click);
            // 
            // CHK_EnableLink
            // 
            this.CHK_EnableLink.AutoSize = true;
            this.CHK_EnableLink.Location = new System.Drawing.Point(21, 307);
            this.CHK_EnableLink.Name = "CHK_EnableLink";
            this.CHK_EnableLink.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableLink.TabIndex = 26;
            this.CHK_EnableLink.Text = "启用";
            this.CHK_EnableLink.UseVisualStyleBackColor = true;
            // 
            // CHK_EnableMail
            // 
            this.CHK_EnableMail.AutoSize = true;
            this.CHK_EnableMail.Location = new System.Drawing.Point(21, 510);
            this.CHK_EnableMail.Name = "CHK_EnableMail";
            this.CHK_EnableMail.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableMail.TabIndex = 40;
            this.CHK_EnableMail.Text = "启用";
            this.CHK_EnableMail.UseVisualStyleBackColor = true;
            // 
            // BTN_TestMail
            // 
            this.BTN_TestMail.Location = new System.Drawing.Point(199, 552);
            this.BTN_TestMail.Name = "BTN_TestMail";
            this.BTN_TestMail.Size = new System.Drawing.Size(75, 23);
            this.BTN_TestMail.TabIndex = 41;
            this.BTN_TestMail.Text = "测试邮箱";
            this.BTN_TestMail.UseVisualStyleBackColor = true;
            this.BTN_TestMail.Click += new System.EventHandler(this.BTN_TestMail_Click);
            // 
            // CHK_AutoLink
            // 
            this.CHK_AutoLink.AutoSize = true;
            this.CHK_AutoLink.Location = new System.Drawing.Point(21, 97);
            this.CHK_AutoLink.Name = "CHK_AutoLink";
            this.CHK_AutoLink.Size = new System.Drawing.Size(48, 16);
            this.CHK_AutoLink.TabIndex = 23;
            this.CHK_AutoLink.Text = "启用";
            this.CHK_AutoLink.UseVisualStyleBackColor = true;
            this.CHK_AutoLink.CheckedChanged += new System.EventHandler(this.CHK_AutoLink_CheckedChanged);
            // 
            // UInput_MailAddress
            // 
            this.UInput_MailAddress.Content = "";
            this.UInput_MailAddress.Location = new System.Drawing.Point(17, 530);
            this.UInput_MailAddress.Name = "UInput_MailAddress";
            this.UInput_MailAddress.Password = false;
            this.UInput_MailAddress.Size = new System.Drawing.Size(176, 47);
            this.UInput_MailAddress.TabIndex = 39;
            this.UInput_MailAddress.Title = "邮箱";
            // 
            // UInput_LinkPassword
            // 
            this.UInput_LinkPassword.Content = "";
            this.UInput_LinkPassword.Location = new System.Drawing.Point(17, 424);
            this.UInput_LinkPassword.Name = "UInput_LinkPassword";
            this.UInput_LinkPassword.Password = true;
            this.UInput_LinkPassword.Size = new System.Drawing.Size(176, 47);
            this.UInput_LinkPassword.TabIndex = 38;
            this.UInput_LinkPassword.Title = "密码";
            // 
            // UInput_LinkUserName
            // 
            this.UInput_LinkUserName.Content = "";
            this.UInput_LinkUserName.Location = new System.Drawing.Point(17, 375);
            this.UInput_LinkUserName.Name = "UInput_LinkUserName";
            this.UInput_LinkUserName.Password = false;
            this.UInput_LinkUserName.Size = new System.Drawing.Size(176, 47);
            this.UInput_LinkUserName.TabIndex = 37;
            this.UInput_LinkUserName.Title = "账号";
            // 
            // UInput_LinkServer
            // 
            this.UInput_LinkServer.Content = "";
            this.UInput_LinkServer.Location = new System.Drawing.Point(17, 326);
            this.UInput_LinkServer.Name = "UInput_LinkServer";
            this.UInput_LinkServer.Password = false;
            this.UInput_LinkServer.Size = new System.Drawing.Size(176, 47);
            this.UInput_LinkServer.TabIndex = 36;
            this.UInput_LinkServer.Title = "服务器";
            // 
            // UInput_CertifyPassword
            // 
            this.UInput_CertifyPassword.Content = "";
            this.UInput_CertifyPassword.Location = new System.Drawing.Point(17, 222);
            this.UInput_CertifyPassword.Name = "UInput_CertifyPassword";
            this.UInput_CertifyPassword.Password = true;
            this.UInput_CertifyPassword.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyPassword.TabIndex = 35;
            this.UInput_CertifyPassword.Title = "密码（通常为身份证后6位）";
            // 
            // UInput_CertifyId
            // 
            this.UInput_CertifyId.Content = "";
            this.UInput_CertifyId.Location = new System.Drawing.Point(17, 172);
            this.UInput_CertifyId.Name = "UInput_CertifyId";
            this.UInput_CertifyId.Password = false;
            this.UInput_CertifyId.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyId.TabIndex = 34;
            this.UInput_CertifyId.Title = "学号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 12F);
            this.label5.Location = new System.Drawing.Point(14, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "连接窗口";
            // 
            // BTN_OpenInfoForm
            // 
            this.BTN_OpenInfoForm.Location = new System.Drawing.Point(19, 36);
            this.BTN_OpenInfoForm.Name = "BTN_OpenInfoForm";
            this.BTN_OpenInfoForm.Size = new System.Drawing.Size(75, 23);
            this.BTN_OpenInfoForm.TabIndex = 42;
            this.BTN_OpenInfoForm.Text = "打开";
            this.BTN_OpenInfoForm.UseVisualStyleBackColor = true;
            this.BTN_OpenInfoForm.Click += new System.EventHandler(this.BTN_OpenInfoForm_Click);
            // 
            // TMR_ReSent
            // 
            this.TMR_ReSent.Interval = 1000;
            // 
            // SubFrmSLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 595);
            this.Controls.Add(this.BTN_OpenInfoForm);
            this.Controls.Add(this.BTN_TestMail);
            this.Controls.Add(this.CHK_EnableMail);
            this.Controls.Add(this.UInput_MailAddress);
            this.Controls.Add(this.UInput_LinkPassword);
            this.Controls.Add(this.UInput_LinkUserName);
            this.Controls.Add(this.UInput_LinkServer);
            this.Controls.Add(this.UInput_CertifyPassword);
            this.Controls.Add(this.UInput_CertifyId);
            this.Controls.Add(this.BTN_SetDefault);
            this.Controls.Add(this.CHK_EnableLink);
            this.Controls.Add(this.CHK_AutoLink);
            this.Controls.Add(this.CHK_EnableCertify);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP_StartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "SubFrmSLink";
            this.Text = "SubFRM_SLink";
            this.Load += new System.EventHandler(this.SubFrmSLink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTP_StartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CHK_EnableCertify;
        private System.Windows.Forms.Button BTN_SetDefault;
        private System.Windows.Forms.CheckBox CHK_EnableLink;
        private UInput UInput_CertifyId;
        private UInput UInput_CertifyPassword;
        private UInput UInput_LinkServer;
        private UInput UInput_LinkUserName;
        private UInput UInput_LinkPassword;
        private UInput UInput_MailAddress;
        private System.Windows.Forms.CheckBox CHK_EnableMail;
        private System.Windows.Forms.Button BTN_TestMail;
        private System.Windows.Forms.CheckBox CHK_AutoLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_OpenInfoForm;
        private System.Windows.Forms.Timer TMR_ReSent;
    }
}