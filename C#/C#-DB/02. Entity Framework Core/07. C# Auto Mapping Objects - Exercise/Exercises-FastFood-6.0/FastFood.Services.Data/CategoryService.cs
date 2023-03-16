namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using FastFood.Data;
    using Models;
    using Web.ViewModels.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public CategoryService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        //public async Task GetImageNames(CreateCategoryInputModel model)
        //{
        //    string[] images = Directory
        //        .GetFiles(Directory.GetCurrentDirectory())
        //        .Where(n => n.EndsWith(".jpg"))
        //        .ToArray();

        //    //string[] imgExt = { ".jpeg", ".bnp", ".png", ".svg" };
        //    //DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
        //    //string[] imageNames = di
        //    //    .GetFiles()
        //    //    .Where(f => imgExt.Contains(f.Extension))
        //    //    .Select(f => f.Name)
        //    //    .ToArray();
        //}

        public async Task CreateAsync(CreateCategoryInputModel model)
        {
            Category category = mapper.Map<Category>(model);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryAllViewModel>> GetAllAsync()
            => await context.Categories
                .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}
