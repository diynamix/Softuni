namespace CommandPattern.Core
{
    using System;

    using Contracts;

    internal class ExitCommand : ICommand
    {
        private const int DefaultErrorCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DefaultErrorCode);
            return null;
        }
    }
}
