USE [master];

GO
BACKUP DATABASE [SoftUni]
	TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\SoftUniDB.bak' 
	-- WITH NOFORMAT, NOINIT,
	-- NAME = N'SoftUniDB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
GO

GO

DROP DATABASE [SoftUni]

GO

GO
RESTORE DATABASE [SoftUni] 
	FROM DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\SoftUniDB.bak'
	-- WITH  FILE = 1, NOUNLOAD, STATS = 5;
GO