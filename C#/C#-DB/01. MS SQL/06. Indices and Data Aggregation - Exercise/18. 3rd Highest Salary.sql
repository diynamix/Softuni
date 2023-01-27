WITH SalaryRank AS (
	SELECT
			DepartmentID,
			Salary,
			DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
		FROM Employees
)
	
SELECT
		DISTINCT DepartmentID,
		Salary AS ThirdHighestSalary
	FROM SalaryRank
	WHERE [Rank] = 3


/*
-- 02
SELECT
		DepartmentID,
		MAX(Salary) AS ThirdHighestSalary
	FROM (
		SELECT 
				DepartmentID,
				Salary,
				DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
			FROM Employees
	) AS SalaryRank
	WHERE [Rank] = 3
	GROUP BY DepartmentID
*/