using System;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] elements = input.Replace("Create", "").Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> iterator = new ListyIterator<string>(elements);

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(iterator.Print());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}