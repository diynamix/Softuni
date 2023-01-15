using System;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            Dictionary<string, HashSet<string>> sides = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                AddCheck(users, sides, input);
            }

            var sorted = sides.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);
            foreach (var side in sorted)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var name in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {name}");
                }
            }
        }

        static void AddCheck(Dictionary<string, string> users, Dictionary<string, HashSet<string>> sides, string input)
        {
            string token = input.Contains("|") ? "|" : "->";
            string[] tokens = input.Split($" {token} ");
            string side = token == "|" ? tokens[0] : tokens[1];
            string name = token == "|" ? tokens[1] : tokens[0];

            if (!sides.ContainsKey(side))
            {
                sides[side] = new HashSet<string>();
            }
            if (!users.ContainsKey(name))
            {
                sides[side].Add(name);
                users[name] = side;
            }

            if (token == "->")
            {
                if (users.ContainsKey(name))
                {
                    if (sides[users[name]].Contains(name))
                    {
                        sides[users[name]].Remove(name);
                    }
                    sides[side].Add(name);
                    users[name] = side;
                }
                Console.WriteLine($"{name} joins the {side} side!");
            }
        }
    }
}
