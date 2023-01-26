SELECT TOP(1)
		(SELECT AVG(Salary)
			FROM Employees
			WHERE DepartmentID = d.DepartmentID
		) AS MinAverageSalary
	FROM Departments d
	WHERE (SELECT COUNT(*) FROM Employees WHERE DepartmentID = d.DepartmentID) > 0
	ORDER BY MinAverageSalary

-- with GROUP BY
--SELECT TOP(1)
--		AVG(Salary) AS MinAverageSalary
--	FROM Employees
--	GROUP BY DepartmentID
--	ORDER BY MinAverageSalary