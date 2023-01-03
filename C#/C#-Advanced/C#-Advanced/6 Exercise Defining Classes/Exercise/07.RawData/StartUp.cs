using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                cars.Add(CreateCar(input));
            }

            string criteria = Console.ReadLine();

            List<Car> sortedCars = SortCars(cars, criteria);

            foreach (Car car in sortedCars)
            {
                Console.WriteLine(car);
            }
        }

        static Car CreateCar(string input)
        {
            string[] tokens = input.Split();

            string model = tokens[0];
            int engineSpeed = int.Parse(tokens[1]);
            int enginePower = int.Parse(tokens[2]);
            int cargoWeight = int.Parse(tokens[3]);
            string cargoType = tokens[4];
            float tire1Pressure = float.Parse(tokens[5]);
            int tire1Age = int.Parse(tokens[6]);
            float tire2Pressure = float.Parse(tokens[7]);
            int tire2Age = int.Parse(tokens[8]);
            float tire3Pressure = float.Parse(tokens[9]);
            int tire3Age = int.Parse(tokens[10]);
            float tire4Pressure = float.Parse(tokens[11]);
            int tire4Age = int.Parse(tokens[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoType, cargoWeight);
            Tire tire1 = new Tire(tire1Age, tire1Pressure);
            Tire tire2 = new Tire(tire2Age, tire2Pressure);
            Tire tire3 = new Tire(tire3Age, tire3Pressure);
            Tire tire4 = new Tire(tire4Age, tire4Pressure);
            List<Tire> tires = new List<Tire>() { tire1, tire2, tire3, tire4 };

            return new Car(model, engine, cargo, tires);
        }

        static List<Car> SortCars(List<Car> cars, string criteria)
        {
            if (criteria == "fragile")
            {
                return cars
                    .Where(c => c.Cargo.Type == criteria && c.Tires.Any(t => t.Pressure < 1))
                    .ToList();
            }
            return cars
                    .Where(c => c.Cargo.Type == criteria && c.Engine.Power > 250)
                    .ToList();
        }
    }
}