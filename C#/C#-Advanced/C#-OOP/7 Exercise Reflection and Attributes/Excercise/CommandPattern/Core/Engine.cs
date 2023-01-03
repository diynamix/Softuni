namespace CommandPattern.Core
{
    using System;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        private Engine()
        {
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter commandInterpreter) : this()
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string inputLine = reader.ReadLine();
                    string result = commandInterpreter.Read(inputLine);
                    writer.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }
        }
    }
}