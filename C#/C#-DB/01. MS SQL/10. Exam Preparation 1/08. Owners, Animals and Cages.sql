SELECT
		o.[Name] + '-' + a.[Name] AS OwnersAnimals,
		o.PhoneNumber,
		ac.CageId
	FROM Owners o
		JOIN Animals a ON o.Id = a.OwnerId
		JOIN AnimalTypes [at] ON a.AnimalTypeId = [at].Id
		JOIN AnimalsCages ac ON a.Id = ac.AnimalId
	WHERE [at].AnimalType = 'Mammals'
	ORDER BY o.[Name], a.[Name] DESC