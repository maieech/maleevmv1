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
using System.Windows.Shapes;

namespace kr222
{

    public partial class RegisterWindow : Window
    {
        public User NewUser { get; private set; }

        public RegisterWindow()
        {
            InitializeComponent();
            NewUser = new User
            {
                RegistrationDate = DateTime.Now.Date
            };
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password) ||
                string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Заполните обязательные поля (Логин, Пароль и ФИО)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewUser.Login = txtLogin.Text;
            NewUser.Password = txtPassword.Password;
            NewUser.FullName = txtFullName.Text;
            NewUser.PhoneNumber = txtPhone.Text;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

