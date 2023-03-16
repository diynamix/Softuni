namespace FastFood.Services.Data.Contracts
{
    using Web.ViewModels.Orders;

    public interface IOrderService
    {
        Task CreateAsync(CreateOrderInputModel model);

        Task<IEnumerable<OrderAllViewModel>> GetAllAsync();

        CreateOrderViewModel GetAllEmployeesAndItemsAsync();
    }
}
