﻿using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int item = int.Parse(Console.ReadLine());
                
                box.Items.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
