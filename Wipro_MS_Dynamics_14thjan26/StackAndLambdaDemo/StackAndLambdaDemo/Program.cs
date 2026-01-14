using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndLambdaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------------- STACK DEMO ----------------
            Stack<int> stack = new Stack<int>();

            // Push elements into stack
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Pop element
            int poppedValue = stack.Pop();
            Console.WriteLine("Popped Value: " + poppedValue);

            // Peek top element
            int topValue = stack.Peek();
            Console.WriteLine("Top Value: " + topValue);

            // Check if stack contains 20
            bool contains20 = stack.Contains(20);
            Console.WriteLine("Stack contains 20: " + contains20);

            // Count elements
            Console.WriteLine("Current Count: " + stack.Count);

            // Clear stack
            stack.Clear();
            Console.WriteLine("Stack cleared. Current Count after clearing: " + stack.Count);

            Console.WriteLine("--------------------------------");

            // ---------------- LAMBDA & LINQ DEMO ----------------

            // Lambda expression to check even number
            Func<int, bool> IsEven = number => number % 2 == 0;

            // List of numbers
            List<int> numbers = new List<int> { 3, 5, 81, 45, 32, 15, 70 };

            // Display all numbers
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // Find first number greater than 10
            int result = numbers.Find(n => n > 10);

            // Find even numbers using LINQ
            var evenNumbers = numbers.Where(n => n % 2 == 0);

            Console.WriteLine("Here are the list of even numbers in the house");
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Here are the number greater than 10 in list implemented via lambda expression " + result);

            Console.ReadLine();
        }
    }
}