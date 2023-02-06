SELECT
		cur.CurrencyCode,
		cur.[Description] AS Currency,
		COUNT(c.CountryName) AS NumberOfCountries
	FROM Currencies cur
		LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
	GROUP BY cur.CurrencyCode, cur.[Description]
	ORDER BY NumberOfCountries DESC, Currency


-- 02
SELECT
		cur.CurrencyCode,
		cur.[Description] AS Currency,
		COUNT(c.CountryName) AS NumberOfCountries
	FROM Countries c
		RIGHT JOIN Currencies cur ON c.CurrencyCode = cur.CurrencyCode
	GROUP BY cur.CurrencyCode, cur.[Description]
	ORDER BY NumberOfCountries DESC, Currency