namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            Type authorType = typeof(AuthorAttribute);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(ca => ca.AttributeType == authorType))
                {
                    object[] attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
