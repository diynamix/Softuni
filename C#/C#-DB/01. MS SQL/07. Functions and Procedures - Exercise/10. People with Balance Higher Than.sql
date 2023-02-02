CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Money DECIMAL(18, 4))
AS
	SELECT ah.FirstName, ah.LastName
		FROM AccountHolders ah
			JOIN (
				SELECT 
					AccountHolderId,
					SUM(Balance) AS TotalBalance
				FROM Accounts
				GROUP BY AccountHolderId
			) a ON ah.Id = a.AccountHolderId
		WHERE TotalBalance > @Money
		ORDER BY ah.FirstName, ah.LastName