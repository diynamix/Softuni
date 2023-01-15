using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] orderedEvenNums = Console.ReadLine()
            //   .Split(", ")
            //   .Select(int.Parse)
            //   .Where(x => x % 2 == 0)
            //   .OrderBy(x => x)
            //   .ToArray();

            Func<string, int> parseStrinToInt = x => int.Parse(x);
            Func<int, bool> isEven = x => x % 2 == 0;
            Func<int, int> identity = x => x;

            string input = Console.ReadLine();
            string[] tokens = input.Split(", ");
            int[] nums = tokens.Select(parseStrinToInt).ToArray();
            int[] evenNums = nums.Where(isEven).ToArray();
            int[] orderedEvenNums = evenNums.OrderBy(identity).ToArray();

            Console.WriteLine(String.Join(", ", orderedEvenNums));
        }
    }
}
