using System;
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
            if (string.IsNullOrWhiteSpace(NewRequest.RequestNumber) || string.IsNullOrWhiteSpace(NewRequest.ClientName) || string.IsNullOrWhiteSpace(NewRequest.PhoneNumber))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            DialogResult = true;
            Close();
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
