using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderBackupTool.gui
{
    public partial class RestoreBackupMenu : Form
    {
        public RestoreBackupMenu()
        {
            InitializeComponent();
        }

        private void BackupsLocationSelect_Click(object sender, EventArgs e)
        {
            var selectionDialog = new FolderBrowserDialog();

            if (selectionDialog.ShowDialog() == DialogResult.OK)
                this.BackupsLocationInput.Text = selectionDialog.SelectedPath;
        }

        private void RestorationLocationSelect_Click(object sender, EventArgs e)
        {
            var selectionDialog = new FolderBrowserDialog();

            if (selectionDialog.ShowDialog() == DialogResult.OK)
                this.RestorationLocationInput.Text = selectionDialog.SelectedPath;
        }

        private void BackupsLocationInput_TextChanged(object sender, EventArgs e)
        {
            this.RestoreButton.Enabled = false;
            this.BackupSelect.Enabled = false;
            this.BackupSelect.Items.Clear();

            var backupsLocation = this.BackupsLocationInput.Text;

            new Task(() => 
            {
                if (!string.IsNullOrEmpty(backupsLocation) &&
                    Directory.Exists(backupsLocation))
                {
                    var existingBackups = Directory.GetDirectories(backupsLocation);
                    foreach (var backupDirectory in existingBackups)
                    {
                        if (File.Exists(Path.Combine(backupDirectory, BackupProcess.BackupDataFilename)))
                        {
                            var backupDirectoryInfo = new DirectoryInfo(backupDirectory);
                            this.BackupSelect.Items.Add(backupDirectoryInfo.Name);
                        }
                    }

                    this.BackupSelect.Enabled = true;
                }

                this.UpdateRestoreBackupButton();

            }).Start();
        }

        private void UpdateRestoreBackupButton()
        {
            var backupsLocation = this.BackupsLocationInput.Text;
            var restorationLocation = this.RestorationLocationInput.Text;
            var selectedBackup = (string)this.BackupSelect.SelectedItem;

            bool enableRestoreButton = !string.IsNullOrEmpty(backupsLocation) &&
                !string.IsNullOrEmpty(restorationLocation) &&
                !string.IsNullOrEmpty(selectedBackup) &&
                Directory.Exists(backupsLocation) &&
                Directory.Exists(restorationLocation);

            this.RestoreButton.Enabled = enableRestoreButton;

        }

        private void RestorationLocationInput_TextChanged(object sender, EventArgs e)
        {
            this.UpdateRestoreBackupButton();
        }

        private void BackupSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateRestoreBackupButton();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            this.RestoreBackup();
        }

        private void RestoreBackup()
        {
            this.RestoreButton.Enabled = false;
            this.LocationGroup.Enabled = false;
            this.ProgressGroup.Enabled = true;

            var backupsLocation = this.BackupsLocationInput.Text;
            var restorationLocation = this.RestorationLocationInput.Text;
            var restoredBackupName = (string) this.BackupSelect.SelectedItem;

            var restorationProcess = new BackupRestorationProcess(backupsLocation, restoredBackupName, restorationLocation);
            var restorationMonitor = new RestorationProgressMonitor();

            restorationMonitor.ErrorReceived += (inputPath, outputPath, error, directory) =>
                this.Log($"Could not copy \"{inputPath}\" to \"{outputPath}\": {error.GetType()}");

            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (a, b) =>
            {
                this.RestorationProgressLabel.Text = restorationMonitor.LastRestored;
                this.RestorationProgressBar.Value = (int) restorationMonitor.FilesRestored;
            };
            timer.Start();

            new Task(() =>
            {
                try
                {
                    this.Log($"Restoring backup \"{restoredBackupName}\"...");
                    this.Log("Loading backup data...");

                    this.StatusInformationLabel.Text = "Loading backup data...";

                    restorationProcess.LoadBackupData();

                    this.Log($"Restoring {restorationProcess.FilesToRestore} files, {restorationProcess.DirectoriesToRestore} directories");
                    this.Log("Restoring files...");

                    this.StatusInformationLabel.Text = "Restoring files...";
                    this.RestorationProgressBar.Maximum = (int) restorationProcess.FilesToRestore;

                    restorationProcess.RestoreBackup(restorationMonitor);

                    this.Log($"{restorationMonitor.FilesRestored} files restored");
                    this.Log($"Restored backup {restoredBackupName}");
                    this.StatusInformationLabel.Text = "Done.";

                    this.RestorationProgressLabel.Text = "";
                    this.RestorationProgressBar.Value = this.RestorationProgressBar.Maximum;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
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
