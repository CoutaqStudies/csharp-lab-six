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
            if (!System.Environment.OSVersion.ToString().Contains("Unix"))
                osModifier = @".\";
            List<GeographicalUnit> countries = new List<GeographicalUnit>();
            List<LogEntry> log = new List<LogEntry>();
            ConsoleApp.Start(countries, log);

        }
    }
}
