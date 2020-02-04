using System;
using System.Collections.Generic;
using LabOne;

namespace LabFive
{
    public class Program
    {
        public static String osModifier;
        public static void Main(string[] args)
        {
            List<GeographicalUnit> countries = new List<GeographicalUnit>();
            List<LogEntry> log = new List<LogEntry>();
            //ConsoleApp.Start(countries, log);
            //TaskTwo.Execute();
            //TaskThree.Execute();
            if (System.Environment.OSVersion.ToString().Contains("Unix")) {
                osModifier = @"/bin/Debug/netcoreapp3.0/";
                Console.WriteLine("not windows");
            }
            else
                osModifier = @".\";
            TaskThree.Execute();
            //Console.WriteLine(System.Environment.OSVersion);
        }
    }
}
