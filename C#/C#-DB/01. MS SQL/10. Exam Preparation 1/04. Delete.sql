DELETE Volunteers
	WHERE DepartmentId IN (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')

DELETE VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'