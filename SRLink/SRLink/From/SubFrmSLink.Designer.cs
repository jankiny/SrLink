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
            this.TMR_ReSent = new System.Windows.Forms.Timer(this.components);
            this.LBL_Tip_AutoLink = new System.Windows.Forms.Label();
            this.LBL_Tip_Certify = new System.Windows.Forms.Label();
            this.LBL_Tip_Link = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(14, 18);
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
            this.DTP_StartTime.Location = new System.Drawing.Point(99, 37);
            this.DTP_StartTime.Name = "DTP_StartTime";
            this.DTP_StartTime.ShowUpDown = true;
            this.DTP_StartTime.Size = new System.Drawing.Size(66, 21);
            this.DTP_StartTime.TabIndex = 12;
            this.DTP_StartTime.Value = new System.DateTime(2020, 6, 29, 8, 0, 0, 0);
            this.DTP_StartTime.ValueChanged += new System.EventHandler(this.DTP_StartTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F);
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "内网认证";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F);
            this.label3.Location = new System.Drawing.Point(14, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "网络连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F);
            this.label4.Location = new System.Drawing.Point(14, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "发送IP地址";
            // 
            // CHK_EnableCertify
            // 
            this.CHK_EnableCertify.AutoSize = true;
            this.CHK_EnableCertify.Location = new System.Drawing.Point(21, 99);
            this.CHK_EnableCertify.Name = "CHK_EnableCertify";
            this.CHK_EnableCertify.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableCertify.TabIndex = 23;
            this.CHK_EnableCertify.Text = "启用";
            this.CHK_EnableCertify.UseVisualStyleBackColor = true;
            this.CHK_EnableCertify.CheckedChanged += new System.EventHandler(this.CHK_EnableCertify_CheckedChanged);
            // 
            // BTN_SetDefault
            // 
            this.BTN_SetDefault.Location = new System.Drawing.Point(199, 300);
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
            this.CHK_EnableLink.Location = new System.Drawing.Point(21, 257);
            this.CHK_EnableLink.Name = "CHK_EnableLink";
            this.CHK_EnableLink.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableLink.TabIndex = 26;
            this.CHK_EnableLink.Text = "启用";
            this.CHK_EnableLink.UseVisualStyleBackColor = true;
            this.CHK_EnableLink.CheckedChanged += new System.EventHandler(this.CHK_EnableLink_CheckedChanged);
            // 
            // CHK_EnableMail
            // 
            this.CHK_EnableMail.AutoSize = true;
            this.CHK_EnableMail.Location = new System.Drawing.Point(21, 460);
            this.CHK_EnableMail.Name = "CHK_EnableMail";
            this.CHK_EnableMail.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableMail.TabIndex = 40;
            this.CHK_EnableMail.Text = "启用";
            this.CHK_EnableMail.UseVisualStyleBackColor = true;
            this.CHK_EnableMail.CheckedChanged += new System.EventHandler(this.CHK_EnableMail_CheckedChanged);
            // 
            // BTN_TestMail
            // 
            this.BTN_TestMail.Location = new System.Drawing.Point(199, 502);
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
            this.CHK_AutoLink.Location = new System.Drawing.Point(21, 41);
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
            this.UInput_MailAddress.Location = new System.Drawing.Point(17, 480);
            this.UInput_MailAddress.Name = "UInput_MailAddress";
            this.UInput_MailAddress.Password = false;
            this.UInput_MailAddress.Size = new System.Drawing.Size(176, 47);
            this.UInput_MailAddress.TabIndex = 39;
            this.UInput_MailAddress.Title = "邮箱";
            this.UInput_MailAddress.UcContentTextChanged += new SRLink.From.UInput.ContentTextChanged(this.UInput_MailAddress_UcContentTextChanged);
            // 
            // UInput_LinkPassword
            // 
            this.UInput_LinkPassword.Content = "";
            this.UInput_LinkPassword.Location = new System.Drawing.Point(17, 374);
            this.UInput_LinkPassword.Name = "UInput_LinkPassword";
            this.UInput_LinkPassword.Password = true;
            this.UInput_LinkPassword.Size = new System.Drawing.Size(176, 47);
            this.UInput_LinkPassword.TabIndex = 38;
            this.UInput_LinkPassword.Title = "密码";
            this.UInput_LinkPassword.UcContentTextChanged += new SRLink.From.UInput.ContentTextChanged(this.UInput_LinkPassword_UcContentTextChanged);
            // 
            // UInput_LinkUserName
            // 
            this.UInput_LinkUserName.Content = "";
            this.UInput_LinkUserName.Location = new System.Drawing.Point(17, 325);
            this.UInput_LinkUserName.Name = "UInput_LinkUserName";
            this.UInput_LinkUserName.Password = false;
            this.UInput_LinkUserName.Size = new System.Drawing.Size(176, 47);
            this.UInput_LinkUserName.TabIndex = 37;
            this.UInput_LinkUserName.Title = "账号(参考：hzgsd+手机尾号)";
            this.UInput_LinkUserName.UcContentTextChanged += new SRLink.From.UInput.ContentTextChanged(this.UInput_LinkUserName_UcContentTextChanged);
            // 
            // UInput_LinkServer
            // 
            this.UInput_LinkServer.Content = "";
            this.UInput_LinkServer.Location = new System.Drawing.Point(17, 276);
            this.UInput_LinkServer.Name = "UInput_LinkServer";
            this.UInput_LinkServer.Password = false;
            this.UInput_LinkServer.Size = new System.Drawing.Size(176, 47);
            this.UInput_LinkServer.TabIndex = 36;
            this.UInput_LinkServer.Title = "服务器";
            this.UInput_LinkServer.UcContentTextChanged += new SRLink.From.UInput.ContentTextChanged(this.UInput_LinkServer_UcContentTextChanged);
            // 
            // UInput_CertifyPassword
            // 
            this.UInput_CertifyPassword.Content = "";
            this.UInput_CertifyPassword.Location = new System.Drawing.Point(17, 168);
            this.UInput_CertifyPassword.Name = "UInput_CertifyPassword";
            this.UInput_CertifyPassword.Password = true;
            this.UInput_CertifyPassword.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyPassword.TabIndex = 35;
            this.UInput_CertifyPassword.Title = "密码（参考：身份证后6位）";
            this.UInput_CertifyPassword.UcContentTextChanged += new SRLink.From.UInput.ContentTextChanged(this.UInput_CertifyPassword_UcContentTextChanged);
            // 
            // UInput_CertifyId
            // 
            this.UInput_CertifyId.Content = "";
            this.UInput_CertifyId.Location = new System.Drawing.Point(17, 118);
            this.UInput_CertifyId.Name = "UInput_CertifyId";
            this.UInput_CertifyId.Password = false;
            this.UInput_CertifyId.Size = new System.Drawing.Size(176, 47);
            this.UInput_CertifyId.TabIndex = 34;
            this.UInput_CertifyId.Title = "学号";
            this.UInput_CertifyId.UcContentTextChanged += new SRLink.From.UInput.ContentTextChanged(this.UInput_CertifyId_UcContentTextChanged);
            // 
            // TMR_ReSent
            // 
            this.TMR_ReSent.Interval = 1000;
            this.TMR_ReSent.Tick += new System.EventHandler(this.TMR_ReSent_Tick);
            // 
            // LBL_Tip_AutoLink
            // 
            this.LBL_Tip_AutoLink.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Tip_AutoLink.Location = new System.Drawing.Point(197, 41);
            this.LBL_Tip_AutoLink.Name = "LBL_Tip_AutoLink";
            this.LBL_Tip_AutoLink.Size = new System.Drawing.Size(193, 36);
            this.LBL_Tip_AutoLink.TabIndex = 42;
            this.LBL_Tip_AutoLink.Text = "Tip：当超过设定的时间后，会自动按配置进行连接。直到检测到网络已连接。";
            this.LBL_Tip_AutoLink.Visible = false;
            // 
            // LBL_Tip_Certify
            // 
            this.LBL_Tip_Certify.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Tip_Certify.Location = new System.Drawing.Point(97, 99);
            this.LBL_Tip_Certify.Name = "LBL_Tip_Certify";
            this.LBL_Tip_Certify.Size = new System.Drawing.Size(291, 36);
            this.LBL_Tip_Certify.TabIndex = 42;
            this.LBL_Tip_Certify.Text = "Tip：填入内网认证页面的账号密码。启用功能后，会在连接L2TP前先完成内网认证。";
            this.LBL_Tip_Certify.Visible = false;
            // 
            // LBL_Tip_Link
            // 
            this.LBL_Tip_Link.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Tip_Link.Location = new System.Drawing.Point(99, 257);
            this.LBL_Tip_Link.Name = "LBL_Tip_Link";
            this.LBL_Tip_Link.Size = new System.Drawing.Size(291, 36);
            this.LBL_Tip_Link.TabIndex = 42;
            this.LBL_Tip_Link.Text = "Tip：填入随e行设置里的服务器地址、账号、密码。连接成功后，需要维护连接，请不要关闭程序。";
            this.LBL_Tip_Link.Visible = false;
            // 
            // SubFrmSLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 596);
            this.Controls.Add(this.LBL_Tip_Link);
            this.Controls.Add(this.LBL_Tip_Certify);
            this.Controls.Add(this.LBL_Tip_AutoLink);
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
        private System.Windows.Forms.Timer TMR_ReSent;
        private System.Windows.Forms.Label LBL_Tip_AutoLink;
        private System.Windows.Forms.Label LBL_Tip_Certify;
        private System.Windows.Forms.Label LBL_Tip_Link;
    }
}