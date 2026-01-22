using System;
namespace CalculatorLibrary
{
    /// <summary> 
    /// Simple Calculator with basic operations 
    /// </summary> 
    public class Calculator
    {
        /// <summary> 
        /// Add two numbers 
        /// </summary> 
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary> 
        /// Subtract two numbers 
        /// </summary> 
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        /// <summary> 
        /// Multiply two numbers 
        /// </summary> 
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        /// <summary> 
        /// Divide two numbers 
        /// </summary> 
        /// <exception cref="DivideByZeroException">When dividing by zero</exception> 
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");

            return a / b;
        }
    }
}
