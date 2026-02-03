using System;

// Define delegate type
// Complete Step 1:............
delegate int Operation(int a, int b);

class Program
{
    // Implement delegate methods
    // Complete Step 2:............
    static int Add(int a, int b)
    {
        return a + b;
    }
    static int Subtract(int a, int b)
    {
        return a - b;
    }
    static int Multiply(int a, int b)
    {
        return a * b;
    }
    static int Divide(int a, int b)
    {
        return a / b;
    }

    // Implement callback mechanism
    // Complete Step 3:............
    static int PerformOperation(int a, int b, Operation op)
    {
        return op(a, b);
    }

    static void Main(string[] args)
    {
        // Input handling
        // Complete Step 4:............
        Console.WriteLine("Enter first number:");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter operation (add, subtract, multiply, divide):");
        string operation = Console.ReadLine().ToLower();
        Operation op = null;

        switch (operation)
        {
            case "add":
                op = Add;
                break;
            case "subtract":
                op = Subtract;
                break;
            case "multiply":
                op = Multiply;
                break;
            case "divide":
                op = Divide;
                break;
            default:
                Console.WriteLine("Invalid operation");
                return;
        }

        // Output handling
        // Complete Step 5:............
        int result = PerformOperation(num1, num2, op);
        Console.WriteLine("Result: " + result);
    }
}