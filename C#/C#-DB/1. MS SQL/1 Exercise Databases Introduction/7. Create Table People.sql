CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	-- [Picture] IMAGE, -- PictureURL
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX),
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Peter', 1.77, 75.2, 'm', '1998-05-27'),
('George', NULL, NULL, 'm', '1997-11-05'),
('Maria', 1.62, 53.2, 'f', '1999-04-03'),
('Diana', 1.60, 50.1, 'f', '1999-10-05'),
('John', 1.85, 83.4, 'm', '1999-03-14')