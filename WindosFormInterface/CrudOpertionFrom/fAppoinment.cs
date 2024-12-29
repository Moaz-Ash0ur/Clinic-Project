using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClincBussniesLayer;
using Guna.UI2.WinForms.Suite;

namespace ClinicManagmentSystem
{
    public partial class fAppoinment : Form
    {

        private int DocID;
        private int PatID;
        private int AppoinmentID;
        private int MedicalRecordIDPrv = -1;
        private int PaymentIDPrv = -1;

        public fAppoinment()
        {
            InitializeComponent();
        }

        private void _CheckVisible()
        {
            if (btnAddAppoiment.Visible == false)
            {
                btnAddAppoiment.Visible = true;
            }
          
            if (guna2DataGridView1.Visible == false)
            {
                guna2DataGridView1.Visible = true;

            }
            if (btnSave.Visible == true)
            {

                btnSave.Visible = false;

            }
            if (btnCancel.Visible == true)
            {
                btnCancel.Visible = false;

            }
            if (TabConApp.Visible == true)
            {
                TabConApp.Visible = false;
            }
            
           
            if (btnViewMidcal.Visible == false)
            {
                btnViewMidcal.Visible = true;
            }

            if (btnViewPrescp.Visible == false)
            {
                btnViewPrescp.Visible = true;
            }



        }

        private void _ShowAllAppoimnents()
        {
            // Fetch updated data and bind to DataGridView
            guna2DataGridView1.DataSource = null;
            DataTable dt = clsAppointments.GetAllAppoinments();
            guna2DataGridView1.DataSource = dt;
        } 

        private void _InLoadFillID()
        {
            List<int> list =  clsAppointments.GetDoctorID();

            combDoctor.DataSource = list;

            List<int> list1 = clsAppointments.GetAllPateintID();
            combPateint.DataSource = list1;


        }

        private void _ShowInfoInComboDcotr()
        {
            
            DataTable dt =  clsAppointments.GetDoctorInfo(DocID);

            foreach (DataRow row in dt.Rows)
            {
               txtNameDoc.Text = (row[0]).ToString();
               txtSpecDoc.Text = (row[1]).ToString();
            }

        }

        private void _ShowInfoInComboPateint()
        {
           
            DataTable dt = clsAppointments.GetPateintInfo(PatID);

            foreach (DataRow row in dt.Rows)
            {
                txtPatName.Text = (row[0]).ToString();
                txtPhone.Text = (row[1]).ToString();
            }

        }

        private bool _CheckDateTimeAppoinment()
        {
          
            TimeSpan selectedTime = txtTime.Value.TimeOfDay;

            DateTime selectedDate = txtDateTime.Value.Date;

            DateTime combinedDateTime = selectedDate.Add(selectedTime);

            txtDateTime.Value = combinedDateTime;


            // Check if the date-time exists in the database
            if (clsAppointments.IsAppointmentDateExists(txtDateTime.Value,DocID))
            {
                MessageBox.Show("This time have an Appoinment to this doctor select another time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;

        }


        //start Evebnt fun
        private void fAppoinment_Load(object sender, EventArgs e)
        {
            _InLoadFillID();
            _ShowAllAppoimnents();

            txtTime.Format = DateTimePickerFormat.Time; 
            txtTime.ShowUpDown = true;

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _ShowAllAppoimnents();
            _CheckVisible();
        }

        private void combDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

            DocID = (int)combDoctor.SelectedItem;
            _ShowInfoInComboDcotr();

        }

        private void combPateint_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatID = (int)combPateint.SelectedItem;
            _ShowInfoInComboPateint();
        }

        private void AddAppoiment_Click(object sender, EventArgs e)
        {
          if(lbAppoinID.Text != "??")
            {
                ClearAfterAdd();
            }

            TabConApp.Visible = true;   
            btnAddAppoiment.Visible = false;  
            btnViewMidcal.Visible = false;
            btnViewPrescp.Visible = false;  
            btnSave.Visible = true;
            btnCancel.Visible = true;
            guna2DataGridView1.Visible = false;
            AppoinmentID = -1;
        }

        private void ClearAfterAdd()
        {
            lbAppoinID.Text = "";
            combPateint.SelectedIndex = 0;
            combDoctor.SelectedIndex = 0;
            txtDateTime.Value = DateTime.Now;
            combStatus.SelectedIndex = -1;
            txtNameDoc.Text = "";
            txtSpecDoc.Text = "";
            txtPatName.Text = "";
            txtPhone.Text = "";
            btnGetMedicalRecord.Enabled = false;
            lbMedicalRecord.Text = "??";
            lbPaymentID.Text = "??";
        }

        //Add Appoinment
        private void _AddNewAppoinment()
        {
            clsAppointments appointment = new clsAppointments();

            appointment.pateintid = (int)combPateint.SelectedItem;
            appointment.doctorid = (int)combDoctor.SelectedItem;
            appointment.appointDate = txtDateTime.Value;

            try
            {
                appointment.appointStatus = combStatus.SelectedItem.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            appointment.MedicalRecord = MedicalRecordIDPrv;
            appointment.PaymentID = PaymentIDPrv;

            if (!_CheckDateTimeAppoinment()) return;

            DialogResult result = MessageBox.Show("Are you Sure Add Apoinments ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if (appointment.Save())
                {

                    lbAppoinID.Text = appointment.AppoimentID.ToString();
                    MessageBox.Show($"Appointment With ID [{appointment.AppoimentID.ToString()}] Addedd Successfully", "Confirm", MessageBoxButtons.YesNo);
                    _ShowAllAppoimnents();
                    ClearAfterAdd();
                }
                else
                {
                    MessageBox.Show($"Faild To Add !", "Confirm", MessageBoxButtons.OK);
                    ClearAfterAdd();
                }

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show($"Added Canceld !", "Confirm", MessageBoxButtons.OK);
                ClearAfterAdd();
            }

        }


         private void btnSave_Click(object sender, EventArgs e)
        {

            if (AppoinmentID == -1)
            {
                _AddNewAppoinment();
            }
            else if(AppoinmentID != -1)
            {
                _UpdateNewAppoinment();
            }
            ClearAfterAdd();
        }


        //=============================================================================
       
        //Update Appoinmemt
        private void _FillDateTimeMnual()
        {
            TimeSpan selectedTime = txtTime.Value.TimeOfDay;

            DateTime selectedDate = txtDateTime.Value.Date;

            DateTime combinedDateTime = selectedDate.Add(selectedTime);

            txtDateTime.Value = combinedDateTime;

        }

        private void _UpdateNewAppoinment()
        {
           
            clsAppointments appointment = clsAppointments.Find(AppoinmentID);

            appointment.pateintid = (int)combPateint.SelectedItem;
            appointment.doctorid = (int)combDoctor.SelectedItem;
            _FillDateTimeMnual();
            appointment.appointDate = txtDateTime.Value;

            appointment.appointStatus = combStatus.SelectedItem.ToString();

            if (lbMedicalRecord.Text!="??")
            {
                appointment.MedicalRecord = Convert.ToInt32(lbMedicalRecord.Text);
            }
            if (lbPaymentID.Text!="??")
            {
                appointment.PaymentID = Convert.ToInt32(lbPaymentID.Text);
            }
          


            if (!_CheckDateTimeAppoinment()) return;


            if (appointment.Save())
            {
                MessageBox.Show($"Appointment With ID [{appointment.AppoimentID.ToString()}] Updated Successfully", "Confirm", MessageBoxButtons.YesNo);
                _ShowAllAppoimnents();
            }
            else
            {
                MessageBox.Show($"Faild To Updated !", "Confirm", MessageBoxButtons.OK);

            }
            _ShowAllAppoimnents();
        }

        private void _ShowAppoinmentToUpdate()
        {

            AppoinmentID = (int)guna2DataGridView1.CurrentRow.Cells[0].Value;

            clsAppointments appointment = clsAppointments.Find(AppoinmentID);

            lbAppoinID.Text = AppoinmentID.ToString();
            combPateint.SelectedItem = appointment.pateintid;
            combDoctor.SelectedItem = appointment.doctorid;
            txtDateTime.Value = appointment.appointDate;


            if (appointment.MedicalRecord <= 0)
            {
                lbMedicalRecord.Text = "??";
            }
            else
            {
                lbMedicalRecord.Text = appointment.MedicalRecord.ToString();
            }

            if (appointment.PaymentID <= 0)
            {
                lbPaymentID.Text = "??";
            }
            else
            {
                lbPaymentID.Text = appointment.PaymentID.ToString();
            }


            //handel time and date
            TimeSpan timePart = txtDateTime.Value.TimeOfDay;
            txtTime.Value = txtTime.Value.Date.Add(timePart);

            combStatus.SelectedItem = appointment.appointStatus.ToString();

        }

        private void UpdatelStripMenuItem_Click(object sender, EventArgs e)
        {
          
            TabConApp.Visible = true;
            btnAddAppoiment.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            guna2DataGridView1.Visible = false;
            btnViewMidcal.Visible = false;
            btnViewPrescp.Visible = false;    

            _ShowAppoinmentToUpdate();
        }

        //delete Appoinemt

        private void DleteStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Appoinments [" + guna2DataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsAppointments.DeleteFullAppoinment((int)guna2DataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Appoinments Deleted Successfully.");
                    _ShowAllAppoimnents();
                }
                else
                    MessageBox.Show("Appoinments is not deleted.");

            }

        }

        //===================================================================================
        //get data from another form Medical record
        private void _CheckMedicalRecordStatus(string selected ="")
        {
            if(selected == "Completed")
            {
                btnGetMedicalRecord.Enabled = true;
            }
            else
            {
                btnGetMedicalRecord.Enabled = false;    
            }
        }


        private void btnGetMedicalRecord_Click(object sender, EventArgs e)
        {

            frMedicalRecord recordMid= new frMedicalRecord(-1);

             recordMid.ShowDialog();

            clsMedicalRecord newMedical = recordMid._MedicalRecord;

             if(!(newMedical.MedicalRecordID <= 0))
            {
                MedicalRecordIDPrv = newMedical.MedicalRecordID;
                lbMedicalRecord.Text = MedicalRecordIDPrv.ToString();
            }
            //just want to store the medical record add gt the ID and assign to this appoinment
          

        }


        //get data from another form payment

        private void btnGetPayment_Click(object sender, EventArgs e)
        {
            frPayment payment= new frPayment(-1); 
            payment.ShowDialog();

            clsPayments newpayment = payment._Payment;

            if (!(newpayment.PaymentID <= 0))
            {
                PaymentIDPrv = newpayment.PaymentID;
                lbPaymentID.Text = PaymentIDPrv.ToString();
            }


        }

        private void combStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combStatus.SelectedItem != null)
                {
                    _CheckMedicalRecordStatus(combStatus.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {

            }
           
        }





        //Show all Medical and precption
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

          ManageMedicalRecord manageMedicalRecord = new ManageMedicalRecord();
           manageMedicalRecord.ShowDialog();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ManagePrescription ManagePrescription = new ManagePrescription();
            ManagePrescription.ShowDialog();
        }
        //open Payment
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ManagePayment payment = new ManagePayment();
            payment.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home.Logout();
            this.Close();
        }

        private void Add_Appoinments_Click(object sender, EventArgs e)
        {

        }
    }
}
