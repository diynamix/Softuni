namespace Vehicles.Exception
{
    using System;

    public class InvalidVehicleTypeException : Exception
    {
        private const string defaultMessage = "Vehickle type not supported!";

        public InvalidVehicleTypeException() : base(defaultMessage)
        {

        }

        public InvalidVehicleTypeException(string message) : base(message)
        {

        }
    }
}
