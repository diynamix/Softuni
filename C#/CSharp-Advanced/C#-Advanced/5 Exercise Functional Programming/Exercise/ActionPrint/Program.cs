using System;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = strings => Console.WriteLine(String.Join(Environment.NewLine, strings));

            string[] strings = Console.ReadLine().Split();

            print(strings);
        }
    }
}
