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


namespace RepairRequest
{
    public partial class MainForm : Form
    {
        private List<RepairRequestApp.RepairRequest> requests = new List<RepairRequestApp.RepairRequest>();
        public MainForm()
        {
            InitializeComponent();
            UpdateRequestList();
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            var addForm = new RequestForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                requests.Add(addForm.Request);
                UpdateRequestList();
            }

        }
        private void UpdateRequestList()
        {
            lstRequests.Items.Clear();
            foreach (var req in requests)
            {
                lstRequests.Items.Add(req.ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
