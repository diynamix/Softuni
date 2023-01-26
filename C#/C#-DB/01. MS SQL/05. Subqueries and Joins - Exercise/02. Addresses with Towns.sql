SELECT TOP(50) FirstName, LastName, [Name] AS Town, AddressText
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
	ORDER BY FirstName, LastName