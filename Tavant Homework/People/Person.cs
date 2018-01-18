using System;

namespace RestAPI.Controllers
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        Person(string lastName, string firstName, string gender, string favoriteColor, string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(lastName)) return;
            LastName = lastName;
            if (string.IsNullOrWhiteSpace(firstName)) return;
            FirstName = firstName;
            if (string.IsNullOrWhiteSpace(gender)) return;
            Gender = gender;
            if (string.IsNullOrWhiteSpace(favoriteColor)) return;
            FavoriteColor = favoriteColor;
            if (!DateTime.TryParse(dateOfBirth,out var dob)) return;
            DateOfBirth = dob;
        }
    }
}
