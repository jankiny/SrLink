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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("常规");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("连接器");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("关于");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSP_SLB_Statu = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TMR_Handle = new System.Windows.Forms.Timer(this.components);
            this.TMR_UpdateTime = new System.Windows.Forms.Timer(this.components);
            this.TMR_ToolBarRetain = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LVW_Menu = new System.Windows.Forms.ListView();
            this.ILT_Menu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSP_SLB_Statu,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(713, 17);
            this.toolStripStatusLabel2.Spring = true;
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
            // TMR_ToolBarRetain
            // 
            this.TMR_ToolBarRetain.Interval = 3000;
            this.TMR_ToolBarRetain.Tick += new System.EventHandler(this.TMR_ToolBarRetain_Tick);
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 539);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 2;
            // 
            // LVW_Menu
            // 
            this.LVW_Menu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ILT_Menu});
            this.LVW_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVW_Menu.FullRowSelect = true;
            this.LVW_Menu.HideSelection = false;
            this.LVW_Menu.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.LVW_Menu.Location = new System.Drawing.Point(0, 0);
            this.LVW_Menu.MultiSelect = false;
            this.LVW_Menu.Name = "LVW_Menu";
            this.LVW_Menu.Size = new System.Drawing.Size(196, 539);
            this.LVW_Menu.TabIndex = 0;
            this.LVW_Menu.UseCompatibleStateImageBehavior = false;
            this.LVW_Menu.View = System.Windows.Forms.View.Details;
            this.LVW_Menu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LVW_Menu_MouseClick);
            // 
            // ILT_Menu
            // 
            this.ILT_Menu.Text = "菜单";
            this.ILT_Menu.Width = 192;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "树大网络AutoLink";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_Main_FormClosing);
            this.Load += new System.EventHandler(this.FRM_Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSP_SLB_Statu;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer TMR_Handle;
        private System.Windows.Forms.Timer TMR_UpdateTime;
        private System.Windows.Forms.Timer TMR_ToolBarRetain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView LVW_Menu;
        private System.Windows.Forms.ColumnHeader ILT_Menu;
    }
}

