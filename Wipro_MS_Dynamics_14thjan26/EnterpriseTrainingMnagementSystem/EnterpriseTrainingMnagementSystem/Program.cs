using System;
using System.Collections.Generic;

namespace EnterpriseTrainingManagementSystem
{
    // Course class
    class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public Course(string code, string name)
        {
            CourseCode = code;
            CourseName = name;
        }
    }

    // Enrollment Request class
    class EnrollmentRequest
    {
        public int LearnerId { get; set; }
        public string CourseCode { get; set; }

        public EnrollmentRequest(int learnerId, string courseCode)
        {
            LearnerId = learnerId;
            CourseCode = courseCode;
        }
    }

    // Session class
    class Session
    {
        public string SessionName { get; set; }

        public Session(string name)
        {
            SessionName = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // STEP 1: Manage Course Catalog
            List<Course> courseList = new List<Course>();
            Dictionary<string, Course> courseDictionary = new Dictionary<string, Course>();

            Course c1 = new Course("C101", "C# Fundamentals");
            Course c2 = new Course("J101", "Java Basics");

            courseList.Add(c1);
            courseList.Add(c2);

            courseDictionary.Add(c1.CourseCode, c1);
            courseDictionary.Add(c2.CourseCode, c2);

            Console.WriteLine("Courses added successfully.");

            // STEP 2: Fast Course Lookup
            Console.WriteLine("\nFetching course by code C101:");
            Console.WriteLine(courseDictionary["C101"].CourseName);

            // STEP 3: Avoid Duplicate Enrollment
            HashSet<int> enrolledLearners = new HashSet<int>();

            enrolledLearners.Add(101);
            enrolledLearners.Add(102);

            Console.WriteLine("\nTrying to enroll learner 101 again:");
            bool added = enrolledLearners.Add(101);
            Console.WriteLine(added ? "Enrollment successful" : "Duplicate enrollment prevented");

            // STEP 4: Process Enrollment Requests in Order
            Queue<EnrollmentRequest> enrollmentQueue = new Queue<EnrollmentRequest>();
            enrollmentQueue.Enqueue(new EnrollmentRequest(101, "C101"));
            enrollmentQueue.Enqueue(new EnrollmentRequest(102, "J101"));

            Console.WriteLine("\nProcessing enrollment requests:");
            while (enrollmentQueue.Count > 0)
            {
                EnrollmentRequest req = enrollmentQueue.Dequeue();
                Console.WriteLine($"Learner {req.LearnerId} enrolled for course {req.CourseCode}");
            }

            // STEP 5: Support Undo for Admin Actions
            Stack<string> adminActions = new Stack<string>();
            adminActions.Push("Added Course C101");
            adminActions.Push("Added Course J101");

            Console.WriteLine("\nUndo last admin action:");
            Console.WriteLine(adminActions.Pop());

            // STEP 6: Display Sessions Sorted by Start Time
            SortedList<DateTime, Session> sessions = new SortedList<DateTime, Session>();
            sessions.Add(new DateTime(2026, 1, 15, 10, 0, 0), new Session("Morning Session"));
            sessions.Add(new DateTime(2026, 1, 15, 14, 0, 0), new Session("Afternoon Session"));

            Console.WriteLine("\nTraining sessions sorted by time:");
            foreach (var session in sessions)
            {
                Console.WriteLine($"{session.Key} - {session.Value.SessionName}");
            }

            Console.WriteLine("\nSystem execution completed.");
        }
    }
}