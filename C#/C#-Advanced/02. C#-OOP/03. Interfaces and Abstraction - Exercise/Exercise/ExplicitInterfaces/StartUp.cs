namespace ExplicitInterfaces
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }
        }
    }
}
