using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int endRange = int.Parse(Console.ReadLine());
            HashSet<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToHashSet();

            int[] numbers = Enumerable.Range(1, endRange).ToArray();

            foreach (int divider in dividers)
            {
                predicates.Add(p => p % divider == 0);
            }

            foreach (int number in numbers)
            {
                bool isDivisible = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
