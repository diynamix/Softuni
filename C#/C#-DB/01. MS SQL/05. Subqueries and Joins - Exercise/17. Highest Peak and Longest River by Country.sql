SELECT TOP(5)
		CountryName,
		MAX(Elevation) AS HighestPeakElevation,
		MAX([Length]) AS LongestRiverLength
	FROM Countries c
		JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		JOIN Mountains m ON mc.MountainId = m.Id
		JOIN Peaks p ON m.Id = p.MountainId
		JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
		JOIN Rivers r ON cr.RiverId = r.Id
	GROUP BY CountryName
	ORDER BY
		HighestPeakElevation DESC,
		LongestRiverLength DESC,
		CountryName