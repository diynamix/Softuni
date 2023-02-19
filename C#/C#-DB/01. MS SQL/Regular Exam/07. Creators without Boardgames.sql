SELECT c.Id, CONCAT_WS(' ', FirstName, LastName) AS CreatorName, Email
	FROM Creators c
		LEFT JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
		LEFT JOIN Boardgames b ON cb.BoardgameId = b.Id
	WHERE CreatorId IS NULL
	ORDER BY CreatorName