using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Core.Models;

namespace LibraryManagementSystem.Core.Services
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Borrower> Borrowers { get; set; } = new List<Borrower>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        public bool BorrowBook(string isbn, Borrower borrower)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null || book.IsBorrowed)
                return false;

            book.Borrow();
            borrower.BorrowBook(book);
            return true;
        }

        public bool ReturnBook(string isbn, Borrower borrower)
        {
            var book = borrower.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
                return false;

            book.Return();
            borrower.ReturnBook(book);
            return true;
        }
    }
}
