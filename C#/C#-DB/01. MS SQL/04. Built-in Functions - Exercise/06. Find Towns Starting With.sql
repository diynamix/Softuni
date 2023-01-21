SELECT *
	FROM Towns
	--WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name]