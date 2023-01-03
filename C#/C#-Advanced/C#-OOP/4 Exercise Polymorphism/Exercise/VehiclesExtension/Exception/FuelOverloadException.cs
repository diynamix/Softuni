namespace Vehicles.Exception
{
    using System;

    public class FuelOverloadException : Exception
    {
        public FuelOverloadException(string message) : base(message)
        {

        }
    }
}
