namespace SRLink.From
{
    partial class SubFrmAbout
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
            this.UDisplay_Author = new SRLink.From.UDisplay();
            this.UDisplay_Version = new SRLink.From.UDisplay();
            this.UDisplay_Note = new SRLink.From.UDisplay();
            this.SuspendLayout();
            // 
            // UDisplay_Author
            // 
            this.UDisplay_Author.Content = "Jankiny";
            this.UDisplay_Author.Key = "作者";
            this.UDisplay_Author.Location = new System.Drawing.Point(28, 22);
            this.UDisplay_Author.Name = "UDisplay_Author";
            this.UDisplay_Author.Size = new System.Drawing.Size(286, 23);
            this.UDisplay_Author.TabIndex = 8;
            this.UDisplay_Author.UnderLine = false;
            // 
            // UDisplay_Version
            // 
            this.UDisplay_Version.Content = "vX.X.X_yymmdd_alpha";
            this.UDisplay_Version.Key = "版本";
            this.UDisplay_Version.Location = new System.Drawing.Point(28, 51);
            this.UDisplay_Version.Name = "UDisplay_Version";
            this.UDisplay_Version.Size = new System.Drawing.Size(286, 23);
            this.UDisplay_Version.TabIndex = 8;
            this.UDisplay_Version.UnderLine = false;
            // 
            // UDisplay_Note
            // 
            this.UDisplay_Note.Content = "Github主页";
            this.UDisplay_Note.Key = "说明：";
            this.UDisplay_Note.Location = new System.Drawing.Point(28, 80);
            this.UDisplay_Note.Name = "UDisplay_Note";
            this.UDisplay_Note.Size = new System.Drawing.Size(286, 23);
            this.UDisplay_Note.TabIndex = 8;
            this.UDisplay_Note.UnderLine = true;
            this.UDisplay_Note.Click += new System.EventHandler(this.UDisplay_Note_Click);
            // 
            // SubFrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 177);
            this.Controls.Add(this.UDisplay_Note);
            this.Controls.Add(this.UDisplay_Version);
            this.Controls.Add(this.UDisplay_Author);
            this.Name = "SubFrmAbout";
            this.Text = "SubFrmAbout";
            this.ResumeLayout(false);

        }

        #endregion
        private UDisplay UDisplay_Author;
        private UDisplay UDisplay_Version;
        private UDisplay UDisplay_Note;
    }
}