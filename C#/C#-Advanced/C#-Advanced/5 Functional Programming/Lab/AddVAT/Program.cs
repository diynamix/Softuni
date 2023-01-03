using System;
using System.Linq;
using System.Collections.Generic;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVAT = x => x * 1.20m;

            string input = Console.ReadLine();
            string[] tokens = input.Split(", ");
            decimal[] nums = tokens.Select(decimal.Parse).ToArray();
            List<decimal> numsWithVAT = nums.Select(addVAT).ToList();

            numsWithVAT.ForEach(num => Console.WriteLine($"{num:f2}"));
        }
    }
}
