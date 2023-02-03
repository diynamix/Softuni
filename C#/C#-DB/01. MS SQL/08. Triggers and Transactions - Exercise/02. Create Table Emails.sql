--CREATE TABLE NotificationEmails (
--	Id INT PRIMARY KEY IDENTITY,
--	Recipient INT NOT NULL REFERENCES Accounts(Id),
--	[Subject] NVARCHAR(MAX),
--	Body NVARCHAR(MAX)
--)

CREATE TRIGGER tr_AddEmailOnNewRecordInLogs
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
		VALUES
			(
				(SELECT AccountId FROM inserted),
				(SELECT 'Balance change for account: ' + CAST(AccountId AS NVARCHAR(MAX)) FROM inserted),
				(SELECT
					'On '
					+ FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt')
					+ ' your balance was changed from '
					+ CAST(OldSum AS NVARCHAR(MAX))
					+ ' to '
					+ CAST(NewSum AS NVARCHAR(MAX))
					+ '.'
					FROM inserted)
			)