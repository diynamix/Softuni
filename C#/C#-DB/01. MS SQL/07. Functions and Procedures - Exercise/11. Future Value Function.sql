CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @Years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @FV DECIMAL(18, 4) = @Sum * (POWER((1 + @YearlyInterestRate), @Years))
	RETURN @FV
END