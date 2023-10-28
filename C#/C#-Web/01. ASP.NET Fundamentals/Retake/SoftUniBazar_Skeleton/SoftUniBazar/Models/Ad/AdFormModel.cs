namespace SoftUniBazar.Models.Ad
{
    using System.ComponentModel.DataAnnotations;

    using Category;

    using static Common.EntityValidationConstants.Ad;

    public class AdFormModel
    {
        public AdFormModel()
        {
            Categories = new HashSet<CategoryAllDataModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public ICollection<CategoryAllDataModel> Categories { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
