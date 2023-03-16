namespace FastFood.Web.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;
    using Common.Messages;

    public class CreatePositionInputModel
    {
        [MinLength(ViewModelsValidation.PositionNameMinLength)]
        [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
        //[StringLength(ViewModelsValidation.PositionNameMaxLength, MinimumLength = ViewModelsValidation.PositionNameMinLength, ErrorMessage = ErrorMessages.PositionNameErrorMessage)]
        public string PositionName { get; set; } = null!;
    }
}