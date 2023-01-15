using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!trainers.Any(t => t.Name == tokens[0]))
                {
                    trainers.Add(new Trainer(tokens[0]));
                }

                Trainer trainer = trainers.Find(t => t.Name == tokens[0]);

                trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }

                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}