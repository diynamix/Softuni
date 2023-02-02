CREATE PROC usp_GetEmployeesSalaryAboveNumber(@MinSalary DECIMAL(18, 4))
AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE Salary >= @MinSalary