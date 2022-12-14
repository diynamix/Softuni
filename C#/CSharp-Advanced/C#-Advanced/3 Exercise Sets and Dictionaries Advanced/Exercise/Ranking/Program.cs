using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(":");
                passwords.Add(tokens[0], tokens[1]);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contest = tokens[0];
                if (!passwords.ContainsKey(contest)) continue;
                string password = tokens[1];
                if (passwords[contest] != password) continue;
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!students.ContainsKey(username))
                {
                    students.Add(username, new Student(username));
                }
                if (!students[username].Contests.ContainsKey(contest))
                {
                    students[username].Contests.Add(contest, points);
                    students[username].TotalPoints += points;
                }
                if (students[username].Contests[contest] < points)
                {
                    students[username].TotalPoints += points - students[username].Contests[contest];
                    students[username].Contests[contest] = points;
                }
            }

            KeyValuePair<string, Student> bestStudet = students.OrderByDescending(x => x.Value.TotalPoints).First();
            Console.WriteLine($"Best candidate is {bestStudet.Key} with total {bestStudet.Value.TotalPoints} points.");

            Console.WriteLine("Ranking:");
            foreach (KeyValuePair<string, Student> student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                var sortedContests = student.Value.Contests.OrderByDescending(x => x.Value);
                foreach (KeyValuePair<string, int> contest in sortedContests)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }

    class Student
    {
        public Student(string name)
        {
            Name = name;
            TotalPoints = 0;
            Contests = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public Dictionary<string, int> Contests { get; set; }
    }
}
