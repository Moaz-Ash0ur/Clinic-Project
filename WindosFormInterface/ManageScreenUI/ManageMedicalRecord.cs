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
    public partial class ManageMedicalRecord : Form
    {
        public ManageMedicalRecord()
        {
            InitializeComponent();
        }

        public void _ShowAllMedicalRecord()
        {
            guna2DataGridView1.DataSource = null;
            DataTable DT = clsMedicalRecord.GetAllMedicalRecord();
            guna2DataGridView1.DataSource = DT; 
        }

        private void ManageMedicalRecord_Load(object sender, EventArgs e)
        {
            _ShowAllMedicalRecord();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frMedicalRecord f2 = new frMedicalRecord((int)guna2DataGridView1.CurrentRow.Cells[0].Value);
            f2.ShowDialog();
            _ShowAllMedicalRecord();
        }




    }
}
