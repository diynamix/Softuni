using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {

                    matrix[row, col] = numbers[col];
                }
            }

            string[] bombs = Console.ReadLine().Split();
            int aliveCells = 0;
            int aliveCellsSum = 0;

            for (int i = 0; i < bombs.Length; i++)
            {
                int bombRow = int.Parse(bombs[i].Split(",")[0]);
                int bombCol = int.Parse(bombs[i].Split(",")[1]);

                if (bombRow < 0 || bombRow >= size
                    || bombCol < 0 || bombCol >= size
                    || matrix[bombRow, bombCol] <= 0)
                {
                    continue;
                }

                int damage = matrix[bombRow, bombCol];
                int startRow = Math.Max(0, bombRow - 1);
                int startCol = Math.Max(0, bombCol - 1);
                int endRow = Math.Min(size - 1, bombRow + 1);
                int endCol = Math.Min(size - 1, bombCol + 1);

                for (int row = startRow; row <= endRow; row++)
                {
                    for (int col = startCol; col <= endCol; col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= damage;
                        }
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsSum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
