namespace PetStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Mapping;
    using PetStore.Data.Common.Repos;
    using PetStore.Data.Models;
    using Web.ViewModels.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        //private readonly IMapper mapper;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
            //this.mapper = mapper;
        }

        public async Task CreteAsync(CreateCategoryInputModel inputModel)
        {
            //Category category = this.mapper.Map<Category>(inputModel);
            Category category = AutoMapperConfig.MapperInstance.Map<Category>(inputModel);
            await this.repository.AddAsync(category);
            await this.repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListCategoryViewModel>> GetAllAsync()
        {
            return await this.repository
                .AllAsNoTracking()
                .To<ListCategoryViewModel>()
                .ToArrayAsync();
        }

        public async Task<IEnumerable<ListCategoryViewModel>> GetAllWithPaginationAsync(int pageNumber)
        {
            return await this.repository
                .AllAsNoTracking()
                .Skip((pageNumber - 1) * 2)
                .Take(2)
                .To<ListCategoryViewModel>()
                .ToArrayAsync();
        }

        public async Task<EditCategoryViewModel> GetByIdAndPrepareForEditAsync(int id)
        {
            Category categoryToEdit = await this.repository
                .AllAsNoTracking()
                .FirstAsync(c => c.Id == id);

            return AutoMapperConfig.MapperInstance.Map<EditCategoryViewModel>(categoryToEdit);
        }

        public async Task EditCategoryAsync(EditCategoryViewModel inputModel)
        {
            Category categoryToUpdate = await this.repository
                .All()
                .FirstAsync(c => c.Id == inputModel.Id);

            categoryToUpdate.Name = inputModel.Name;
            this.repository.Update(categoryToUpdate);
            await this.repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
            => await this.repository
                .AllAsNoTracking()
                .AnyAsync(c => c.Id == id);
    }
}
