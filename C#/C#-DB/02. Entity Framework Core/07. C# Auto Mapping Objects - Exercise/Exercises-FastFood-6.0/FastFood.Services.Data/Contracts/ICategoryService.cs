namespace FastFood.Services.Data.Contracts
{
    using Web.ViewModels.Categories;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel model);

        Task<IEnumerable<CategoryAllViewModel>> GetAllAsync();
    }
}
