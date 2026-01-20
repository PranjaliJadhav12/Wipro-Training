using System;

namespace Demo_delegates_Indexers_properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentMarks myStudents = new StudentMarks();

            myStudents[0] = 90;
            myStudents[1] = 100;
            myStudents[2] = 200;
            myStudents[3] = 160;

            Console.WriteLine("student marks are ");
            Console.WriteLine(myStudents[0]);
            Console.WriteLine(myStudents[1]);
            Console.WriteLine(myStudents[2]);
            Console.WriteLine(myStudents[3]);

            Console.ReadKey();
        }
    }

    class StudentMarks
    {
        private int[] marks = new int[5];

        // Indexer
        public int this[int index]
        {
            get
            {
                return marks[index];
            }
            set
            {
                marks[index] = value;
            }
        }
    }
}