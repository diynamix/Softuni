namespace FastFood.Services.Data.Contracts
{
    using Web.ViewModels.Items;

    public interface IItemService
    {
        Task CreateAsync(CreateItemInputModels model);

        Task<IEnumerable<ItemsAllViewModel>> GetAllAsync();

        Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync();
    }
}
