namespace SoftUniBazar.Models.Ad
{
    using System.ComponentModel.DataAnnotations;

    public class AdAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Added on")]
        public string CreatedOn { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Price { get; set; } = null!;

        [Display(Name = "Seller")]
        public string Owner { get; set; } = null!;
    }
}
