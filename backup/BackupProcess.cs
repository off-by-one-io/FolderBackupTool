using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FolderBackupTool
{
    class BackupProcess
    {
        public static readonly string BackupDataFilename = "backup_data.json";

        private string SourceDirectory;
        private string BackupsDirectory;

        public DirectoryScan SourceDataScan { get; private set; }
        private DirectoryEntry ReferenceData;

        private List<FileEntry> DataDiff;

        public long DetectedFileChanges
        {
            get => this.DataDiff == null ? 0 : this.DataDiff.Count;
        }

        public BackupProcess(string sourceDirectory, string backupsDirectory)
        {
            this.SourceDirectory = sourceDirectory;
            this.BackupsDirectory = backupsDirectory;
        }

        public void LoadSourceData(DirectoryScanProgressMonitor monitor)
        {
            this.SourceDataScan = new DirectoryScan(this.SourceDirectory);
            this.SourceDataScan.ScanDirectory(monitor);
        }

        public void LoadReferenceData(string referenceBackupId)
        {
            string referenceBackupPath = Path.Combine(this.BackupsDirectory, referenceBackupId);
            var directoryData = BackupDataIo.LoadDirectoryData(referenceBackupPath);

            this.ReferenceData = directoryData.Data;
        }

        public void UseEmptyReferenceData()
        {
            this.ReferenceData = new DirectoryEntry();
        }

        public void ProcessDataDifference()
        {
            if (this.SourceDataScan == null)
                throw new InvalidOperationException("No source data provided");

            if (this.ReferenceData == null)
                throw new InvalidOperationException("No reference data provided");

            var diff = BackupDataFilter.CompareDirectoryData(this.ReferenceData, this.SourceDataScan.ScannedData);
            this.DataDiff = diff;
        }

        public void CreateBackup(string backupId, BackupProgressMonitor monitor = null)
        {
            if (this.DataDiff == null)
                throw new InvalidOperationException("Data difference unknown");

            string outputRootDir = Path.Combine(this.BackupsDirectory, backupId);
            Directory.CreateDirectory(outputRootDir);

            foreach (var file in this.DataDiff)
            {
                var outputDir = Path.Combine(outputRootDir, DirectoryEntry.GetPath(file.ParentDirectory));
                var outputPath = Path.Combine(outputDir, file.Name);

                Directory.CreateDirectory(outputDir);
                File.Copy(file.Path, outputPath);

                monitor?.CopyFile(file.Path);
            }

            foreach (var file in this.DataDiff)
                file.LatestVersion = backupId;

            monitor?.CopyFile(BackupProcess.BackupDataFilename);

            string backupDataFilePath = Path.Combine(outputRootDir, BackupProcess.BackupDataFilename);
            BackupDataIo.WriteDirectoryData(this.SourceDataScan.ScannedData, backupDataFilePath);

            monitor?.Finish();
        }
    }
}
