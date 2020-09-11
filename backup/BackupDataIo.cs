using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolderBackupTool
{
    class BackupDataIo
    {
        public static BackupData LoadDirectoryData(string path)
        {
            BackupData output = new BackupData();

            string input = File.ReadAllText(path);
            dynamic inputData = JsonConvert.DeserializeObject(input);
            var data = DeserializeData(inputData, output);

            output.Data = data;

            return output;
        }

        public static void WriteDirectoryData(DirectoryEntry directoryData, string path)
        {
            JObject preSerializedData = PreSerializeDirectoryData(directoryData);
            string serializedData = JsonConvert.SerializeObject(preSerializedData);

            File.WriteAllText(path, serializedData);
        }

        private static DirectoryEntry DeserializeData(dynamic input, BackupData backupData)
        {
            DirectoryEntry dirEntry = new DirectoryEntry();
            dirEntry.Name = input["n"];

            foreach (var file in input["f"])
            {
                var fileEntry = new FileEntry();
                fileEntry.Name = file["n"];
                fileEntry.Length = file["l"];
                fileEntry.LastWriteTime = file["lwt"];
                fileEntry.LatestVersion = file["v"];
                fileEntry.ParentDirectory = dirEntry;

                dirEntry.Files.Add(fileEntry.Name, fileEntry);
                backupData.FileCount++;
            }

            foreach (var childDir in input["d"])
            {
                DirectoryEntry childDirEntry = DeserializeData(childDir, backupData);
                childDirEntry.ParentDirectory = dirEntry;
                dirEntry.Directories.Add(childDirEntry.Name, childDirEntry);
            }

            backupData.DirectoryCount++;

            return dirEntry;
        }

        private static JObject PreSerializeDirectoryData(DirectoryEntry directoryData)
        {
            var output = new JObject();
            output["n"] = directoryData.Name;

            var files = new JArray();
            foreach (var file in directoryData.Files.Values)
            {
                var fileObject = new JObject();
                fileObject["n"] = file.Name;
                fileObject["l"] = file.Length;
                fileObject["lwt"] = file.LastWriteTime;
                fileObject["v"] = file.LatestVersion;
                files.Add(fileObject);
            }

            output["f"] = files;

            var directories = new JArray();
            foreach (var dir in directoryData.Directories.Values)
                directories.Add(PreSerializeDirectoryData(dir));

            output["d"] = directories;

            return output;
        }
    }
}
