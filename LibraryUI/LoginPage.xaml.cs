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

namespace LibraryUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow _mainWindow;
        public LoginPage()
        {
            InitializeComponent();
            _mainWindow = Application.Current.MainWindow as MainWindow;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindow == null)
            {
                _mainWindow = Application.Current.MainWindow as MainWindow;
            }

            if (_mainWindow != null && StudentIDTextBox.Text == _mainWindow.student.StudentID && PasswordTextBox.Password == _mainWindow.student.Password)
            {
                _mainWindow.MainFrame.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
