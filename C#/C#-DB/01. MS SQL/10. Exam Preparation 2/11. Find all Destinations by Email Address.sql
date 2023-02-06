CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @DestinationsCount INT = (
		SELECT COUNT(*)
			FROM Passengers p
				RIGHT JOIN FlightDestinations fd ON p.Id = fd.PassengerId
			WHERE p.Email = @email
			GROUP BY p.Email
	)

	RETURN ISNULL(@DestinationsCount, 0)
END