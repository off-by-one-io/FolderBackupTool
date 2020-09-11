using System;
using System.Collections.Generic;
using System.Text;

namespace FolderBackupTool
{
    class FileEntry
    {
        public string Name;
        public string Path;
        public DirectoryEntry ParentDirectory;
        public DateTime LastWriteTime;
        public long Length;
        public string LatestVersion;
    }
}
