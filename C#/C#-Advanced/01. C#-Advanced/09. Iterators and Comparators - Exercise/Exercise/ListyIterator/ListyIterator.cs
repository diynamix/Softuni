using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    internal class ListyIterator<T>
    {
        private List<T> collection;
        private int index = 0;

        public ListyIterator(params T[] array)
        {
            collection = array.ToList();
        }

        public bool Move()
        {
            if (index < collection.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index < collection.Count - 1;
        }

        public string Print()
        {
            try
            {
                return collection[index].ToString();
            }
            catch (Exception)
            {
                return "Invalid Operation!";
            }
        }
    }
}
