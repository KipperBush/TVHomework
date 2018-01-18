using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace Homework.Console.Classes
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public string DateOfBirth { get; set; }

        public Person(string lastName, string firstName, string gender, string favoriteColor, string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(lastName)) throw new InvalidDataException("Last name required");
            LastName = lastName;
            if (string.IsNullOrWhiteSpace(firstName)) throw new InvalidDataException("First name required");
            FirstName = firstName;
            if (string.IsNullOrWhiteSpace(gender)) throw new InvalidDataException("Gender required");
            Gender = gender;
            if (string.IsNullOrWhiteSpace(favoriteColor)) throw new InvalidDataException("Favorite color required");
            FavoriteColor = favoriteColor;
            if (!DateTime.TryParse(dateOfBirth, out var dob)) throw new InvalidDataException("Valid birthdate required");
            DateOfBirth = dob.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
        }
    }
}