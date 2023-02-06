SELECT
		u.Username,
		g.[Name],
		COUNT(ugi.ItemId) AS [Items Count],
		SUM(i.Price) AS [Items Price]
	FROM UserGameItems ugi
		JOIN UsersGames ug ON ugi.UserGameId = ug.Id
		JOIN Games g ON ug.GameId = g.Id
		JOIN Users u ON ug.UserId = u.Id
		JOIN Items i ON ugi.ItemId = i.Id
	GROUP BY u.Username, g.[Name]
	HAVING COUNT(ugi.ItemId) >= 10
	ORDER BY [Items Count] DESC, [Items Price] DESC, Username