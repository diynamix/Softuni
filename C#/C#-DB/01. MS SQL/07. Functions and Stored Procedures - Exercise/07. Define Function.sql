CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @I INT = LEN(@word)
	WHILE (@I > 0)
	BEGIN
		DECLARE @char NCHAR(1) = SUBSTRING(@word, @I, 1)
		IF (@char NOT LIKE '[' + @setOfLetters + ']')
			RETURN 0
		SET @I -= 1
	END

	RETURN 1
END