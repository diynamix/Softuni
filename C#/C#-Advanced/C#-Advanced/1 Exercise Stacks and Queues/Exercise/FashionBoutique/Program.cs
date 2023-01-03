using System;
using System.Linq;
using System.Collections.Generic;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());
            int racks = 1;
            int sum = capacity;

            while (clothes.Count > 0)
            {
                int cloth = clothes.Peek();
                if (sum - cloth < 0)
                {
                    racks++;
                    sum = capacity;
                }
                sum -= cloth;
                clothes.Pop();
            }
            Console.WriteLine(racks);
        }
    }
}
