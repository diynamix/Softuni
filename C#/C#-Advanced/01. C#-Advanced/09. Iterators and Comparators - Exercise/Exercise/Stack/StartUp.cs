using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input.StartsWith("Push"))
                {
                        stack.Push(input.Replace("Push ", "").Split(", ", StringSplitOptions.RemoveEmptyEntries));
                }
                else if (input.StartsWith("Pop"))
                {
                    stack.Pop();
                }
            }

            foreach (var element in stack.Where(x => x != null).Reverse())
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack.Where(x => x != null).Reverse())
            {
                Console.WriteLine(element);
            }
        }
    }
}