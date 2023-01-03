namespace Logger.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaultMessage = "Provided path does not exists or is invalid!";

        public InvalidPathException() : base(DefaultMessage) { }
        public InvalidPathException(string path) : base(path) { }
    }
}
