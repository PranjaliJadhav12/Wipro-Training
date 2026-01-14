using System;
using System.Collections.Generic;

namespace StackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a stack of strings
            Stack<string> bookStack = new Stack<string>();

            // Push elements into stack
            bookStack.Push("C# Basics");
            bookStack.Push("OOP Concepts");
            bookStack.Push("Data Structures");

            Console.WriteLine("Books added to stack.");

            // Peek top element
            string topBook = bookStack.Peek();
            Console.WriteLine("Top book: " + topBook);

            // Pop element
            string removedBook = bookStack.Pop();
            Console.WriteLine("Removed book: " + removedBook);

            // Check if stack contains an item
            bool hasOOP = bookStack.Contains("OOP Concepts");
            Console.WriteLine("Stack contains 'OOP Concepts': " + hasOOP);

            // Count elements
            Console.WriteLine("Total books in stack: " + bookStack.Count);

            // Clear stack
            bookStack.Clear();
            Console.WriteLine("Stack cleared. Current count: " + bookStack.Count);
        }
    }
}