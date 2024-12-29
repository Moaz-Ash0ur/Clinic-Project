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
    public partial class ManagePateints : Form
    {
        public ManagePateints()
        {
            InitializeComponent();
        }

        private clsPateints _Pateint;
        private int _PersonIdPrv;
        private int _PateintID = -1;


        private void ManagePateints_Load(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            _ShowAllPateints();
        }

        private void _ShowAllPateints()
        {
            //   dgvShowUser
            DataTable dt = clsPateints.GetAllPersonsPatients();
            guna2DataGridView1.DataSource = dt;

        }

        private void _WhenClickAdd()
        {
            guna2TabControl1.Visible = true;
            guna2DataGridView1.Visible = false;
            btnAdd.Visible = false;
            btnSave2.Visible = true;
            btnCancel2.Visible = true;
            //change it when want to update for the ID Users
            _PersonIdPrv = -1;
            _PateintID = -1;
        }

        private void _WhenSelectToolPateint()
        {
            if (guna2TabControl1.Visible == true)
            {
                guna2TabControl1.Visible = false;
            }


            if (guna2DataGridView1.Visible == false)
            {
                guna2DataGridView1.Visible = true;
            }

            if (btnAdd.Visible == false)
            {
                btnAdd.Visible = true;
            }

            if (btnSave2.Visible == true)
            {
                btnSave2.Visible = false;
            }

            if (btnCancel2.Visible == true)
            {
                btnCancel2.Visible = false;
            }

        }

        private void SaveUserInfo()
        {

            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("You Should Fill this field First !", "Warnning", MessageBoxButtons.OK);
                return;
            }

            if (_PateintID == -1)
            {
                _Pateint = new clsPateints();
                _Pateint.PersonIDP = Convert.ToInt32(lbPersonID.Text);
                

                if (_Pateint.Save())
                {
                    lbPateintID.Text = _Pateint.PatientID.ToString();
                    MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK);
                    _ShowAllPateints();
                }
                else
                    MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);

            }
            //else in Update Mode
            else
            {
                _Pateint.PersonIDP = Convert.ToInt32(lbPersonID.Text);

                if (_Pateint.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK);
                    _ShowAllPateints();

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

            //Part info user
            lbPateintID.Text = "??";
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

        private void btnGetPerson_Click(object sender, EventArgs e)
        {
            fPerson form2 = new fPerson(_PersonIdPrv);
            form2.ShowDialog();

            clsPerson newPerson = form2._Person;

            if (newPerson.PersonID < 0)
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
            lbPersonID.Text = lbPersonID.Text;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                ClearInput();
            }
            _WhenClickAdd();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (_PateintID == -1)
            {
                SaveUserInfo();
            }
            else
            {
                SaveUserInfo();

            }
            ClearInput();
        }

        private void PateintMenuStrip_Click(object sender, EventArgs e)
        {
            _WhenSelectToolPateint();
        }

        private void _WhenClickUpdate()
        {
            guna2TabControl1.Visible = true;
            btnAdd.Visible = false;

            if (btnSave2.Visible == false)
            {
                btnSave2.Visible = true;
            }

            if (btnCancel2.Visible == false)
            {
                btnCancel2.Visible = true;
            }
            //=============================

            _Pateint = clsPateints.Find((int)guna2DataGridView1.CurrentRow.Cells[0].Value);

            _PateintID = _Pateint.PatientID;
            _PersonIdPrv = _Pateint.PersonIDP;
            lbPateintID.Text = _PateintID.ToString();   
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _WhenClickUpdate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this [" + guna2DataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                //Perform Delele and refresh
                if (clsPateints.Delete((int)guna2DataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Pateint Deleted Successfully.");
                    _ShowAllPateints();
                }
                else
                    MessageBox.Show("Pateint is not deleted.");
            }

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home.Logout();
            this.Close();
        }
    }
}
