namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using FastFood.Data;
    using Models;
    using Web.ViewModels.Items;

    public class ItemService : IItemService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public ItemService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreateItemInputModels model)
        {
            Item item = mapper.Map<Item>(model);

            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemsAllViewModel>> GetAllAsync()
            => await context.Items
                .ProjectTo<ItemsAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        public async Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync()
            => await context.Categories
                .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}
