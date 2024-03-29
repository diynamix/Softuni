CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
	IF (@MoneyAmount < 0) THROW 50001, 'Money amount cannot be negative!', 1
	UPDATE Accounts 
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId