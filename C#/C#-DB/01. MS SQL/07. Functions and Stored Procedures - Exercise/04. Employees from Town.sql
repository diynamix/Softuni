CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(MAX))
AS
	SELECT e.FirstName, e.LastName
		FROM Towns t
			RIGHT JOIN Addresses a ON t.TownID = a.TownID
			RIGHT JOIN Employees e ON a.AddressID = e.AddressID
		WHERE t.[Name] = @TownName