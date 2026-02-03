-- Create Database LMES_DB
create database LMES_DB;

-- this command is used to select the database
use LMES_DB;

-- Create Table Courses
CREATE TABLE Courses (
    CourseId INT PRIMARY KEY IDENTITY,
    CourseName VARCHAR(100) NOT NULL,
    Duration INT,
    Fees DECIMAL(10,2)
);

 -- Create Table Students
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(15)
);

-- Create Table Trainers
CREATE TABLE Trainers (
    TrainerId INT PRIMARY KEY IDENTITY,
    TrainerName VARCHAR(100),
    Expertise VARCHAR(100)
);

-- Create Table Enrollments
CREATE TABLE Enrollments (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    StudentId INT,
    CourseId INT,
    EnrollmentDate DATE DEFAULT GETDATE(),

    CONSTRAINT FK_Student FOREIGN KEY (StudentId)
    REFERENCES Students(StudentId),

    CONSTRAINT FK_Course FOREIGN KEY (CourseId)
    REFERENCES Courses(CourseId)
);

-- Create Table Roles
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY,
    RoleName VARCHAR(50)
);

-- Create Table Users
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50) UNIQUE,
    PasswordHash VARCHAR(255),
    RoleId INT,

    FOREIGN KEY (RoleId)
    REFERENCES Roles(RoleId)
);

-- Insert initial roles into Roles table
INSERT INTO Roles VALUES ('Admin'), ('Trainer'), ('Student');

-- Insert sample data into Students and Courses tables
INSERT INTO Students VALUES ('Aman Sharma', 'aman@mail.com', '9999999999');
INSERT INTO Courses VALUES ('Java Full Stack', 60, 25000);
INSERT INTO Enrollments (StudentId, CourseId) VALUES (1, 1);

-- Query to get the total number of students enrolled in each course
SELECT 
    c.CourseName,
    COUNT(e.StudentId) AS TotalStudents
FROM Courses c
LEFT JOIN Enrollments e ON c.CourseId = e.CourseId
GROUP BY c.CourseName;

-- Query to list all tables in the LMES_DB database
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

-- Query to get the list of students along with their enrolled courses
SELECT 
    s.FullName,
    c.CourseName,
    e.EnrollmentDate
FROM Enrollments e
JOIN Students s ON e.StudentId = s.StudentId
JOIN Courses c ON e.CourseId = c.CourseId;

-- Create a new SQL login and user for Trainer with SELECT permission on Courses table
CREATE LOGIN TrainerLogin WITH PASSWORD = 'Trainer@123';
CREATE USER TrainerUser FOR LOGIN TrainerLogin;

-- Grant SELECT permission on Courses table to TrainerUser
GRANT SELECT ON Courses TO TrainerUser;

-- Attempt to insert an enrollment with a non-existent StudentId to demonstrate foreign key constraint
INSERT INTO Enrollments (StudentId, CourseId)
VALUES (999, 1);

-- Query to get the total number of students enrolled in each course
SELECT c.CourseName, COUNT(e.StudentId) AS TotalStudents
FROM Courses c
LEFT JOIN Enrollments e ON c.CourseId = e.CourseId
GROUP BY c.CourseName;