namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthDatable> citizensAndPets = new List<IBirthDatable>();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Citizen")
                {
                    citizensAndPets.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens[0] == "Pet")
                {
                    citizensAndPets.Add(new Pet(tokens[1], tokens[2]));
                }
                else
                {
                    continue;
                }
            }

            string year = Console.ReadLine();

            foreach (IBirthDatable citizenOrPet in citizensAndPets)
            {
                if (citizenOrPet.CheckYear(year))
                {
                    Console.WriteLine(citizenOrPet.BirthDate);
                }
            }
        }
    }
}