SELECT *
	FROM Towns
	--WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	WHERE [Name] LIKE '[^RBD]%'
	ORDER BY [Name]