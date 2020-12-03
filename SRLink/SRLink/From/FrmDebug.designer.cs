namespace SRLink.From
{
    partial class FrmDebug
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
            this.TBX_Board = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBL_SettingLink = new System.Windows.Forms.Label();
            this.LBL_SettingMail = new System.Windows.Forms.Label();
            this.LBL_SettingCertify = new System.Windows.Forms.Label();
            this.LBL_AutoLink = new System.Windows.Forms.Label();
            this.LBL_RunAtStartup = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBX_Board
            // 
            this.TBX_Board.AcceptsReturn = true;
            this.TBX_Board.AcceptsTab = true;
            this.TBX_Board.BackColor = System.Drawing.SystemColors.MenuText;
            this.TBX_Board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBX_Board.ForeColor = System.Drawing.Color.White;
            this.TBX_Board.Location = new System.Drawing.Point(0, 114);
            this.TBX_Board.Multiline = true;
            this.TBX_Board.Name = "TBX_Board";
            this.TBX_Board.ReadOnly = true;
            this.TBX_Board.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBX_Board.Size = new System.Drawing.Size(466, 197);
            this.TBX_Board.TabIndex = 6;
            this.TBX_Board.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBL_SettingLink);
            this.groupBox1.Controls.Add(this.LBL_SettingMail);
            this.groupBox1.Controls.Add(this.LBL_SettingCertify);
            this.groupBox1.Controls.Add(this.LBL_AutoLink);
            this.groupBox1.Controls.Add(this.LBL_RunAtStartup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前配置";
            // 
            // LBL_SettingLink
            // 
            this.LBL_SettingLink.AutoSize = true;
            this.LBL_SettingLink.Location = new System.Drawing.Point(12, 65);
            this.LBL_SettingLink.Name = "LBL_SettingLink";
            this.LBL_SettingLink.Size = new System.Drawing.Size(101, 12);
            this.LBL_SettingLink.TabIndex = 0;
            this.LBL_SettingLink.Text = "启用连接网络()：";
            // 
            // LBL_SettingMail
            // 
            this.LBL_SettingMail.AutoSize = true;
            this.LBL_SettingMail.Location = new System.Drawing.Point(12, 89);
            this.LBL_SettingMail.Name = "LBL_SettingMail";
            this.LBL_SettingMail.Size = new System.Drawing.Size(89, 12);
            this.LBL_SettingMail.TabIndex = 0;
            this.LBL_SettingMail.Text = "启用发送Ip()：";
            // 
            // LBL_SettingCertify
            // 
            this.LBL_SettingCertify.AutoSize = true;
            this.LBL_SettingCertify.Location = new System.Drawing.Point(12, 41);
            this.LBL_SettingCertify.Name = "LBL_SettingCertify";
            this.LBL_SettingCertify.Size = new System.Drawing.Size(77, 12);
            this.LBL_SettingCertify.TabIndex = 0;
            this.LBL_SettingCertify.Text = "启用认证()：";
            // 
            // LBL_AutoLink
            // 
            this.LBL_AutoLink.AutoSize = true;
            this.LBL_AutoLink.Location = new System.Drawing.Point(240, 17);
            this.LBL_AutoLink.Name = "LBL_AutoLink";
            this.LBL_AutoLink.Size = new System.Drawing.Size(77, 12);
            this.LBL_AutoLink.TabIndex = 0;
            this.LBL_AutoLink.Text = "自动连接()：";
            // 
            // LBL_RunAtStartup
            // 
            this.LBL_RunAtStartup.AutoSize = true;
            this.LBL_RunAtStartup.Location = new System.Drawing.Point(12, 17);
            this.LBL_RunAtStartup.Name = "LBL_RunAtStartup";
            this.LBL_RunAtStartup.Size = new System.Drawing.Size(77, 12);
            this.LBL_RunAtStartup.TabIndex = 0;
            this.LBL_RunAtStartup.Text = "开机启动()：";
            // 
            // FrmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBX_Board);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDebug";
            this.Text = "SrLink调试窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDebug_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBX_Board;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LBL_RunAtStartup;
        private System.Windows.Forms.Label LBL_SettingLink;
        private System.Windows.Forms.Label LBL_SettingMail;
        private System.Windows.Forms.Label LBL_SettingCertify;
        private System.Windows.Forms.Label LBL_AutoLink;
    }
}