using System;
using System.Linq;
using System.Collections.Generic;

namespace TilesMaster
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> areas = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 },
            };

            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0 },
                { "Wall", 0 },
                { "Floor", 0 },
            };

            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int white = whiteTiles.Pop();
                int grey = greyTiles.Dequeue();

                if (white == grey)
                {
                    int newTile = white + grey;

                    KeyValuePair<string, int> location = areas.FirstOrDefault(x => x.Value == newTile);

                    if (location.Key != null)
                    {
                        locations[location.Key]++;
                    }
                    else
                    {
                        locations["Floor"]++;
                    }
                }
                else
                {
                    whiteTiles.Push(white / 2);
                    greyTiles.Enqueue(grey);
                }
            }

            string whiteLeft = whiteTiles.Count > 0 ? String.Join(", ", whiteTiles) : "none";
            string greyLeft = greyTiles.Count > 0 ? String.Join(", ", greyTiles) : "none";

            Console.WriteLine($"White tiles left: {whiteLeft}");
            Console.WriteLine($"Grey tiles left: {greyLeft}");

            locations = locations
                .OrderByDescending(l => l.Value)
                .ThenBy(l => l.Key)
                .Where(l => l.Value > 0)
                .ToDictionary(l => l.Key, l => l.Value);

            foreach (KeyValuePair<string, int> location in locations)
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}