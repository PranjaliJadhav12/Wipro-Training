using NUnit.Framework;
using LibraryManagementSystem.Core.Models;
using LibraryManagementSystem.Core.Services;

namespace LibraryManagementSystem.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library _library;
        private Borrower _borrower;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
            _borrower = new Borrower
            {
                Name = "Rushikesh",
                BorrowerId = 1
            };
        }

        // 1️⃣ Test: Add Book
        [Test]
        public void AddBook_ShouldIncreaseBookCount()
        {
            var book = new Book
            {
                Title = "Clean Code",
                Author = "Robert Martin",
                ISBN = "123"
            };

            _library.AddBook(book);

            Assert.That(_library.Books.Count, Is.EqualTo(1));
        }

        // 2️⃣ Test: Borrow Book (Available)
        [Test]
        public void BorrowBook_WhenAvailable_ShouldReturnTrue()
        {
            var book = new Book
            {
                Title = "1984",
                Author = "George Orwell",
                ISBN = "456"
            };

            _library.AddBook(book);

            var result = _library.BorrowBook("456", _borrower);

            Assert.That(result, Is.True);
            Assert.That(book.IsBorrowed, Is.True);
            Assert.That(_borrower.BorrowedBooks.Count, Is.EqualTo(1));
        }

        // 3️⃣ Test: Borrow Book (Already Borrowed)
        [Test]
        public void BorrowBook_WhenAlreadyBorrowed_ShouldReturnFalse()
        {
            var book = new Book
            {
                Title = "Dune",
                Author = "Frank Herbert",
                ISBN = "789",
                IsBorrowed = true
            };

            _library.AddBook(book);

            var result = _library.BorrowBook("789", _borrower);

            Assert.That(result, Is.False);
            Assert.That(book.IsBorrowed, Is.True);
            Assert.That(_borrower.BorrowedBooks.Count, Is.EqualTo(0));
        }

        // 4️⃣ Test: Return Book
        [Test]
        public void ReturnBook_WhenBorrowed_ShouldReturnTrue()
        {
            var book = new Book
            {
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                ISBN = "111"
            };

            _library.AddBook(book);
            _library.BorrowBook("111", _borrower);

            var result = _library.ReturnBook("111", _borrower);

            Assert.That(result, Is.True);
            Assert.That(book.IsBorrowed, Is.False);
            Assert.That(_borrower.BorrowedBooks.Count, Is.EqualTo(0));
        }
    }
}
