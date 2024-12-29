using ClincBussniesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagmentSystem
{
    public partial class ManagePrescription : Form
    {
        public ManagePrescription()
        {
            InitializeComponent();
        }

        private void _ShowAllPrescription()
        {
            guna2DataGridView1.DataSource = null;
            DataTable DT = clsPrescription.GetAllPrescription();
            guna2DataGridView1.DataSource = DT;
        }

        private void ManagePrescription_Load(object sender, EventArgs e)
        {
            _ShowAllPrescription();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)

        {
            FrPrescription f2 = new FrPrescription((int)guna2DataGridView1.CurrentRow.Cells[0].Value, (int)guna2DataGridView1.CurrentRow.Cells[1].Value);
            f2.ShowDialog();
            _ShowAllPrescription();
        }

       



    }
}
