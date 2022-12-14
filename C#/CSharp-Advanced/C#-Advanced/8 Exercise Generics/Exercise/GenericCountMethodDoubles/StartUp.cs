using System;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                double item = double.Parse(Console.ReadLine());
                
                box.Items.Add(item);
            }

            double compere = double.Parse(Console.ReadLine());

            int greaterNums = box.CountGreaterNums(compere);

            Console.WriteLine(greaterNums);
        }
    }
}
