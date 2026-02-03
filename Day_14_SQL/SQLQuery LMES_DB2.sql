use lmes_db;

----------------stored procedures (Data Manipulation)-------------------

-- Create Table TrainerCourses
CREATE TABLE TrainerCourses (
    TrainerCourseId INT IDENTITY PRIMARY KEY,
    TrainerId INT,
    CourseId INT,

    FOREIGN KEY (TrainerId) REFERENCES Trainers(TrainerId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

-- Insert sample data into Courses
INSERT INTO Trainers (TrainerName, Expertise)
VALUES
('Rahul Mehta', 'Java'),
('Neha Verma', 'Data Science');

select * from Trainers;
SELECT * FROM Courses;

-- Query to get trainers along with the courses they teach
SELECT 
    t.TrainerName,
    c.CourseName
FROM TrainerCourses tc
JOIN Trainers t ON tc.TrainerId = t.TrainerId
JOIN Courses c ON tc.CourseId = c.CourseId;



-- Insert sample data into TrainerCourses
INSERT INTO TrainerCourses VALUES (1, 1);
INSERT INTO TrainerCourses VALUES (1, 2);


-- Create a stored procedure to add a new student
CREATE PROCEDURE AddStudent
    @FullName VARCHAR(100),
    @Email VARCHAR(100),
    @Phone VARCHAR(15)
AS
BEGIN
    INSERT INTO Students VALUES (@FullName, @Email, @Phone);
END;

-- Execute the stored procedure to add a new student
EXEC AddStudent 'Riya Sharma', 'riya@mail.com', '9876543210';

-- Create a stored procedure to add a new course
CREATE PROCEDURE AddCourse
    @CourseName VARCHAR(100),
    @Duration INT,
    @Fees DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Courses VALUES (@CourseName, @Duration, @Fees);
END;

-- Execute the stored procedure to add a new course
EXEC AddCourse 'Data Science', 90, 35000;

-- Create a stored procedure to enroll a student in a course
CREATE PROCEDURE EnrollStudent
    @StudentId INT,
    @CourseId INT
AS
BEGIN
    INSERT INTO Enrollments (StudentId, CourseId)
    VALUES (@StudentId, @CourseId);
END;
-- Execute the stored procedure to enroll a student
EXEC EnrollStudent 1, 2;

-- Create a stored procedure to get the total number of students enrolled in each course
CREATE PROCEDURE StudentsPerCourse
AS
BEGIN
    SELECT 
        c.CourseName,
        COUNT(e.StudentId) AS TotalStudents
    FROM Courses c
    LEFT JOIN Enrollments e ON c.CourseId = e.CourseId
    GROUP BY c.CourseName;
END;
 -- Execute the stored procedure to get the total number of students per course
EXEC StudentsPerCourse;

---------------TRIGGERS (Data Integrity & Automation)-------------------

-- Create a trigger to prevent duplicate student entries based on Email
CREATE TRIGGER trg_PreventDuplicateStudent
ON Students
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Students s
        JOIN inserted i ON s.Email = i.Email
    )
    BEGIN
        RAISERROR ('Email already exists', 16, 1);
        RETURN;
    END

    INSERT INTO Students (FullName, Email, Phone)
    SELECT FullName, Email, Phone FROM inserted;
END;

-- Test the trigger by attempting to insert a duplicate student
INSERT INTO Students VALUES ('Aman', 'riya@mail.com', '9999999999');

-- Create a trigger to log enrollment actions
CREATE TABLE EnrollmentAudit (
    AuditId INT IDENTITY PRIMARY KEY,
    StudentId INT,
    CourseId INT,
    ActionType VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE()
);

--create trigger to log enrollments
CREATE TRIGGER trg_EnrollmentInsert
ON Enrollments
AFTER INSERT
AS
BEGIN
    INSERT INTO EnrollmentAudit (StudentId, CourseId, ActionType)
    SELECT StudentId, CourseId, 'ENROLLED'
    FROM inserted;
END;
-- Test the trigger by enrolling a student
EXEC EnrollStudent 2, 1;
-- View the enrollment audit log
SELECT * FROM EnrollmentAudit;

-- Create a trigger to prevent deletion of courses with enrolled students
CREATE TRIGGER trg_PreventCourseDelete
ON Courses
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Enrollments e
        JOIN deleted d ON e.CourseId = d.CourseId
    )
    BEGIN
        RAISERROR ('Cannot delete course with enrollments', 16, 1);
        RETURN;
    END

    DELETE FROM Courses
    WHERE CourseId IN (SELECT CourseId FROM deleted);
END;

-- View current data in Courses, Students, Enrollments, and EnrollmentAudit tables
SELECT * FROM Courses;
SELECT * FROM Students;
SELECT * FROM Enrollments;
SELECT * FROM EnrollmentAudit;


-- Test the trigger by attempting to delete a course with enrollments
DELETE FROM Courses WHERE CourseId = 1;