SELECT
		c.CountryName,
		cc.ContinentName,
		COUNT(r.RiverName) AS RiversCount,
		CASE
			WHEN SUM(r.[Length]) IS NULL THEN 0
			ELSE SUM(r.[Length])
		END AS TotalLength
	FROM Countries c
		LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers r ON cr.RiverId = r.Id
		LEFT JOIN Continents cc ON c.ContinentCode = cc.ContinentCode
	GROUP BY c.CountryName, cc.ContinentName
	ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName