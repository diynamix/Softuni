using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum1 = 0;
            int sum2 = 0;
            for (int row = 0; row < n; row++)
            {
                sum1 += matrix[row, row];
                sum2 += matrix[row, n - 1 - row];
            }

            Console.WriteLine($"{Math.Abs(sum1 - sum2)}");
        }
    }
}
