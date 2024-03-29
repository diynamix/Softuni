CREATE TABLE Monasteries (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX) NOT NULL,
	CountryCode CHAR(2) NOT NULL REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries([Name], CountryCode)
	VALUES
('Rila Monastery �St. Ivan of Rila�', 'BG'), 
('Bachkovo Monastery �Virgin Mary�', 'BG'),
('Troyan Monastery �Holy Mother''s Assumption�', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('S�mela Monastery', 'TR')

--ALTER TABLE Countries
--	ADD IsDeleted BIT NOT NULL DEFAULT 0

UPDATE Countries
	SET IsDeleted = 1
	WHERE CountryCode IN (
		SELECT cc.CountryCode
			FROM (
				SELECT c.CountryCode, COUNT(cr.RiverId) AS RiversCount
					FROM Countries c
						JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
					GROUP BY c.CountryCode
					HAVING COUNT(cr.RiverId) > 3
			) AS cc
	)

SELECT m.[Name] AS Monastery, c.CountryName AS Country
	FROM Monasteries m
		JOIN Countries c ON m.CountryCode = c.CountryCode
	WHERE IsDeleted = 0
	ORDER BY Monastery