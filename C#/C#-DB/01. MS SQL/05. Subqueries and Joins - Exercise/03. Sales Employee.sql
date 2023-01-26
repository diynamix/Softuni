SELECT EmployeeID, FirstName, LastName, [Name] AS DepartmentName
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE [Name] = 'Sales'
	ORDER BY EmployeeID