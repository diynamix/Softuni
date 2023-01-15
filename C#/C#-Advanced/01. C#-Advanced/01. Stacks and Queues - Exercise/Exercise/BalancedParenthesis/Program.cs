using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> brackets = new Queue<char>(Console.ReadLine().ToCharArray());
            int counter = 0;
            bool balnced = true;

            if (brackets.Count % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            while (brackets.Count > 0)
            {
                char first = brackets.Dequeue();
                char second = brackets.Peek();

                if ((first == '(' && second == ')')
                    || (first == '{' && second == '}')
                    || (first == '[' && second == ']'))
                {
                    brackets.Dequeue();
                    counter = 0;
                    continue;
                }
                else
                {
                    brackets.Enqueue(first);
                }

                counter++;

                if (counter == brackets.Count)
                {
                    balnced = false;
                    break;
                }
            }

            if (balnced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
