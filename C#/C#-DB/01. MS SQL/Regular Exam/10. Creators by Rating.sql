SELECT LastName, CEILING(AVG(Rating)) AS AverageRating, p.[Name] AS PublisherName
	FROM Creators c
		JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
		JOIN Boardgames b ON cb.BoardgameId = b.Id
		JOIN Publishers p ON b.PublisherId = p.Id
	WHERE p.[Name] = 'Stonemaier Games'
	GROUP BY LastName, p.[Name]
	ORDER BY AVG(Rating) DESC