using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryClasses;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class LibraryTests
    {
        private Library library;
        private Book testBook1;
        private Book testBook2;

        [TestInitialize]
        public void Setup()
        {
            library = new Library();
            testBook1 = new Book("001", "Test Book 1", "Test Author 1", "Test Publisher", 2024);
            testBook2 = new Book("002", "Test Book 2", "Test Author 2", "Test Publisher", 2024);
        }

        [TestMethod]
        public void Constructor_CreatesEmptyBooksList()
        {
            // Assert
            Assert.AreEqual(0, library.Books.Count);
        }

        [TestMethod]
        public void AddBook_AddsBookToLibrary()
        {
            // Act
            library.addBook(testBook1);

            // Assert
            Assert.AreEqual(1, library.Books.Count);
            Assert.IsTrue(library.Books.Contains(testBook1));
        }

        [TestMethod]
        public void RemoveBook_RemovesBookFromLibrary()
        {
            // Arrange
            library.addBook(testBook1);

            // Act
            library.removeBook(testBook1);

            // Assert
            Assert.AreEqual(0, library.Books.Count);
            Assert.IsFalse(library.Books.Contains(testBook1));
        }

        [TestMethod]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            library.addBook(testBook1);
            library.addBook(testBook2);

            // Act
            List<Book> allBooks = library.getAllBooks();

            // Assert
            Assert.AreEqual(2, allBooks.Count);
            Assert.IsTrue(allBooks.Contains(testBook1));
            Assert.IsTrue(allBooks.Contains(testBook2));
        }

        [TestMethod]
        public void SearchBookByTitle_ExistingTitle_ReturnsMatchingBooks()
        {
            // Arrange
            library.addBook(testBook1);
            library.addBook(testBook2);

            // Act
            List<Book> foundBooks = library.searchBookByTitle("Test Book 1");

            // Assert
            Assert.AreEqual(1, foundBooks.Count);
            Assert.AreEqual(testBook1, foundBooks[0]);
        }

        [TestMethod]
        public void SearchBookByTitle_NonExistingTitle_ReturnsEmptyList()
        {
            // Arrange
            library.addBook(testBook1);

            // Act
            List<Book> foundBooks = library.searchBookByTitle("Non Existing Book");

            // Assert
            Assert.AreEqual(0, foundBooks.Count);
        }

        [TestMethod]
        public void GetAvailableBooks_ReturnsCorrectCount()
        {
            // Arrange
            library.addBook(testBook1);
            library.addBook(testBook2);
            testBook1.IsAvailable = false;

            // Act
            int availableCount = library.getAvailableBooks();

            // Assert
            Assert.AreEqual(1, availableCount);
        }
    }
}