using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> reversed = new List<int>();
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    reversed.Add(numbers[i]);
                }
                return reversed;
            };

            Func<List<int>, Predicate<int>, List<int>> excludeDivisible = (numbers, match) =>
            {
                List<int> result = new List<int>();

                foreach (int number in numbers)
                {
                    if (!match(number))
                    {
                        result.Add(number);
                    }
                }

                return result;
            };

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());

            numbers = excludeDivisible(numbers, n => n % divider == 0);

            numbers = reverse(numbers);

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
