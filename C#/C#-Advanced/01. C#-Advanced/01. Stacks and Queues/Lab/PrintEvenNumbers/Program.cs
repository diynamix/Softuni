using System;
using System.Linq;
using System.Collections.Generic;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(nums);
            Queue<int> even = new Queue<int>();
            while (queue.Count > 0)
            {
                int num = queue.Dequeue();
                if (num % 2 == 0)
                {
                    even.Enqueue(num);
                }
            }
            Console.WriteLine(string.Join(", ", even));
        }
    }
}
