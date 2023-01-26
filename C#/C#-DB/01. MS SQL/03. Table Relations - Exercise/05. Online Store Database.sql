-- CREATE DATABASE OnlineStoreDatabase

-- USE OnlineStoreDatabase

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE OrderItems(
	OrderID INT REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT REFERENCES Items(ItemID) NOT NULL
	PRIMARY KEY (OrderID, ItemID)
)