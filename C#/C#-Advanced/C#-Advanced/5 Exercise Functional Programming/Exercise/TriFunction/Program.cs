using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkEqualOrLargerNameSum = (name, sum) => name.Sum(ch => ch) >= sum;

            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, sum, match) => names.FirstOrDefault(name => match(name, sum));

            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Console.WriteLine(getFirstName(names, sum, checkEqualOrLargerNameSum));
        }
    }
}

// Variant 2
//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace TriFunction
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int num = int.Parse(Console.ReadLine());
//            List<string> names = Console.ReadLine().Split().ToList();

//            var name = names.Find(n => n.ToCharArray().Select(ch => (int)ch).Sum() >= num);
//            Console.WriteLine(name);
//        }
//    }
//}
