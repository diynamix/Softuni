namespace Vehicles.Factories
{
    using Contracts;
    using Exception;
    using Models;
    using Models.Contracts;

    // This should not be static!!!
    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {

        }

        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidVehicleTypeException();
            }

            return vehicle;
        }
    }
}
