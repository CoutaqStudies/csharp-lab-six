using System;
using System.IO;

namespace LabFive
{
    internal class TaskFour
    {
        internal static void Execute()
        {
            String path = Program.osModifier + "backup";
            if (!Directory.Exists(path))
            {
                DirectoryInfo dirBackup = Directory.CreateDirectory(path);
            }
                
        }
    }
}