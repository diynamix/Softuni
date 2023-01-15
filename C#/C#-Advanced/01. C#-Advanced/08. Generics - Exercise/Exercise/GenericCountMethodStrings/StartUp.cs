using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string item = Console.ReadLine();
                
                box.Items.Add(item);
            }

            string compere = Console.ReadLine();

            int greaterNums = box.CountGreaterNums(compere);

            Console.WriteLine(greaterNums);
        }
    }
}
