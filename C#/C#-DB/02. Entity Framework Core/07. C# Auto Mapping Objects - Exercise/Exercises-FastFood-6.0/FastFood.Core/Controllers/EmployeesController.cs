namespace FastFood.Web.Controllers
{
    using System;
    using FastFood.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            IEnumerable<RegisterEmployeeViewModel> availablePositions = await employeeService.GetAllAvailablePositionsAsync();

            return View(availablePositions);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register");
            }

            await employeeService.RegisterAsync(model);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<EmployeesAllViewModel> employees = await employeeService.GetAllAsync();

            return View(employees.ToList());
        }
    }
}
