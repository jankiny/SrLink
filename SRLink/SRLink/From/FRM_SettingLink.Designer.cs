namespace SRLink.From
{
    partial class FRM_SettingLink
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBX_Enable = new System.Windows.Forms.CheckBox();
            this.OFD_Path = new System.Windows.Forms.OpenFileDialog();
            this.BTN_ChoosePath = new System.Windows.Forms.Button();
            this.TBX_Path = new System.Windows.Forms.TextBox();
            this.DDL_Way = new System.Windows.Forms.ComboBox();
            this.PNL_Position = new System.Windows.Forms.Panel();
            this.TBX_Y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBX_X = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_Test = new System.Windows.Forms.Button();
            this.PNL_Position.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "运行方式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "程序位置：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBX_Enable
            // 
            this.CBX_Enable.AutoSize = true;
            this.CBX_Enable.Location = new System.Drawing.Point(19, 17);
            this.CBX_Enable.Name = "CBX_Enable";
            this.CBX_Enable.Size = new System.Drawing.Size(48, 16);
            this.CBX_Enable.TabIndex = 6;
            this.CBX_Enable.Text = "启用";
            this.CBX_Enable.UseVisualStyleBackColor = true;
            // 
            // OFD_Path
            // 
            this.OFD_Path.Filter = "随e行运行程序|*.exe";
            this.OFD_Path.InitialDirectory = "C:\\Program Files (x86)\\";
            // 
            // BTN_ChoosePath
            // 
            this.BTN_ChoosePath.Location = new System.Drawing.Point(253, 41);
            this.BTN_ChoosePath.Name = "BTN_ChoosePath";
            this.BTN_ChoosePath.Size = new System.Drawing.Size(25, 23);
            this.BTN_ChoosePath.TabIndex = 13;
            this.BTN_ChoosePath.Text = "X";
            this.BTN_ChoosePath.UseVisualStyleBackColor = true;
            this.BTN_ChoosePath.Click += new System.EventHandler(this.BTN_ChoosePath_Click);
            // 
            // TBX_Path
            // 
            this.TBX_Path.Location = new System.Drawing.Point(91, 42);
            this.TBX_Path.Name = "TBX_Path";
            this.TBX_Path.ReadOnly = true;
            this.TBX_Path.Size = new System.Drawing.Size(156, 21);
            this.TBX_Path.TabIndex = 14;
            // 
            // DDL_Way
            // 
            this.DDL_Way.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DDL_Way.FormattingEnabled = true;
            this.DDL_Way.Items.AddRange(new object[] {
            "窗体抓取",
            "鼠标模拟点击"});
            this.DDL_Way.Location = new System.Drawing.Point(91, 75);
            this.DDL_Way.Name = "DDL_Way";
            this.DDL_Way.Size = new System.Drawing.Size(156, 20);
            this.DDL_Way.TabIndex = 15;
            this.DDL_Way.SelectedIndexChanged += new System.EventHandler(this.DDL_Way_SelectedIndexChanged);
            // 
            // PNL_Position
            // 
            this.PNL_Position.Controls.Add(this.TBX_Y);
            this.PNL_Position.Controls.Add(this.label4);
            this.PNL_Position.Controls.Add(this.TBX_X);
            this.PNL_Position.Controls.Add(this.label2);
            this.PNL_Position.Controls.Add(this.label5);
            this.PNL_Position.Location = new System.Drawing.Point(12, 103);
            this.PNL_Position.Name = "PNL_Position";
            this.PNL_Position.Size = new System.Drawing.Size(257, 28);
            this.PNL_Position.TabIndex = 16;
            // 
            // TBX_Y
            // 
            this.TBX_Y.Location = new System.Drawing.Point(205, 3);
            this.TBX_Y.Name = "TBX_Y";
            this.TBX_Y.Size = new System.Drawing.Size(31, 21);
            this.TBX_Y.TabIndex = 1;
            this.TBX_Y.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Y：";
            // 
            // TBX_X
            // 
            this.TBX_X.Location = new System.Drawing.Point(112, 3);
            this.TBX_X.Name = "TBX_X";
            this.TBX_X.Size = new System.Drawing.Size(31, 21);
            this.TBX_X.TabIndex = 1;
            this.TBX_X.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "X：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "点击位置：";
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(33, 141);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(75, 23);
            this.BTN_Save.TabIndex = 17;
            this.BTN_Save.Text = "应用";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_Test
            // 
            this.BTN_Test.Location = new System.Drawing.Point(182, 141);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(75, 23);
            this.BTN_Test.TabIndex = 18;
            this.BTN_Test.Text = "测试";
            this.BTN_Test.UseVisualStyleBackColor = true;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
            // 
            // FRM_SettingLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 172);
            this.Controls.Add(this.BTN_Test);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.PNL_Position);
            this.Controls.Add(this.DDL_Way);
            this.Controls.Add(this.TBX_Path);
            this.Controls.Add(this.BTN_ChoosePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBX_Enable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_SettingLink";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置连接";
            this.PNL_Position.ResumeLayout(false);
            this.PNL_Position.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBX_Enable;
        private System.Windows.Forms.OpenFileDialog OFD_Path;
        private System.Windows.Forms.Button BTN_ChoosePath;
        private System.Windows.Forms.TextBox TBX_Path;
        private System.Windows.Forms.ComboBox DDL_Way;
        private System.Windows.Forms.Panel PNL_Position;
        private System.Windows.Forms.TextBox TBX_Y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBX_X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Test;
    }
}