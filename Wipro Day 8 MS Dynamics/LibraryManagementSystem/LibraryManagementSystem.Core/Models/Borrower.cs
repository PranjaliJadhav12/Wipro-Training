using System.Collections.Generic;

namespace LibraryManagementSystem.Core.Models
{
    public class Borrower
    {
        public string Name { get; set; }
        public int BorrowerId { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
        }
    }
}
