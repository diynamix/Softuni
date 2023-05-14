namespace PetStore.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    
    using Common;
    using Data.Models;
    using Services.Mapping;

    public class CreateCategoryInputModel : IMapTo<Category>
    {
        [Required]
        //[MinLength(CategoryInputModelValidationConstants.NameMinLength)]
        //[MaxLength(CategoryInputModelValidationConstants.NameMaxLength)]
        [StringLength( CategoryInputModelValidationConstants.NameMaxLength, 
            MinimumLength = CategoryInputModelValidationConstants.NameMinLength,
            ErrorMessage = CategoryInputModelValidationConstants.InvalidNameErrorMessage)]
        public string Name { get; set; } = null!;
    }
}
