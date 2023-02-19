SELECT b.Id, b.[Name], YearPublished, c.[Name] AS CategoryName
	FROM Boardgames b
		JOIN Categories c ON b.CategoryId = c.Id
	WHERE c.[Name] IN ('Strategy Games', 'Wargames')
	ORDER BY YearPublished DESC