using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ServiceCenterApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Request> Requests { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Requests = new ObservableCollection<Request>();
            dgRequests.ItemsSource = Requests;
        }

        private void BtnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            var requestForm = new RequestForm();
            if (requestForm.ShowDialog() == true)
            {
                Requests.Add(requestForm.NewRequest);
            }
        }

        private void BtnEditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (dgRequests.SelectedItem is Request selectedRequest)
            {
                var requestForm = new RequestForm(selectedRequest);
                if (requestForm.ShowDialog() == true)
                {
                    var index = Requests.IndexOf(selectedRequest);
                    Requests[index] = requestForm.NewRequest;
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования.");
            }
        }

        private void BtnAssignMaster_Click(object sender, RoutedEventArgs e)
        {
            if (dgRequests.SelectedItem is Request selectedRequest)
            {
                var assignMasterForm = new AssignMasterForm(selectedRequest);
                if (assignMasterForm.ShowDialog() == true)
                {
                    MessageBox.Show($"Мастер {selectedRequest.ResponsiblePerson} назначен на выполнение работы.");
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для назначения мастера.");
            }
        }

        private void BtnShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            var statisticsForm = new StatisticsForm(Requests.ToList()); 
            statisticsForm.ShowDialog(); 
        }



        private void BtnSearchRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

