using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolderBackupTool
{
    class DirectoryScan
    {
        private string ScannedDirectory;

        public DirectoryEntry ScannedData { get; private set; }

        public DirectoryScan(string scannedDirectory)
        {
            this.ScannedDirectory = scannedDirectory;
        }

        public void ScanDirectory(DirectoryScanProgressMonitor monitor = null)
        {
            var scannedData = this.ScanDirectory(this.ScannedDirectory, monitor);
            monitor?.FinishScan();
            this.ScannedData = scannedData;
        }

        private DirectoryEntry ScanDirectory(string scannedDirectory, DirectoryScanProgressMonitor monitor = null)
        {
            var dirInfo = new FileInfo(scannedDirectory);

            var dirEntry = new DirectoryEntry();
            dirEntry.Name = dirInfo.Name;

            string[] files = Directory.GetFiles(scannedDirectory);
            string[] directories = Directory.GetDirectories(scannedDirectory);

            foreach (var file in files)
            {
                try
                {
                    var fileEntry = this.ScanFile(file, monitor);
                    fileEntry.ParentDirectory = dirEntry;
                    dirEntry.Files.Add(fileEntry.Name, fileEntry);
                }
                catch (Exception e)
                {
                    monitor?.AddError(file, e, dirEntry);
                }
            }

            monitor?.Descent(directories.Length);

            foreach (var dir in directories)
            {
                try
                {
                    var childDirectoryEntry = this.ScanDirectory(dir, monitor);
                    childDirectoryEntry.ParentDirectory = dirEntry;
                    dirEntry.Directories.Add(childDirectoryEntry.Name, childDirectoryEntry);
                }
                catch (Exception e)
                {
                    monitor?.AddError(dir, e, dirEntry);
                }
            }

            monitor?.Ascend(directories.Length);

            return dirEntry;
        }

        private FileEntry ScanFile(string scannedFile, DirectoryScanProgressMonitor monitor = null)
        {
            var fileInfo = new FileInfo(scannedFile);
            var fileEntry = new FileEntry();

            fileEntry.Name = fileInfo.Name;
            fileEntry.Path = fileInfo.FullName;
            fileEntry.LastWriteTime = fileInfo.LastWriteTimeUtc;
            fileEntry.Length = fileInfo.Length;

            monitor?.ScanFile(fileInfo.FullName);

            return fileEntry;
        }
    }
}
