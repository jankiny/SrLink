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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PNL_Certify = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PNL_Link = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PNL_Mail = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PNL_Certify.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PNL_Link.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PNL_Mail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(12, 12);
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
            this.DTP_StartTime.Location = new System.Drawing.Point(97, 31);
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
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "内网认证";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F);
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "网络连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F);
            this.label4.Location = new System.Drawing.Point(12, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "发送IP地址";
            // 
            // CHK_EnableCertify
            // 
            this.CHK_EnableCertify.AutoSize = true;
            this.CHK_EnableCertify.Location = new System.Drawing.Point(19, 29);
            this.CHK_EnableCertify.Name = "CHK_EnableCertify";
            this.CHK_EnableCertify.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableCertify.TabIndex = 23;
            this.CHK_EnableCertify.Text = "启用";
            this.CHK_EnableCertify.UseVisualStyleBackColor = true;
            this.CHK_EnableCertify.CheckedChanged += new System.EventHandler(this.CHK_EnableCertify_CheckedChanged);
            // 
            // BTN_SetDefault
            // 
            this.BTN_SetDefault.Location = new System.Drawing.Point(185, 27);
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
            this.CHK_EnableLink.Location = new System.Drawing.Point(19, 29);
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
            this.CHK_EnableMail.Location = new System.Drawing.Point(19, 30);
            this.CHK_EnableMail.Name = "CHK_EnableMail";
            this.CHK_EnableMail.Size = new System.Drawing.Size(48, 16);
            this.CHK_EnableMail.TabIndex = 40;
            this.CHK_EnableMail.Text = "启用";
            this.CHK_EnableMail.UseVisualStyleBackColor = true;
            this.CHK_EnableMail.CheckedChanged += new System.EventHandler(this.CHK_EnableMail_CheckedChanged);
            // 
            // BTN_TestMail
            // 
            this.BTN_TestMail.Location = new System.Drawing.Point(197, 28);
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
            this.CHK_AutoLink.Location = new System.Drawing.Point(19, 35);
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
            this.UInput_MailAddress.Location = new System.Drawing.Point(15, 6);
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
            this.UInput_LinkPassword.Location = new System.Drawing.Point(15, 102);
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
            this.UInput_LinkUserName.Location = new System.Drawing.Point(15, 53);
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
            this.UInput_LinkServer.Location = new System.Drawing.Point(15, 4);
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
            this.UInput_CertifyPassword.Location = new System.Drawing.Point(15, 54);
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
            this.UInput_CertifyId.Location = new System.Drawing.Point(15, 4);
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
            this.LBL_Tip_AutoLink.Location = new System.Drawing.Point(195, 17);
            this.LBL_Tip_AutoLink.Name = "LBL_Tip_AutoLink";
            this.LBL_Tip_AutoLink.Size = new System.Drawing.Size(203, 36);
            this.LBL_Tip_AutoLink.TabIndex = 42;
            this.LBL_Tip_AutoLink.Text = "Tip：启用后，会自动按配置进行连接（执行顺序即配置页面的顺序）。请确保以下配置是正确。";
            this.LBL_Tip_AutoLink.Visible = false;
            // 
            // LBL_Tip_Certify
            // 
            this.LBL_Tip_Certify.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Tip_Certify.Location = new System.Drawing.Point(97, 12);
            this.LBL_Tip_Certify.Name = "LBL_Tip_Certify";
            this.LBL_Tip_Certify.Size = new System.Drawing.Size(303, 36);
            this.LBL_Tip_Certify.TabIndex = 42;
            this.LBL_Tip_Certify.Text = "Tip：请填入内网认证页面的账号密码。可以不启用，但建议启用，因为通过完成内网认证可判定可以连接校园网。";
            this.LBL_Tip_Certify.Visible = false;
            // 
            // LBL_Tip_Link
            // 
            this.LBL_Tip_Link.Font = new System.Drawing.Font("楷体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Tip_Link.Location = new System.Drawing.Point(99, 12);
            this.LBL_Tip_Link.Name = "LBL_Tip_Link";
            this.LBL_Tip_Link.Size = new System.Drawing.Size(301, 36);
            this.LBL_Tip_Link.TabIndex = 42;
            this.LBL_Tip_Link.Text = "Tip：请填入随e行设置里的服务器地址、账号、密码，并通过手动连接测试配置正确性。若本阶段连接失败，会自动取消“自动连接”功能。详见“README.md”。";
            this.LBL_Tip_Link.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DTP_StartTime);
            this.panel1.Controls.Add(this.CHK_AutoLink);
            this.panel1.Controls.Add(this.LBL_Tip_AutoLink);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 62);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CHK_EnableCertify);
            this.panel2.Controls.Add(this.LBL_Tip_Certify);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 54);
            this.panel2.TabIndex = 44;
            // 
            // PNL_Certify
            // 
            this.PNL_Certify.Controls.Add(this.UInput_CertifyId);
            this.PNL_Certify.Controls.Add(this.UInput_CertifyPassword);
            this.PNL_Certify.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_Certify.Location = new System.Drawing.Point(0, 116);
            this.PNL_Certify.Name = "PNL_Certify";
            this.PNL_Certify.Size = new System.Drawing.Size(439, 110);
            this.PNL_Certify.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.CHK_EnableLink);
            this.panel3.Controls.Add(this.LBL_Tip_Link);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(439, 50);
            this.panel3.TabIndex = 46;
            // 
            // PNL_Link
            // 
            this.PNL_Link.Controls.Add(this.UInput_LinkServer);
            this.PNL_Link.Controls.Add(this.BTN_SetDefault);
            this.PNL_Link.Controls.Add(this.UInput_LinkUserName);
            this.PNL_Link.Controls.Add(this.UInput_LinkPassword);
            this.PNL_Link.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_Link.Location = new System.Drawing.Point(0, 276);
            this.PNL_Link.Name = "PNL_Link";
            this.PNL_Link.Size = new System.Drawing.Size(439, 156);
            this.PNL_Link.TabIndex = 47;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.CHK_EnableMail);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 432);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(439, 54);
            this.panel4.TabIndex = 48;
            // 
            // PNL_Mail
            // 
            this.PNL_Mail.Controls.Add(this.UInput_MailAddress);
            this.PNL_Mail.Controls.Add(this.BTN_TestMail);
            this.PNL_Mail.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_Mail.Location = new System.Drawing.Point(0, 486);
            this.PNL_Mail.Name = "PNL_Mail";
            this.PNL_Mail.Size = new System.Drawing.Size(439, 58);
            this.PNL_Mail.TabIndex = 49;
            // 
            // SubFrmSLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 665);
            this.Controls.Add(this.PNL_Mail);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.PNL_Link);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PNL_Certify);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SubFrmSLink";
            this.Text = "SubFRM_SLink";
            this.Load += new System.EventHandler(this.SubFrmSLink_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PNL_Certify.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PNL_Link.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.PNL_Mail.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PNL_Certify;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PNL_Link;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel PNL_Mail;
    }
}