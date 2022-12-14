namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>();

            while (collection.Count < 10)
            {
                try
                {
                    if (!collection.Any())
                    {
                        collection.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        collection.Add(ReadNumber(collection.Max(), 100));
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(String.Join(", ", collection));
        }

        public static int ReadNumber(int start, int end)
        {
            int number;
            try
            {
                number = int.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
