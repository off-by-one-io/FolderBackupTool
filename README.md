# IncrementalFolderBackupTool

## Disclaimer

This project was haphazardly cobbled together over a few days. It was never intended to be used by another person. Use at your own risk.

## Concept

The software is supposed to perform basic "copy folder"-type file backups with the additional benefit of supporting incremental backups.
This allows having an actual backup history without wasting storage space on mostly identical data.

Backups are generated as subdirectories of a single backups folder. 
Each subfolder contains only the file changes that happened since the preceding increment as well as a data file.
This data file keeps track of which files are part of the current increment as well as which backup subfolder contains their most recent version.

## Usage

There are two intentional ways to use this software: via GUI or via command line.

### CLI

```
IncrementalFolderBackupTool.exe backup <source> <backups_directory> [options]

Options:
-p <preceding_backup_id>
-n <backup_id_to_create>
```

```
IncrementalFolderBackupTool.exe restore <backups_directory> <backup_name> <destination>
```

