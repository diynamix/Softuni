﻿namespace BirthdayCelebrations.Models
{
    using Contracts;

    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }

        public bool CheckYear(string year) => BirthDate.EndsWith($"/{year}");
    }
}
