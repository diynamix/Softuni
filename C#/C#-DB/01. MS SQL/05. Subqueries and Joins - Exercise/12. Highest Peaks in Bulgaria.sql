SELECT 
		c.CountryCode,
		MountainRange,
		PeakName,
		Elevation
	FROM Countries c
		JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		JOIN Mountains m ON mc.MountainId = m.Id
		JOIN Peaks p ON m.Id = p.MountainId
	WHERE c.CountryCode = 'BG'
		AND Elevation > 2835
	ORDER BY Elevation DESC