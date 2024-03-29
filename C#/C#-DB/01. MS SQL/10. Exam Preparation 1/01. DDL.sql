--CREATE DATABASE Zoo

--USE Zoo

CREATE TABLE Owners (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes (
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages (
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages (
	CageId INT NOT NULL REFERENCES Cages(Id) UNIQUE,
	AnimalId INT NOT NULL REFERENCES Animals(Id) UNIQUE,
	CONSTRAINT PK_CagesAnimals
		PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments (
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL,
)

CREATE TABLE Volunteers (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT REFERENCES Animals(Id),
	DepartmentId INT NOT NULL REFERENCES VolunteersDepartments(Id)
)