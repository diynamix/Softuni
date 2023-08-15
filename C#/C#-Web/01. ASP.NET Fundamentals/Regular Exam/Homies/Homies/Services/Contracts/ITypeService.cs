namespace Homies.Services.Contracts
{
    using Models.Type;

    public interface ITypeService
    {
        Task<ICollection<TypeAllDataModel>> GetAllTypesAsync();
    }
}
