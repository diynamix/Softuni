namespace MiniORM.App;

using Data;
using MiniORM.App.Data.Entities;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniDbContext dbContext = new SoftUniDbContext(Config.ConnectionString);

        // Add new employee
        /*
        Employee employee = new Employee()
        {
            FirstName = "Test",
            LastName = "Testov",
            DepartmentId = dbContext.Departments.First().Id,
            IsEmployed = true,
        };

        dbContext.Employees.Add(employee);
        */

        // Delete the new employee after adding id
        /*
        Employee employee = dbContext
            .Employees.First(e => e.FirstName == "Test");

        dbContext.Employees.Remove(employee);
        */

        dbContext.SaveChanges();
    }
}