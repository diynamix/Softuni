using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = (numbers) =>
            {
                int min = int.MaxValue;

                foreach (int i in numbers)
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }

                return min;
            };

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(min(numbers));
        }
    }
}
