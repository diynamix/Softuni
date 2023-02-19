SELECT TOP(5) b.[Name], Rating, c.[Name] AS CategoryName
	FROM Boardgames b
		JOIN PlayersRanges p ON b.PlayersRangeId = p.Id
		JOIN Categories c ON b.CategoryId = c.Id
	WHERE (Rating > 7.00 AND b.[Name] LIKE '%a%')
		OR (Rating > 7.50 AND PlayersMin >= 2 AND PlayersMax <= 5)
	ORDER BY b.[Name], Rating DESC