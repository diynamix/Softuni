CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(MAX))
RETURNS TABLE
AS
	RETURN SELECT
			SUM(Cash) AS SumCash
		FROM
		(
			SELECT 
				ug.GameId,		
				ug.Cash,
				ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowNumber
			FROM UsersGames ug
				JOIN Games g ON ug.GameId = g.Id	
			WHERE g.[Name] = @GameName
			GROUP BY ug.GameId, ug.Cash
		) AS t
		WHERE t.RowNumber % 2 = 1