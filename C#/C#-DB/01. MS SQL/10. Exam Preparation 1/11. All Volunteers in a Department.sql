CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (
		SELECT COUNT(*)
			FROM Volunteers v
				JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
			WHERE vd.DepartmentName = @VolunteersDepartment
			GROUP BY vd.DepartmentName
	)
END