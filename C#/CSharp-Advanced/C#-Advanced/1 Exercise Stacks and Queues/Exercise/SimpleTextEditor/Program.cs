using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<string> updates = new Stack<string>();
            string text = "";
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                int cmd = int.Parse(input[0]);

                if (cmd == 1)
                {
                    updates.Push(text);
                    text += input[1];
                }
                else if (cmd == 2)
                {
                    updates.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(input[1]));
                }
                else if (cmd == 3)
                {
                    Console.WriteLine(text[int.Parse(input[1]) - 1]);
                }
                else if (cmd == 4)
                {
                    text = updates.Pop();
                }
            }
        }
    }
}
