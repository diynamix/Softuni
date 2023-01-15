using System;

namespace WallDestroyer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];

            int vRow = 0;
            int vCol = 0;

            int hidRods = 0;
            int holes = 0;

            for (int row = 0; row < size; row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < symbols.Length; col++)
                {
                    char symbol = symbols[col];
                    if (symbol == 'V')
                    {
                        vRow = row;
                        vCol = col;
                        holes++;
                    }
                    wall[row, col] = symbol;
                }
            }

            string direction = String.Empty;

            while ((direction = Console.ReadLine()) != "End")
            {
                int lastRow = vRow;
                int lastCol = vCol;

                switch (direction)
                {
                    case "up":
                        if (vRow - 1 < 0) continue;
                        vRow--;
                        break;
                    case "down":
                        if (vRow + 1 >= size) continue;
                        vRow++;
                        break;
                    case "left":
                        if (vCol - 1 < 0) continue;
                        vCol--;
                        break;
                    case "right":
                        if (vCol + 1 >= size) continue;
                        vCol++;
                        break;
                }

                if (wall[vRow, vCol] == 'R')
                {
                    vRow = lastRow;
                    vCol = lastCol;
                    hidRods++;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }
                else if (wall[vRow, vCol] == 'C')
                {
                    wall[vRow, vCol] = 'E';
                    holes++;
                    wall[lastRow, lastCol] = '*';
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                    break;
                }
                else
                {
                    if (wall[vRow, vCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                    }
                    else
                    {
                        holes++;
                    }

                    wall[lastRow, lastCol] = '*';
                    wall[vRow, vCol] = 'V';
                }
            }

            if (direction == "End")
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {hidRods} rod(s).");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}