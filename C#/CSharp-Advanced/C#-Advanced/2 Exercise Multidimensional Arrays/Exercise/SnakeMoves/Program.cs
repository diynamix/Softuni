using System;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimentions = Console.ReadLine().Split();
            int rows = int.Parse(dimentions[0]);
            int cols = int.Parse(dimentions[1]);

            char[,] matrix = new char[rows, cols];
            string input = Console.ReadLine();
            int charCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = input[charCount % input.Length];
                    }
                    else
                    {
                        matrix[row, cols - 1 - col] = input[charCount % input.Length];
                    }
                    charCount++;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
