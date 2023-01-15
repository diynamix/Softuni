using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public int CountGreaterNums(T compare)
        {
            int counter = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                if (compare.CompareTo(Items[i]) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
