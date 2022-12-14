using System;
using System.Linq;
using System.Collections.Generic;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                string command = Console.ReadLine();

                if (command == "2" && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (command == "3" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == "4" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else if (command.Length > 1)
                {
                    stack.Push(int.Parse(command.Split()[1]));
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(String.Join(", ", stack));
            }
        }
    }
}
