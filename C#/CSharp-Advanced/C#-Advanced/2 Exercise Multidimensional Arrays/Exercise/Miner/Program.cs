using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();

            char[,] field = new char[size, size];
            int minerRow = 0;
            int minerCol = 0;
            int coals = 0;

            for (int row = 0; row < size; row++)
            {
                char[] symbols = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = symbols[col];
                    if (symbols[col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (symbols[col] == 'c')
                    {
                        coals++;
                    }
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                string cmd = directions[i];

                if ((cmd == "left" && minerCol == 0)
                    || (cmd == "right" && minerCol == size - 1)
                    || (cmd == "up" && minerRow == 0)
                    || (cmd == "down" && minerRow == size - 1))
                {
                    continue;
                }

                field[minerRow, minerCol] = '*';

                switch (cmd)
                {
                    case "left":
                        minerCol--;
                        break;
                    case "right":
                        minerCol++;
                        break;
                    case "up":
                        minerRow--;
                        break;
                    case "down":
                        minerRow++;
                        break;
                }


                if (field[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }

                if (field[minerRow, minerCol] == 'c')
                {
                    coals--;
                    field[minerRow, minerCol] = '*';
                }

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");
        }
    }
}
