namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using FastFood.Data;
    using Web.ViewModels.Employees;
    using FastFood.Models;

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public EmployeeService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
            => await context.Employees
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task RegisterAsync(RegisterEmployeeInputModel model)
        {
            Employee employee = mapper.Map<Employee>(model);

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositionsAsync()
            => await context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}
