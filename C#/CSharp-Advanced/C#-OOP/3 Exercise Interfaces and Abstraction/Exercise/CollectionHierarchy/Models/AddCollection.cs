namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contarcts;

    public class AddCollection<T> : IAddCollection<T>
    {
        private List<T> collection;

        public AddCollection()
        {
            collection = new List<T>();
        }

        public int Add(T element)
        {
            collection.Add(element);
            return collection.Count - 1;
        }
    }
}
