﻿using System;
using System.Linq;

namespace LabFive
{
    internal class TaskThree
    {
        internal static void Execute()
        {
            String data = System.IO.File.ReadAllText(@".\TaskTwo.txt");
            String[] lines = data.Split("\n");
            String file = "";
            int count = 0;
            foreach(String line in lines)
            {
                if (line.Any(char.IsDigit))
                {
                    count++;
                    file += line + "\n";
                }
            }
            Console.WriteLine("Removed "+(lines.Length - count)+" lines.");
            System.IO.File.WriteAllText(@".\TaskTwoOutput.txt",file.Trim());
        }
    }
}