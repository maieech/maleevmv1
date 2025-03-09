using System;
using System.Windows;

namespace ServiceCenterApp
{
    public partial class AssignMasterForm : Window
    {
        public Request CurrentRequest { get; set; }

        public AssignMasterForm(Request request)
        {
            InitializeComponent();
            CurrentRequest = request;
            DataContext = CurrentRequest; // Привязка текущей заявки
        }

        private void BtnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentRequest.ResponsiblePerson))
            {
                MessageBox.Show("Пожалуйста, выберите мастера для выполнения работы.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CurrentRequest.MasterComment))
            {
                MessageBox.Show("Пожалуйста, введите комментарий мастера.");
                return;
            }

            // Обновление информации о мастере и комментарии
            MessageBox.Show($"Мастер {CurrentRequest.ResponsiblePerson} назначен на выполнение работы.");
            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
