using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[dimentions[0], dimentions[1]];
            for (int row = 0; row < dimentions[0]; row++)
            {
                string[] symbols = Console.ReadLine().Split();
                for (int col = 0; col < dimentions[1]; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int counter = 0;
            for (int row = 0; row < dimentions[0] - 1; row++)
            {
                for (int col = 0; col < dimentions[1] - 1; col++)
                {
                    if ((matrix[row, col] == matrix[row, col + 1])
                        && (matrix[row, col] == matrix[row + 1, col])
                        && (matrix[row, col] == matrix[row + 1, col + 1]))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
