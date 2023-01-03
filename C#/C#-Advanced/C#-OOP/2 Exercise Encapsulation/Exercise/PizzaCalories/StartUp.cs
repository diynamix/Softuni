using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ");

                Pizza pizza = new Pizza(tokens[1]);

                input = Console.ReadLine();
                tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                pizza.Dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));

                while ((input = Console.ReadLine()) != "END")
                {
                    tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    pizza.AddTopping(new Topping(tokens[1], double.Parse(tokens[2])));
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
}
    }
}
