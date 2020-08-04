namespace SRLink
{
    partial class FRM_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSP_SLB_Statu = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSP_SLB_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BTN_Stop = new System.Windows.Forms.Button();
            this.PNL_Step3 = new System.Windows.Forms.Panel();
            this.PBX_Mail = new System.Windows.Forms.PictureBox();
            this.LBL_Line2 = new System.Windows.Forms.Label();
            this.LBL_Step3 = new System.Windows.Forms.Label();
            this.PNL_Step2 = new System.Windows.Forms.Panel();
            this.PBX_Link = new System.Windows.Forms.PictureBox();
            this.LBL_Line1 = new System.Windows.Forms.Label();
            this.LBL_Step2 = new System.Windows.Forms.Label();
            this.PNL_Step1 = new System.Windows.Forms.Panel();
            this.PBX_Certify = new System.Windows.Forms.PictureBox();
            this.LBL_Step1 = new System.Windows.Forms.Label();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.TBX_Board = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LBL_LinkInfo = new System.Windows.Forms.Label();
            this.LBL_MailInfo = new System.Windows.Forms.Label();
            this.LBL_CertifyInfo = new System.Windows.Forms.Label();
            this.BTN_Set = new System.Windows.Forms.Button();
            this.BTN_MailConfig = new System.Windows.Forms.Button();
            this.BTN_LinkConfig = new System.Windows.Forms.Button();
            this.BTN_CerifyConfig = new System.Windows.Forms.Button();
            this.LBL_MailEnable = new System.Windows.Forms.Label();
            this.LBL_LinkEnable = new System.Windows.Forms.Label();
            this.LBL_CertifyEnable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_StartTime = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TMR_Handle = new System.Windows.Forms.Timer(this.components);
            this.TMR_UpdateTime = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.PNL_Step3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Mail)).BeginInit();
            this.PNL_Step2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Link)).BeginInit();
            this.PNL_Step1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Certify)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSP_SLB_Statu,
            this.toolStripStatusLabel2,
            this.TSP_SLB_Time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(454, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSP_SLB_Statu
            // 
            this.TSP_SLB_Statu.Name = "TSP_SLB_Statu";
            this.TSP_SLB_Statu.Size = new System.Drawing.Size(56, 17);
            this.TSP_SLB_Statu.Text = "欢迎使用";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(243, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // TSP_SLB_Time
            // 
            this.TSP_SLB_Time.Name = "TSP_SLB_Time";
            this.TSP_SLB_Time.Size = new System.Drawing.Size(140, 17);
            this.TSP_SLB_Time.Text = "yyyy-MM-dd hh:mm:ss";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(430, 278);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BTN_Stop);
            this.tabPage1.Controls.Add(this.PNL_Step3);
            this.tabPage1.Controls.Add(this.PNL_Step2);
            this.tabPage1.Controls.Add(this.PNL_Step1);
            this.tabPage1.Controls.Add(this.BTN_Start);
            this.tabPage1.Controls.Add(this.TBX_Board);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(422, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "连接";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BTN_Stop
            // 
            this.BTN_Stop.Location = new System.Drawing.Point(329, 35);
            this.BTN_Stop.Name = "BTN_Stop";
            this.BTN_Stop.Size = new System.Drawing.Size(75, 23);
            this.BTN_Stop.TabIndex = 5;
            this.BTN_Stop.Text = "终止";
            this.BTN_Stop.UseVisualStyleBackColor = true;
            this.BTN_Stop.Click += new System.EventHandler(this.BTN_Stop_Click);
            // 
            // PNL_Step3
            // 
            this.PNL_Step3.Controls.Add(this.PBX_Mail);
            this.PNL_Step3.Controls.Add(this.LBL_Line2);
            this.PNL_Step3.Controls.Add(this.LBL_Step3);
            this.PNL_Step3.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNL_Step3.Location = new System.Drawing.Point(188, 3);
            this.PNL_Step3.Name = "PNL_Step3";
            this.PNL_Step3.Size = new System.Drawing.Size(121, 59);
            this.PNL_Step3.TabIndex = 4;
            // 
            // PBX_Mail
            // 
            this.PBX_Mail.BackgroundImage = global::SRLink.Properties.Resources.mail_normal;
            this.PBX_Mail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX_Mail.Location = new System.Drawing.Point(76, 4);
            this.PBX_Mail.Name = "PBX_Mail";
            this.PBX_Mail.Size = new System.Drawing.Size(35, 35);
            this.PBX_Mail.TabIndex = 1;
            this.PBX_Mail.TabStop = false;
            // 
            // LBL_Line2
            // 
            this.LBL_Line2.AutoSize = true;
            this.LBL_Line2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Line2.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Line2.Location = new System.Drawing.Point(5, 23);
            this.LBL_Line2.Name = "LBL_Line2";
            this.LBL_Line2.Size = new System.Drawing.Size(54, 12);
            this.LBL_Line2.TabIndex = 1;
            this.LBL_Line2.Text = "------>";
            // 
            // LBL_Step3
            // 
            this.LBL_Step3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBL_Step3.AutoSize = true;
            this.LBL_Step3.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Step3.Location = new System.Drawing.Point(75, 44);
            this.LBL_Step3.Name = "LBL_Step3";
            this.LBL_Step3.Size = new System.Drawing.Size(41, 12);
            this.LBL_Step3.TabIndex = 0;
            this.LBL_Step3.Text = "发送IP";
            // 
            // PNL_Step2
            // 
            this.PNL_Step2.Controls.Add(this.PBX_Link);
            this.PNL_Step2.Controls.Add(this.LBL_Line1);
            this.PNL_Step2.Controls.Add(this.LBL_Step2);
            this.PNL_Step2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNL_Step2.Location = new System.Drawing.Point(69, 3);
            this.PNL_Step2.Name = "PNL_Step2";
            this.PNL_Step2.Size = new System.Drawing.Size(119, 59);
            this.PNL_Step2.TabIndex = 3;
            // 
            // PBX_Link
            // 
            this.PBX_Link.BackgroundImage = global::SRLink.Properties.Resources.network_normal;
            this.PBX_Link.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX_Link.Location = new System.Drawing.Point(73, 4);
            this.PBX_Link.Name = "PBX_Link";
            this.PBX_Link.Size = new System.Drawing.Size(35, 35);
            this.PBX_Link.TabIndex = 1;
            this.PBX_Link.TabStop = false;
            // 
            // LBL_Line1
            // 
            this.LBL_Line1.AutoSize = true;
            this.LBL_Line1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBL_Line1.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Line1.Location = new System.Drawing.Point(5, 23);
            this.LBL_Line1.Name = "LBL_Line1";
            this.LBL_Line1.Size = new System.Drawing.Size(54, 12);
            this.LBL_Line1.TabIndex = 1;
            this.LBL_Line1.Text = "------>";
            // 
            // LBL_Step2
            // 
            this.LBL_Step2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBL_Step2.AutoSize = true;
            this.LBL_Step2.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Step2.Location = new System.Drawing.Point(77, 44);
            this.LBL_Step2.Name = "LBL_Step2";
            this.LBL_Step2.Size = new System.Drawing.Size(29, 12);
            this.LBL_Step2.TabIndex = 0;
            this.LBL_Step2.Text = "连接";
            // 
            // PNL_Step1
            // 
            this.PNL_Step1.Controls.Add(this.PBX_Certify);
            this.PNL_Step1.Controls.Add(this.LBL_Step1);
            this.PNL_Step1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNL_Step1.Location = new System.Drawing.Point(3, 3);
            this.PNL_Step1.Name = "PNL_Step1";
            this.PNL_Step1.Size = new System.Drawing.Size(66, 59);
            this.PNL_Step1.TabIndex = 2;
            // 
            // PBX_Certify
            // 
            this.PBX_Certify.BackgroundImage = global::SRLink.Properties.Resources.check_normal;
            this.PBX_Certify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX_Certify.Location = new System.Drawing.Point(13, 4);
            this.PBX_Certify.Name = "PBX_Certify";
            this.PBX_Certify.Size = new System.Drawing.Size(35, 35);
            this.PBX_Certify.TabIndex = 1;
            this.PBX_Certify.TabStop = false;
            // 
            // LBL_Step1
            // 
            this.LBL_Step1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBL_Step1.AutoSize = true;
            this.LBL_Step1.ForeColor = System.Drawing.Color.DimGray;
            this.LBL_Step1.Location = new System.Drawing.Point(17, 43);
            this.LBL_Step1.Name = "LBL_Step1";
            this.LBL_Step1.Size = new System.Drawing.Size(29, 12);
            this.LBL_Step1.TabIndex = 0;
            this.LBL_Step1.Text = "认证";
            // 
            // BTN_Start
            // 
            this.BTN_Start.Location = new System.Drawing.Point(329, 6);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(75, 23);
            this.BTN_Start.TabIndex = 1;
            this.BTN_Start.Text = "立即连接";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // TBX_Board
            // 
            this.TBX_Board.AcceptsReturn = true;
            this.TBX_Board.AcceptsTab = true;
            this.TBX_Board.BackColor = System.Drawing.SystemColors.MenuText;
            this.TBX_Board.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBX_Board.ForeColor = System.Drawing.Color.White;
            this.TBX_Board.Location = new System.Drawing.Point(3, 62);
            this.TBX_Board.Multiline = true;
            this.TBX_Board.Name = "TBX_Board";
            this.TBX_Board.ReadOnly = true;
            this.TBX_Board.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBX_Board.Size = new System.Drawing.Size(416, 187);
            this.TBX_Board.TabIndex = 0;
            this.TBX_Board.TabStop = false;
            this.TBX_Board.Text = "time: message";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LBL_LinkInfo);
            this.tabPage2.Controls.Add(this.LBL_MailInfo);
            this.tabPage2.Controls.Add(this.LBL_CertifyInfo);
            this.tabPage2.Controls.Add(this.BTN_Set);
            this.tabPage2.Controls.Add(this.BTN_MailConfig);
            this.tabPage2.Controls.Add(this.BTN_LinkConfig);
            this.tabPage2.Controls.Add(this.BTN_CerifyConfig);
            this.tabPage2.Controls.Add(this.LBL_MailEnable);
            this.tabPage2.Controls.Add(this.LBL_LinkEnable);
            this.tabPage2.Controls.Add(this.LBL_CertifyEnable);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.DTP_StartTime);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LBL_LinkInfo
            // 
            this.LBL_LinkInfo.AutoSize = true;
            this.LBL_LinkInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_LinkInfo.Location = new System.Drawing.Point(156, 126);
            this.LBL_LinkInfo.Name = "LBL_LinkInfo";
            this.LBL_LinkInfo.Size = new System.Drawing.Size(29, 12);
            this.LBL_LinkInfo.TabIndex = 11;
            this.LBL_LinkInfo.Text = "配置";
            // 
            // LBL_MailInfo
            // 
            this.LBL_MailInfo.AutoSize = true;
            this.LBL_MailInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_MailInfo.Location = new System.Drawing.Point(156, 56);
            this.LBL_MailInfo.Name = "LBL_MailInfo";
            this.LBL_MailInfo.Size = new System.Drawing.Size(53, 12);
            this.LBL_MailInfo.TabIndex = 11;
            this.LBL_MailInfo.Text = "邮箱地址";
            // 
            // LBL_CertifyInfo
            // 
            this.LBL_CertifyInfo.AutoSize = true;
            this.LBL_CertifyInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_CertifyInfo.Location = new System.Drawing.Point(156, 91);
            this.LBL_CertifyInfo.Name = "LBL_CertifyInfo";
            this.LBL_CertifyInfo.Size = new System.Drawing.Size(125, 12);
            this.LBL_CertifyInfo.TabIndex = 11;
            this.LBL_CertifyInfo.Text = "连接账号（验证状态）";
            // 
            // BTN_Set
            // 
            this.BTN_Set.Location = new System.Drawing.Point(288, 17);
            this.BTN_Set.Name = "BTN_Set";
            this.BTN_Set.Size = new System.Drawing.Size(57, 23);
            this.BTN_Set.TabIndex = 10;
            this.BTN_Set.Text = "保存";
            this.BTN_Set.UseVisualStyleBackColor = true;
            this.BTN_Set.Click += new System.EventHandler(this.BTN_Set_Click);
            // 
            // BTN_MailConfig
            // 
            this.BTN_MailConfig.Location = new System.Drawing.Point(320, 51);
            this.BTN_MailConfig.Name = "BTN_MailConfig";
            this.BTN_MailConfig.Size = new System.Drawing.Size(25, 23);
            this.BTN_MailConfig.TabIndex = 10;
            this.BTN_MailConfig.Text = "X";
            this.BTN_MailConfig.UseVisualStyleBackColor = true;
            this.BTN_MailConfig.Click += new System.EventHandler(this.BTN_MailConfig_Click);
            // 
            // BTN_LinkConfig
            // 
            this.BTN_LinkConfig.Location = new System.Drawing.Point(320, 121);
            this.BTN_LinkConfig.Name = "BTN_LinkConfig";
            this.BTN_LinkConfig.Size = new System.Drawing.Size(25, 23);
            this.BTN_LinkConfig.TabIndex = 10;
            this.BTN_LinkConfig.Text = "X";
            this.BTN_LinkConfig.UseVisualStyleBackColor = true;
            this.BTN_LinkConfig.Click += new System.EventHandler(this.BTN_LinkConfig_Click);
            // 
            // BTN_CerifyConfig
            // 
            this.BTN_CerifyConfig.Location = new System.Drawing.Point(320, 86);
            this.BTN_CerifyConfig.Name = "BTN_CerifyConfig";
            this.BTN_CerifyConfig.Size = new System.Drawing.Size(25, 23);
            this.BTN_CerifyConfig.TabIndex = 10;
            this.BTN_CerifyConfig.Text = "X";
            this.BTN_CerifyConfig.UseVisualStyleBackColor = true;
            this.BTN_CerifyConfig.Click += new System.EventHandler(this.BTN_CerifyConfig_Click);
            // 
            // LBL_MailEnable
            // 
            this.LBL_MailEnable.AutoSize = true;
            this.LBL_MailEnable.ForeColor = System.Drawing.Color.Red;
            this.LBL_MailEnable.Location = new System.Drawing.Point(357, 56);
            this.LBL_MailEnable.Name = "LBL_MailEnable";
            this.LBL_MailEnable.Size = new System.Drawing.Size(41, 12);
            this.LBL_MailEnable.TabIndex = 9;
            this.LBL_MailEnable.Text = "未就绪";
            // 
            // LBL_LinkEnable
            // 
            this.LBL_LinkEnable.AutoSize = true;
            this.LBL_LinkEnable.ForeColor = System.Drawing.Color.Red;
            this.LBL_LinkEnable.Location = new System.Drawing.Point(357, 126);
            this.LBL_LinkEnable.Name = "LBL_LinkEnable";
            this.LBL_LinkEnable.Size = new System.Drawing.Size(41, 12);
            this.LBL_LinkEnable.TabIndex = 9;
            this.LBL_LinkEnable.Text = "未就绪";
            // 
            // LBL_CertifyEnable
            // 
            this.LBL_CertifyEnable.AutoSize = true;
            this.LBL_CertifyEnable.ForeColor = System.Drawing.Color.Red;
            this.LBL_CertifyEnable.Location = new System.Drawing.Point(357, 91);
            this.LBL_CertifyEnable.Name = "LBL_CertifyEnable";
            this.LBL_CertifyEnable.Size = new System.Drawing.Size(41, 12);
            this.LBL_CertifyEnable.TabIndex = 9;
            this.LBL_CertifyEnable.Text = "未就绪";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "邮箱接收IP地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "连  接   随e行：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "进行校园网认证：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "开  启  时  间：";
            // 
            // DTP_StartTime
            // 
            this.DTP_StartTime.CustomFormat = "HH:mm";
            this.DTP_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_StartTime.Location = new System.Drawing.Point(156, 17);
            this.DTP_StartTime.Name = "DTP_StartTime";
            this.DTP_StartTime.ShowUpDown = true;
            this.DTP_StartTime.Size = new System.Drawing.Size(66, 21);
            this.DTP_StartTime.TabIndex = 2;
            this.DTP_StartTime.Value = new System.DateTime(2020, 6, 29, 8, 0, 0, 0);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(422, 252);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Jankiny";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "v2.0.0_200629_alpha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "作者：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "版本：";
            // 
            // TMR_Handle
            // 
            this.TMR_Handle.Interval = 200;
            this.TMR_Handle.Tick += new System.EventHandler(this.TMR_Handle_Tick);
            // 
            // TMR_UpdateTime
            // 
            this.TMR_UpdateTime.Enabled = true;
            this.TMR_UpdateTime.Interval = 500;
            this.TMR_UpdateTime.Tick += new System.EventHandler(this.TMR_UpdateTime_Tick);
            // 
            // FRM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 315);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FRM_Main";
            this.Text = "树大网络AutoLink";
            this.Load += new System.EventHandler(this.FRM_Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.PNL_Step3.ResumeLayout(false);
            this.PNL_Step3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Mail)).EndInit();
            this.PNL_Step2.ResumeLayout(false);
            this.PNL_Step2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Link)).EndInit();
            this.PNL_Step1.ResumeLayout(false);
            this.PNL_Step1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Certify)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSP_SLB_Statu;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel TSP_SLB_Time;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox TBX_Board;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTP_StartTime;
        private System.Windows.Forms.Button BTN_CerifyConfig;
        private System.Windows.Forms.Label LBL_MailEnable;
        private System.Windows.Forms.Label LBL_LinkEnable;
        private System.Windows.Forms.Label LBL_CertifyEnable;
        private System.Windows.Forms.Label LBL_MailInfo;
        private System.Windows.Forms.Label LBL_CertifyInfo;
        private System.Windows.Forms.Button BTN_MailConfig;
        private System.Windows.Forms.Button BTN_LinkConfig;
        private System.Windows.Forms.Label LBL_LinkInfo;
        private System.Windows.Forms.Timer TMR_Handle;
        private System.Windows.Forms.Panel PNL_Step1;
        private System.Windows.Forms.Label LBL_Step1;
        private System.Windows.Forms.Panel PNL_Step3;
        private System.Windows.Forms.Label LBL_Step3;
        private System.Windows.Forms.Panel PNL_Step2;
        private System.Windows.Forms.Label LBL_Step2;
        private System.Windows.Forms.Button BTN_Stop;
        private System.Windows.Forms.Label LBL_Line2;
        private System.Windows.Forms.Label LBL_Line1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BTN_Set;
        private System.Windows.Forms.PictureBox PBX_Certify;
        private System.Windows.Forms.PictureBox PBX_Mail;
        private System.Windows.Forms.PictureBox PBX_Link;
        private System.Windows.Forms.Timer TMR_UpdateTime;
    }
}

