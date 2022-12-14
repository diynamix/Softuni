namespace Raiding
{
    using System;
    using System.Collections.Generic;

    using Modules;
    using Raiding.Factory;

    public class StartUp
    {
        static void Main(string[] args)
        {
            HeroFactory factory = new HeroFactory();

            List<BaseHero> raid = new List<BaseHero>();

            int raidMembers = int.Parse(Console.ReadLine());

            while (raid.Count < raidMembers)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    var hero = factory.CreateHero(name, heroType);

                    raid.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int heroesPower = 0;

            foreach (BaseHero hero in raid)
            {
                heroesPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
