using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int engineLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineLines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(tokens[0], int.Parse(tokens[1]));
                if (tokens.Length > 2)
                {
                    if (tokens[2].ToCharArray().All(char.IsDigit))
                    {
                        engine.Displacement = int.Parse(tokens[2]);
                    }
                    else
                    {
                        engine.Efficiency = tokens[2];
                    }
                }
                if (tokens.Length > 3)
                {
                    if (tokens[3].ToCharArray().All(char.IsDigit))
                    {
                        engine.Displacement = int.Parse(tokens[3]);
                    }
                    else
                    {
                        engine.Efficiency = tokens[3];
                    }
                }

                engines.Add(engine);
            }

            int carLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < carLines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = engines.Find(e => e.Model == tokens[1]);
                Car car = new Car(tokens[0], engine);
                if (tokens.Length > 2)
                {
                    if (tokens[2].ToCharArray().All(char.IsDigit))
                    {
                        car.Weight = int.Parse(tokens[2]);
                    }
                    else
                    {
                        car.Color = tokens[2];
                    }
                }
                if (tokens.Length > 3)
                {
                    if (tokens[3].ToCharArray().All(char.IsDigit))
                    {
                        car.Weight = int.Parse(tokens[3]);
                    }
                    else
                    {
                        car.Color = tokens[3];
                    }
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}