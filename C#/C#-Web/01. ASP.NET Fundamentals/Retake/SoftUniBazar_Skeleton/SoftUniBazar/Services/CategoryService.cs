namespace SoftUniBazar.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;
    using Models.Category;

    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext dbContext;

        public CategoryService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<CategoryAllDataModel>> GetAllCategoriesAsync()
        {
            return await dbContext.Categories
                .Select(t => new CategoryAllDataModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }
    }
}
