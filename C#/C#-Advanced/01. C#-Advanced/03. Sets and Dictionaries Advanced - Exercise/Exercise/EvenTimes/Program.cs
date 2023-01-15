using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<int, int> repeatition = new Dictionary<int, int>();

            for (int i = 0; i < lines; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!repeatition.ContainsKey(num))
                {
                    repeatition.Add(num, 0);
                }
                repeatition[num]++;
            }

            Console.WriteLine(repeatition.First(x => x.Value % 2 == 0).Key);
        }
    }
}
