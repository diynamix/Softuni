CREATE PROC usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(7))
AS
BEGIN
	SELECT FirstName, LAstName
		FROM Employees
		WHERE @LevelOfSalary = dbo.ufn_GetSalaryLevel(Salary)
END