using CsvSharp.Attributes;

using System;

namespace CsvSharp.Test.Models
{
    public class GeniusIgnore : Genius
    {
        [CsvIgnore]
        public string FullName => $"{FirstName} {LastName}";

        public GeniusIgnore() { }

        public GeniusIgnore(string firstName, string lastName, DateTime birthDate) : base(firstName, lastName, birthDate) { }
    }
}
