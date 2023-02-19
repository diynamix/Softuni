CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (
		SELECT COUNT(*)
			FROM CreatorsBoardgames cb
				JOIN Creators c ON cb.CreatorId = c.Id
			WHERE (c.FirstName = @name)
	)
END

--SELECT dbo.udf_CreatorWithBoardgames('Bruno')