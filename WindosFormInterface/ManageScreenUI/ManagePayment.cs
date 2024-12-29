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
    public partial class ManagePayment : Form
    {
        public ManagePayment()
        {
            InitializeComponent();
        }

        private void _ShowAllPayments()
        {
            guna2DataGridView1.DataSource = null;
            DataTable dt = clsPayments.GetAllPayments();
            guna2DataGridView1.DataSource = dt;
           
        }

        private void ManagePayment_Load(object sender, EventArgs e)
        {
            _ShowAllPayments();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            frPayment fr = new frPayment(-1);
            fr.ShowDialog();
            _ShowAllPayments();
        }


    }
}
