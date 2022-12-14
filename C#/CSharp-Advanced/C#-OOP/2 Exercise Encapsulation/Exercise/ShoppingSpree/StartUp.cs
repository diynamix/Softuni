using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                //Dictionary<string, decimal> people = new Dictionary<string, decimal>();
                //Console.ReadLine().Split(";").ToList().ForEach(kvp =>
                //{
                //    string[] tokens = kvp.Split("=");
                //    people.Add(tokens[0], decimal.Parse(tokens[1]));
                //});
                //Dictionary<string, decimal> products = new Dictionary<string, decimal>();
                //Console.ReadLine().Split(";").ToList().ForEach(kvp =>
                //{
                //    string[] tokens = kvp.Split("=");
                //    people.Add(tokens[0], decimal.Parse(tokens[1]));
                //});
                List<Person> people = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .Select(i =>
                    {
                        string name = i.Split("=")[0];
                        decimal money = decimal.Parse(i.Split("=")[1]);
                        return new Person(name, money);
                    })
                    .ToList();

                List<Product> products = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .Select(i =>
                    {
                        string name = i.Split("=")[0];
                        decimal cost = decimal.Parse(i.Split("=")[1]);
                        return new Product(name, cost);
                    })
                    .ToList();

                string command = String.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Person person = people.Find(p => p.Name == tokens[0]);
                    Product product = products.Find(p => p.Name == tokens[1]);
                    if (person.Money >= product.Cost)
                    {
                        person.Money -= product.Cost;
                        person.Bag.Add(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ax)
            {
                Console.WriteLine(ax.Message);
            }
        }
    }
}
