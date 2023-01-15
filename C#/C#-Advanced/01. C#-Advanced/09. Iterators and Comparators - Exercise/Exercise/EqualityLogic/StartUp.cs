using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> people = new HashSet<Person>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                sortedPeople.Add(new Person(tokens[0], int.Parse(tokens[1])));
                people.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(people.Count);
        }
    }
}