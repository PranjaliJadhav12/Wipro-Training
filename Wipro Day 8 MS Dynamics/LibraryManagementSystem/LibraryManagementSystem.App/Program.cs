using System;
using LibraryManagementSystem.Core.Models;
using LibraryManagementSystem.Core.Services;

namespace LibraryManagementSystem.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            var book = new Book
            {
                Title = "Clean Code",
                Author = "Robert Martin",
                ISBN = "123"
            };

            var borrower = new Borrower
            {
                Name = "Rushikesh",
                BorrowerId = 1
            };

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            bool result = library.BorrowBook("123", borrower);

            Console.WriteLine(result
                ? "Book borrowed successfully"
                : "Book already borrowed");

            Console.ReadLine();
        }
    }
}
