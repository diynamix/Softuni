using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lines = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = lines[0];
            int m = lines[1];

            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                setN.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                setM.Add(int.Parse(Console.ReadLine()));
            }

            foreach (int num in setN)
            {
                if (setM.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
