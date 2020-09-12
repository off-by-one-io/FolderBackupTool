using System;
using System.Collections.Generic;
using System.Text;

namespace FolderBackupTool
{
    class BackupProgressMonitor
    {
        public long FilesCopied { get; private set; } = 0;
        public string LastCopied { get; private set; } = "";
        
        public void CopyFile(string path)
        {
            this.LastCopied = path;
            this.FilesCopied++;
        }

        public void Finish()
        {
            this.LastCopied = "";
        }
    }
}
