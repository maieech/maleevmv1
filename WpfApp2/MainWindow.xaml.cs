using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ServiceCenterApp
{
    public partial class MainWindow : Window
    {
        // Коллекция заявок для отображения в DataGrid
        public ObservableCollection<Request> Requests { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Requests = new ObservableCollection<Request>();
            dgRequests.ItemsSource = Requests; // Привязка коллекции заявок к DataGrid
        }

        // Открытие формы добавления новой заявки
        private void BtnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            var requestForm = new RequestForm();
            if (requestForm.ShowDialog() == true) // Если форма закрыта с результатом "Сохранить"
            {
                // Добавляем новую заявку в коллекцию
                Requests.Add(requestForm.NewRequest);
            }
        }

        // Открытие формы редактирования заявки
        private void BtnEditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (dgRequests.SelectedItem is Request selectedRequest)
            {
                var requestForm = new RequestForm(selectedRequest); // Передаем выбранную заявку для редактирования
                if (requestForm.ShowDialog() == true)
                {
                    // Обновляем заявку в коллекции
                    var index = Requests.IndexOf(selectedRequest);
                    Requests[index] = requestForm.NewRequest;
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования.");
            }
        }

        // Поиск заявки (реализуем позже)
        private void BtnSearchRequest_Click(object sender, RoutedEventArgs e)
        {
            // Логика поиска заявки
        }
    }
}
