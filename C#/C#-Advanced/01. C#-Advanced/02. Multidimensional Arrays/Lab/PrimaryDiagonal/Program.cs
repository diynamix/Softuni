using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                sum += input[i];
            }
            Console.WriteLine(sum);
        }
    }
}
