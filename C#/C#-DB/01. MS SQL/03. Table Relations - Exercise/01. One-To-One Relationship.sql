--CREATE DATABASE EntityRelationsDemo

--GO

--USE EntityRelationsDemo

--GO

CREATE TABLE Passports(
	PassportID INT IDENTITY(101, 1) NOT NULL,
	PassportNumber VARCHAR(10) NOT NULL
)

ALTER TABLE Passports
	ADD --CONSTRAINT PK_Passports_PassportID
		PRIMARY KEY (PassportID)

INSERT INTO Passports(PassportNumber)
	VALUES
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')


CREATE TABLE Persons(
	PersonID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	PassportID INT NOT NULL
)

ALTER TABLE Persons
	ADD --CONSTRAINT PK_Persons_PersonID
		PRIMARY KEY (PersonID)

ALTER TABLE Persons
	ADD --CONSTRAINT FK_Persons_PassportID
		FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

ALTER TABLE Persons
	ADD --CONSTRAINT UC_Persons_PassportID
		UNIQUE (PassportID)

INSERT INTO Persons(FirstName, Salary, PassportID)
	VALUES
		('Roberto', 43300.00, 102),
		('Tom', 56100.00, 103),
		('Yana', 60200.00, 101)