namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(" ");

            string cmdName = cmdArgs[0];
            string[] invokeArgs = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCommandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command");
            if (intendedCommandType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = intendedCommandType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");
            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement required pattern! Try implementing ICommand Interface Instead!");
            }

            object cmdInstance = Activator.CreateInstance(intendedCommandType);
            string result = (string)executeMethodInfo
                .Invoke(cmdInstance, new object[] { invokeArgs });

            return result;
        }
    }
}