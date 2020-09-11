using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Text;

namespace FolderBackupTool
{
    class DirectoryEntry
    {
        public string Name;
        public DirectoryEntry ParentDirectory;
        public Dictionary<string, DirectoryEntry> Directories = new Dictionary<string, DirectoryEntry>();
        public Dictionary<string, FileEntry> Files = new Dictionary<string, FileEntry>();

        public static string GetPath(DirectoryEntry dir)
        {
            if (dir.ParentDirectory == null)
                return "";
            else
                return Path.Combine(GetPath(dir.ParentDirectory), dir.Name);
        }
    }
}
