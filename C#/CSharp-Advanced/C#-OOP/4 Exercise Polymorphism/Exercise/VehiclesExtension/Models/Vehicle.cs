namespace Vehicles.Models
{
    using System;

    using Contracts;
    using Exception;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double fuelConsumptionIncrement)
        {
            FuelQuantity = fuelQuantity <= tankCapacity ? fuelQuantity : 0;
            FuelConsumption = fuelConsumption + fuelConsumptionIncrement;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > FuelQuantity)
            {
                throw new InsufficientFuelException(String.Format(ExceptionMessages.InsufficientFuelExceptionMessage, this.GetType().Name));
            }

            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            const double FuelConsumptionIncrement = 1.4;
            FuelConsumption -= FuelConsumptionIncrement;
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > FuelQuantity)
            {
                throw new InsufficientFuelException(String.Format(ExceptionMessages.InsufficientFuelExceptionMessage, this.GetType().Name));
            }

            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
            FuelConsumption += FuelConsumptionIncrement;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new FuelOverloadException(String.Format(ExceptionMessages.FuelOverloadExceptionMessage, liters));
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}