using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(info[0], int.Parse(info[1]), info[2]));
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person toCompare = people[index];

            int match = people.Where(p => p.CompareTo(toCompare) == 0).Count();
            if (match > 1)
            {
                Console.WriteLine($"{match} {people.Count() - match} {people.Count()}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}