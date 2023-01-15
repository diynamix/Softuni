using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passed = 0;
            string command = String.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    int time = greenDuration;
                    while (time > 0 && cars.Count > 0)
                    {
                        string car = cars.Dequeue();
                        time -= car.Length;
                        passed++;
                        if (time < 0)
                        {
                            if (time + freeWindow < 0)
                            {
                                int index = car.Length + time + freeWindow;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[index]}.");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
