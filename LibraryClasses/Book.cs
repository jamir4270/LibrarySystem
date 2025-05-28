using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClasses
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }

        private string bookID;
        private bool isAvailable;
        private string status;

        public Book(string bookID, string title, string author, string publisher, int yearPublished)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            Publisher = publisher;
            YearPublished = yearPublished;
            IsAvailable = true; // Default to available when created
            Status = "Available"; // Default status
        }

        public string BookID
        {
            get { return bookID; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Book ID cannot be null or empty.");
                }
                bookID = value;
            }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public string Status
        {
            get 
            { 
                if(isAvailable)
                {
                    return "Available";
                }
                else
                {
                    return "Unavailable"; // Return the custom status if not available
                } 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Status cannot be null or empty.");
                }
                status = value;
            }
        }
    }
}
