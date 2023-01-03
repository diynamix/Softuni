using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(";");

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Add filter")
                {
                    filters.Add(filter + value, GetPredicate(filter, value));
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (KeyValuePair<string, Predicate<string>> filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            Console.WriteLine(String.Join(" ", people));
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                case "Contains":
                    return s => s.Contains(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
