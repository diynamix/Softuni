using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int bigest = queue.Max();

            while (queue.Count > 0)
            {
                int order = queue.Peek();
                if (food < order)
                {
                    break;
                }
                food -= order;
                queue.Dequeue();
            }

            Console.WriteLine(bigest);

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
