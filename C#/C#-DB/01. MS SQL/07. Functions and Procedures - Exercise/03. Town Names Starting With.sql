CREATE PROC usp_GetTownsStartingWith (@StartString NVARCHAR(MAX))
AS
	SELECT [Name]
		FROM Towns
		WHERE [Name] LIKE @StartString + '%'