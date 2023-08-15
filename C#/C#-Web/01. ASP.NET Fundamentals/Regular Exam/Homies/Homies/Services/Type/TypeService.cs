namespace Homies.Services.Type
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Type;

    public class TypeService : ITypeService
    {
        private readonly HomiesDbContext dbContext;

        public TypeService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<TypeAllDataModel>> GetAllTypesAsync()
        {
            return await dbContext.Types
                .Select(t => new TypeAllDataModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }
    }
}
