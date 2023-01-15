using System;
using System.Linq;
using System.Collections.Generic;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isEven = Console.ReadLine() == "even";

            List<int> numbers = new List<int>();
            List<int> result = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = number => number % 2 == 0;
            Predicate<int> odd = number => number % 2 != 0;

            if (isEven)
            {
                result = numbers.Where(n => even(n)).ToList();
            }
            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
