namespace Logger.Core.Exceptions
{
    public class EmptyDateTimeException : Exception
    {
        private const string DefaultMessage = "DateTime of message text cannot be null or whitespace!";

        public EmptyDateTimeException() : base(DefaultMessage) { }
        public EmptyDateTimeException(string dateTime) : base(dateTime) { }
    }
}
