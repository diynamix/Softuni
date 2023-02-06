DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = 'Alex')
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

DECLARE @Item1Id INT = (SELECT Id FROM Items WHERE Name = 'Blackguard')
DECLARE @Item2Id INT = (SELECT Id FROM Items WHERE Name = 'Bottomless Potion of Amplification')
DECLARE @Item3Id INT = (SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)')
DECLARE @Item4Id INT = (SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin')
DECLARE @Item5Id INT = (SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric')
DECLARE @Item6Id INT = (SELECT Id FROM Items WHERE Name = 'Hellfire Amulet')

DECLARE @TotalCost MONEY = (
	SELECT SUM(Price)
		FROM Items
		WHERE Id IN (@Item1Id, @Item2Id, @Item3Id, @Item4Id, @Item5Id, @Item6Id)
)

UPDATE UsersGames
	SET Cash -= @TotalCost
	WHERE Id = @UserGameId

INSERT INTO UserGameItems
	VALUES
		(@Item1Id, @UserGameId),
		(@Item2Id, @UserGameId),
		(@Item3Id, @UserGameId),
		(@Item4Id, @UserGameId),
		(@Item5Id, @UserGameId),
		(@Item6Id, @UserGameId)

SELECT
		u.Username,
		g.[Name],
		ug.Cash,
		i.[Name] AS [Item Name]
	FROM Users u
		JOIN UsersGames ug ON u.Id = ug.UserId
		JOIN Games g ON ug.GameId = g.Id
		JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
		JOIN Items AS i ON ugi.ItemId = i.Id
	WHERE g.Id = @GameId
	ORDER BY i.[Name]