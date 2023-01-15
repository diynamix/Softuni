using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tirePackages = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = String.Empty;

            //Reading tires
            while ((input = Console.ReadLine()) != "No more tires")
            {
                Tire[] tirePackage = new Tire[4];
                string[] tokens = input.Split();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);

                    tirePackage[i / 2] = new Tire(year, pressure);
                }

                tirePackages.Add(tirePackage);
            }

            //Reading engines
            while ((input = Console.ReadLine()) != "Engines done")
            {
                int horsePower = int.Parse(input.Split()[0]);
                double cubicCapacity = double.Parse(input.Split()[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            //Reading cars info
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input.Split();

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Engine engine = engines[engineIndex];
                Tire[] carPackage = tirePackages[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, carPackage);
                cars.Add(car);
            }

            //Select special cars ----------------------------------------------------------------------

            List<Car> specialCars = cars
                .FindAll(c => c.Year >= 2017
                && c.Engine.HorsePower > 330
                && c.Tires.Select(t => t.Pressure).Sum() >= 9
                && c.Tires.Select(t => t.Pressure).Sum() <= 10);

            //Drive 20 km all special cars
            //Print information about each special car
            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }
        }
    }
}