using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personTokens = Console.ReadLine().Split(" ");

            string[] drinkTokens = Console.ReadLine().Split(" ");
            
            string[] bankTokens = Console.ReadLine().Split(" ");

            Threeuple<string, string, string> person = new Threeuple<string, string, string>
            {
                Item1 = $"{personTokens[0]} {personTokens[1]}",
                Item2 = personTokens[2],
                Item3 = personTokens[3],
            };

            Threeuple<string, int, bool> drink = new Threeuple<string, int, bool>
            {
                Item1 = drinkTokens[0],
                Item2 = int.Parse(drinkTokens[1]),
                Item3 = drinkTokens[2] == "drunk",
            };
            
            Threeuple<string, double, string> bankAccount = new Threeuple<string, double, string>
            {
                Item1 = bankTokens[0],
                Item2 = double.Parse(bankTokens[1]),
                Item3 = bankTokens[2],
            };

            Console.WriteLine(person);
            Console.WriteLine(drink);
            Console.WriteLine(bankAccount);
        }
    }
}
