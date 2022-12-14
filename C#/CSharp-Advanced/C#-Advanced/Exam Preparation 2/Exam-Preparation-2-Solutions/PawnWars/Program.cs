using System;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            int wRow = 0;
            int wCol = 0;

            int bRow = 0;
            int bCol = 0;

            for (int row = 0; row < 8; row++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < 8; col++)
                {
                    char c = symbols[col];
                    if (c == 'b')
                    {
                        bRow = row;
                        bCol = col;
                    }
                    else if (c == 'w')
                    {
                        wRow = row;
                        wCol = col;
                    }
                    board[row, col] = c;
                }
            }

            while (true)
            {
                if (wCol > 0)
                {
                    if (board[wRow - 1, wCol - 1] == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {(char)(wCol - 1 + 97)}{8 - wRow + 1}.");
                        return;
                    }
                }

                if (wCol < 7)
                {
                    if (board[wRow - 1, wCol + 1] == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {(char)(wCol + 1 + 97)}{8 - wRow + 1}.");
                        return;
                    }
                }

                board[wRow, wCol] = '-';
                board[--wRow, wCol] = 'w';

                if (wRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(wCol + 97)}{8 - wRow}.");
                    return;
                }

                if (bCol > 0)
                {
                    if (board[bRow + 1, bCol - 1] == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {(char)(bCol - 1 + 97)}{8 - bRow - 1}.");
                        return;
                    }
                }

                if (bCol < 7)
                {
                    if (board[bRow + 1, bCol + 1] == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {(char)(bCol + 1 + 97)}{8 - bRow - 1}.");
                        return;
                    }
                }

                board[bRow, bCol] = '-';
                board[++bRow, bCol] = 'b';

                if (bRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(bCol + 97)}{8 - bRow}.");
                    return;
                }
            }
        }
    }
}