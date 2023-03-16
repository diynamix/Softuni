namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.EntityConfiguration;

    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
        }

        [Key]
        //[MaxLength(ValidationConstants.GuidMaxLength)]
        public string Id { get; set; }

        [MaxLength(EntitiesValidation.EmployeeNameMaxLength)]
        public string Name { get; set; } = null!;

        [Range(15, 80)]
        public int Age { get; set; }

        [MaxLength(EntitiesValidation.EmployeeAddressMaxLength)]
        public string Address { get; set; } = null!;

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}