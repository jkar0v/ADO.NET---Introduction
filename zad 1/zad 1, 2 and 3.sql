CREATE DATABASE SchoolDB;
GO

USE SchoolDB;
GO


CREATE TABLE Students (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50),
Age INT,
Grade INT,
Mark DECIMAL(3,2)
);

INSERT INTO Students (Name, Age, Grade, Mark)
VALUES
(N'София Иванова', 18, 12, 6.00),
(N'Йоана Николова', 19, 11, 5.94),
(N'Филип Николов', 24, 12, 5.50),
(N'Николай Филипов', 18, 10, 5.48),
(N'Живко Каров', 19, 12, 6.00);