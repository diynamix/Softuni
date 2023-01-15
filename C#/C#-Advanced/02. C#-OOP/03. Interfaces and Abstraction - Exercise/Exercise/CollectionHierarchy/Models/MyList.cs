namespace CollectionHierarchy.Models
{
    using System;
    using System.Collections.Generic;

    using Contarcts;

    public class MyList<T> : IMyList<T>
    {
        private List<T> collection;

        public MyList()
        {
            collection = new List<T>();
        }

        public int Used => collection.Count;

        public int Add(T element)
        {
            collection.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            T removed = collection[0];
            collection.RemoveAt(0);
            return removed;
        }
    }
}
