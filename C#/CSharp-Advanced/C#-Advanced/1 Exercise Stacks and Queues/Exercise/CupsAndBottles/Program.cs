using System;
using System.Linq;
using System.Collections.Generic;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wasted = 0;

            while (true)
            {
                int cup = cups.Peek();

                while (cup > 0 && bottles.Count > 0)
                {
                    int bottle = bottles.Pop();
                    int bottleCopy = bottle;
                    bottleCopy -= cup;
                    cup -= bottle;
                    if (cup <= 0)
                    {
                        cups.Dequeue();
                        wasted += bottleCopy;
                    }
                }

                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
                    break;
                }
                if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {String.Join(" ", cups)}");
                    break;
                }
            }

            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
