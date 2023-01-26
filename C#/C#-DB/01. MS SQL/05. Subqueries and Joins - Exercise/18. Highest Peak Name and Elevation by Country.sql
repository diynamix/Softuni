WITH CTE_Ranking AS (
	SELECT 
			CountryName AS Country,
			MountainRange,
			PeakName,
			Elevation,
			DENSE_RANK() OVER (
				PARTITION BY CountryName
				ORDER BY Elevation DESC
			) AS [PeakRank]
		FROM Countries c
			LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
			LEFT JOIN Mountains m ON mc.MountainId = m.Id
			LEFT JOIN Peaks p ON p.MountainId = m.Id
)
	
SELECT TOP(5)
		Country,
		CASE
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
		END AS [Highest Peak Name],
		CASE
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
		END AS [Highest Peak Elevation],
		CASE
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
		END AS Mountain
	FROM CTE_Ranking
	WHERE PeakRank = 1
	ORDER BY Country, [Highest Peak Name] 