namespace CollectionHierarchy
{
    using System;

    using Models;

    public class StartUp
    {
        static void Main()
        {
            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] addElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int elementsToRemove = int.Parse(Console.ReadLine());

            foreach (string element in addElements)
            {
                Console.Write(addCollection.Add(element) + " ");
            }
            Console.WriteLine();

            foreach (string element in addElements)
            {
                Console.Write(addRemoveCollection.Add(element) + " ");
            }
            Console.WriteLine();

            foreach (string element in addElements)
            {
                Console.Write(myList.Add(element) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < elementsToRemove; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < elementsToRemove; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}