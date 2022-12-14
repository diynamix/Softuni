﻿using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddLast(3);
            list.AddFirst(4);

            //list.RemoveFirst();
            //list.RemoveLast();

            list.ForEach(number =>
            {
                Console.WriteLine($"Each number in list: {number}");
            });

            Console.WriteLine(String.Join(", ", list.ToArray()));

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}