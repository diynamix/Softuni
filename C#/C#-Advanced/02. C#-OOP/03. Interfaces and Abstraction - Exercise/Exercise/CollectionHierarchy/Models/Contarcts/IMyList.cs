namespace CollectionHierarchy.Models.Contarcts
{
    public interface IMyList<T> : IAddCollection<T>, IAddRemoveCollection<T>
    {
        int Used { get; }
    }
}
