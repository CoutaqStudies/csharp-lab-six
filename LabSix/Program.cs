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
            ConsoleApp.Execute(countries, log);
        }
    }
}
