using System;
namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<int> listInt = new DoublyLinkedList<int>();

            listInt.AddFirst(3);
            listInt.AddFirst(2);
            listInt.AddFirst(1);
            listInt.AddLast(4);

            Console.WriteLine("RemoveFirst: " + listInt.RemoveFirst());
            Console.WriteLine("RemoveLast: " + listInt.RemoveLast());

            int[] arrInt = listInt.ToArray();

            listInt.ForEach(i => Console.WriteLine(i));

            // --------------------------------------------------------------

            DoublyLinkedList<string> listStr = new DoublyLinkedList<string>();

            listStr.AddFirst("c");
            listStr.AddFirst("b");
            listStr.AddFirst("a");
            listStr.AddLast("d");

            Console.WriteLine("RemoveFirst: " + listStr.RemoveFirst());
            Console.WriteLine("RemoveLast: " + listStr.RemoveLast());

            string[] arrStr = listStr.ToArray();

            listStr.ForEach(i => Console.WriteLine(i));
        }
    }
}