using System;
using System.Linq;
using System.Collections.Generic;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vloger> users = new Dictionary<string, Vloger>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split();
                string vloger = tokens[0];
                string action = tokens[1];
                string vloger2 = tokens[2];

                if (action == "joined" && !users.ContainsKey(vloger))
                {
                    users.Add(vloger, new Vloger(vloger));
                }
                else if (users.ContainsKey(vloger) && users.ContainsKey(vloger2) && vloger != vloger2)
                {
                    users[vloger].Following.Add(vloger2);
                    users[vloger2].Followers.Add(vloger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {users.Count} vloggers in its logs.");

            var sorted = users.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count);
            int counter = 0;
            foreach (var user in sorted)
            {
                counter++;
                string userName = user.Key;
                string[] followers = user.Value.Followers.ToArray();
                int following = user.Value.Following.Count;
                Console.WriteLine($"{counter}. {userName} : {followers.Length} followers, {following} following");
                if (counter == 1 && followers.Length > 0)
                {
                    Array.Sort(followers);
                    foreach (var follower in followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }

        }
    }

    class Vloger
    {
        public Vloger(string name)
        {
            Name = name;
            Followers = new HashSet<string>();
            Following = new HashSet<string>();
        }
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
