CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
	SELECT
			ap.AirportName,
			p.FullName,
			CASE
				WHEN fd.TicketPrice <= 400 THEN 'Low'
				WHEN fd.TicketPrice <= 1500 THEN 'Medium'
				ELSE 'High'
			END AS LevelOfTickerPrice,
			ac.Manufacturer,
			ac.Condition,
			act.TypeName
		FROM Airports ap
			LEFT JOIN FlightDestinations fd ON ap.Id = fd.AirportId
			LEFT JOIN Passengers p ON fd.PassengerId = p.Id
			LEFT JOIN Aircraft ac ON fd.AircraftId = ac.Id
			LEFT JOIN AircraftTypes act ON ac.TypeId = act.Id
		WHERE ap.AirportName = @airportName
		ORDER BY ac.Manufacturer, p.FullName