namespace FolderBackupTool.gui
{
    partial class MainMenu
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
            this.CreateBackupButton = new System.Windows.Forms.Button();
            this.RestoreBackupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateBackupButton
            // 
            this.CreateBackupButton.Location = new System.Drawing.Point(12, 12);
            this.CreateBackupButton.Name = "CreateBackupButton";
            this.CreateBackupButton.Size = new System.Drawing.Size(294, 55);
            this.CreateBackupButton.TabIndex = 0;
            this.CreateBackupButton.Text = "Create backup";
            this.CreateBackupButton.UseVisualStyleBackColor = true;
            this.CreateBackupButton.Click += new System.EventHandler(this.CreateBackupButton_Click);
            // 
            // RestoreBackupButton
            // 
            this.RestoreBackupButton.Location = new System.Drawing.Point(12, 73);
            this.RestoreBackupButton.Name = "RestoreBackupButton";
            this.RestoreBackupButton.Size = new System.Drawing.Size(294, 55);
            this.RestoreBackupButton.TabIndex = 0;
            this.RestoreBackupButton.Text = "Restore backup";
            this.RestoreBackupButton.UseVisualStyleBackColor = true;
            this.RestoreBackupButton.Click += new System.EventHandler(this.RestoreBackupButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 147);
            this.Controls.Add(this.RestoreBackupButton);
            this.Controls.Add(this.CreateBackupButton);
            this.Name = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateBackupButton;
        private System.Windows.Forms.Button RestoreBackupButton;
    }
}