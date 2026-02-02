using System;

Console.WriteLine("===== Student Marks Management System =====");

// Input student details
Console.Write("Enter Student Name: ");
string name = Console.ReadLine();

Console.Write("Enter Marks for Subject 1: ");
int m1 = int.Parse(Console.ReadLine());

Console.Write("Enter Marks for Subject 2: ");
int m2 = int.Parse(Console.ReadLine());

Console.Write("Enter Marks for Subject 3: ");
int m3 = int.Parse(Console.ReadLine());

// Processing
int total = m1 + m2 + m3;
double average = total / 3.0;

// Result logic
string result = (average >= 40) ? "PASS" : "FAIL";

// Output
Console.WriteLine("\n----- Student Report -----");
Console.WriteLine("Name     : " + name);
Console.WriteLine("Total    : " + total);
Console.WriteLine("Average  : " + average);
Console.WriteLine("Result   : " + result);// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
