using System.Windows;

namespace ServiceCenterApp
{
    public partial class AssignMasterForm : Window
    {
        private readonly Request _request;

        public AssignMasterForm(Request request)
        {
            InitializeComponent();
            _request = request;
        }

        private void BtnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (cbMasters.SelectedItem != null)
            {
                _request.AssignedMaster = cbMasters.SelectedItem.ToString();  // Назначаем мастера
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мастера.");
            }
        }
    }
}

