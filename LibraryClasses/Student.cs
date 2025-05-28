using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClasses;

namespace LibraryClasses
{
    public class Student
    {
        private string studentID;
        private string name;
        private string email;
        private string password;
        private string program;

        private List<Book> borrowedBooks;
        private const int maxBooks = 5;

        public Student(string studentID, string name, string email, string password, string program)
        {
            StudentID = studentID;
            Name = name;
            Email = email;
            Password = password;
            Program = program;
            borrowedBooks = new List<Book>();
        }

        public string StudentID
        {
            get { return studentID; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Student ID cannot be null or empty.");
                }
                studentID = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Email must be a valid email address.");
                }
                email = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                {
                    throw new ArgumentException("Password must be at least 6 characters long.");
                }
                password = value;
            }
        }

        public string Program
        {
            get { return program; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Program cannot be null or empty.");
                }
                program = value;
            }
        }

        public List<Book> BorrowedBooks
        {
            get { return borrowedBooks; }
        }

        public bool BorrowBook(Book book)
        {
            if(borrowedBooks.Count < maxBooks)
            {
                book.IsAvailable = false;
                borrowedBooks.Add(book);
                return true;
            }
            return false;
        }

        public void ReturnBook(Book book)
        {
            borrowedBooks.Remove(book);
        }
    }
}
