using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, int> students = new Dictionary<string, int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                Submit(submissions, students, input);
            }

            Console.WriteLine("Results:");

            foreach (var student in students.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submit in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submit.Key} - {submit.Value}");
            }
        }

        static void Submit(Dictionary<string, int> submissions, Dictionary<string, int> students, string input)
        {
            string[] tokens = input.Split($"-");
            string username = tokens[0];
            string language = tokens[1];
            if (language == "banned")
            {
                students.Remove(username);
                return;
            }
            int points = int.Parse(tokens[2]);

            if (!submissions.ContainsKey(language))
            {
                submissions.Add(language, 0);
            }
            submissions[language]++;

            if (!students.ContainsKey(username))
            {
                students.Add(username, 0);
            }
            if (points > students[username])
            {
                students[username] = points;
            }
        }
    }
}
