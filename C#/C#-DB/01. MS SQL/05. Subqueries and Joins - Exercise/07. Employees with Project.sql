SELECT TOP(5) e.EmployeeID, FirstName, [Name] AS ProjectName
	FROM Employees e
		JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE StartDate > '2002-08-13'
		AND EndDate IS NULL
	ORDER BY e.EmployeeID