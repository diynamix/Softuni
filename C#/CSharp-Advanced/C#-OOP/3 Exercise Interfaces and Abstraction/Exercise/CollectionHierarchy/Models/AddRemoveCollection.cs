namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contarcts;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private List<T> collection;

        public AddRemoveCollection()
        {
            collection = new List<T>();
        }

        public int Add(T element)
        {
            collection.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            T removed = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return removed;
        }
    }
}
