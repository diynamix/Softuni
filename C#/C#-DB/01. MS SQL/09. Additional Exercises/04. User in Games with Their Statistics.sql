SELECT 
		u.Username, 
		g.[Name] as Game, 
		MAX(ch.[Name]) as [Character],
		SUM(s.Strength) + MAX(bs.Strength) + MAX(chs.Strength) as Strength,
		SUM(s.Defence) + MAX(bs.Defence) + MAX(chs.Defence) as Defence,
		SUM(s.Speed) + MAX(bs.Speed) + MAX(chs.Speed) as Speed,
		SUM(s.Mind) + MAX(bs.Mind) + MAX(chs.Mind) as Mind,
		SUM(s.Luck) + MAX(bs.Luck) + MAX(chs.Luck) as luck
	FROM Users AS u
		JOIN UsersGames ug ON u.id = ug.UserId
		JOIN Games g ON ug.GameId = g.Id
		JOIN GameTypes gt ON g.GameTypeId = gt.Id
		JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
		JOIN items i ON ugi.ItemId = i.Id
		JOIN [Statistics] s ON i.StatisticId = s.Id
		JOIN [Statistics] bs ON gt.BonusStatsId = bs.Id
		JOIN Characters ch ON ug.CharacterId = ch.Id
		JOIN [Statistics] chs ON ch.StatisticId = chs.Id
	GROUP BY u.Username, g.[Name]
	ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC