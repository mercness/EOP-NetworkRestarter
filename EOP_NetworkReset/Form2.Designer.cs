namespace EOP_NetworkReset
{
    partial class FrmWarningsLog
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
            this.ListBoxWarnings = new System.Windows.Forms.ListBox();
            this.ButtonSaveToFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxWarnings
            // 
            this.ListBoxWarnings.FormattingEnabled = true;
            this.ListBoxWarnings.Location = new System.Drawing.Point(12, 12);
            this.ListBoxWarnings.Name = "ListBoxWarnings";
            this.ListBoxWarnings.Size = new System.Drawing.Size(329, 420);
            this.ListBoxWarnings.TabIndex = 0;
            // 
            // ButtonSaveToFile
            // 
            this.ButtonSaveToFile.Location = new System.Drawing.Point(266, 438);
            this.ButtonSaveToFile.Name = "ButtonSaveToFile";
            this.ButtonSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonSaveToFile.TabIndex = 1;
            this.ButtonSaveToFile.Text = "Save to File";
            this.ButtonSaveToFile.UseVisualStyleBackColor = true;
            this.ButtonSaveToFile.Click += new System.EventHandler(this.ButtonSaveToFile_Click);
            // 
            // FrmWarningsLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 470);
            this.Controls.Add(this.ButtonSaveToFile);
            this.Controls.Add(this.ListBoxWarnings);
            this.Name = "FrmWarningsLog";
            this.Text = "Warnings Log";
            this.Load += new System.EventHandler(this.FrmWarningsLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxWarnings;
        private System.Windows.Forms.Button ButtonSaveToFile;
    }
}