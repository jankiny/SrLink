namespace SRLink.From
{
    partial class FrmMain
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "常规"}, 0, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("黑体", 12F));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "连接器"}, 1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("黑体", 12F));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "关于"}, 2, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("黑体", 12F));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TMR_SrLink = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LVW_Menu = new System.Windows.Forms.ListView();
            this.ILT_Menu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IMGL_Menu = new System.Windows.Forms.ImageList(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.立即连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.显示ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.立即连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换网络ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.NotifyIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TMR_SrLink
            // 
            this.TMR_SrLink.Enabled = true;
            this.TMR_SrLink.Interval = 3000;
            this.TMR_SrLink.Tick += new System.EventHandler(this.TMR_SrLink_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LVW_Menu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.AutoScrollMinSize = new System.Drawing.Size(0, 410);
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Size = new System.Drawing.Size(634, 411);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 2;
            // 
            // LVW_Menu
            // 
            this.LVW_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LVW_Menu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ILT_Menu});
            this.LVW_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVW_Menu.FullRowSelect = true;
            this.LVW_Menu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LVW_Menu.HideSelection = false;
            this.LVW_Menu.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.LVW_Menu.Location = new System.Drawing.Point(0, 0);
            this.LVW_Menu.MultiSelect = false;
            this.LVW_Menu.Name = "LVW_Menu";
            this.LVW_Menu.Scrollable = false;
            this.LVW_Menu.ShowGroups = false;
            this.LVW_Menu.Size = new System.Drawing.Size(161, 411);
            this.LVW_Menu.SmallImageList = this.IMGL_Menu;
            this.LVW_Menu.TabIndex = 0;
            this.LVW_Menu.UseCompatibleStateImageBehavior = false;
            this.LVW_Menu.View = System.Windows.Forms.View.Details;
            this.LVW_Menu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LVW_Menu_MouseClick);
            // 
            // ILT_Menu
            // 
            this.ILT_Menu.Text = "菜单";
            this.ILT_Menu.Width = 203;
            // 
            // IMGL_Menu
            // 
            this.IMGL_Menu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMGL_Menu.ImageStream")));
            this.IMGL_Menu.TransparentColor = System.Drawing.Color.Transparent;
            this.IMGL_Menu.Images.SetKeyName(0, "About.png");
            this.IMGL_Menu.Images.SetKeyName(1, "Link.png");
            this.IMGL_Menu.Images.SetKeyName(2, "Normal.png");
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "SrLink(网络连接器)";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // NotifyIconMenuStrip
            // 
            this.NotifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.立即连接ToolStripMenuItem1,
            this.断开连接ToolStripMenuItem1,
            this.切换网络ToolStripMenuItem,
            this.toolStripSeparator2,
            this.显示ToolStripMenuItem1,
            this.退出ToolStripMenuItem1});
            this.NotifyIconMenuStrip.Name = "NotifyIconMenuStrip";
            this.NotifyIconMenuStrip.Size = new System.Drawing.Size(181, 142);
            // 
            // 立即连接ToolStripMenuItem1
            // 
            this.立即连接ToolStripMenuItem1.Name = "立即连接ToolStripMenuItem1";
            this.立即连接ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.立即连接ToolStripMenuItem1.Text = "立即连接";
            this.立即连接ToolStripMenuItem1.Click += new System.EventHandler(this.立即连接ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem1
            // 
            this.断开连接ToolStripMenuItem1.Name = "断开连接ToolStripMenuItem1";
            this.断开连接ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.断开连接ToolStripMenuItem1.Text = "断开连接";
            this.断开连接ToolStripMenuItem1.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_ClickAsync);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // 显示ToolStripMenuItem1
            // 
            this.显示ToolStripMenuItem1.Name = "显示ToolStripMenuItem1";
            this.显示ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.显示ToolStripMenuItem1.Text = "显示窗口";
            this.显示ToolStripMenuItem1.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_ClickAsync);
            // 
            // 立即连接ToolStripMenuItem
            // 
            this.立即连接ToolStripMenuItem.Name = "立即连接ToolStripMenuItem";
            this.立即连接ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.立即连接ToolStripMenuItem.Text = "立即连接";
            this.立即连接ToolStripMenuItem.Click += new System.EventHandler(this.立即连接ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 切换网络ToolStripMenuItem
            // 
            this.切换网络ToolStripMenuItem.Name = "切换网络ToolStripMenuItem";
            this.切换网络ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.切换网络ToolStripMenuItem.Text = "切换网络";
            this.切换网络ToolStripMenuItem.Click += new System.EventHandler(this.切换网络ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SrLink";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FRM_Main_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.NotifyIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TMR_SrLink;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView LVW_Menu;
        private System.Windows.Forms.ColumnHeader ILT_Menu;
        private System.Windows.Forms.ImageList IMGL_Menu;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 立即连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 立即连接ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 切换网络ToolStripMenuItem;
    }
}

