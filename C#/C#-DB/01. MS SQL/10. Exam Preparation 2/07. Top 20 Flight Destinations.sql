SELECT TOP(20) fd.Id, [Start], FullName, AirportName, TicketPrice
	FROM FlightDestinations fd
		LEFT JOIN Passengers p ON fd.PassengerId = p.Id
		LEFT JOIN Airports a ON fd.AirportId = a.Id
	WHERE DAY([Start]) % 2 = 0
	ORDER BY TicketPrice DESC, AirportName