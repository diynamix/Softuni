namespace UniversityCompetition.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int id = students.Models.Count + 1;
            IStudent student = new Student(id, firstName, lastName);

            students.AddModel(student);

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            
            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject = null;
            int id = subjects.Models.Count + 1;
            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(id, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(id, subjectName);
            }
            else if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(id, subjectName);
            }

            subjects.AddModel(subject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> subjectIds = requiredSubjects
                .Select(s => subjects.FindByName(s).Id)
                .ToList();

            int id = universities.Models.Count + 1;
            IUniversity university = new University(id, universityName, category, capacity, subjectIds);

            universities.AddModel(university);

            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(" ")[0];
            string lastName = studentName.Split(" ")[1];

            IStudent student = students.FindByName(studentName);

            IUniversity university = universities.FindByName(universityName);

            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            if (university.RequiredSubjects.All(rs => student.CoveredExams.Contains(rs)) == false)
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University?.Name == universityName)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            int studentsCount = students.Models.Where(s => s.University == university).Count();

            //if (studentsCount == university.Capacity)
            //{
            //    return null;
            //}

            student.JoinUniversity(university);

            return String.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);

            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            int studentsCount = students.Models.Where(s => s.University == university).Count();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
