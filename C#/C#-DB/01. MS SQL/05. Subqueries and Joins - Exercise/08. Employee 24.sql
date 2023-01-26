SELECT
		e.EmployeeID,
		FirstName,
		CASE
			WHEN YEAR(StartDate) >= '2005' THEN NULL
			ELSE [Name]
		END AS ProjectName
	FROM Employees e
		JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24