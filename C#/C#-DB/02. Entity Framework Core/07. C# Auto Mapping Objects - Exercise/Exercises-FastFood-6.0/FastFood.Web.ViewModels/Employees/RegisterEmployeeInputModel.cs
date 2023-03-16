namespace FastFood.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class RegisterEmployeeInputModel
    {
        [MinLength(ViewModelsValidation.EmployeeNameMinLength)]
        [MaxLength(ViewModelsValidation.EmployeeNameMaxLength)]
        public string Name { get; set; } = null!;

        [Range(18, 80)]
        public int Age { get; set; }

        public int PositionId { get; set; }

        //public string PositionName { get; set; } = null!;

        [MinLength(ViewModelsValidation.EmployeeAddressMinLength)]
        [MaxLength(ViewModelsValidation.EmployeeAddressMaxLength)]
        public string Address { get; set; } = null!;
    }
}
