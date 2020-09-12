using System;
using System.IO;

namespace FolderBackupTool
{
    class BackupRestorationProcess
    {
        private string BackupsDirectory;
        private string BackupToRestore;
        private string OutputDirectory;

        private BackupData DataToRestore;

        public long FilesToRestore { get => this.DataToRestore == null ? 0 : this.DataToRestore.FileCount; }
        public long DirectoriesToRestore { get => this.DataToRestore == null ? 0 : this.DataToRestore.DirectoryCount; }

        public BackupRestorationProcess(string backupsDirectory, string backupToRestore, string outputDirectory)
        {
            this.BackupsDirectory = backupsDirectory;
            this.BackupToRestore = backupToRestore;
            this.OutputDirectory = outputDirectory;
        }

        public void LoadBackupData()
        {
            var dataFilePath = Path.Combine(this.BackupsDirectory, this.BackupToRestore, BackupProcess.BackupDataFilename);

            this.DataToRestore = BackupDataIo.LoadDirectoryData(dataFilePath);
        }

        public void RestoreBackup(RestorationProgressMonitor monitor = null)
        {
            if (this.DataToRestore == null)
                throw new InvalidOperationException("No data has been loaded");

            this.RestoreDirectory(this.DataToRestore.Data, this.OutputDirectory, monitor);
        }

        private void RestoreDirectory(DirectoryEntry directory, string outputDirectory, RestorationProgressMonitor monitor = null)
        {
            try
            {
                Directory.CreateDirectory(outputDirectory);
            }
            catch(Exception e)
            {
                monitor?.AddError(directory.Name, outputDirectory, e, directory);
            }
            
            foreach (var file in directory.Files.Values)
            {
                var relativeFilePath = Path.Combine(DirectoryEntry.GetPath(file.ParentDirectory), file.Name);
                var inputFilePath = Path.Combine(this.BackupsDirectory, file.LatestVersion, relativeFilePath);
                var outputFilePath = Path.Combine(outputDirectory, file.Name);

                try
                {
                    File.Copy(inputFilePath, outputFilePath);

                    monitor?.RestoreFile(outputFilePath);
                }
                catch(Exception e)
                {
                    monitor?.AddError(inputFilePath, outputFilePath, e, directory);
                }
            }

            foreach (var childDir in directory.Directories.Values)
            {
                this.RestoreDirectory(childDir, Path.Combine(outputDirectory, childDir.Name), monitor);
            }

        }
    }
}
