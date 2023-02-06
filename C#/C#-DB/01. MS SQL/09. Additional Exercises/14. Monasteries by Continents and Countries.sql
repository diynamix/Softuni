UPDATE Countries
	SET CountryName = 'Burma'
	WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries([Name], CountryCode)
	SELECT
		'Hanga Abbey',
		CountryCode
			FROM Countries
			WHERE CountryName = 'Tanzania'

INSERT INTO Monasteries([Name], CountryCode)
	SELECT
		'Myin-Tin-Daik',
		CountryCode
			FROM Countries
			--WHERE CountryCode = 'MM'
			WHERE CountryName = 'Myanmar'

SELECT 
		cc.ContinentName, 
		c.CountryName, 
		COUNT(m.Id) AS MonasteriesCount
	FROM Continents cc
		RIGHT JOIN Countries c ON cc.ContinentCode = c.ContinentCode
		LEFT JOIN Monasteries m ON c.CountryCode = m.CountryCode
	WHERE c.IsDeleted = 0
	GROUP BY cc.ContinentName, c.CountryCode, c.CountryName
	ORDER BY MonasteriesCount DESC, c.CountryName