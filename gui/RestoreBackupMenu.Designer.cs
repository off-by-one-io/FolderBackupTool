namespace FolderBackupTool.gui
{
    partial class RestoreBackupMenu
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
            this.BackupsLocationInput = new System.Windows.Forms.TextBox();
            this.BackupsLocationLabel = new System.Windows.Forms.Label();
            this.BackupsLocationSelect = new System.Windows.Forms.Button();
            this.BackupSelect = new System.Windows.Forms.ComboBox();
            this.LocationGroup = new System.Windows.Forms.GroupBox();
            this.RestorationLocationLabel = new System.Windows.Forms.Label();
            this.RestorationLocationSelect = new System.Windows.Forms.Button();
            this.RestorationLocationInput = new System.Windows.Forms.TextBox();
            this.BackupSelectionLabel = new System.Windows.Forms.Label();
            this.RestorationProgressLabel = new System.Windows.Forms.Label();
            this.StatusInformationLabel = new System.Windows.Forms.Label();
            this.RestorationProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressGroup = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.LocationGroup.SuspendLayout();
            this.ProgressGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackupsLocationInput
            // 
            this.BackupsLocationInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupsLocationInput.Location = new System.Drawing.Point(12, 40);
            this.BackupsLocationInput.Name = "BackupsLocationInput";
            this.BackupsLocationInput.Size = new System.Drawing.Size(294, 23);
            this.BackupsLocationInput.TabIndex = 2;
            this.BackupsLocationInput.TextChanged += new System.EventHandler(this.BackupsLocationInput_TextChanged);
            // 
            // BackupsLocationLabel
            // 
            this.BackupsLocationLabel.AutoSize = true;
            this.BackupsLocationLabel.Location = new System.Drawing.Point(12, 22);
            this.BackupsLocationLabel.Name = "BackupsLocationLabel";
            this.BackupsLocationLabel.Size = new System.Drawing.Size(88, 15);
            this.BackupsLocationLabel.TabIndex = 1;
            this.BackupsLocationLabel.Text = "Backups folder:";
            // 
            // BackupsLocationSelect
            // 
            this.BackupsLocationSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupsLocationSelect.Location = new System.Drawing.Point(312, 40);
            this.BackupsLocationSelect.Name = "BackupsLocationSelect";
            this.BackupsLocationSelect.Size = new System.Drawing.Size(75, 23);
            this.BackupsLocationSelect.TabIndex = 0;
            this.BackupsLocationSelect.Text = "Search...";
            this.BackupsLocationSelect.UseVisualStyleBackColor = true;
            this.BackupsLocationSelect.Click += new System.EventHandler(this.BackupsLocationSelect_Click);
            // 
            // BackupSelect
            // 
            this.BackupSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BackupSelect.Enabled = false;
            this.BackupSelect.FormattingEnabled = true;
            this.BackupSelect.Location = new System.Drawing.Point(12, 84);
            this.BackupSelect.Name = "BackupSelect";
            this.BackupSelect.Size = new System.Drawing.Size(375, 23);
            this.BackupSelect.TabIndex = 3;
            this.BackupSelect.SelectedIndexChanged += new System.EventHandler(this.BackupSelect_SelectedIndexChanged);
            // 
            // LocationGroup
            // 
            this.LocationGroup.Controls.Add(this.RestorationLocationLabel);
            this.LocationGroup.Controls.Add(this.RestorationLocationSelect);
            this.LocationGroup.Controls.Add(this.RestorationLocationInput);
            this.LocationGroup.Controls.Add(this.BackupSelectionLabel);
            this.LocationGroup.Controls.Add(this.BackupsLocationSelect);
            this.LocationGroup.Controls.Add(this.BackupSelect);
            this.LocationGroup.Controls.Add(this.BackupsLocationInput);
            this.LocationGroup.Controls.Add(this.BackupsLocationLabel);
            this.LocationGroup.Location = new System.Drawing.Point(12, 12);
            this.LocationGroup.Name = "LocationGroup";
            this.LocationGroup.Size = new System.Drawing.Size(400, 172);
            this.LocationGroup.TabIndex = 4;
            this.LocationGroup.TabStop = false;
            this.LocationGroup.Text = "Location";
            // 
            // RestorationLocationLabel
            // 
            this.RestorationLocationLabel.AutoSize = true;
            this.RestorationLocationLabel.Location = new System.Drawing.Point(12, 116);
            this.RestorationLocationLabel.Name = "RestorationLocationLabel";
            this.RestorationLocationLabel.Size = new System.Drawing.Size(63, 15);
            this.RestorationLocationLabel.TabIndex = 4;
            this.RestorationLocationLabel.Text = "Restore to:";
            // 
            // RestorationLocationSelect
            // 
            this.RestorationLocationSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestorationLocationSelect.Location = new System.Drawing.Point(312, 134);
            this.RestorationLocationSelect.Name = "RestorationLocationSelect";
            this.RestorationLocationSelect.Size = new System.Drawing.Size(75, 23);
            this.RestorationLocationSelect.TabIndex = 0;
            this.RestorationLocationSelect.Text = "Search...";
            this.RestorationLocationSelect.UseVisualStyleBackColor = true;
            this.RestorationLocationSelect.Click += new System.EventHandler(this.RestorationLocationSelect_Click);
            // 
            // RestorationLocationInput
            // 
            this.RestorationLocationInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RestorationLocationInput.Location = new System.Drawing.Point(12, 134);
            this.RestorationLocationInput.Name = "RestorationLocationInput";
            this.RestorationLocationInput.Size = new System.Drawing.Size(294, 23);
            this.RestorationLocationInput.TabIndex = 2;
            this.RestorationLocationInput.TextChanged += new System.EventHandler(this.RestorationLocationInput_TextChanged);
            // 
            // BackupSelectionLabel
            // 
            this.BackupSelectionLabel.AutoSize = true;
            this.BackupSelectionLabel.Location = new System.Drawing.Point(12, 66);
            this.BackupSelectionLabel.Name = "BackupSelectionLabel";
            this.BackupSelectionLabel.Size = new System.Drawing.Size(102, 15);
            this.BackupSelectionLabel.TabIndex = 1;
            this.BackupSelectionLabel.Text = "Backup to restore:";
            // 
            // RestorationProgressLabel
            // 
            this.RestorationProgressLabel.AutoSize = true;
            this.RestorationProgressLabel.Location = new System.Drawing.Point(25, 43);
            this.RestorationProgressLabel.Name = "RestorationProgressLabel";
            this.RestorationProgressLabel.Size = new System.Drawing.Size(16, 15);
            this.RestorationProgressLabel.TabIndex = 15;
            this.RestorationProgressLabel.Text = "   ";
            // 
            // StatusInformationLabel
            // 
            this.StatusInformationLabel.AutoSize = true;
            this.StatusInformationLabel.Location = new System.Drawing.Point(14, 22);
            this.StatusInformationLabel.Name = "StatusInformationLabel";
            this.StatusInformationLabel.Size = new System.Drawing.Size(16, 15);
            this.StatusInformationLabel.TabIndex = 14;
            this.StatusInformationLabel.Text = "   ";
            // 
            // RestorationProgressBar
            // 
            this.RestorationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RestorationProgressBar.Location = new System.Drawing.Point(14, 40);
            this.RestorationProgressBar.Name = "RestorationProgressBar";
            this.RestorationProgressBar.Size = new System.Drawing.Size(215, 23);
            this.RestorationProgressBar.TabIndex = 11;
            // 
            // ProgressGroup
            // 
            this.ProgressGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressGroup.Controls.Add(this.RestorationProgressLabel);
            this.ProgressGroup.Controls.Add(this.LogBox);
            this.ProgressGroup.Controls.Add(this.RestorationProgressBar);
            this.ProgressGroup.Controls.Add(this.StatusInformationLabel);
            this.ProgressGroup.Enabled = false;
            this.ProgressGroup.Location = new System.Drawing.Point(418, 12);
            this.ProgressGroup.Name = "ProgressGroup";
            this.ProgressGroup.Size = new System.Drawing.Size(244, 242);
            this.ProgressGroup.TabIndex = 16;
            this.ProgressGroup.TabStop = false;
            this.ProgressGroup.Text = "Progress";
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 15;
            this.LogBox.Location = new System.Drawing.Point(14, 69);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(215, 154);
            this.LogBox.TabIndex = 18;
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(288, 190);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(124, 34);
            this.RestoreButton.TabIndex = 17;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // RestoreBackupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 273);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.ProgressGroup);
            this.Controls.Add(this.LocationGroup);
            this.MinimumSize = new System.Drawing.Size(690, 312);
            this.Name = "RestoreBackupMenu";
            this.Text = "Restore Backup";
            this.LocationGroup.ResumeLayout(false);
            this.LocationGroup.PerformLayout();
            this.ProgressGroup.ResumeLayout(false);
            this.ProgressGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox BackupsLocationInput;
        private System.Windows.Forms.Label Backups;
        private System.Windows.Forms.Button BackupsLocationSelect;
        private System.Windows.Forms.Label BackupsLocationLabel;
        private System.Windows.Forms.ComboBox BackupSelect;
        private System.Windows.Forms.GroupBox LocationGroup;
        private System.Windows.Forms.Button RestorationLocationSelect;
        private System.Windows.Forms.TextBox RestorationLocationInput;
        private System.Windows.Forms.Label BackupSelectionLabel;
        private System.Windows.Forms.Label RestorationLocationLabel;
        private System.Windows.Forms.Label RestorationProgressLabel;
        private System.Windows.Forms.Label StatusInformationLabel;
        private System.Windows.Forms.ProgressBar RestorationProgressBar;
        private System.Windows.Forms.GroupBox ProgressGroup;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.ListBox LogBox;
    }
}