using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryClasses;

namespace LibraryUI
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private MainWindow _mainWindow;
        private Book selectedBook;

        public HomePage()
        {
            InitializeComponent();
            _mainWindow = Application.Current.MainWindow as MainWindow;
            
            RefreshBooksList();
        }

        private void RefreshBooksList()
        {
            if (_mainWindow?.library != null)
            {
                BooksDataGrid.ItemsSource = _mainWindow.library.Books;
                ClearBookDetails();
            }
        }

        private void ClearBookDetails()
        {
            BookIDTextBlock.Text = "Book ID: ";
            TitleTextBlock.Text = "Title: ";
            AuthorTextBlock.Text = "Author: ";
            PublisherTextBlock.Text = "Publisher: ";
            YearPublishedTextBlock.Text = "Year Published: ";
            StatusTextBlock.Text = "Status: ";
            BorrowButton.IsEnabled = false;
        }

        private void UpdateBookDetails(Book book)
        {
            if (book != null)
            {
                BookIDTextBlock.Text = $"Book ID: {book.BookID}";
                TitleTextBlock.Text = $"Title: {book.Title}";
                AuthorTextBlock.Text = $"Author: {book.Author}";
                PublisherTextBlock.Text = $"Publisher: {book.Publisher}";
                YearPublishedTextBlock.Text = $"Year Published: {book.YearPublished}";
                StatusTextBlock.Text = $"Status: {(book.IsAvailable ? "Available" : "Borrowed")}";
                BorrowButton.IsEnabled = book.IsAvailable;
            }
            else
            {
                ClearBookDetails();
            }
        }

        private void MyBooks_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("My Books feature coming soon!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("My Profile feature coming soon!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                RefreshBooksList();
                return;
            }

            var filteredBooks = _mainWindow.library.Books.Where(b => 
                b.Title.ToLower().Contains(searchTerm) || 
                b.Author.ToLower().Contains(searchTerm) ||
                b.BookID.ToLower().Contains(searchTerm)
            ).ToList();

            BooksDataGrid.ItemsSource = filteredBooks;
        }

        private void BookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = BooksDataGrid.SelectedItem as Book;
            UpdateBookDetails(selectedBook);
        }

        private void BorrowButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null && selectedBook.IsAvailable)
            {
                selectedBook.IsAvailable = false;
                MessageBox.Show($"Successfully borrowed '{selectedBook.Title}'!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateBookDetails(selectedBook);
                BooksDataGrid.Items.Refresh();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
