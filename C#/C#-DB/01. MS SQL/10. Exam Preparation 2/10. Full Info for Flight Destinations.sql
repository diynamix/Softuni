SELECT AirportName, [Start] AS DayTime, TicketPrice, FullName, Manufacturer, Model
	FROM FlightDestinations fd
		LEFT JOIN Airports ap ON fd.AirportId = ap.Id
		LEFT JOIN Passengers p ON fd.PassengerId = p.Id
		LEFT JOIN Aircraft ac ON fd.AircraftId = ac.Id
	WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20
		AND TicketPrice > 2500
	ORDER BY Model