using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    internal class Parking
    {
        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        private List<Car> cars;
        private int capacity;

        public int Count { get { return this.cars.Count; } }
        //public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.Find(car => car.RegistrationNumber == registrationNumber);
            return car;
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.cars.Find(c => c.RegistrationNumber == registrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                this.RemoveCar(registrationNumber);
            }
        }
    }
}