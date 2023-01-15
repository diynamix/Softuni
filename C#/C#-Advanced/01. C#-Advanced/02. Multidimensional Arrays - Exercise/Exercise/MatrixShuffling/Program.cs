using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmd = command.Split();

                if (cmd.Length != 5
                    || cmd[0] != "swap"
                    || (int.Parse(cmd[1]) < 0 || int.Parse(cmd[1]) > rows - 1)
                    || (int.Parse(cmd[2]) < 0 || int.Parse(cmd[2]) > cols - 1)
                    || (int.Parse(cmd[3]) < 0 || int.Parse(cmd[3]) > rows - 1)
                    || (int.Parse(cmd[4]) < 0 || int.Parse(cmd[4]) > cols - 1))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);
                    string copy = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = copy;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
