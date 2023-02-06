CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
	SELECT a.[Name],
			CASE
				WHEN o.[Name] IS NULL THEN 'For adoption'
				ELSE o.[Name]
			END AS OwnersName
		FROM Animals a
			LEFT JOIN Owners o ON a.OwnerId = o.Id
		WHERE a.[Name] = @AnimalName