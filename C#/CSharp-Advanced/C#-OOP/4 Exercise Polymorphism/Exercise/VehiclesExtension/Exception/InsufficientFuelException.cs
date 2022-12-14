namespace Vehicles.Exception
{
    using System;

    public class InsufficientFuelException : Exception
    {
        public InsufficientFuelException(string message) : base(message)
        {

        }
    }
}
