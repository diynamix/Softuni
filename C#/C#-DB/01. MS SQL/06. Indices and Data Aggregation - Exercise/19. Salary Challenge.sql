SELECT TOP 10
		FirstName,
		LastName,
		e.DepartmentID
	FROM Employees e
		JOIN (
			SELECT DepartmentID, AVG(Salary) AS AvgSalary
			FROM Employees
			GROUP BY DepartmentID
		) AS AvgTable
			ON e.DepartmentID = AvgTable.DepartmentID
	WHERE Salary > AvgTable.AvgSalary