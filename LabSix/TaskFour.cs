using System;
using System.IO;

namespace LabFive
{
    internal class TaskFour
    {
        internal static void Execute()
        {
            String dirPath = Program.osModifier + "backup";
            String dataPath = Program.osModifier + @"lab.dat";
            if (!Directory.Exists(dirPath))
            {
                DirectoryInfo dirBackup = Directory.CreateDirectory(dirPath);
            }
            //File.Copy(dataPath, dirPath+@"/lab_backup.dat");   not complicated enough
            FileStream fileToCopy = new FileStream(dataPath, FileMode.Open);
            FileStream fileToSave = new FileStream(dirPath + @"/lab_backup.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileToCopy.CopyTo(fileToSave);
            fileToSave.Close();
            Console.WriteLine("Size: " + fileToCopy.Length + " bytes.");
            Console.WriteLine("Last access: " + File.GetLastAccessTime(dataPath) + ".");
            Console.WriteLine("Last modified: " + File.GetLastWriteTime(dataPath) + ".");
        }
    }
}