using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class People
    {
        private static List<Person> people = new List<Person>();

        public static List<Person> Gender()
        {
            if (people == null || people.Count < 1) return null;
            return people.OrderBy(x => x.Gender).ToList();
        }
        public static List<Person> Birthdate()
        {
            if (people == null || people.Count < 1) return null;
            return people.OrderBy(x => x.DateOfBirth).ToList();
        }
        public static List<Person> Name()
        {
            if (people == null || people.Count < 1) return null;
            return people.OrderByDescending(x => x.LastName).ToList();
        }

    }
}
