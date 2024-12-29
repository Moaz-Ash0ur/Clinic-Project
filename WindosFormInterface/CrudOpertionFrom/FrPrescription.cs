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
    public partial class FrPrescription : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PrescriptionID;
        public clsPrescription _Prescription;
        int _MedicalRecordID2;

        public FrPrescription(int id,int MidRecord)
        {
            InitializeComponent();

            _PrescriptionID = id;

            _MedicalRecordID2 = MidRecord;

            if (_PrescriptionID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;

        }

        private void LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add Prescription";
                _Prescription = new clsPrescription();
                return;
            }

            _Prescription = clsPrescription.Find(_PrescriptionID);

            if (_Prescription == null)
            {
                MessageBox.Show("This form will be closed because No Prescription with ID = " + _PrescriptionID);
                this.Close();

                return;
            }

            this.Text = "Update Prescription";
            lbPrescriptionid.Text = _Prescription.PrescriptionID.ToString();
            lbMedicalRecordID.Text = _Prescription.MedicalRecordID.ToString();
            txtMedcationName.Text = _Prescription.MedicationName;
            txtDosage.Text = _Prescription.Dosage;
            txtFrequency.Text = _Prescription.Frequency;    
            txtStartDate.Value = _Prescription.StartDate;   
            txtEndDate.Value = _Prescription.EndDate;   
            txtNote.Text = _Prescription.SpecialInstructions;



        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {

            _Prescription.MedicalRecordID = _MedicalRecordID2;

            _Prescription.MedicationName = txtMedcationName.Text;
            _Prescription.Dosage = txtDosage.Text;
            _Prescription.Frequency = txtFrequency.Text;
            _Prescription.StartDate = txtStartDate.Value ;
            _Prescription.EndDate = txtEndDate.Value;
            _Prescription.SpecialInstructions = txtNote.Text;


            if (_Prescription.Save())
            {
                _PrescriptionID = _Prescription.PrescriptionID;
                lbPrescriptionid.Text = _PrescriptionID.ToString();
                lbMedicalRecordID.Text = _MedicalRecordID2.ToString();
                if (MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK) == DialogResult.OK)
                {

                    this.Close();

                }

            }
            else
                MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);

            _Mode = enMode.Update;
        }

        private void FrPrescription_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Close();
        }



    }
}
