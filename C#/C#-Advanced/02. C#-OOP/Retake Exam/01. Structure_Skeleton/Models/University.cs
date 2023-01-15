namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using UniversityCompetition.Utilities.Messages;

    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;

            RequiredSubjects = (IReadOnlyCollection<int>)requiredSubjects;
        }

        public int Id { get; private set; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Category
        {
            get { return category; }
            private set
            {
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects { get; private set; }
    }
}
