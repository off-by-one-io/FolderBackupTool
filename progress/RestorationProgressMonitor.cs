using System;
using System.Collections.Generic;
using System.Text;

namespace FolderBackupTool.progress
{
    class RestorationProgressMonitor
    {
        public long FilesRestored { get; private set; } = 0;
        public string LastRestored { get; private set; } = "";

        public event ErrorEventHandler ErrorReceived;

        public void RestoreFile(string path)
        {
            this.LastRestored = path;
            this.FilesRestored++;
        }

        public void AddError(string inputPath, string outputPath, Exception error, DirectoryEntry parentDirectory)
        {
            ErrorEventHandler errorEventHandler = ErrorReceived;
            errorEventHandler?.Invoke(inputPath, outputPath, error, parentDirectory);
        }

        public delegate void ErrorEventHandler(string inputPath, string outputPath, Exception error, DirectoryEntry parentDirectory);

    }
}
