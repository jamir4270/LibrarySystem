using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClasses
{
    public class Library
    {
        private List<Book> books;

        public List<Book> Books => books;

        public Library()
        {
            books = new List<Book>();
        }

        public List<Book> getAllBooks()
        {
            return books;
        }

        public List<Book> searchBookByTitle(string title)
        {
            List<Book> searchedBooks = new List<Book>();

            foreach(Book book in books)
            {
                if(book.Title ==  title)
                    searchedBooks.Add(book);
            }
            return searchedBooks;
        }

        public void addBook(Book book)
        {
            books.Add(book);
        }
        public void removeBook(Book book)
        {
            books.Remove(book);
        }
        public int getAvailableBooks()
        {
            int availableBooks = 0;
            foreach(Book book in books)
            {
                if (book.IsAvailable)
                    availableBooks++;
            }
            return availableBooks;
        }


    }
}
