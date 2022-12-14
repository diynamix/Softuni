using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(numbers, new CustomComparator());

            Console.WriteLine(String.Join(" ", numbers));
        }
    }

    class CustomComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && Math.Abs(y) % 2 == 1)
            {
                return -1;
            }
            if (Math.Abs(x) % 2 == 1 && y % 2 == 0)
            {
                return 1;
            }
            return x.CompareTo(y);
        }
    }
}