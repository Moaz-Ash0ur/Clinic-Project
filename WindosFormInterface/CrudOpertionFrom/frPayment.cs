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
    public partial class frPayment : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public int _PaymentID;
        public clsPayments _Payment;


        public frPayment(int id)
        {
            InitializeComponent();

            _PaymentID = id;

            if (_PaymentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;


        }

        private void LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add Payments";
                _Payment = new clsPayments();
                return;
            }

            _Payment = clsPayments.Find(_PaymentID);

            if (_Payment == null)
            {
                MessageBox.Show("This form will be closed because No Payment with ID = " + _PaymentID);
                this.Close();

                return;
            }

            this.Text = "Update Payment";
            lbIdPay.Text = _PaymentID.ToString();
            txtAmount.Text = (_Payment.AmountPaid).ToString();
            txtMethodPay.Text = _Payment.PaymentMethod;
            txtDate.Value = _Payment.PaymentDate;
            txtNote.Text = _Payment.AdditionalNotes;

        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {

            _Payment.AmountPaid = Convert.ToInt32(txtAmount.Text);
            _Payment.PaymentMethod = txtMethodPay.SelectedItem.ToString();
            _Payment.PaymentDate = txtDate.Value;
            _Payment.AdditionalNotes = txtNote.Text;

            if (_Payment.Save())
            {
                lbIdPay.Text = _Payment.PaymentID.ToString();
                _PaymentID = _Payment.PaymentID;
                if (MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                }

            }
            else
                MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);

            _Mode = enMode.Update;
        }

        private void frPayment_Load(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
