using System;
using System.Collections.Generic;

namespace LabFive
{
    internal class TaskTwo
    {
        internal static void Execute()
        {
            int startNum = 4;
            int step = 7;
            int[] prog = new int[15];
            for (int i = 0; i < prog.Length; i++){
                prog[i] = startNum + (step * i);
            }
            String file = "";
            foreach(int i in prog)
            {
                file += i + "\n";
            }
            file = file.Trim();
            System.IO.File.WriteAllText(@".\prog.dat", ConsoleApp.StringToBinary(file));
            ReadProg();
        }
        private static void ReadProg()
        {
            String data = System.IO.File.ReadAllText(@".\prog.dat");
            data = ConsoleApp.BinaryToString(data);
            List<int> prog = new List<int>();
            foreach (String line in data.Split("\n"))
            {
                prog.Add(int.Parse(line));
            }
            String file = prog[4] + "\n" + prog[5];
            Console.WriteLine(file);
            System.IO.File.WriteAllText(@".\newprog.dat", ConsoleApp.StringToBinary(file));
        }
    }
}