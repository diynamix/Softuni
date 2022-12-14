using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!chars.ContainsKey(c))
                {
                    chars.Add(c, 0);
                }
                chars[c]++;
            }

            foreach (KeyValuePair<char, int> c in chars)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
