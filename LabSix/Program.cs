using System;
using System.Collections.Generic;
using LabOne;

namespace LabFive
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<GeographicalUnit> countries = new List<GeographicalUnit>();
            List<LogEntry> log = new List<LogEntry>();
            //ConsoleApp.Start(countries, log);
            //TaskTwo.Execute();
            //TaskThree.Execute();
            Console.WriteLine();
            String osModifier = "";
            if (System.Environment.OSVersion.ToString().Contains("Unix"))
            {
                osModifier = @".\";
            }
            else
            {

            }
        }
    }
}
