using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    public class Program
    {
        public static void Main()
        {
            const int maxCaf = 300;
            int takenCaf = 0;

            Stack<int> caffeinе = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (caffeinе.Count > 0 && energyDrinks.Count > 0)
            {
                int caf = caffeinе.Pop();
                int drink = energyDrinks.Dequeue();
                int currentTakenCaf = caf * drink;

                if (currentTakenCaf + takenCaf > maxCaf)
                {
                    takenCaf -= 30;
                    if (takenCaf < 0)
                    {
                        takenCaf = 0;
                    }
                    energyDrinks.Enqueue(drink);
                }
                else
                {
                    takenCaf += currentTakenCaf;
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {takenCaf} mg caffeine.");
        }
    }
}