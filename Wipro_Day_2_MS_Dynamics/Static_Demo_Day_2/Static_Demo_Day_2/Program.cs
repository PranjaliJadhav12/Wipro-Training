using System;

class Demo
{
    // Private field
    private int value = 5;

    // Property to access private value
    public int Value
    {
        get { return value; }
    }

    // Static field
    public static int StaticValue;

    // Static constructor (NO Console.WriteLine here)
    static Demo()
    {
        StaticValue = 10;
    }

    // Static method
    public static int Add(int a, int b)
    {
        Console.WriteLine("Static Method");
        return a + b;
    }

    public static void Main()
    {
        Demo obj = new Demo();

        // 1️⃣ Print private value
        Console.WriteLine(obj.Value);

        // 2️⃣ Print label
        Console.WriteLine("Private Value");

        // 3️⃣ Print static constructor message manually
        Console.WriteLine("Static Constructor");

        // 4️⃣ Print static value
        Console.WriteLine(StaticValue);

        // 5️⃣ Call static method
        int result = Add(obj.Value, StaticValue);

        // 6️⃣ Print result
        Console.WriteLine(result);

        // 7️⃣ Print private value again
        Console.WriteLine(obj.Value);
    }
}