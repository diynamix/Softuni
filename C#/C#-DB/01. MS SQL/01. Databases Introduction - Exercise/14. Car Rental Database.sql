-- CREATE DATABASE [CarRental]

-- USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(20) NOT NULL,
	[DailyRate] DECIMAL(5, 2) NOT NULL,
	[WeeklyRate] DECIMAL(5, 2) NOT NULL,
	[MonthlyRate] DECIMAL(6, 2) NOT NULL,
	[WeekendRate] DECIMAL(5, 2) NOT NULL,
)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(30) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL,
	[Model] VARCHAR(30) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] IMAGE,
	[Condition] VARCHAR(30) NOT NULL,
	[Available] BIT NOT NULL,
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] VARCHAR(50) NOT NULL,
	[FullName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[ZIPCode] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] VARCHAR(20) NOT NULL,
	[TaxRate] DECIMAL(10, 2) NOT NULL,
	[OrderStatus] VARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(200)
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
	VALUES
('Family cars', 20.00, 70.00, 250.00, 35.00),
('Racing cars', 50.00, 300.00, 1000.00, 75.00),
('Waggons', 40.00, 140.00, 500.00, 70.00)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
	VALUES
('0001', 'Ford', 'Model A', 2006, 3, 3, NULL, 'Good', 1),
('0002', 'Peugeot', 'Model B', 2015, 1, 5, NULL, 'Great', 1),
('0003', 'Porshe', 'Model C', 2022, 2, 5, NULL, 'Like New', 0)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
	VALUES
('Peter', 'Scott', 'Cashier', NULL),
('Jannette', 'Wood', 'Sales assistant', NULL),
('Tobias', 'Konnery', 'Manager', NULL)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
	VALUES
('A928B47', 'John Smith', 'Britain', 'Birmingham', 'CL12 0TH', NULL),
('SK90I13', 'George Washington', 'USA', 'Washington', '1000', NULL),
('RT57UU6', 'Don Mercury', 'Argentina', 'Mendoza', '5L10K0', NULL)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes])
	VALUES
(1, 1, 1, 200, 500000, 503000, 503000, '2023-01-12', '2023-03-01', 48, 'Monthly', 1000, 'Received by customer', NULL),
(2, 2, 2, 100, 25000, 26300, 26300, '2023-01-13', '2023-01-15', 3, 'Weekend', 35, 'Received by customer', NULL),
(3, 3, 3, 120, 100, 100, 100, '2023-01-21', '2023-01-22', 2, 'Weekend', 0, 'Cancelled', NULL)