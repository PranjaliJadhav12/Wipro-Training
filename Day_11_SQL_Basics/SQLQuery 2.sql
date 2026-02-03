--lets create a database first
CREATE DATABASE ms_dynamic;

use ms_dynamic;
--Now let's create some tables
-- Table: MyCourses
CREATE TABLE MyCourses (
	    CourseId INT PRIMARY KEY,
	    CourseName VARCHAR(100)
	);
	--- Table: My_Students
CREATE TABLE My_Students (
	    StudentId INT PRIMARY KEY,
	    StudentName VARCHAR(50),
	    CourseId INT
	);
	-- Table: Trainers
CREATE TABLE Trainers (
	    TrainerId INT PRIMARY KEY,
	    TrainerName VARCHAR(50),
	    ManagerId INT
	);
	--insert some data into MyCourses table
INSERT INTO MyCourses (CourseId, CourseName) VALUES
(1, 'Computer Science'),
(2, 'Information Technology'),
(3, 'Data Science'),
(4, 'Cyber Security');

--insert some data into My_Students table
INSERT INTO My_Students (StudentId, StudentName, CourseId) VALUES
(101, 'Aman', 1),
(102, 'Riya', 2),
(103, 'Rahul', 3),
(104, 'Sneha', 1),
(105, 'Karan', 4);

--insert some data into Trainers table
INSERT INTO Trainers (TrainerId, TrainerName, ManagerId) VALUES
(1, 'Arjun', NULL),
(2, 'Meera', 1),
(3, 'Rohit', 1),
(4, 'Anjali', 2);

-- Let's verify the inserted data
SELECT * FROM MyCourses;
SELECT * FROM My_Students;
SELECT * FROM Trainers;

-- Query to count total number of students in My_Students table
SELECT COUNT(*) AS total_students
FROM My_Students;

--Query to find the minimum and maximum StudentId from My_Students table
SELECT 
    MIN(StudentId) AS min_student_id,
    MAX(StudentId) AS max_student_id
FROM My_Students;

-- Query to calculate the average StudentId from My_Students table
SELECT AVG(CourseId) AS avg_course_id
FROM My_Students;

-- Query to find the length of each StudentName in My_Students table
SELECT StudentName, LEN(StudentName) AS name_length
FROM My_Students;

-- Query to convert TrainerName to lowercase in Trainers table
SELECT LOWER(TrainerName) AS trainer_name
FROM Trainers;