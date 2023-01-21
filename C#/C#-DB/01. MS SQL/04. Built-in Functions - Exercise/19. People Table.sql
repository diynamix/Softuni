CREATE TABLE [People](
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Birthdate DATE NOT NULL
)

INSERT INTO [People](Id, [Name], Birthdate)
	VALUES
		('Peter', '1996-01-07'),
		('George','2003-09-21'),
		('Diana','1999-10-05')

Select
		[Name],
		DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
		DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
		DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
		DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
	FROM People