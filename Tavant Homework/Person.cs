using System;
using System.Globalization;

namespace Homework
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
            if (string.IsNullOrWhiteSpace(lastName)) return;
            LastName = lastName;
            if (string.IsNullOrWhiteSpace(firstName)) return;
            FirstName = firstName;
            if (string.IsNullOrWhiteSpace(gender)) return;
            Gender = gender;
            if (string.IsNullOrWhiteSpace(favoriteColor)) return;
            FavoriteColor = favoriteColor;
            if (!DateTime.TryParse(dateOfBirth, out var dob)) return;
            DateOfBirth = dob.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
        }
    }
}