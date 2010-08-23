namespace CustomTxtExporter
{
    partial class CustomTxtExporterSetup
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboOverride = new System.Windows.Forms.CheckBox();
            this.cboUseImageFileName = new System.Windows.Forms.CheckBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(285, 92);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboOverride
            // 
            this.cboOverride.AutoSize = true;
            this.cboOverride.Location = new System.Drawing.Point(12, 12);
            this.cboOverride.Name = "cboOverride";
            this.cboOverride.Size = new System.Drawing.Size(140, 17);
            this.cboOverride.TabIndex = 2;
            this.cboOverride.Text = "Override default settings";
            this.cboOverride.UseVisualStyleBackColor = true;
            this.cboOverride.CheckedChanged += new System.EventHandler(this.cboOverride_CheckedChanged);
            // 
            // cboUseImageFileName
            // 
            this.cboUseImageFileName.AutoSize = true;
            this.cboUseImageFileName.Enabled = false;
            this.cboUseImageFileName.Location = new System.Drawing.Point(32, 35);
            this.cboUseImageFileName.Name = "cboUseImageFileName";
            this.cboUseImageFileName.Size = new System.Drawing.Size(215, 17);
            this.cboUseImageFileName.TabIndex = 3;
            this.cboUseImageFileName.Text = "Name text file the same as the image file";
            this.cboUseImageFileName.UseVisualStyleBackColor = true;
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(32, 58);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(328, 20);
            this.txtDestination.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(366, 56);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // CustomTxtExporterSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 127);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.cboUseImageFileName);
            this.Controls.Add(this.cboOverride);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomTxtExporterSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Text Exporter Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cboOverride;
        private System.Windows.Forms.CheckBox cboUseImageFileName;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnBrowse;
    }
}