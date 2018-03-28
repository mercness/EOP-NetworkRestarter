namespace EOP_NetworkReset
{
    partial class FormSettings
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
            this.ButtonSettingsSave = new System.Windows.Forms.Button();
            this.LabelmsWarning = new System.Windows.Forms.Label();
            this.TextWarningLowerLimitMs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PollingTimeMs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonSettingsSave
            // 
            this.ButtonSettingsSave.Location = new System.Drawing.Point(197, 56);
            this.ButtonSettingsSave.Name = "ButtonSettingsSave";
            this.ButtonSettingsSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSettingsSave.TabIndex = 0;
            this.ButtonSettingsSave.Text = "Save";
            this.ButtonSettingsSave.UseVisualStyleBackColor = true;
            this.ButtonSettingsSave.Click += new System.EventHandler(this.ButtonSettingsSave_Click);
            // 
            // LabelmsWarning
            // 
            this.LabelmsWarning.AutoSize = true;
            this.LabelmsWarning.Location = new System.Drawing.Point(13, 13);
            this.LabelmsWarning.Name = "LabelmsWarning";
            this.LabelmsWarning.Size = new System.Drawing.Size(125, 13);
            this.LabelmsWarning.TabIndex = 1;
            this.LabelmsWarning.Text = "Warning Lower Limit (ms)";
            // 
            // TextWarningLowerLimitMs
            // 
            this.TextWarningLowerLimitMs.Location = new System.Drawing.Point(144, 10);
            this.TextWarningLowerLimitMs.Name = "TextWarningLowerLimitMs";
            this.TextWarningLowerLimitMs.Size = new System.Drawing.Size(128, 20);
            this.TextWarningLowerLimitMs.TabIndex = 2;
            this.TextWarningLowerLimitMs.Text = "50";
            this.TextWarningLowerLimitMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Polling Time (ms)";
            // 
            // PollingTimeMs
            // 
            this.PollingTimeMs.Location = new System.Drawing.Point(144, 30);
            this.PollingTimeMs.Name = "PollingTimeMs";
            this.PollingTimeMs.Size = new System.Drawing.Size(128, 20);
            this.PollingTimeMs.TabIndex = 4;
            this.PollingTimeMs.Text = "1000";
            this.PollingTimeMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormSettings
            // 
            this.ClientSize = new System.Drawing.Size(284, 85);
            this.Controls.Add(this.PollingTimeMs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextWarningLowerLimitMs);
            this.Controls.Add(this.LabelmsWarning);
            this.Controls.Add(this.ButtonSettingsSave);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSettingsSave;
        private System.Windows.Forms.Label LabelmsWarning;
        private System.Windows.Forms.TextBox TextWarningLowerLimitMs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PollingTimeMs;
    }
}