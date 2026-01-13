// See https://aka.ms/new-console-template for more information
using Demo3_AbstractClassesInAction;

Console.WriteLine("Hello, World!");
using System;

namespace Demo_AbstractClassesInAction
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new DiscountedProduct()
            {
                Name = "Laptop",
                Price = 50000,
                DiscountPercent = 10
            };

            product.DisplayProduct();
            Console.WriteLine($"Final Price: {product.CalculateFinalPrice()}");

            Console.ReadLine();
        }
    }
}