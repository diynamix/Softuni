SELECT g.[Name], gt.[Name], u.Username, ug.[Level], ug.Cash, c.[Name]
	FROM UsersGames ug
		JOIN Games g ON ug.GameId = g.Id
		JOIN GameTypes gt ON g.GameTypeId = gt.Id
		JOIN Users u ON ug.UserId = u.Id
		JOIN Characters c ON ug.CharacterId = c.Id
	ORDER BY ug.[Level] DESC, u.Username, g.[Name]