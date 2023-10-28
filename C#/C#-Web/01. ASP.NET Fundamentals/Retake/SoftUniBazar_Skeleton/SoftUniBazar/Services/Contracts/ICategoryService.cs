namespace SoftUniBazar.Services.Contracts
{
    using Models.Category;

    public interface ICategoryService
    {
        Task<ICollection<CategoryAllDataModel>> GetAllCategoriesAsync();
    }
}
