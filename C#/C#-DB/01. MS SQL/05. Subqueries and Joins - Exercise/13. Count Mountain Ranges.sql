SELECT 
		c.CountryCode,
		(SELECT COUNT(*)
			FROM MountainsCountries mc
			WHERE mc.CountryCode = c.CountryCode
		) AS MountainRanges
	FROM Countries c
	WHERE c.CountryCode IN ('BG', 'RU', 'US')