using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepairRequestApp;


namespace RepairRequestApp
{
    public partial class RequestForm : Form
    {
        public RepairRequest Request { get; private set; }

        public RequestForm()
        {
            InitializeComponent();
            cmbDeviceType.Items.AddRange(new string[] { "Холодильник", "Стиральная машина", "Телевизор" });
            cmbStatus.Items.AddRange(new string[] { "Новая", "В процессе ремонта", "Завершена" });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Request = new RepairRequest
                {
                    Id = txtId.Text,
                    DateAdded = dtpDate.Value,
                    DeviceType = cmbDeviceType.SelectedItem.ToString(),
                    Model = txtModel.Text,
                    Description = txtDescription.Text,
                    ClientName = txtClientName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Status = cmbStatus.SelectedItem.ToString()
                };
                DialogResult = DialogResult.OK;
                Close();
            }

        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text) ||
                string.IsNullOrWhiteSpace(txtClientName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void RequestForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
