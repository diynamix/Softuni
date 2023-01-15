using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] colorClothes = input[1].Split(',');

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < colorClothes.Length; j++)
                {
                    string currentClothe = colorClothes[j];
                    if (!clothes[color].ContainsKey(currentClothe))
                    {
                        clothes[color].Add(currentClothe, 0);
                    }
                    clothes[color][currentClothe]++;
                }
            }

            string[] lookFor = Console.ReadLine().Split();
            string lookForColor = lookFor[0];
            string lookForCloth = lookFor[1];

            foreach (var color in clothes)
            {
                Console.WriteLine(color.Key + " clothes:");
                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (lookForColor == color.Key && lookForCloth == cloth.Key)
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
