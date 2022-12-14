namespace Vehicles.Exception
{
    using System;

    public class NegativeFuelException : Exception
    {
        private const string defaultMessage = "Fuel must be a positive number";

        public NegativeFuelException() : base(defaultMessage)
        {

        }
    }
}
