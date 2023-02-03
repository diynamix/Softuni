CREATE PROC usp_AssignProject(@employeeId INT, @projectID INT)
AS
	DECLARE @EmployeesProjectsCount INT =
		(SELECT COUNT(*) FROM EmployeesProjects
			WHERE EmployeeID = @employeeId);

	IF (@EmployeesProjectsCount >= 3)
		THROW 50001, 'The employee has too many projects!', 1;

	--DECLARE @EmployeeInThisProjectCount INT =
	--	(SELECT COUNT(*) FROM EmployeesProjects
	--		WHERE EmployeeID = @employeeId AND ProjectID = @projectId);

	--IF (@EmployeeInThisProjectCount >= 1)
	--	THROW 50002, 'Employee already in this projects', 1;

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
		VALUES (@EmployeeId, @ProjectId);


-- 02
CREATE PROC usp_AssignProject(@employeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @EmployeesProjectsCount INT =
		(SELECT COUNT(*) FROM EmployeesProjects
			WHERE EmployeeID = @employeeId);

	IF (@EmployeesProjectsCount >= 3)
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1);
		ROLLBACK;
	END

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
		VALUES (@EmployeeId, @ProjectId);
COMMIT