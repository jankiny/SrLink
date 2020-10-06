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
            this.SuspendLayout();
            // 
            // TBX_Board
            // 
            this.TBX_Board.AcceptsReturn = true;
            this.TBX_Board.AcceptsTab = true;
            this.TBX_Board.BackColor = System.Drawing.SystemColors.MenuText;
            this.TBX_Board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBX_Board.ForeColor = System.Drawing.Color.White;
            this.TBX_Board.Location = new System.Drawing.Point(0, 0);
            this.TBX_Board.Multiline = true;
            this.TBX_Board.Name = "TBX_Board";
            this.TBX_Board.ReadOnly = true;
            this.TBX_Board.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBX_Board.Size = new System.Drawing.Size(466, 311);
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
            // FrmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBX_Board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDebug";
            this.Text = "SrLink调试窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDebug_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBX_Board;
        private System.Windows.Forms.Label label1;
    }
}