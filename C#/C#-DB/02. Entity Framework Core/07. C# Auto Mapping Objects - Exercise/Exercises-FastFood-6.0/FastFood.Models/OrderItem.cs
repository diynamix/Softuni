﻿namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Common.EntityConfiguration;

    public class OrderItem
    {
        [ForeignKey(nameof(Order))]
        //[MaxLength(ValidationConstants.GuidMaxLength)]
        public string OrderId { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;

        [ForeignKey(nameof(Item))]
        //[MaxLength(ValidationConstants.GuidMaxLength)]
        public string ItemId { get; set; } = null!;

        public virtual Item Item { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}