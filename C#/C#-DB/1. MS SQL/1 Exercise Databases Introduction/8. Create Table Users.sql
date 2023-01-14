CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	-- [ProfilePicture] IMAGE,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	-- [IsDeleted] VARCHAR(5) NOT NULL,
	-- CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false'),
	[IsDeleted] BIT NOT NULL,
)

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted])
	VALUES
('Peter', '123', '1998-05-27', 1),
('George', '456', '1997-11-05', 0),
('Vikki', '789', '1999-04-03', 0),
('Diana', '012', '1999-10-05', 1),
('John', '345', '1999-03-14', 1)