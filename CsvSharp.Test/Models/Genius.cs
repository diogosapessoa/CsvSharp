using CsvSharp.Attributes;

using System;

namespace CsvSharp.Test.Models
{
    public class Genius
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [CsvDateTimeFormat("yyyy-MM-dd")]
        public DateTime BirthDate { get; set; }

        public Genius() { }

        public Genius(string firstname, string lastName, DateTime birthDate)
        {
            FirstName = firstname;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"FirstName={FirstName}, LastName={LastName}, BirthDate={BirthDate}";
        }
    }
}
