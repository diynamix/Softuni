using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personTokens = Console.ReadLine().Split(" ");

            string[] drinkTokens = Console.ReadLine().Split(" ");
            
            string[] numberTokens = Console.ReadLine().Split(" ");

            Tuple<string, string> nameAddress = new Tuple<string, string>
            {
                Item1 = $"{personTokens[0]} {personTokens[1]}",
                Item2 = personTokens[2],
            };

            Tuple<string, int> nameBeer = new Tuple<string, int>
            {
                Item1 = drinkTokens[0],
                Item2 = int.Parse(drinkTokens[1]),
            };
            
            Tuple<int, double> numbers = new Tuple<int, double>
            {
                Item1 = int.Parse(numberTokens[0]),
                Item2 = double.Parse(numberTokens[1]),
            };

            Console.WriteLine(nameAddress);
            Console.WriteLine(nameBeer);
            Console.WriteLine(numbers);
        }
    }
}
