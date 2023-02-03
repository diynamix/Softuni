--CREATE TABLE Logs (
--	LogId INT PRIMARY KEY IDENTITY,
--	AccountId INT NOT NULL REFERENCES Accounts(Id),
--	OldSum MONEY NOT NULL,
--	NewSum MONEY NOT NULL
--)

CREATE TRIGGER tr_AddRecordToLogsOnAccountChange
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountId, OldSum, NewSum)
		SELECT i.Id, d.Balance, i.Balance
			FROM inserted i
				JOIN deleted d ON i.Id = d.Id
			WHERE i.Balance != d.Balance


-- 02
--CREATE TRIGGER tr_AddRecordToLogsOnAccountChange
--ON Accounts FOR UPDATE
--AS
--	INSERT INTO Logs (AccountId, OldSum, NewSum)
--		VALUES
--			(
--				(SELECT Id FROM inserted), 
--				(SELECT Balance FROM deleted), 
--				(SELECT Balance FROM inserted)
--			)