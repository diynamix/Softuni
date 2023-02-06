SELECT FullName,
		COUNT(DISTINCT a.Id) AS CountOfAircraft,
		SUM(TicketPrice) AS TotalPayed
	FROM Passengers p
		JOIN FlightDestinations fd ON p.Id = fd.PassengerId
		JOIN Aircraft a ON fd.AircraftId = a.Id
	WHERE FullName LIKE '_a%'
	GROUP BY FullName
	HAVING COUNT(DISTINCT a.Id) > 1
	ORDER BY FullName