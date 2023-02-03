--CREATE TABLE Deleted_Employees (
--	EmployeeId INT PRIMARY KEY IDENTITY,
--	FirstName NVARCHAR(30) NOT NULL,
--	LastName NVARCHAR(30) NOT NULL,
--	MiddleName NVARCHAR(30),
--	JobTitle NVARCHAR(30) NOT NULL,
--	DepartmentId INT NOT NULL REFERENCES Departments(DepartmentId),
--	Salary MONEY NOT NULL
--)

CREATE TRIGGER tr_AddToDeleted_EmployeesOnDeletingEmployee
On Employees FOR DELETE
AS
	INSERT Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary
		FROM deleted