﻿namespace Logger.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefaultMessage = "File name cannot be null or whitespace!";

        public EmptyFileNameException() : base(DefaultMessage) { }
        public EmptyFileNameException(string fileName) : base(fileName) { }
    }
}
