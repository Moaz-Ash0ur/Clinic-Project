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
using System.Xml.Linq;

namespace ClinicManagmentSystem
{
    public partial class frMedicalRecord : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _MedicalRecordID;
        public clsMedicalRecord _MedicalRecord;

        public frMedicalRecord(int id)
        {
            InitializeComponent();

            _MedicalRecordID = id;

            if (_MedicalRecordID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        //after git id from another form load data 
        private void LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add Medical Record";
                _MedicalRecord = new clsMedicalRecord();
                return;
            }

             _MedicalRecord = clsMedicalRecord.Find(_MedicalRecordID);

            if (_MedicalRecord == null)
            {
                MessageBox.Show("This form will be closed because No Medical Record with ID = " + _MedicalRecordID);
                this.Close();

                return;
            }

            this.Text = "Update Medical Record";
            lbMedicalRecordID.Text = _MedicalRecordID.ToString();
            txtDecrption.Text = _MedicalRecord.VisitDescription;
            txtDigns.Text = _MedicalRecord.Diagnosis;
            txtNote.Text = _MedicalRecord.AdditionalNotes;



        }

        private void btnSaveMedical_Click(object sender, EventArgs e)
        {
            
             _MedicalRecord.VisitDescription = txtDecrption.Text;
             _MedicalRecord.Diagnosis = txtDigns.Text;
            _MedicalRecord.AdditionalNotes = txtNote.Text ;


            if (_MedicalRecord.Save())
            {
                _MedicalRecordID = _MedicalRecord.MedicalRecordID;
                lbMedicalRecordID.Text = _MedicalRecordID.ToString();
                if (MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    btnAddPrescr.Enabled = true;   
                }

            }
            else
                MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);

            _Mode = enMode.Update;
           
        }

        private void frMedicalRecord_Load(object sender, EventArgs e)
        {
            LoadData();
        }




        //ADD prescrption to medical record
        private void btnAddPrescr_Click(object sender, EventArgs e)
        {
            FrPrescription fr = new FrPrescription(-1,_MedicalRecordID);
            fr.ShowDialog();    
        }



    }
}
