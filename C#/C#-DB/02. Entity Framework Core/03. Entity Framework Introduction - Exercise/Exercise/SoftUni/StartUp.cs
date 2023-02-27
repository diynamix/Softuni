namespace SoftUni
{
    using System.Globalization;
    using System.Text;

    using Microsoft.EntityFrameworkCore;

    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = String.Empty;

            //03
            result = GetEmployeesFullInformation(dbContext);
            //04
            //result = GetEmployeesWithSalaryOver50000(dbContext);
            //05
            //result = GetEmployeesFromResearchAndDevelopment(dbContext);
            //06
            //result = AddNewAddressToEmployee(dbContext);
            //07
            //result = GetEmployeesInPeriod(dbContext);
            //08
            //result = GetAddressesByTown(dbContext);
            //09
            //result = GetEmployee147(dbContext);
            //10
            //result = GetDepartmentsWithMoreThan5Employees(dbContext);
            //11
            //result = GetLatestProjects(dbContext);
            //12
            //result = IncreaseSalaries(dbContext);
            //13
            //result = GetEmployeesByFirstNameStartingWithSa(dbContext);
            //14
            //result = DeleteProjectById(dbContext);
            //15
            //result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        // Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithSalary = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                })
                .ToArray();

            foreach (var e in employeesWithSalary)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesRnD = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary,
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var e in employeesRnD)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            // context.Addresses.Add(newAddress);

            Employee? employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = newAddress;

            context.SaveChanges();

            string[] employeeAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();

            return String.Join(Environment.NewLine, employeeAddresses);
        }

        // Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithProjects = context.Employees
                //.Where(e => e.EmployeesProjects
                //    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished",
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employeesWithProjects)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] addresses = context.Addresses
                .AsNoTracking()
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees")
                .ToArray();

            return String.Join(Environment.NewLine, addresses);
        }

        // Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            int employeeId = 147;

            Employee? e = context.Employees
                .Find(employeeId);

            Project[] projects = context.EmployeesProjects
                .AsNoTracking()
                .Where(ep => ep.EmployeeId == employeeId)
                .Select(ep => ep.Project)
                .OrderBy(p => p.Name)
                .ToArray();

            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

            foreach (Project p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .AsNoTracking()
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    d.Employees,
                })
                .ToArray();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (Employee e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .AsNoTracking()
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToArray();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            decimal salaryIncreasementPercentage = 12;

            string[] departmentsToIncreaseSalary = { "Engineering", "Tool Design", "Marketing", "Information Services" };

            Employee[] employeesToIncreaseSalary = context.Employees
                .Where(e => departmentsToIncreaseSalary.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (Employee e in employeesToIncreaseSalary)
            {
                e.Salary *= 1 + salaryIncreasementPercentage / 100;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            string[] employees = context.Employees
                .AsNoTracking()
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
                .ToArray();

            return String.Join(Environment.NewLine, employees);
        }

        // Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            // Delete all rows from EmployeeProject that refer to Project with Id 2
            var epToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(epToDelete);

            Project projectToDelete = context.Projects.Find(2)!;
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            string[] projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            return String.Join(Environment.NewLine, projects);
        }

        // Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Seattle";

            Town? townToDelete = context.Towns
                .FirstOrDefault(t => t.Name == townName);

            Address[] addressesInTownToDelete = context.Addresses
                .Where(a => a.Town == townToDelete)
                .ToArray();

            Employee[] employeesToChangeAddress = context.Employees
                .Where(e => addressesInTownToDelete.Any(a => a == e.Address))
                .ToArray();

            foreach (Employee e in employeesToChangeAddress)
            {
                e.AddressId = null;
                e.Address = null;
            }

            context.Towns.Remove(townToDelete!);
            context.Addresses.RemoveRange(addressesInTownToDelete);
            context.SaveChanges();

            return $"{addressesInTownToDelete.Length} addresses in {townName} were deleted";
        }
    }
}