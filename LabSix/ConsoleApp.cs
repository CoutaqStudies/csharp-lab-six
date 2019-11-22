using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LabOne;

namespace LabFive
{
    public class ConsoleApp
    {
        
        public static void Execute(List<GeographicalUnit> countries, List<LogEntry> log) 
        {
            String prompt = "1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход";
            Console.WriteLine(prompt);
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Execute(countries,log);
            }
            switch (input)
            {
                case 1:
                    String output = "\n--------------------------------------\n";
                     if (countries.Count==0)
                         output = ("The list is empty!");
                     else
                     {
                         foreach (GeographicalUnit country in countries)
                             output += country.getInfoTable();
                     }
                    Console.WriteLine(output);
                    Execute(countries,log);
                    break;
                case 2:
                        Console.Write("Please enter the country: ");
                        string name = Console.ReadLine();
                        Console.Write("Please enter the capital: ");
                        string capital = Console.ReadLine();
                        int population = 0;
                        while (true)
                        {
                            try
                            {
                                Console.Write("Please enter the population: ");
                                population = int.Parse(Console.ReadLine());
                                if (population < 0)
                                {
                                    throw new FormatException();
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.Write("Incorrect input, try again: ");
                            }
                        }
                        string formString = "";
                        string upperString = "";
                        GeographicalUnit.FormOfGov form;
                        while (true)
                        {
                            try
                            {
                                Console.Write("Please enter the form of government: ");
                                formString = Console.ReadLine();
                                upperString = (formString.ToUpper()).ToString();
                                if (upperString != "US" && upperString != "F")
                                {
                                    throw new FormatException();
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.Write("Incorrect input, try again: ");
                            }
                        }
                        form = (GeographicalUnit.FormOfGov)Enum.Parse(typeof(GeographicalUnit.FormOfGov), upperString);
                    countries.Add(new GeographicalUnit(name, capital, population, form ));
                    Console.WriteLine($"Added {name} to the list.");
                    log = addEntry(new LogEntry(name, LogEntry.Action.ADD), log);
                    Execute(countries,log);
                    break;
                case 3:
                    int entry = 0;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Which entry do you want to remove? ");
                            entry = int.Parse(Console.ReadLine());
                            if (entry > countries.Count || entry < 1)
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }

                    Console.WriteLine($"Removed {countries[entry-1].getName()} from the list.");
                    log = addEntry(new LogEntry(countries[entry - 1].getName(), LogEntry.Action.DELETE), log);
                    countries.RemoveAt(entry - 1);
                    Execute(countries,log);
                    break;
                case 4:
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Which entry do you want to update? ");
                            entry = int.Parse(Console.ReadLine());
                            if (entry > countries.Count || entry < 1)
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    Console.Write("Please enter the country: ");
                    name = Console.ReadLine();
                    Console.Write("Please enter the capital: ");
                    capital = Console.ReadLine();
                    while (true)
                    {
                        try
                        {
                            Console.Write("Please enter the population: ");
                            population = int.Parse(Console.ReadLine());
                            if (population < 0)
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    while (true)
                    {
                        try
                        {
                            Console.Write("Please enter the form of government: ");
                            formString = Console.ReadLine();
                            upperString = (formString.ToUpper()).ToString();
                            if (upperString != "US" && upperString != "F")
                            {
                                throw new FormatException();
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Write("Incorrect input, try again: ");
                        }
                    }
                    form = (GeographicalUnit.FormOfGov)Enum.Parse(typeof(GeographicalUnit.FormOfGov), upperString);
                    Console.WriteLine($"Updated {name}.");
                    countries.RemoveAt(entry - 1);
                    countries.Insert(entry-1, new GeographicalUnit(name, capital, population, form));
                    log = addEntry(new LogEntry(name, LogEntry.Action.UPDATE), log);
                    Execute(countries,log);
                    break;
                case 5:
                    List<GeographicalUnit> old_countries = new List<GeographicalUnit>();
                    List<GeographicalUnit> removeList = new List<GeographicalUnit>();
                    old_countries = countries.ToList();
                    Console.WriteLine("Filters: Population size and form of government.");
                    Console.WriteLine("Choose the filter: ");
                    if (Console.ReadLine().ToUpper() == "FORM")
                    {
                        int number = 0;
                        Console.WriteLine("Federation(F) or Unitary state(US): ");
                        if (Console.ReadLine().ToUpper() == "F")
                        {
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.getForm().Equals(GeographicalUnit.FormOfGov.US))
                                    removeList.Add(country);
                                   
                            }
                        }
                        else
                        {
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.getForm().Equals(GeographicalUnit.FormOfGov.F))
                                    removeList.Add(country);
                            }
                        }
                    }
                    else
                    {
                        int number = 0;
                        Console.WriteLine("Less or More: ");
                        if (Console.ReadLine().ToUpper() == "LESS")
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Less then ");
                                    number = int.Parse(Console.ReadLine());
                                    if (number < 0)
                                        throw new FormatException();
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.Write("Incorrect input, try again: ");
                                }
                            }
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.getPopulation() > number)
                                    removeList.Add(country);
                            }
                        }
                        else
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Write("More then ");
                                    number = int.Parse(Console.ReadLine());
                                    if (number < 0)
                                        throw new FormatException();
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.Write("Incorrect input, try again: ");
                                }
                            }
                            foreach (GeographicalUnit country in old_countries)
                            {
                                if (country.getPopulation() < number)
                                    removeList.Add(country);
                            }
                        }
                    }
                    foreach (GeographicalUnit country in removeList)
                    {
                        countries.Remove(country);
                    }
                    output = "\n--------------------------------------\n";
                    if (countries.Count == 0)
                        output = ("The list is empty!");
                    else
                    {
                        foreach (GeographicalUnit country in countries)
                        {
                            output += country.getInfoTable();
                        }
                    }

                    Console.WriteLine(output);
                    countries = old_countries.ToList();
                    Execute(countries,log);
                    break;
                case 6:
                    output = "";
                    foreach(LogEntry i in log)
                    {
                        output += i.logFormatted()+"\n";
                    }
                    output+=($"\n{longestIdleTime(log)} - Самый долгий период бездействия пользователя");
                    Console.WriteLine(output);
                    Execute(countries,log);
                    break;
                case 7:
                    return;
            }
        }
        public static List<LogEntry> addEntry(LogEntry entry, List<LogEntry> list, int size = 50)
        {
            List<LogEntry> newList = list.ToList();
            if (list.Count() < size)
            {
                newList.Add(entry);
            }
            else
            {
                newList.RemoveAt(0);
                newList.Add(entry);
            }
            return newList;
        }
        public static String longestIdleTime(List<LogEntry> log)
        {
            TimeSpan startTime, endTime;
            String idle = "";
            if (log.Count() == 1 || log.Count == 0)
                idle = "00:00:00";
            else
            {
                for (int i = 0; i < log.Count() - 1; i++)
                {
                    startTime = TimeSpan.ParseExact(log[i].getTime(), @"h\:mm\:ss", CultureInfo.InvariantCulture);
                    endTime = TimeSpan.ParseExact(log[i + 1].getTime(), @"h\:mm\:ss", CultureInfo.InvariantCulture);
                    double diffInSeconds = (endTime - startTime).TotalSeconds;
                    TimeSpan time = TimeSpan.FromSeconds(diffInSeconds);
                    idle = time.ToString(@"h\:mm\:ss");
                }
            }
            return idle;
        }
    }
}
