namespace WindFarm.Exceptions
{
    using System;

    public class FoodNotEatenException : Exception
    {
        public FoodNotEatenException(string message) : base(message)
        {
        }
    }
}
