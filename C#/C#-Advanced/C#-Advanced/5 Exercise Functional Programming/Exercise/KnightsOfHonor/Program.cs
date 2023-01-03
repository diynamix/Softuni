using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[], string> printNamesWithAddedTitle = (names, title) =>
            {
                foreach (string name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            string[] names = Console.ReadLine().Split();

            printNamesWithAddedTitle(names, "Sir");
        }
    }
}
