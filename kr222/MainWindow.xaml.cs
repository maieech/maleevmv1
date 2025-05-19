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

namespace kr222
{
    public partial class MainWindow : Window
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();
        private User currentUser = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTestData();
            RefreshBooksList();
        }

        private void InitializeTestData()
        {
            users.Add(new User
            {
                Login = "admin",
                Password = "admin",
                FullName = "Администратор",
                PhoneNumber = "1234567890",
                RegistrationDate = DateTime.Now.Date
            });

            books.Add(new Book
            {
                Article = "001",
                Title = "Война и мир",
                Genre = "Роман",
                Description = "Классика русской литературы",
                ReleaseDate = new DateTime(1869, 1, 1),
                Status = BookStatus.Available
            });
        }

        private void RefreshBooksList()
        {
            dgBooks.ItemsSource = null;
            dgBooks.ItemsSource = books;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            var user = users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                currentUser = user;
                lblUserInfo.Text = $"Вы вошли как: {user.FullName}";
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            if (registerWindow.ShowDialog() == true)
            {
                users.Add(registerWindow.NewUser);
                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isBookSelected = dgBooks.SelectedItem != null;
            btnEditBook.IsEnabled = isBookSelected;
            btnIssueBook.IsEnabled = isBookSelected && currentUser != null;
            btnReturnBook.IsEnabled = isBookSelected && currentUser != null;
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Для добавления книги необходимо авторизоваться", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var editWindow = new BookEditWindow();
            if (editWindow.ShowDialog() == true)
            {
                books.Add(editWindow.Book);
                RefreshBooksList();
            }
        }

        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Для редактирования книги необходимо авторизоваться", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dgBooks.SelectedItem is Book selectedBook)
            {
                var editWindow = new BookEditWindow(selectedBook);
                if (editWindow.ShowDialog() == true)
                {
                    RefreshBooksList();
                }
            }
        }

        private void btnIssueBook_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser == null) return;

            if (dgBooks.SelectedItem is Book selectedBook)
            {
                if (selectedBook.Status == BookStatus.Available)
                {
                    selectedBook.Status = BookStatus.Issued;
                    selectedBook.CurrentReader = currentUser;
                    RefreshBooksList();
                }
            }
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser == null) return;

            if (dgBooks.SelectedItem is Book selectedBook)
            {
                if (selectedBook.Status == BookStatus.Issued && selectedBook.CurrentReader == currentUser)
                {
                    selectedBook.Status = BookStatus.Available;
                    selectedBook.CurrentReader = null;
                    RefreshBooksList();
                }
            }
        }
    }

    public enum BookStatus
    {
        Available,
        Issued,
        Maintenance
    }

    public class Book
    {
        public string Article { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BookStatus Status { get; set; }
        public User CurrentReader { get; set; }
    }

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

