using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace ServiceCenterApp
{
    public partial class RequestForm : Window
    {
        public Request NewRequest { get; set; }

        public RequestForm()
        {
            InitializeComponent();
            NewRequest = new Request();
            NewRequest.RequestDate = DateTime.Today;
            DataContext = NewRequest;
        }

        public RequestForm(Request request)
        {
            InitializeComponent();
            NewRequest = request;
            DataContext = NewRequest;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewRequest.RequestNumber) ||
                string.IsNullOrWhiteSpace(NewRequest.ClientName) ||
                string.IsNullOrWhiteSpace(NewRequest.PhoneNumber))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }


            if (!ValidatePhoneNumber(NewRequest.PhoneNumber))
            {
                MessageBox.Show("Номер телефона должен содержать только цифры и быть длиной 10 символов.");
                return;
            }

            DialogResult = true;
            Close();
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            var regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(phoneNumber);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

