using System;
using Vehicles.Exception;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, fuelConsumptionIncrement)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new FuelOverloadException(String.Format(ExceptionMessages.FuelOverloadExceptionMessage, liters));
            }

            base.Refuel(liters * 0.95);
        }
    }
}
