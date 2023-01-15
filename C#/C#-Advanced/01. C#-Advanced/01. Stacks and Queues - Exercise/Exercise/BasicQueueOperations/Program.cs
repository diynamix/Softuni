using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int toEnqueue = integers[0]; // to add
            int toDequeue = integers[1]; // to remove
            int toLook = integers[2];

            Queue<int> queue = new Queue<int>(array);

            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(toLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
