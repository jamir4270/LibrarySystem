using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryClasses;
using System;

namespace UnitTest
{
    [TestClass]
    public class StudentTests
    {
        private Student student;
        private Book testBook;

        [TestInitialize]
        public void Setup()
        {
            student = new Student("23-1-00001", "Test Student", "test@student.com", "password123", "Computer Science");
            testBook = new Book("001", "Test Book", "Test Author", "Test Publisher", 2024);
        }

        [TestMethod]
        public void Constructor_ValidInput_CreatesStudentWithCorrectProperties()
        {
            // Assert
            Assert.AreEqual("23-1-00001", student.StudentID);
            Assert.AreEqual("Test Student", student.Name);
            Assert.AreEqual("test@student.com", student.Email);
            Assert.AreEqual("password123", student.Password);
            Assert.AreEqual("Computer Science", student.Program);
            Assert.AreEqual(0, student.BorrowedBooks.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyStudentID_ThrowsArgumentException()
        {
            new Student("", "Test Student", "test@student.com", "password123", "Computer Science");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidEmail_ThrowsArgumentException()
        {
            new Student("23-1-00001", "Test Student", "invalid-email", "password123", "Computer Science");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShortPassword_ThrowsArgumentException()
        {
            new Student("23-1-00001", "Test Student", "test@student.com", "12345", "Computer Science");
        }

        [TestMethod]
        public void BorrowBook_UnderLimit_ReturnsTrue()
        {
            // Act
            bool result = student.BorrowBook(testBook);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, student.BorrowedBooks.Count);
            Assert.IsFalse(testBook.IsAvailable);
        }

        [TestMethod]
        public void BorrowBook_OverLimit_ReturnsFalse()
        {
            // Arrange
            for (int i = 0; i < 5; i++)
            {
                Book book = new Book($"00{i}", "Test Book", "Test Author", "Test Publisher", 2024);
                student.BorrowBook(book);
            }

            // Act
            bool result = student.BorrowBook(testBook);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(5, student.BorrowedBooks.Count);
            Assert.IsTrue(testBook.IsAvailable);
        }

        [TestMethod]
        public void ReturnBook_ExistingBook_RemovesFromBorrowedBooks()
        {
            // Arrange
            student.BorrowBook(testBook);

            // Act
            student.ReturnBook(testBook);

            // Assert
            Assert.AreEqual(0, student.BorrowedBooks.Count);
        }
    }
}