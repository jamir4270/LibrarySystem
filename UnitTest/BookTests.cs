using System;
using LibraryClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Constructor_ValidInput_CreatesBookWithCorrectProperties()
        {
            // Arrange
            string bookId = "001";
            string title = "Test Book";
            string author = "Test Author";
            string publisher = "Test Publisher";
            int yearPublished = 2024;

            // Act
            Book book = new Book(bookId, title, author, publisher, yearPublished);

            // Assert
            Assert.AreEqual(bookId, book.BookID);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(publisher, book.Publisher);
            Assert.AreEqual(yearPublished, book.YearPublished);
            Assert.IsTrue(book.IsAvailable);
            Assert.AreEqual("Available", book.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyBookID_ThrowsArgumentException()
        {
            // Arrange & Act
            new Book("", "Test Book", "Test Author", "Test Publisher", 2024);
        }

        [TestMethod]
        public void IsAvailable_WhenChanged_UpdatesStatus()
        {
            // Arrange
            Book book = new Book("001", "Test Book", "Test Author", "Test Publisher", 2024);

            // Act
            book.IsAvailable = false;

            // Assert
            Assert.IsFalse(book.IsAvailable);
            Assert.AreEqual("Unavailable", book.Status);

            // Act again
            book.IsAvailable = true;

            // Assert again
            Assert.IsTrue(book.IsAvailable);
            Assert.AreEqual("Available", book.Status);
        }
    }
}
