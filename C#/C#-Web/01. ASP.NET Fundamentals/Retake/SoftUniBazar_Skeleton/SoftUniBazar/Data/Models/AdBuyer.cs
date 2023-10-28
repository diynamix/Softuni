namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Build.Framework;

    public class AdBuyer
    {
        [Required]
        [ForeignKey(nameof(Buyer))]
        public string BuyerId { get; set; } = null!;

        [Required]
        public IdentityUser Buyer { get; set; } = null!;

        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        [Required]
        public Ad Ad { get; set; } = null!;
    }
}
