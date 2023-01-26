SELECT ContinentCode, CurrencyCode, CurrencyUsage
	FROM (
		SELECT 
				ContinentCode,
				CurrencyCode,
				COUNT(CurrencyCode) AS CurrencyUsage,
				DENSE_RANK() OVER(
					PARTITION BY ContinentCode
					ORDER BY COUNT(CurrencyCode) DESC
				) AS CurrencyRank
			FROM Countries
			GROUP BY ContinentCode, CurrencyCode
			HAVING COUNT(CurrencyCode) > 1
	) AS Ranking
	WHERE CurrencyRank = 1
	ORDER BY ContinentCode


-- 02

--WITH CTE_Ranking (ContinentCode, CurrencyCode, CurrencyUsage, CurrencyRank) AS (
WITH CTE_Ranking AS (
	SELECT 
			ContinentCode,
			CurrencyCode,
			COUNT(CurrencyCode) AS CurrencyUsage,
			DENSE_RANK() OVER(
				PARTITION BY ContinentCode
				ORDER BY COUNT(CurrencyCode) DESC
			) AS CurrencyRank
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
		HAVING COUNT(CurrencyCode) > 1
)
	
SELECT ContinentCode, CurrencyCode, CurrencyUsage
	FROM CTE_Ranking
	WHERE CurrencyRank = 1
	ORDER BY ContinentCode


/*
-- TO DO...
-- 1
SELECT
		ContinentCode,
		--(SELECT CurrencyCode FROM s WHERE CurrencyUsage = MAX(CurrencyUsage)),
		MAX(CurrencyUsage) AS CurrencyUsage
	FROM (
		SELECT
				ContinentCode,
				CurrencyCode,
				COUNT(CurrencyCode) AS CurrencyUsage
			FROM Countries
			GROUP BY ContinentCode, CurrencyCode
			HAVING COUNT(CurrencyCode) > 1
	) AS s
	GROUP BY ContinentCode
	ORDER BY ContinentCode


-- 2
WITH CTE_Empl (ContinentCode, CurrencyCode, CurrencyUsage) AS (
	SELECT
			ContinentCode,
			CurrencyCode,
			COUNT(CurrencyCode) AS CurrencyUsage
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
		HAVING COUNT(CurrencyCode) > 1
)
	
SELECT
		c.ContinentCode
		--(SELECT MAX(CurrencyUsage) FROM CTE_Empl WHERE c.ContinentCode = t.ContinentCode)
		--CurrencyCode,
		--CurrencyUsage
	FROM Continents c
	JOIN CTE_Empl t ON c.ContinentCode = t.ContinentCode
	--FROM CTE_Empl t
	GROUP BY c.ContinentCode
*/