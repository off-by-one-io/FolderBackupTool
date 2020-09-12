using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderBackupTool
{
    public partial class CreateBackupMenu : Form
    {
        public CreateBackupMenu()
        {
            InitializeComponent();
        }

        private void BackupSourceSelect_Click(object sender, EventArgs e)
        {
            var selectionDialog = new FolderBrowserDialog();

            if (selectionDialog.ShowDialog() == DialogResult.OK)
                this.BackupSourceInput.Text = selectionDialog.SelectedPath;
        }

        private void BackupDestinationSelect_Click(object sender, EventArgs e)
        {
            var selectionDialog = new FolderBrowserDialog();

            if (selectionDialog.ShowDialog() == DialogResult.OK)
                this.BackupDestinationInput.Text = selectionDialog.SelectedPath;
        }

        private void BackupSourceInput_TextChanged(object sender, EventArgs e)
        {
            this.UpdateConfigurationGroup();
        }

        private void BackupDestinationInput_TextChanged(object sender, EventArgs e)
        {
            this.UpdateConfigurationGroup();
        }

        private void UpdateConfigurationGroup()
        {
            string backupSource = this.BackupSourceInput.Text;
            string backupDest = this.BackupDestinationInput.Text;

            this.ConfigurationGroup.Enabled = false;
            this.CreateBackupButton.Enabled = false;

            this.PrecedingBackupSelect.Items.Clear();
            this.FullBackupToggle.Checked = false;

            new Task(() => 
            {
                if (!string.IsNullOrEmpty(backupSource) &&
                    !string.IsNullOrEmpty(backupDest) &&
                    Directory.Exists(backupSource) &&
                    Directory.Exists(backupDest))
                {
                    var existingBackups = Directory.GetDirectories(backupDest);
                    foreach (var backupDirectory in existingBackups)
                    {
                        if (File.Exists(Path.Combine(backupDirectory, BackupProcess.BackupDataFilename)))
                        {
                            var backupDirectoryInfo = new DirectoryInfo(backupDirectory);
                            this.PrecedingBackupSelect.Items.Add(backupDirectoryInfo.Name);
                        }
                    }

                    if (this.PrecedingBackupSelect.Items.Count > 0)
                    {
                        this.ConfigurationGroup.Enabled = true;
                        this.FullBackupToggle.Checked = false;
                    }
                    else
                    {
                        this.FullBackupToggle.Checked = true;
                        this.CreateBackupButton.Enabled = true;
                    }
                }
            }).Start();
            
        }

        private void PrecedingBackupSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateCreateBackupButton();
        }

        private void FullBackupToggle_CheckedChanged(object sender, EventArgs e)
        {
            this.PrecedingBackupSelect.Enabled = !this.FullBackupToggle.Checked;
            UpdateCreateBackupButton();
        }

        private void UpdateCreateBackupButton()
        {
            bool choiceMade = this.FullBackupToggle.Checked || !string.IsNullOrEmpty((string)this.PrecedingBackupSelect.SelectedItem);
            this.CreateBackupButton.Enabled = choiceMade;
        }

        private void CreateBackupButton_Click(object sender, EventArgs e)
        {
            this.CreateBackup();
        }

        private void CreateBackup()
        {
            this.LocationGroup.Enabled = false;
            this.ConfigurationGroup.Enabled = false;
            this.CreateBackupButton.Enabled = false;

            this.ProgressGroup.Enabled = true;

            var sourceDirectory = this.BackupSourceInput.Text;
            var destinationDirectory = this.BackupDestinationInput.Text;
            var backupProcess = new BackupProcess(sourceDirectory, destinationDirectory);

            var precedingBackupName = (string) this.PrecedingBackupSelect.SelectedItem;
            var backupName = DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ssZ");

            var scanMonitor = new DirectoryScanProgressMonitor();
            var backupMonitor = new BackupProgressMonitor();

            scanMonitor.ErrorReceived += (path, error, directory) => 
                this.Log($"Could not scan path \"{path}\": {error.GetType()}");

            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (a, b) =>
            {
                this.ScanProgressLabel.Text = scanMonitor.LastScanned;
                this.ScanProgressBar.Value = (int)(scanMonitor.Progress * this.ScanProgressBar.Maximum);

                this.BackupProgressLabel.Text = backupMonitor.LastCopied;
                this.BackupProgressBar.Value = (int) backupMonitor.FilesCopied;
            };
            timer.Start();

            new Task(() => 
            {
                try
                {
                    this.Log("Scanning source directory...");
                    this.StatusInformationLabel.Text = "Scanning source directory...";
                    backupProcess.LoadSourceData(scanMonitor);
                    this.ScanProgressBar.Value = this.ScanProgressBar.Maximum;
                    this.ScanProgressLabel.Text = "";
                    this.Log($"Found {scanMonitor.FilesScanned} files, {scanMonitor.FoldersScanned} directories");

                    if (this.FullBackupToggle.Checked)
                        backupProcess.UseEmptyReferenceData();
                    else
                    {
                        this.Log("Loading preceding backup...");
                        this.StatusInformationLabel.Text = "Loading preceding backup...";
                        var referenceBackupDataFile = Path.Combine(destinationDirectory, precedingBackupName, BackupProcess.BackupDataFilename);
                        backupProcess.LoadReferenceData(referenceBackupDataFile);
                    }

                    this.Log("Preparing backup data...");
                    this.StatusInformationLabel.Text = "Preparing backup data...";
                    backupProcess.ProcessDataDifference();

                    this.Log($"Detected {backupProcess.DetectedFileChanges} changed files");
                    this.Log("Writing backup data...");
                    this.StatusInformationLabel.Text = "Writing backup data...";
                    this.BackupProgressBar.Maximum = (int) backupProcess.DetectedFileChanges + 1;
                    backupProcess.CreateBackup(backupName, backupMonitor);
                    this.BackupProgressLabel.Text = "";

                    this.Log($"{backupMonitor.FilesCopied} files created");
                    this.Log($"Created backup \"{backupName}\"");
                    this.StatusInformationLabel.Text = "Done.";
                }
                catch(Exception e)
                {
                    this.LogBox.Enabled = false;
                }

                timer.Stop();
                timer.Dispose();
            }).Start();

        }

        private void Log(string logEntry)
        {
            this.LogBox.Items.Add(logEntry);
        }

    }
}
