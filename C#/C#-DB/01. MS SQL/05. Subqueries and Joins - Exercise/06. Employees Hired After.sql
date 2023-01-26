SELECT FirstName, LastName, HireDate, [Name] AS DeptName
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE HireDate > '1999-01-01'
		AND [Name] IN ('Sales', 'Finance')
	ORDER BY HireDate