namespace FolderBackupTool
{
    partial class CreateBackupMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackupSourceSelect = new System.Windows.Forms.Button();
            this.BackupSourceLabel = new System.Windows.Forms.Label();
            this.BackupDestinationLabel = new System.Windows.Forms.Label();
            this.BackupDestinationSelect = new System.Windows.Forms.Button();
            this.BackupSourceInput = new System.Windows.Forms.TextBox();
            this.BackupDestinationInput = new System.Windows.Forms.TextBox();
            this.PrecedingBackupSelect = new System.Windows.Forms.ComboBox();
            this.FullBackupToggle = new System.Windows.Forms.CheckBox();
            this.PrecedingBackupLabel = new System.Windows.Forms.Label();
            this.LocationGroup = new System.Windows.Forms.GroupBox();
            this.ConfigurationGroup = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.CreateBackupButton = new System.Windows.Forms.Button();
            this.BackupProgressBar = new System.Windows.Forms.ProgressBar();
            this.ScanProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusInformationLabel = new System.Windows.Forms.Label();
            this.ProgressGroup = new System.Windows.Forms.GroupBox();
            this.BackupProgressLabel = new System.Windows.Forms.Label();
            this.ScanProgressLabel = new System.Windows.Forms.Label();
            this.LocationGroup.SuspendLayout();
            this.ConfigurationGroup.SuspendLayout();
            this.ProgressGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackupSourceSelect
            // 
            this.BackupSourceSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupSourceSelect.Location = new System.Drawing.Point(328, 46);
            this.BackupSourceSelect.Name = "BackupSourceSelect";
            this.BackupSourceSelect.Size = new System.Drawing.Size(75, 23);
            this.BackupSourceSelect.TabIndex = 0;
            this.BackupSourceSelect.Text = "Search...";
            this.BackupSourceSelect.UseVisualStyleBackColor = true;
            this.BackupSourceSelect.Click += new System.EventHandler(this.BackupSourceSelect_Click);
            // 
            // BackupSourceLabel
            // 
            this.BackupSourceLabel.AutoSize = true;
            this.BackupSourceLabel.Location = new System.Drawing.Point(15, 28);
            this.BackupSourceLabel.Name = "BackupSourceLabel";
            this.BackupSourceLabel.Size = new System.Drawing.Size(87, 15);
            this.BackupSourceLabel.TabIndex = 1;
            this.BackupSourceLabel.Text = "Backup source:";
            // 
            // BackupDestinationLabel
            // 
            this.BackupDestinationLabel.AutoSize = true;
            this.BackupDestinationLabel.Location = new System.Drawing.Point(15, 72);
            this.BackupDestinationLabel.Name = "BackupDestinationLabel";
            this.BackupDestinationLabel.Size = new System.Drawing.Size(111, 15);
            this.BackupDestinationLabel.TabIndex = 1;
            this.BackupDestinationLabel.Text = "Backup destination:";
            // 
            // BackupDestinationSelect
            // 
            this.BackupDestinationSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupDestinationSelect.Location = new System.Drawing.Point(328, 90);
            this.BackupDestinationSelect.Name = "BackupDestinationSelect";
            this.BackupDestinationSelect.Size = new System.Drawing.Size(75, 23);
            this.BackupDestinationSelect.TabIndex = 0;
            this.BackupDestinationSelect.Text = "Search...";
            this.BackupDestinationSelect.UseVisualStyleBackColor = true;
            this.BackupDestinationSelect.Click += new System.EventHandler(this.BackupDestinationSelect_Click);
            // 
            // BackupSourceInput
            // 
            this.BackupSourceInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupSourceInput.Location = new System.Drawing.Point(15, 46);
            this.BackupSourceInput.Name = "BackupSourceInput";
            this.BackupSourceInput.Size = new System.Drawing.Size(307, 23);
            this.BackupSourceInput.TabIndex = 2;
            this.BackupSourceInput.TextChanged += new System.EventHandler(this.BackupSourceInput_TextChanged);
            // 
            // BackupDestinationInput
            // 
            this.BackupDestinationInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupDestinationInput.Location = new System.Drawing.Point(15, 90);
            this.BackupDestinationInput.Name = "BackupDestinationInput";
            this.BackupDestinationInput.Size = new System.Drawing.Size(307, 23);
            this.BackupDestinationInput.TabIndex = 2;
            this.BackupDestinationInput.TextChanged += new System.EventHandler(this.BackupDestinationInput_TextChanged);
            // 
            // PrecedingBackupSelect
            // 
            this.PrecedingBackupSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrecedingBackupSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrecedingBackupSelect.FormattingEnabled = true;
            this.PrecedingBackupSelect.Location = new System.Drawing.Point(15, 37);
            this.PrecedingBackupSelect.Name = "PrecedingBackupSelect";
            this.PrecedingBackupSelect.Size = new System.Drawing.Size(388, 23);
            this.PrecedingBackupSelect.TabIndex = 3;
            this.PrecedingBackupSelect.SelectedValueChanged += new System.EventHandler(this.PrecedingBackupSelect_SelectedValueChanged);
            // 
            // FullBackupToggle
            // 
            this.FullBackupToggle.AutoSize = true;
            this.FullBackupToggle.Location = new System.Drawing.Point(15, 66);
            this.FullBackupToggle.Name = "FullBackupToggle";
            this.FullBackupToggle.Size = new System.Drawing.Size(122, 19);
            this.FullBackupToggle.TabIndex = 4;
            this.FullBackupToggle.Text = "Create full backup";
            this.FullBackupToggle.UseVisualStyleBackColor = true;
            this.FullBackupToggle.CheckedChanged += new System.EventHandler(this.FullBackupToggle_CheckedChanged);
            // 
            // PrecedingBackupLabel
            // 
            this.PrecedingBackupLabel.AutoSize = true;
            this.PrecedingBackupLabel.Location = new System.Drawing.Point(15, 19);
            this.PrecedingBackupLabel.Name = "PrecedingBackupLabel";
            this.PrecedingBackupLabel.Size = new System.Drawing.Size(105, 15);
            this.PrecedingBackupLabel.TabIndex = 5;
            this.PrecedingBackupLabel.Text = "Preceding backup:";
            // 
            // LocationGroup
            // 
            this.LocationGroup.Controls.Add(this.BackupSourceSelect);
            this.LocationGroup.Controls.Add(this.BackupSourceLabel);
            this.LocationGroup.Controls.Add(this.BackupDestinationLabel);
            this.LocationGroup.Controls.Add(this.BackupDestinationSelect);
            this.LocationGroup.Controls.Add(this.BackupDestinationInput);
            this.LocationGroup.Controls.Add(this.BackupSourceInput);
            this.LocationGroup.Location = new System.Drawing.Point(12, 12);
            this.LocationGroup.Name = "LocationGroup";
            this.LocationGroup.Size = new System.Drawing.Size(409, 128);
            this.LocationGroup.TabIndex = 6;
            this.LocationGroup.TabStop = false;
            this.LocationGroup.Text = "Location";
            // 
            // ConfigurationGroup
            // 
            this.ConfigurationGroup.Controls.Add(this.PrecedingBackupLabel);
            this.ConfigurationGroup.Controls.Add(this.FullBackupToggle);
            this.ConfigurationGroup.Controls.Add(this.PrecedingBackupSelect);
            this.ConfigurationGroup.Enabled = false;
            this.ConfigurationGroup.Location = new System.Drawing.Point(12, 147);
            this.ConfigurationGroup.Name = "ConfigurationGroup";
            this.ConfigurationGroup.Size = new System.Drawing.Size(409, 97);
            this.ConfigurationGroup.TabIndex = 7;
            this.ConfigurationGroup.TabStop = false;
            this.ConfigurationGroup.Text = "Configuration";
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 15;
            this.LogBox.Location = new System.Drawing.Point(16, 104);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(243, 154);
            this.LogBox.TabIndex = 8;
            // 
            // CreateBackupButton
            // 
            this.CreateBackupButton.Enabled = false;
            this.CreateBackupButton.Location = new System.Drawing.Point(269, 250);
            this.CreateBackupButton.Name = "CreateBackupButton";
            this.CreateBackupButton.Size = new System.Drawing.Size(152, 33);
            this.CreateBackupButton.TabIndex = 9;
            this.CreateBackupButton.Text = "Create backup";
            this.CreateBackupButton.UseVisualStyleBackColor = true;
            this.CreateBackupButton.Click += new System.EventHandler(this.CreateBackupButton_Click);
            // 
            // BackupProgressBar
            // 
            this.BackupProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupProgressBar.Location = new System.Drawing.Point(15, 75);
            this.BackupProgressBar.Name = "BackupProgressBar";
            this.BackupProgressBar.Size = new System.Drawing.Size(243, 23);
            this.BackupProgressBar.TabIndex = 10;
            // 
            // ScanProgressBar
            // 
            this.ScanProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanProgressBar.Location = new System.Drawing.Point(15, 46);
            this.ScanProgressBar.Name = "ScanProgressBar";
            this.ScanProgressBar.Size = new System.Drawing.Size(243, 23);
            this.ScanProgressBar.TabIndex = 11;
            // 
            // StatusInformationLabel
            // 
            this.StatusInformationLabel.AutoSize = true;
            this.StatusInformationLabel.Location = new System.Drawing.Point(15, 28);
            this.StatusInformationLabel.Name = "StatusInformationLabel";
            this.StatusInformationLabel.Size = new System.Drawing.Size(16, 15);
            this.StatusInformationLabel.TabIndex = 14;
            this.StatusInformationLabel.Text = "   ";
            // 
            // ProgressGroup
            // 
            this.ProgressGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressGroup.Controls.Add(this.BackupProgressLabel);
            this.ProgressGroup.Controls.Add(this.ScanProgressLabel);
            this.ProgressGroup.Controls.Add(this.LogBox);
            this.ProgressGroup.Controls.Add(this.StatusInformationLabel);
            this.ProgressGroup.Controls.Add(this.BackupProgressBar);
            this.ProgressGroup.Controls.Add(this.ScanProgressBar);
            this.ProgressGroup.Enabled = false;
            this.ProgressGroup.Location = new System.Drawing.Point(427, 12);
            this.ProgressGroup.Name = "ProgressGroup";
            this.ProgressGroup.Size = new System.Drawing.Size(265, 271);
            this.ProgressGroup.TabIndex = 15;
            this.ProgressGroup.TabStop = false;
            this.ProgressGroup.Text = "Progress";
            // 
            // BackupProgressLabel
            // 
            this.BackupProgressLabel.AutoSize = true;
            this.BackupProgressLabel.Location = new System.Drawing.Point(26, 78);
            this.BackupProgressLabel.Name = "BackupProgressLabel";
            this.BackupProgressLabel.Size = new System.Drawing.Size(16, 15);
            this.BackupProgressLabel.TabIndex = 15;
            this.BackupProgressLabel.Text = "   ";
            // 
            // ScanProgressLabel
            // 
            this.ScanProgressLabel.AutoSize = true;
            this.ScanProgressLabel.Location = new System.Drawing.Point(26, 49);
            this.ScanProgressLabel.Name = "ScanProgressLabel";
            this.ScanProgressLabel.Size = new System.Drawing.Size(16, 15);
            this.ScanProgressLabel.TabIndex = 15;
            this.ScanProgressLabel.Text = "   ";
            // 
            // CreateBackupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 301);
            this.Controls.Add(this.ProgressGroup);
            this.Controls.Add(this.CreateBackupButton);
            this.Controls.Add(this.ConfigurationGroup);
            this.Controls.Add(this.LocationGroup);
            this.MinimumSize = new System.Drawing.Size(700, 340);
            this.Name = "CreateBackupMenu";
            this.Text = "Create Backup";
            this.LocationGroup.ResumeLayout(false);
            this.LocationGroup.PerformLayout();
            this.ConfigurationGroup.ResumeLayout(false);
            this.ConfigurationGroup.PerformLayout();
            this.ProgressGroup.ResumeLayout(false);
            this.ProgressGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackupSourceSelect;
        private System.Windows.Forms.Label BackupSourceLabel;
        private System.Windows.Forms.Label BackupDestinationLabel;
        private System.Windows.Forms.Button BackupDestinationSelect;
        private System.Windows.Forms.TextBox BackupSourceInput;
        private System.Windows.Forms.TextBox BackupDestinationInput;
        private System.Windows.Forms.ComboBox PrecedingBackupSelect;
        private System.Windows.Forms.CheckBox FullBackupToggle;
        private System.Windows.Forms.Label PrecedingBackupLabel;
        private System.Windows.Forms.GroupBox LocationGroup;
        private System.Windows.Forms.GroupBox ConfigurationGroup;
        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.Button CreateBackupButton;
        private System.Windows.Forms.ProgressBar BackupProgressBar;
        private System.Windows.Forms.ProgressBar ScanProgressBar;
        private System.Windows.Forms.Label StatusInformationLabel;
        private System.Windows.Forms.GroupBox ProgressGroup;
        private System.Windows.Forms.Label ScanProgressLabel;
        private System.Windows.Forms.Label BackupProgressLabel;
    }
}

