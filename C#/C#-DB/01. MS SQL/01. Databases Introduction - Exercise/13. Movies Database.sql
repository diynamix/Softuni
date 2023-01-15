-- CREATE DATABASE [Movies]

-- USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200),
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200),
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200),
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Rating] DECIMAL (2, 1) NOT NULL,
	[Notes] NVARCHAR(200),
)

INSERT INTO [Directors]([DirectorName], [Notes])
	VALUES
('James Cameron', NULL),
('Alfred Hitchcock', NULL),
('Quentin Tarantino', NULL),
('Steven Spielberg', NULL),
('Martin Scorsese', NULL)

INSERT INTO [Genres]([GenreName], [Notes])
	VALUES
('Action', NULL),
('Comedy', NULL),
('Drama', NULL),
('Fantasy', NULL),
('Mystery', NULL)

INSERT INTO [Categories]([CategoryName], [Notes])
	VALUES
('Short', NULL),
('Feature', NULL),
('Biography', NULL),
('Documentary', NULL),
('Show', NULL)

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
	VALUES
('Avatar: The Way of Water', 1, 2022, '03:20:00', 4, 2, 9.9, NULL),
('Avatar: The Way of Water', 1, 2022, '03:20:00', 4, 2, 9.9, NULL),
('Avatar: The Way of Water', 1, 2022, '03:20:00', 4, 2, 9.9, NULL),
('Avatar: The Way of Water', 1, 2022, '03:20:00', 4, 2, 9.9, NULL),
('Avatar: The Way of Water', 1, 2022, '03:20:00', 4, 2, 9.9, NULL)