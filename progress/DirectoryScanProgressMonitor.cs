using System;
using System.Collections.Generic;
using System.Text;

namespace FolderBackupTool
{
    class DirectoryScanProgressMonitor
    {
        private double incrementPerFolder = 1;
        public double Progress { get; private set; } = 0;

        public long FilesScanned { get; private set; } = 0;
        public long FoldersScanned { get; private set; } = 0;
        public string LastScanned { get; private set; } = "";

        public event ErrorEventHandler ErrorReceived;

        public void Descent(int folderCount)
        {
            this.incrementPerFolder /= (folderCount > 0 ? folderCount : 1);
        }

        public void Ascend(int folderCount)
        {
            if(folderCount == 0)
                this.Progress += this.incrementPerFolder;
            this.incrementPerFolder *= (folderCount > 0 ? folderCount : 1);
            this.FoldersScanned++;
        }

        public void FinishScan()
        {
            this.Progress = 1;
            this.LastScanned = "";
        }

        public void ScanFile(string path)
        {
            this.LastScanned = path;
            this.FilesScanned++;
        }

        public void AddError(string path, Exception error, DirectoryEntry parentDirectory)
        {
            ErrorEventHandler errorEventHandler = ErrorReceived;
            errorEventHandler?.Invoke(path, error, parentDirectory);
        }

        public delegate void ErrorEventHandler(string path, Exception error, DirectoryEntry parentDirectory);

    }
}
