using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Console.Classes
{
    public class People
    {
        private static List<Person> _people = new List<Person>();

        public void Add(Person person)
        {
            if (person == null) return;
            _people.Add(person);
        }

        public string Add(string personString)
        {
            List<string> splitPS;
            if (personString.Contains("|"))
                splitPS = personString.Split('|').Select(s => s.Trim()).ToList();
            else if (personString.Contains(","))
                splitPS = personString.Split(',').Select(s => s.Trim()).ToList();
            else if (personString.Contains(" "))
                splitPS = personString.Split(' ').Select(s => s.Trim()).ToList();
            else return "no delimiter was found";

            if (splitPS.Count < 5) return "too few arguments too add a person";
            try
            {
                _people.Add(new Person(splitPS[0], splitPS[1], splitPS[2], splitPS[3], splitPS[4]));
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }

        public int Count()
        {
            return _people.Count;
        }

        public void Clear()
        {
            _people.Clear();
        }

        public List<Person> GetPeopleByGender()
        {
            if (_people == null || _people.Count < 1) return null;
            return _people.OrderBy(x => x.Gender).ThenBy(x => x.LastName).ToList();
        }
        public List<Person> GetPeopleByBirthdate()
        {
            if (_people == null || _people.Count < 1) return null;
            return _people.OrderBy(x => DateTime.Parse(x.DateOfBirth)).ToList();
        }
        public List<Person> GetPeopleByName()
        {
            if (_people == null || _people.Count < 1) return null;
            return _people.OrderByDescending(x => x.LastName).ToList();
        }
    }
}