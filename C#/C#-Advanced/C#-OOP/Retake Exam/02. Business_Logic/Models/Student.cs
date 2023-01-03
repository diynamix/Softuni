namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private ICollection<int> coveredExams;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;

            coveredExams = new List<int>();
        }

        public int Id { get; private set; }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => (IReadOnlyCollection<int>)coveredExams;

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
