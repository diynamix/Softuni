SELECT [Name], AnimalType, FORMAT(BirthDate, 'dd.MM.yyyy')
	FROM Animals a
		JOIN AnimalTypes [at] ON a.AnimalTypeId = [at].Id
	ORDER BY [Name]