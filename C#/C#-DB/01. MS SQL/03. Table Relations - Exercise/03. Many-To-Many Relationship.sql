CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

INSERT INTO Students([Name])
	VALUES
		('Mila'),
		('Toni'),
		('Ron')

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(30) NOT NULL,
)

INSERT INTO Exams([Name])
	VALUES
		('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL
		FOREIGN KEY REFERENCES [Students](StudentID),
	ExamID INT NOT NULL
		FOREIGN KEY REFERENCES [Exams](ExamID),
	--CONSTRAINT PK_StudentsExams
		PRIMARY KEY (StudentId, ExamID)
)

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)