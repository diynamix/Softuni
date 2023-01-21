CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName
		FROM Employees
		--WHERE DATEPART(YEAR, HireDate) > 2000
		WHERE YEAR(HireDate) > 2000