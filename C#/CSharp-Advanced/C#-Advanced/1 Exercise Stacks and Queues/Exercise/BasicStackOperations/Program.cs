using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int toPush = integers[0];
            int toPop = integers[1];
            int toLook = integers[2];

            Stack<int> stack = new Stack<int>(array);

            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(toLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
