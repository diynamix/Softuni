namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 4)
                {
                    buyers.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
            }

            string name = String.Empty;

            while ((name = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.Find(b => b.Name == name);
                if (buyer == null) continue;
                buyer.BuyFood();
            }

            Console.WriteLine(buyers.Select(b => b.Food).Sum());
        }
    }
}
