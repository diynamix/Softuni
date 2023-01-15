using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                elements.UnionWith(Console.ReadLine().Split().ToHashSet());
            }

            string[] sorted = elements.ToArray();
            Array.Sort(sorted);

            Array.ForEach(sorted, element => Console.Write(element + " "));
        }
    }
}
