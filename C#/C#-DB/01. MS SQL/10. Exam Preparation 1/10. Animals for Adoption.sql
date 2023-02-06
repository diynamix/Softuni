SELECT [Name], YEAR(BirthDate) AS BirthYear, AnimalType
	FROM Animals a
		LEFT JOIN AnimalTypes [at] ON a.AnimalTypeId = [at].Id
	WHERE
		OwnerId IS NULL
		AND DATEADD(YEAR, 4, BirthDate) > '01/01/2022' -- younger than 4 years instead of 5
		--AND DATEADD(YEAR, 5, BirthDate) > '01/01/2022' -- !!! don't work in Judge
		AND NOT AnimalType = 'Birds'
	ORDER BY [Name]