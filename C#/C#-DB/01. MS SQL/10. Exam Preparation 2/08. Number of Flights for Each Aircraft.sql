SELECT
		a.Id AS AircraftId,
		Manufacturer,
		FlightHours,
		COUNT(*) AS FlightDestinationsCount,
		ROUND(AVG(TicketPrice), 2) AS AvgPrice
	FROM FlightDestinations fd
		LEFT JOIN Aircraft a ON fd.AircraftId = a.Id
	GROUP BY a.Id, a.Manufacturer, a.FlightHours
	HAVING COUNT(*) >= 2
	ORDER BY FlightDestinationsCount DESC, AircraftId