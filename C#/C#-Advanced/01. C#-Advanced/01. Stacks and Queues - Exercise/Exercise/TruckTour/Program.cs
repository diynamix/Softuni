using System;
using System.Linq;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumps.Enqueue(new PetrolPump(data[0], data[1], i));
            }

            while (true)
            {
                int currentLiters = 0;
                bool valid = true;
                for (int i = 0; i < pumps.Count; i++)
                {
                    PetrolPump currentPump = pumps.Dequeue();
                    currentLiters += currentPump.Liters;
                    currentLiters -= currentPump.Distance;
                    pumps.Enqueue(currentPump);

                    if (currentLiters < 0)
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(pumps.Dequeue().Number);
        }
    }

    class PetrolPump
    {
        public PetrolPump(int liters, int distance, int number)
        {
            this.Liters = liters;
            this.Distance = distance;
            this.Number = number;
        }
        public int Liters { get; set; }
        public int Distance { get; set; }
        public int Number { get; set; }
    }
}
