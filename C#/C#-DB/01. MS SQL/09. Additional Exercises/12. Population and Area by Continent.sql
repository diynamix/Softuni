SELECT
		ContinentName,
		SUM(CAST(c.AreaInSqKm AS BIGINT)) AS CountriesArea,
		SUM(CAST(c.[Population] AS BIGINT)) AS CountriesPopulation
	FROM Countries c
		JOIN Continents cc ON c.ContinentCode = cc.ContinentCode
	GROUP BY cc.ContinentName
	ORDER BY CountriesPopulation DESC