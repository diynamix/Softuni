using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount[number] = 0;
                }
                numbersCount[number]++;
            }

            foreach (var number in numbersCount)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
