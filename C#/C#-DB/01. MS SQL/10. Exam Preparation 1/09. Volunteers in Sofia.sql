SELECT [Name], PhoneNumber,
		SUBSTRING([Address], CHARINDEX(',', [Address]) + 2, LEN([Address]) - 7) AS [Address]
	FROM Volunteers
	WHERE
		DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')
		AND [Address] LIKE '%Sofia%'
	ORDER BY [Name]