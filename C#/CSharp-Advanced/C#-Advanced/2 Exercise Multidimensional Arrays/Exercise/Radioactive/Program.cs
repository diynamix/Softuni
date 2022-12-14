using System;
using System.Linq;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split();
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            char[,] field = new char[rows, cols];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = symbols[col];
                    if (symbols[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool won = false;
            bool dead = false;
            for (int i = 0; i < directions.Length; i++)
            {
                char cmd = directions[i];

                if ((cmd == 'L' && playerCol == 0)
                    || (cmd == 'R' && playerCol == cols - 1)
                    || (cmd == 'U' && playerRow == 0)
                    || (cmd == 'D' && playerRow == rows - 1))
                {
                    won = true;
                }

                field[playerRow, playerCol] = '.';

                if (!won)
                {
                    switch (cmd)
                    {
                        case 'L': playerCol--; break;
                        case 'R': playerCol++; break;
                        case 'U': playerRow--; break;
                        case 'D': playerRow++; break;
                    }

                    if (field[playerRow, playerCol] == 'B')
                    {
                        dead = true;
                    }
                    else
                    {
                        field[playerRow, playerCol] = 'P';
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (field[row, col] == 'b')
                        {
                            field[row, col] = 'B';
                        }
                        else if (field[row, col] == 'B')
                        {
                            int prevCol = Math.Max(0, col - 1);
                            int nextCol = Math.Min(cols - 1, col + 1);
                            int prevRow = Math.Max(0, row - 1);
                            int nextRow = Math.Min(rows - 1, row + 1);

                            if (field[row, prevCol] == 'P'
                                || field[row, nextCol] == 'P'
                                || field[prevRow, col] == 'P'
                                || field[nextRow, col] == 'P')
                            {
                                dead = true;
                            }

                            if (field[row, prevCol] != 'B')
                            {
                                field[row, prevCol] = 'b';
                            }
                            if (field[row, nextCol] != 'B')
                            {
                                field[row, nextCol] = 'b';
                            }
                            if (field[prevRow, col] != 'B')
                            {
                                field[prevRow, col] = 'b';
                            }
                            if (field[nextRow, col] != 'B')
                            {
                                field[nextRow, col] = 'b';
                            }
                        }
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (field[row, col] == 'b')
                        {
                            field[row, col] = 'B';
                        }
                    }
                }

                if (won || dead) break;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }

            Console.Write(won ? "won" : "dead");
            Console.WriteLine($": {playerRow} {playerCol}");
        }
    }
}