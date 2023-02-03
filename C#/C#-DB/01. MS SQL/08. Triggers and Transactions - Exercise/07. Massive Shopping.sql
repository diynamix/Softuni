DECLARE @UserGameId INT = (
	SELECT ug.Id
		FROM UsersGames ug 
			JOIN Users u ON ug.UserId = u.Id
			JOIN Games g ON ug.GameId = g.Id
		WHERE u.Username = 'Stamat' AND g.[Name] = 'Safflower'
)

DECLARE @ItemsCost DECIMAL(18, 4)

-- 11-12 level

DECLARE @MinLevel INT = 11
DECLARE @MaxLevel INT = 12
DECLARE @PlayerCash DECIMAL(18, 4) = (
	SELECT Cash
		FROM UsersGames
		WHERE Id = @UserGameId
)

SET @ItemsCost = (
	SELECT SUM(Price)
		FROM Items
		WHERE MinLevel BETWEEN @MinLevel AND @MaxLevel
)

IF (@PlayerCash >= @ItemsCost)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
			SET Cash -= @ItemsCost
			WHERE Id = @UserGameId
		  
		INSERT INTO UserGameItems (ItemId, UserGameId) (
			SELECT Id, @UserGameId
				FROM Items
				WHERE MinLevel BETWEEN @MinLevel AND @MaxLevel
		)
	COMMIT     
END

-- 19-21 level

SET @MinLevel = 19
SET @MaxLevel = 21
SET @PlayerCash = (
	SELECT Cash
		FROM UsersGames
		WHERE Id = @UserGameId
)

SET @ItemsCost = (
	SELECT SUM(Price)
		FROM Items
		WHERE MinLevel BETWEEN @MinLevel AND @MaxLevel
)

IF (@PlayerCash >= @ItemsCost)
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
			SET Cash -= @ItemsCost
			WHERE Id = @UserGameId
		  
		INSERT INTO UserGameItems (ItemId, UserGameId) (
			SELECT Id, @UserGameId
				FROM Items
				WHERE MinLevel BETWEEN @MinLevel AND @MaxLevel
		)
	COMMIT
END

-- result

SELECT i.[Name] AS [Item Name]
	FROM UserGameItems ugi
		JOIN Items i ON i.Id = ugi.ItemId
		JOIN UsersGames ug ON ug.Id = ugi.UserGameId
		JOIN Games g ON g.Id = ug.GameId
	WHERE g.[Name] = 'Safflower'
	ORDER BY [Item Name]