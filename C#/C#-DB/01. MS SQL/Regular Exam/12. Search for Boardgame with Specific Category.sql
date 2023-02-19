CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
SELECT
		b.[Name],
		YearPublished,
		Rating,
		c.[Name] AS CategoryName,
		p.[Name] AS PublisherName,
		CAST(PlayersMin AS VARCHAR(10)) + ' people' AS MinPlayers,
		CAST(PlayersMax AS VARCHAR(10)) + ' people' AS MaxPlayers
	FROM Boardgames b
		JOIN Categories c ON b.CategoryId = c.Id
		JOIN Publishers p ON b.PublisherId = p.Id
		JOIN PlayersRanges pr ON b.PlayersRangeId = pr.Id
	WHERE c.[Name] = @category
	ORDER BY PublisherName, YearPublished DESC

--EXEC usp_SearchByCategory 'Wargames'