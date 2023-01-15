using System;
using System.Linq;
using System.Collections.Generic;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> add = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]++;
                }
            };

            Func<List<int>, List<int>> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]--;
                }

                return numbers;
            };

            Func<List<int>, List<int>> multiply = numbers => numbers.Select(n => n * 2).ToList();

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add": add(numbers); break;
                    case "subtract": numbers = subtract(numbers); break;
                    case "multiply": numbers = multiply(numbers); break;
                    case "print": print(numbers); break;
                    default: break;
                }
            }
        }
    }
}
