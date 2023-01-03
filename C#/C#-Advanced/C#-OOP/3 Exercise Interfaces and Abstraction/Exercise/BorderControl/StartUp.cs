namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Creature> creatures = new List<Creature>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                Creature creature = null;

                if (tokens.Length == 2)
                {
                    creature = new Robot(tokens[0], tokens[1]);
                }
                else if (tokens.Length == 3)
                {
                    creature = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }           
                
                creatures.Add(creature);
            }

            string fake = Console.ReadLine();

            foreach (var creature in creatures)
            {
                if (creature.CheckId(fake))
                {
                    Console.WriteLine(creature.Id);
                }
            }
        }
    }
}