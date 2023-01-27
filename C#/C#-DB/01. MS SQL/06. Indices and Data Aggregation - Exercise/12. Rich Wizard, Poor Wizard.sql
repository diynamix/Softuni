SELECT
		SUM(prev.DepositAmount - [next].DepositAmount) AS SumDifference
	FROM WizzardDeposits prev
		JOIN WizzardDeposits [next] ON prev.Id = [next].Id - 1