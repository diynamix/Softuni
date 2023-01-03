using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] info = Console.ReadLine().Split();
                Person person = new Person(info[0], int.Parse(info[1]));
                people.Add(person);
            }

            List<Person> sortedPeople = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (Person person in sortedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}