namespace PetStore.Web.ViewModels.Categories
{
    using PetStore.Data.Models;
    using PetStore.Services.Mapping;

    public class ListCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
