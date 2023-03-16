namespace FastFood.Services.Data.Contracts
{
    using Web.ViewModels.Employees;

    public interface IEmployeeService
    {
        Task RegisterAsync(RegisterEmployeeInputModel model);

        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();

        Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositionsAsync();
    }
}
