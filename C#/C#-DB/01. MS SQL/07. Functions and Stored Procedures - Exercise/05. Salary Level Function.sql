-- 01
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
BEGIN
	IF @Salary IS NULL
		RETURN NULL

	IF @Salary < 30000
		RETURN 'Low'
	ELSE IF @Salary <= 50000
		RETURN 'Average'
	ELSE
		RETURN 'High'

	RETURN NULL
END
	

-- 02
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
BEGIN
	RETURN CASE
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary <= 50000 THEN 'Average'
		WHEN @salary > 50000 THEN 'High'
		ELSE NULL
	END
END


--SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees