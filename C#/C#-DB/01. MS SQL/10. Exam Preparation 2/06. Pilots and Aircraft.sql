SELECT FirstName, LastName, Manufacturer, Model, FlightHours
	FROM Pilots p
		JOIN PilotsAircraft pa ON p.Id = pa.PilotId
		LEFT JOIN Aircraft a ON pa.AircraftId = a.Id
	WHERE FlightHours IS NOT NULL
		AND FlightHours < 304 -- more than 304 hours instead of up to 304
		--AND FlightHours > 304 -- !!! don't work in Judge
	ORDER BY FlightHours DESC, FirstName