UPDATE Aircraft
	SET Condition = 'A'
		WHERE Condition IN ('C', 'B')
			AND (FlightHours IS Null OR FlightHours <= 100)
			AND [Year] >= 2013