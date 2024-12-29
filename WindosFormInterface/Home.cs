using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

using ClincBussniesLayer;
using Guna.UI2.WinForms;

namespace ClinicManagmentSystem
{
    public partial class Home : Form
    {


        //public enum enPermissions : int
        //{
        //    eAll = -1, pManageDoctor = 1, pManagePateint = 2, pManageAppoinment = 4,
        //    pManagePayment = 8, pManageUser = 16
        //};

        private clsPerson _Person;

        //to send in 
        private int _IdPer;
       clsDoctors _doctor;
       private int _doctorID;

        public Home()
        {
            InitializeComponent();
        }

        //own Function
        public void ControlVisibleInDoctorMenu()
        {

            if (guna2TabControl1.Visible)
            {
                guna2TabControl1.Visible = false;
            }

            if (btnAdd.Visible == false)
            {
                btnAdd.Visible = true;
                
            }

            if (btnSave2.Visible)
            {
                btnSave2.Visible = false;
            }

            if (btnCancel2.Visible)
            {
                btnCancel2.Visible = false;
            }



        }

        public void _RefreshDoctorData()
        {

            DataTable dt = clsDoctors.GetAllPersonDoctors();
            guna2DataGridView1.DataSource = dt;

        }

        private void docotrsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshDoctorData();
            ControlVisibleInDoctorMenu();
        }

        private void AddDoctor_Click(object sender, EventArgs e)
        {
            ClearInput();

            guna2TabControl1.Visible = true;

            if (btnAdd.Visible == true)
                {
                    btnAdd.Visible = false;
                }

            if (btnSave2.Visible == false)
            {
                btnSave2.Visible = true;
            }

            if (btnCancel2.Visible==false)
            {
                btnCancel2.Visible = true;
            }

            _IdPer = -1;//for update in secounf form to know what the mode
            _doctorID = -1;//for know in this from add or update doctor
        }

        private void AssignGender(string gnd)
        {
            try
            {
                gnd = gnd.Substring(0, 1).ToUpper();

                if (gnd == "M")
                {
                    txtGender.SelectedItem = "Male";
                }
                else if (gnd == "F")
                {
                    txtGender.SelectedItem = "Female";
                }

            }
            catch (Exception)
            {

               
            }
           


        }


        //get person info after add it and del wihtas doctor now
        private void btnGetPerson_Click(object sender, EventArgs e) 
        {

            fPerson form2 = new fPerson(_IdPer);
            form2.ShowDialog();

                clsPerson newPerson = form2._Person; 

                 if(newPerson.PersonID < 0)
                  {
                      lbPersonID.Text = "??";
                      return;
                  }

                lbPersonID.Text = newPerson.PersonID.ToString();
                txtName.Text = newPerson.Name; 
                txtEmail.Text = newPerson.Email;
                AssignGender(newPerson.Gender);
                txtPhone.Text = newPerson.PhoneNumber;
                txtAddress.Text = newPerson.Address;
                txtDate.Value = DateTime.Now;

                txtDocPersonID.Text = lbPersonID.Text;

        }

        private void SaveDoctorData()
        {

            if(txtName.Text == string.Empty)
            {
                MessageBox.Show("You Should Fill this field First !","Warnning",MessageBoxButtons.OK);
                return;
            }

            if (_doctorID == -1)
            {
                _doctor = new clsDoctors();

                _doctor.PersonIDD = Convert.ToInt32(lbPersonID.Text);
                _doctor.Specialization = txtSpeicalization.Text;


                if (_doctor.Save())
                {
                    txtDocID.Text = _doctor.DoctorID.ToString();

                    MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK);

                }
                else
                    MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);

            }
            else 
            {
                _doctor.Specialization = txtSpeicalization.Text;

                if (_doctor.Save())
                {

                    MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK);

                }
                else
                    MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);
            }

        }

        private void ClearInput()
        {
            lbPersonID.Text = "??";
            txtName.Text = "";
            txtEmail.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtDate.Value = DateTime.Now;

            txtDocPersonID.Text = "??";
            txtSpeicalization.Text = "";
            txtDocID.Text = "??";
        }


        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2TabControl1.Visible = true;

            if (btnSave2.Visible == false)
            {
                btnSave2.Visible = true;
            }

            if (btnCancel2.Visible == false)
            {
                btnCancel2.Visible = true;
            }
            //=============================

            ClearInput();
            _doctor = clsDoctors.Find((int)guna2DataGridView1.CurrentRow.Cells[0].Value);

            _doctorID = _doctor.DoctorID;
            _IdPer = _doctor.PersonIDD;

            //show doctor data wnat to update
            txtDocPersonID.Text = _doctor.PersonIDD.ToString();
            txtDocID.Text = _doctor.DoctorID.ToString();
            txtSpeicalization.Text = _doctor.Specialization.ToString();


            btnAdd.Visible = false;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this [" + guna2DataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsDoctors.Delete((int)guna2DataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Doctor Deleted Successfully.");
                    _RefreshDoctorData();
                }
                else
                    MessageBox.Show("Doctor is not deleted.");

            }

        }

      
        //========================================================

        //appoinment another form
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!GlobalUser.CurrentUser.CheckPermissions(clsUsers.enPermissions.pManageAppoinment))
            {
                MessageBox.Show("Access Dendied,Contact Wiht Admin", "Falied Access", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            fAppoinment f2 = new fAppoinment();
            f2.ShowDialog();
        }
        //payment another form
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!GlobalUser.CurrentUser.CheckPermissions(clsUsers.enPermissions.pManageUser))
            {
                MessageBox.Show("Access Dendied,Contact Wiht Admin", "Falied Access", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ManagePayment payment = new ManagePayment();
            payment.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        //save info and clear it
        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (_doctorID == -1)
            {
                SaveDoctorData();
                ClearInput();
            }
            else
            {
                SaveDoctorData();
                ClearInput();
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GlobalUser.CurrentUser.CheckPermissions(clsUsers.enPermissions.pManageUser))
            {
                MessageBox.Show("Access Dendied,Contact Wiht Admin","Falied Access",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ManageUser manageUser = new ManageUser();
            manageUser.ShowDialog();    
        }

        private void PateintMenuStrip_Click(object sender, EventArgs e)
        {
            if (!GlobalUser.CurrentUser.CheckPermissions(clsUsers.enPermissions.pManagePateint))
            {
                MessageBox.Show("Access Dendied,Contact Wiht Admin", "Falied Access", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ManagePateints managePateints = new ManagePateints();
            managePateints.Show();
        }

        public static void Logout()
        {
            Form loginForm = Application.OpenForms["Login"]; // Replace "Form1" with your login form's name

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != loginForm)
                {
                    form.Close();
                }
            }

            if (loginForm != null)
            {
                loginForm.Show();
            }
        }


        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
          //  this.Close();
        }




    }
}
