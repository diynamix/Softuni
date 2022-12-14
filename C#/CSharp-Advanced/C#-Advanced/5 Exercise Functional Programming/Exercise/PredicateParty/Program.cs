using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split();

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }
                else if (action == "Double")
                {
                    List<string> peopleToDouble = people.FindAll(GetPredicate(filter, value));
                    int index = people.FindIndex(GetPredicate(filter, value));

                    if (index >= 0)
                    {
                        people.InsertRange(index, peopleToDouble);
                    }
                }
            }

            if (people.Any())
            {
                Console.WriteLine($"{String.Join(", ", people)} are going to the par-ty!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return s => s.StartsWith(value);
                case "EndsWith":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
