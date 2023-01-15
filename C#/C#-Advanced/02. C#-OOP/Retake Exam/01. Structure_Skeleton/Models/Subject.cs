namespace UniversityCompetition.Models
{
    using System;
    
    using Contracts;
    using Utilities.Messages;

    public abstract class Subject : ISubject
    {
        private string subjectName;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
        }

        public int Id { get; private set; }

        public string Name
        {
            get
            {
                return subjectName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);
                }

                subjectName = value;
            }
        }

        public double Rate { get; private set; }
    }
}
