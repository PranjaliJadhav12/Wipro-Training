using System;

// Step 1: PropertyDemo class
public class PropertyDemo
{
    private int value = 5;

    public int Value
    {
        get { return value; }
    }
}

// Step 2: StaticDemo class
public class StaticDemo
{
    private static int privateValue = 10;

    // Static constructor
    static StaticDemo()
    {
        Console.WriteLine("Static Constructor");
    }

    // Static method
    public static void Display()
    {
        Console.WriteLine(privateValue);
        Console.WriteLine("Static Method");
    }
}

// Step 3: MathHelper static class
public static class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

// Step 4: Main method
public class Program
{
    public static void Main()
    {
        // PropertyDemo
        PropertyDemo pd = new PropertyDemo();
        Console.WriteLine(pd.Value);

        Console.WriteLine("Private Value");

        // StaticDemo
        StaticDemo.Display();

        // MathHelper
        int result = MathHelper.Add(5, 10);
        Console.WriteLine(result);

        Console.WriteLine(5);
    }
}