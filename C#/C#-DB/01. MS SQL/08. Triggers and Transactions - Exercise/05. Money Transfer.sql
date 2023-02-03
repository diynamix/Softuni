CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
	BEGIN TRANSACTION
		BEGIN TRY
			EXEC usp_WithdrawMoney @SenderId, @Amount;
			EXEC usp_DepositMoney @ReceiverId, @Amount;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW 50001, 'Something went wrong! Please try again later!', 1
		END CATCH
	COMMIT