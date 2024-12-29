using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClincBussniesLayer;
namespace ClinicManagmentSystem
{
    public partial class fPerson : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PersonID;
        public  clsPerson _Person;

        public fPerson(int id)
        {
            InitializeComponent();

            _PersonID = id;

            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }


        // My Method UI

        private void AssignGender(string gnd)
        {
           gnd = gnd.Substring(0,1).ToUpper();

            if (gnd == "M")
            {
                txtGender.SelectedItem = "Male";
            }
            else if(gnd == "F") 
            {
                txtGender.SelectedItem = "Female";
            }


           // _Person.Address = txtGender.SelectedItem.ToString();

        }

        private string SentGenderToDB()
        {

            if(txtGender.SelectedIndex == 0) {

                return "M";

            }
            else if (txtGender.SelectedIndex == 1)
            {
                return "F";
            }

            return "M";
        }

        private void LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
               this.Text = "Add Person";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();

                return;
            }

            this.Text = "Update Person";
            lbPersonID.Text = _PersonID.ToString();
            txtName.Text = _Person.Name;
            txtEmail.Text = _Person.Email;
             AssignGender(_Person.Gender);
            txtPhone.Text = _Person.PhoneNumber;
            txtAddress.Text = _Person.Address;
            txtDateBirth.Value = DateTime.Now;




        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the chosen image
                    string filePath = openFileDialog.FileName;

                    guna2CirclePictureBox1.Image = Image.FromFile(filePath);
                }

            }



        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            _Person.Name = txtName.Text;
            _Person.Email = txtEmail.Text;
            _Person.PhoneNumber = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.Gender = SentGenderToDB();
            _Person.DateOfBirth = txtDateBirth.Value;


            if (_Person.Save())
            {
                _PersonID = _Person.PersonID;
                lbPersonID.Text = _Person.PersonID.ToString();
                if (MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                }

            }
            else
                MessageBox.Show("Data Is not Saved Successfully.","Error",MessageBoxButtons.OK);




            _Mode = enMode.Update;
           

        }

        private void fPerson_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
