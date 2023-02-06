INSERT INTO Passengers
	SELECT
			CONCAT_WS(' ', FirstName, LastName) AS FullName,
			FirstName + LastName + '@gmail.com' AS Email
		FROM Pilots
		WHERE Id BETWEEN 5 AND 15