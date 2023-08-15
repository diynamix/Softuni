namespace Homies.Models.Event
{
    using System.ComponentModel.DataAnnotations;

    using Type;

    using static Common.EntityValidationConstants.Event;

    public class EventFormModel
    {
        public EventFormModel()
        {
            Types = new HashSet<TypeAllDataModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        public ICollection<TypeAllDataModel> Types { get; set; } = null!;

        public int TypeId { get; set; }
    }
}
