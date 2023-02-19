SELECT CONCAT_WS(' ', FirstName, LastName) AS FullName, Email, MAX(Rating) AS Rating
	FROM Creators c
		JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
		JOIN Boardgames b ON cb.BoardgameId = b.Id
	WHERE Email LIKE '%.com'
	GROUP BY FirstName, LastName, Email