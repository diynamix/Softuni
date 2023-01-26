SELECT TOP(5) EmployeeId, JobTitle, e.AddressId, AddressText
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
	ORDER BY e.AddressID