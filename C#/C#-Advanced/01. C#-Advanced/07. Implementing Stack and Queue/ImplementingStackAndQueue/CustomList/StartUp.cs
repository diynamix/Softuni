using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(100);

            list[0] = 234;

            list.AddRange(new[] { 1, 2, 3, 4 });

            Console.WriteLine(list.RemoveAt(2));
            Console.WriteLine(list.RemoveAt(2));
            Console.WriteLine(list.RemoveAt(2));

            
            Console.WriteLine(list.Contains(234));
            Console.WriteLine(list.Contains(100));

            list.InsetAt(0, -5);

            list.Swap(0, 1);

            list.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            Console.WriteLine(list.Count);
        }
    }
}