using System;
using System.Collections.Generic;

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
                string[] info = Console.ReadLine().Split();

                cars.Add(new Car(info[0], double.Parse(info[1]), double.Parse(info[2])));
            }
            
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string carModel = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car car = cars.Find(c => c.Model == carModel);
                car.Drive(amountOfKm);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}