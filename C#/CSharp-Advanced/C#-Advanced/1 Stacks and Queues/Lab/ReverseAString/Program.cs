using System;
using System.Collections.Generic;

namespace ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            /*
            foreach (char c in stack)
            {
                Console.Write(c);
            }
            */
        }
    }
}