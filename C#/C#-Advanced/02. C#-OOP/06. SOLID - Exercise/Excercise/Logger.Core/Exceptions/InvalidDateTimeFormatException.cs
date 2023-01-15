namespace Logger.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "Provided DateTime format is not suported. Try register it using Validator.RegisterNewFormat.";

        public InvalidDateTimeFormatException() : base(DefaultMessage) { }

        public InvalidDateTimeFormatException(string dateTime) : base(dateTime) { }
    }
}
