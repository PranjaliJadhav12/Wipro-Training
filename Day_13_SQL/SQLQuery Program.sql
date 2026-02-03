use ms_dynamic;

-- Query to retrieve all student names enrolled in course with CourseId = 1
SELECT StudentName
FROM My_Students
WHERE CourseId = 1;
--Joins Examples
-- Query to count the number of students enrolled in each course (left join)
SELECT 
    c.CourseName,
    COUNT(s.StudentId) AS total_students
FROM MyCourses c
LEFT JOIN My_Students s
ON c.CourseId = s.CourseId
GROUP BY c.CourseName;

-- Query to retrieve student names along with their corresponding course names(inner join)
SELECT 
    s.StudentName,
    c.CourseName
FROM My_Students s
INNER JOIN MyCourses c
ON s.CourseId = c.CourseId;

-- Query to retrieve all courses along with their enrolled students (if any)(left join)
SELECT 
    c.CourseName,
    s.StudentName
FROM MyCourses c
LEFT JOIN My_Students s
ON c.CourseId = s.CourseId;

-- Query to retrieve all courses along with their enrolled students (if any)(right join)
SELECT 
    s.StudentName,
    c.CourseName
FROM My_Students s
RIGHT JOIN MyCourses c
ON s.CourseId = c.CourseId;


-- Query to retrieve trainers along with their managers (self-join)
SELECT 
    t.TrainerName AS Trainer,
    m.TrainerName AS Manager
FROM Trainers t
LEFT JOIN Trainers m
ON t.ManagerId = m.TrainerId;


-- Query to retrieve all possible combinations of students and courses (cross join)
SELECT 
    s.StudentName,
    c.CourseName
    FROM My_Students s
    CROSS JOIN MyCourses c;

-- Query to retrieve all students and all courses, matching where possible (full outer join)
SELECT 
    s.StudentName,
    c.CourseName
    FROM My_Students s
    FULL OUTER JOIN MyCourses c
    ON s.CourseId = c.CourseId;