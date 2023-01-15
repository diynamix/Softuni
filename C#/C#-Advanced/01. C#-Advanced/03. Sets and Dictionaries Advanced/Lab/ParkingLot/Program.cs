using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string direction = input.Split(", ")[0];
                string carNumber = input.Split(", ")[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (cars.Contains(carNumber))
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Count > 0)
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
