using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkingWithDrives();
            //WorkWithDirectories();
            WorkWithFiles();
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0, -33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0, -33} {1}", "Path.PathDirectoryChar", DirectorySeparatorChar);
            WriteLine("{0, -33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
            WriteLine("{0, -33} {1}", "Environment.CurrentDirectory", CurrentDirectory);
            WriteLine("{0, -33} {1}", "Environment.SystemDirectory", SystemDirectory);
            WriteLine("{0, -33} {1}", "Path.GetTempPath()", GetTempPath());
            WriteLine("GetFolderPath(Special Folder)");
            WriteLine("{0, -33} {1}", ".System", GetFolderPath(SpecialFolder.System));
            WriteLine("{0, -33} {1}", ".ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0, -33} {1}", ".MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0, -33} {1}", ".Personal", GetFolderPath(SpecialFolder.Personal));
        }

        static void WorkingWithDrives()
        {
            WriteLine("{0,-30} | {1, -10} | {2, -7} | {3, 18} | {4, 18}",
            "NAME", "TYPE", "FORMAT", "SIZE (Bytes)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if(drive.IsReady)
                {
                    WriteLine("{0,-30} | {1, -10} | {2, -7} | {3, 18} | {4, 18}",
                    drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0, -30} | {1, -10}", drive.Name, drive.DriveType);
                }
            }
        }

        static void WorkWithDirectories()
        {
            // Using path combine
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "LS06", "New Folder");
            WriteLine($"Working with : {newFolder}");
            // check if exists
            WriteLine($"Does it exists? {Exists(newFolder)}");
            // create new folder
            CreateDirectory(newFolder);
            WriteLine($"Does it exists? {Exists(newFolder)}");
            WriteLine("Confirm that exists and press enter: ");
            ReadLine();
            WriteLine("Deteleting it");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exists? {Exists(newFolder)}");
        }

        static void WorkWithFiles()
        {
            // define directory
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "LS06", "OutputFiles");
            CreateDirectory(dir);
            // combine file and path
            string textFile = Combine(dir, "BeeSting.txt");
            string backupFile = Combine(dir, "BackUpBee.bak");
            WriteLine($"Working with {textFile}");
            // Check if file exists
            WriteLine($"Does it exists? {File.Exists(textFile)}");
            // Write into the file
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello mah friend bee");
            textWriter.Close();
            
            WriteLine($"Does it exists? {File.Exists(textFile)}");
            // Copy the data to the .bak
            File.Copy(sourceFileName: textFile, destFileName:backupFile);
            WriteLine($"Does it exists? {File.Exists(backupFile)}");
            WriteLine("Confirm that exists and press enter: ");
            ReadLine();
            // delete a file
            // File.Delete(textFile);
            // WriteLine($"Does it exists? {File.Exists(textFile)}");
            // Read from file
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // Getting parts of a path
            WriteLine($"Folder Name : {GetDirectoryName(textFile)}");
            WriteLine($"File Name : {GetFileName(textFile)}");
            WriteLine($"File Name Without Extension : {GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension : {GetExtension(textFile)}");
            WriteLine($"Random File Name : {GetRandomFileName()}");
            WriteLine($"Temporary File Name : {GetTempFileName()}");

            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile} : ");
            WriteLine($"Contains {info.Length} bytes");
            WriteLine($"Last accesed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");

            FileStream file = File.Open(backupFile,FileMode.Open, FileAccess.Read, FileShare.Read);
            var info2 = new FileInfo(backupFile);
            // check if compressed
            WriteLine($"Is the backup file compressed? {info2.Attributes.HasFlag(FileAttributes.Compressed)}");
        }
    }
}
