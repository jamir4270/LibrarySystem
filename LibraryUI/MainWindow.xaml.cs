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
    public partial class MainWindow : Window
    {
        public LoginPage loginPage;
        public HomePage homePage;

        public Library library = new Library();
        public Book book = new Book("001", "No Longer Human", "Osamu Dazai", "Chikuma Shobō", 1948);
        
        public Student student = new Student("23-1-00194", "Jamir Oasis Andrade", "jamirandrade@gmail.com" ,"Ederlezi", "Computer Science");

        public MainWindow()
        {
            InitializeComponent();
            
            library.addBook(book);
            
            loginPage = new LoginPage();
            homePage = new HomePage();
            MainFrame.Navigate(loginPage);
        }
    }
}
