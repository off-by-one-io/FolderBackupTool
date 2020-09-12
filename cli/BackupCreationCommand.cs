using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FolderBackupTool
{
    class BackupCreationCommand
    {
        public static void Execute(string[] args)
        {
            if (args.Length < 3)
            {
                Console.Error.WriteLine("Usage: backup <source> <destination> [options]");
                return;
            }

            string source = args[1];
            string destination = args[2];
            string name = null;
            string preceding = null;

            for (int i = 3; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-p":
                        if (args.Length > i + 1)
                            preceding = args[i + 1];
                        i++;
                        break;
                    case "-n":
                        if (args.Length > i + 1)
                            name = args[i + 1];
                        i++;
                        break;
                    default:
                        Console.Error.WriteLine($"Unknown parameter \"{args[i]}\"");
                        return;
                }
            }

            if (string.IsNullOrEmpty(name))
                name = DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ssZ");

            var parameterError = GetParameterError(source, destination, preceding, name);
            if (parameterError != null)
            {
                Console.Error.WriteLine(parameterError);
                return;
            }

            CreateBackup(source, destination, name, preceding);
        }

        private enum StatusDisplayState
        {
            ScanningSourceData,
            LoadingReferenceData,
            PreparingBackupData,
            WritingBackupData,
            Done
        }

        private static string GetParameterError(string sourceDirectory, string destinationDirectory, string precedingBackup, string backupName)
        {
            if (string.IsNullOrEmpty(sourceDirectory))
                return "Must provide a source directory";

            if (string.IsNullOrEmpty(destinationDirectory))
                return "Must provide a destination directory";

            if (!Directory.Exists(sourceDirectory))
                return $"Directory does not exist: {sourceDirectory}";

            if (!Directory.Exists(destinationDirectory))
                return $"Directory does not exist: {destinationDirectory}";


            if (!string.IsNullOrEmpty(precedingBackup))
            {
                var precedingBackupFile = Path.Combine(destinationDirectory, precedingBackup, BackupProcess.BackupDataFilename);
                if (!File.Exists(precedingBackupFile))
                    return $"Preceding backup does not exist: {precedingBackup}";
            }

            var backupPath = Path.Combine(destinationDirectory, backupName);
            if (Directory.Exists(backupPath))
                return $"Backup ID already exists: {backupName}";

            return null;
        }


        private static void CreateBackup(string backupSource, string backupsDestination, string backupId, string precedingBackupId)
        {

            var backupProcess = new BackupProcess(backupSource, backupsDestination);

            var scanMonitor = new DirectoryScanProgressMonitor();
            var backupMonitor = new BackupProgressMonitor();

            var errors = new Queue<string>();
            scanMonitor.ErrorReceived += (path, error, directory) =>
                errors.Enqueue($"Could not scan path \"{path}\": {error.GetType()}");

            var backupState = StatusDisplayState.LoadingReferenceData;

            var loggerTask = new Task(() => 
            {
                Console.WriteLine(string.IsNullOrEmpty(precedingBackupId) ? "Creating full backup..." : "Loading preceding backup...");
                while (backupState == StatusDisplayState.LoadingReferenceData) ;

                Console.WriteLine("Scanning source directory...");
                while (backupState == StatusDisplayState.ScanningSourceData)
                {
                    CommandLineExecution.RewindConsole();

                    while (errors.Count > 0)
                        Console.Error.WriteLine(errors.Dequeue());

                    Console.Write($"{scanMonitor.FilesScanned} files, {scanMonitor.FoldersScanned} directories found...");
                    Thread.Sleep(20);
                }
                CommandLineExecution.RewindConsole();
                Console.WriteLine($"{scanMonitor.FilesScanned} files, {scanMonitor.FoldersScanned} directories found");

                Console.WriteLine("Preparing backup data...");
                while (backupState == StatusDisplayState.PreparingBackupData) ;
                Console.WriteLine($"Detected {backupProcess.DetectedFileChanges} changed files");

                Console.WriteLine("Writing backup data...");

                while (backupState == StatusDisplayState.WritingBackupData)
                {
                    CommandLineExecution.RewindConsole();
                    Console.Write($"({backupMonitor.FilesCopied} / {backupProcess.DetectedFileChanges + 1}) {backupMonitor.LastCopied}");
                    Thread.Sleep(20);
                }

                CommandLineExecution.RewindConsole();
                Console.WriteLine($"{backupMonitor.FilesCopied} files created");
                Console.WriteLine($"Created backup {backupId}");
            });

            loggerTask.Start();

            try
            {
                if (string.IsNullOrEmpty(precedingBackupId))
                    backupProcess.UseEmptyReferenceData();
                else
                {
                    var referenceBackupDataFile = Path.Join(backupsDestination, precedingBackupId, BackupProcess.BackupDataFilename);
                    backupProcess.LoadReferenceData(referenceBackupDataFile);
                }

                backupState = StatusDisplayState.ScanningSourceData;
                backupProcess.LoadSourceData(scanMonitor);

                backupState = StatusDisplayState.PreparingBackupData;
                backupProcess.ProcessDataDifference();

                backupState = StatusDisplayState.WritingBackupData;
                backupProcess.CreateBackup(backupId, backupMonitor);

                backupState = StatusDisplayState.Done;
                loggerTask.Wait();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Environment.Exit(1);
            }

        }

    }

}
