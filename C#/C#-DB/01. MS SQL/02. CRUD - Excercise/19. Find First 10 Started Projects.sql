SELECT TOP(10) *
	FROM Projects
	WHERE NOT (StartDate IS NULL)
	ORDER BY StartDate, [Name]