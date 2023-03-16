namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using FastFood.Data;
    using FastFood.Web.ViewModels.Items;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Web.ViewModels.Orders;

    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public OrderService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreateOrderInputModel model)
        {
            Order order = mapper.Map<Order>(model);

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderAllViewModel>> GetAllAsync()
            => await context.Orders
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        public CreateOrderViewModel GetAllEmployeesAndItemsAsync()
            => new CreateOrderViewModel()
            {
                Items = context.Items.Select(i => i.Id).ToList(),
                Employees = context.Employees.Select(e => e.Id).ToList(),
            };
    }
}
