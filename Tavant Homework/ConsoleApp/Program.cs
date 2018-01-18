using System;
using System.Collections.Generic;
using System.Linq;
using Homework.Console.Classes;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static People _people = new People();

        private static void Run()
        {
            while (_people == null || _people.Count() == 0)
            {
                var lines = GetDoc();
                _people = GetPeople(lines);
            }
            ShowPeople(_people);
        }

        private static List<string> GetDoc()
        {
            List<string> lines = new List<string>();
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("Input the path to the text file");
                var c = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(c) || !System.IO.File.Exists(c))
                {
                    System.Console.WriteLine("File path not valid, please try again.");
                    continue;
                }
                lines = System.IO.File.ReadLines(c).ToList();
            } while (lines.Count < 1);
            return lines;
        }

        private static People GetPeople(List<string> lines)
        {
            if (lines.Count < 1) return null;
            var people = new People();
            foreach (var line in lines)
            {
               var result = people.Add(line);
                if (result == "") continue;
                System.Console.WriteLine($"Failed to add people due to {result}");
                return null;
            }
            return people;
        }

        private static void ShowPeople(People people)
        {
            var choice = 0;
            var validChoice = false;
            while (!validChoice)
            {
                System.Console.WriteLine("\nWould you like to view the results sorted by\n" +
                                         "\t1 - Gender\n" +
                                         "\t2 - Birth date\n" +
                                         "\t3 - Last name");
                int.TryParse(System.Console.ReadLine(),out var result);
                if (1 > result || result > 3) continue;
                choice = result;
                validChoice = true;
            }

            List<Person> peeps = new List<Person>();
            switch (choice)
            {
                case 1:
                    peeps = people.GetPeopleByGender();
                    break;
                case 2:
                    peeps = people.GetPeopleByBirthdate();
                    break;
                case 3:
                    peeps = people.GetPeopleByName();
                    break;
            }
            if (peeps.Count < 1) return;
            System.Console.WriteLine($"\n\nRESULTS\nLast Name\t{"First Name",15}\t{"Gender",10}\t{"Favorite Color",15}\t{"DOB",10}");
            foreach (var peep in peeps)
            {
                System.Console.WriteLine($"{peep.LastName}\t{peep.FirstName,15}\t{peep.Gender,10}\t{peep.FavoriteColor,15}\t{peep.DateOfBirth,10}");
            }
            CompletionPrompt();
        }

        private static void CompletionPrompt()
        {

            var choice = 0;
            var validChoice = false;
            while (!validChoice)
            {
                System.Console.WriteLine("\n\nWould you like to\n" +
                                         "\t1 - Sort again\n" +
                                         "\t2 - Upload a new file\n" +
                                         "\t3 - Exit");
                int.TryParse(System.Console.ReadLine(), out var result);
                if (1 > result || result > 3) continue;
                choice = result;
                validChoice = true;
            }
            switch (choice)
            {
                case 1:
                    System.Console.Clear();
                    ShowPeople(_people);
                    break;
                case 2:
                    System.Console.Clear();
                    _people.Clear();
                    Run();
                    break;
                case 3:
                    break;
            }
        }
    }
}
