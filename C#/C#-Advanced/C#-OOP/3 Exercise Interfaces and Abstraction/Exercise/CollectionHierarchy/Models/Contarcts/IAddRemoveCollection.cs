namespace CollectionHierarchy.Models.Contarcts
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
