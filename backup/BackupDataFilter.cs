using System;
using System.Collections.Generic;
using System.Text;

namespace FolderBackupTool
{
    class BackupDataFilter
    {
        public static List<FileEntry> CompareDirectoryData(DirectoryEntry previous, DirectoryEntry current)
        {
            var output = new List<FileEntry>();
            CompareDirectoryData(previous, current, output);

            return output;
        }

        private static List<FileEntry> CompareDirectoryData(DirectoryEntry previous, DirectoryEntry current, List<FileEntry> output)
        {
            foreach (var currentFile in current.Files.Values)
            {
                bool equal = previous.Files.ContainsKey(currentFile.Name);
                if (equal)
                {
                    FileEntry previousFile = previous.Files[currentFile.Name];
                    equal = equal &&
                        previousFile.LastWriteTime == currentFile.LastWriteTime &&
                        previousFile.Length == currentFile.Length;

                    if (equal)
                        currentFile.LatestVersion = previousFile.LatestVersion;
                }

                if (!equal)
                    output.Add(currentFile);
            }

            foreach (var currentItem in current.Directories)
            {
                var currentDirectory = currentItem.Value;
                if (previous.Directories.ContainsKey(currentDirectory.Name))
                    CompareDirectoryData(previous.Directories[currentDirectory.Name], currentDirectory, output);
                else
                    AddFiles(currentDirectory, output);
            }

            return output;
        }

        private static List<FileEntry> AddFiles(DirectoryEntry directory, List<FileEntry> output)
        {
            foreach (var currentItem in directory.Files)
            {
                output.Add(currentItem.Value);
            }

            foreach (var currentItem in directory.Directories)
                AddFiles(currentItem.Value, output);

            return output;
        }
    }
}
