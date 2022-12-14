using System;
using System.Linq;
using System.Text;

namespace RallyRacing
{
    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int racingNumber = int.Parse(Console.ReadLine());
            char[,] raceRoute = new char[size, size];

            int carRow = 0;
            int carCol = 0;
            int firstTunnelRow = 0;
            int firstTunnelCol = 0;
            int secondTunnelRow = 0;
            int secondTunnelCol = 0;
            int finishRow = 0;
            int finishCol = 0;
            int kilometers = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowChars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    char symbol = rowChars[col];
                    if (symbol == 'T' && firstTunnelRow == 0 && firstTunnelCol == 0)
                    {
                        firstTunnelRow = row;
                        firstTunnelCol = col;
                    }
                    else if (symbol == 'T')
                    {
                        secondTunnelRow = row;
                        secondTunnelCol = col;
                    }
                    else if (symbol == 'F')
                    {
                        finishRow = row;
                        finishCol = col;
                    }
                    raceRoute[row, col] = symbol;
                }
            }

            string direction = String.Empty;

            while ((direction = Console.ReadLine()) != "End")
            {
                raceRoute[carRow, carCol] = '.';

                if (direction == "left")
                {
                    carCol--;
                }
                else if (direction == "right")
                {
                    carCol++;
                }
                else if (direction == "up")
                {
                    carRow--;
                }
                else if (direction == "down")
                {
                    carRow++;
                }

                kilometers += 10;
                raceRoute[carRow, carCol] = '.';

                if (carRow == finishRow && carCol == finishCol)
                {
                    // reached finish
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    break;
                }
                if (carRow == firstTunnelRow && carCol == firstTunnelCol)
                {
                    // reached first tunnel
                    carRow = secondTunnelRow;
                    carCol = secondTunnelCol;
                    kilometers += 20;

                }
                else if (carRow == secondTunnelRow && carCol == secondTunnelCol)
                {
                    // reached second tunnel
                    carRow = firstTunnelRow;
                    carCol = firstTunnelCol;
                    kilometers += 20;
                }
            }

            if (direction == "End")
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometers} km.");

            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row == carRow && col == carCol)
                    {
                        raceRoute[row, col] = 'C';
                    }
                    sb.Append($"{raceRoute[row, col]}");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}