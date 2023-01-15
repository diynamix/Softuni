-- CREATE DATABASE [Hotel]

-- USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Customers](
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[PhoneNumber] VARCHAR(11) NOT NULL,
	[EmergencyName] VARCHAR(30) NOT NULL,
	[EmergencyNumber] VARCHAR(11) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [RoomStatus](
	[RoomStatus] VARCHAR(30) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [RoomTypes](
	[RoomType] VARCHAR(30) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [BedTypes](
	[BedType] VARCHAR(30) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Rooms](
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomType] VARCHAR(30) FOREIGN KEY REFERENCES [RoomTypes](RoomType) NOT NULL,
	[BedType] VARCHAR(30) FOREIGN KEY REFERENCES [BedTypes](BedType) NOT NULL,
	[Rate] DECIMAL(5, 2) NOT NULL,
	[RoomStatus] VARCHAR(30) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[PaymentDate] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL(6, 2) NOT NULL,
	[TaxRate] DECIMAL(5, 2) NOT NULL,
	[TaxAmount] DECIMAL(5, 2) NOT NULL,
	[PaymentTotal] DECIMAL(6, 2) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[DateOccupied] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](RoomNumber) NOT NULL,
	[RateApplied] DECIMAL(5, 2) NOT NULL,
	[PhoneCharge] DECIMAL(5, 2) NOT NULL,
	[Notes] NVARCHAR(1000)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
	VALUES
('Pocahontas', 'Tirini', 'Manager', NULL),
('John', 'Smith', 'Cashier', NULL),
('Roger', 'McDonald', 'Chef', NULL)
		
INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
	VALUES
('Samantha', 'Rodriguez', '3333333', 'Salma', '4444444', NULL),
('Aurora', 'Restt', '55555555', 'Philip', '085422544', NULL),
('Simon', 'Donovan', '88888888', 'Zack', '55123651', NULL)
		
INSERT INTO [RoomStatus]([RoomStatus], [Notes])
	VALUES
('Available', NULL),
('Occupied', NULL),
('Pending', NULL)
		
INSERT INTO [RoomTypes]([RoomType], [Notes])
	VALUES
('Room', NULL),
('Studio', NULL),
('Apartment', NULL)
		
INSERT INTO [BedTypes]([BedType], [Notes])
	VALUES
('Single', NULL),
('Double', NULL),
('King size', NULL)
		
INSERT INTO [Rooms]([RoomType], [BedType], [Rate], [RoomStatus], [Notes])
	VALUES
('Room', 'Single', 20, 'Available', NULL),
('Studio', 'Double', 30, 'Occupied', NULL),
('Apartment', 'King size', 40, 'Pending', NULL)
		
INSERT INTO [Payments]([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes])
	VALUES
(1, '2023-01-01', 1, '2023-01-13', '2023-01-14', 1, 20.00, 20.00, 4.00, 24.00,NULL),
(2, '2023-01-02', 2, '2023-01-17', '2023-01-21', 4, 120.00, 20.00, 24.00, 124.00,NULL),
(3, '2023-01-03', 3, '2023-01-25', '2023-01-28', 3, 120.00, 20.00, 24.00, 124.00, NULL)
	   	
INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
	VALUES
(1, '2023-01-13', 1, 1, 20.00, 5.00, NULL),
(2, '2023-01-17', 2, 2, 20.00, 17.00, NULL),
(3, '2023-01-25', 3, 3, 20.00, 9.60, NULL)