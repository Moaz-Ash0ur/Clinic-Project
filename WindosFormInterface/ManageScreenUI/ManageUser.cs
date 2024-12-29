using ClincBussniesLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ClinicManagmentSystem
{
    public partial class ManageUser : Form
    {

      private enum enPermissions
        {//deal with like a binary value represnt the value in one value more than opertion can do 
            eAll = -1, pManageDoctor = 1, pManagePateint = 2, pManageAppoinment = 4,
            pManagePayment = 8, pManageUser = 16
        };





        public ManageUser()
        {
            InitializeComponent();
        }

        private clsUsers _User;
        private int _PersonIdPrv;
        private int _UserId = -1;
        private int userPermissions;

        //**************************Check Permmsion*************************
       
        //Load Form
        private void ManageUser_Load(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            _ShowAllUsers();
        }

        //My Own Function For Clinic Sysytem
        private void _ShowAllUsers()
        {
          //   dgvShowUser
            DataTable dt =  clsUsers.GetAllUsers();
            dgvShowUser.DataSource = dt;    
        }

        private void _WhenClickAdd()
        {
            guna2TabControl1.Visible = true;
            dgvShowUser.Visible = false;
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            //change it when want to update for the ID Users
            _PersonIdPrv = -1;
            _UserId = -1;   
        }

        private void _WhenSelectToolUser()
        {
            if (guna2TabControl1.Visible == true)
            {
                guna2TabControl1.Visible = false;
            }


            if (dgvShowUser.Visible == false)
            {
                dgvShowUser.Visible = true;
            }

            if (btnAdd.Visible == false)
            {
                btnAdd.Visible = true;
            }

            if (btnSave.Visible == true)
            {
                btnSave.Visible = false;
            }

            if (btnCancel.Visible == true)
            {
                btnCancel.Visible = false;
            }

        }

        private void _SetPermission()
        {
            // Reset permissions to calculate afresh.
            userPermissions = 0;

            // Add permissions for all checked checkboxes.
            if (chkManageDoctor.Checked)
            {
                userPermissions |= (int)enPermissions.pManageDoctor;
            }
            if (chkManagePatient.Checked)
            {
                userPermissions |= (int)enPermissions.pManagePateint;
            }
            if (chkManageAppoinment.Checked)
            {
                userPermissions |= (int)enPermissions.pManageAppoinment;
            }
            if (chkManagePayment.Checked)
            {
                userPermissions |= (int)enPermissions.pManagePayment;
            }
            if (chkManageUser.Checked)
            {
                userPermissions |= (int)enPermissions.pManageUser;
            }
            if (chkAll.Checked)
            {
                userPermissions = (int)enPermissions.eAll; // Grant all permissions.
            }

            // Optional: Display the combined permissions.
              lbPermissin.Text = $"{userPermissions}";
        }

        private void _AssignPermissionWhenUpdate(int perm) {
        
          if((enPermissions)perm==enPermissions.eAll) { 
                chkAll.Checked = true;
            }

            if ((enPermissions)perm == enPermissions.pManageDoctor)
            {
                chkManageDoctor.Checked = true; 
            }
            if((enPermissions)perm == enPermissions.pManagePateint)
            {
                chkManagePatient.Checked = true;

            }
            if((enPermissions)perm == enPermissions.pManagePayment)
            {
                chkManagePayment.Checked = true;    
            }
            if((enPermissions)perm == enPermissions.pManageAppoinment)
            {
                chkManageAppoinment.Checked = true;
            }


            if ((enPermissions)perm == enPermissions.pManageUser)
            {
                chkManageUser.Checked = true;
            }
        }

        //get info just for person info 

        private void SaveUserInfo()
        {

            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("You Should Fill this field First !", "Warnning", MessageBoxButtons.OK);
                return;
            }

            if (_UserId == -1)
            {
                _User = new clsUsers();
                _User.PersonID = Convert.ToInt32(txtUserIDPerson.Text);
                _User.Username = txtName.Text;
                _User.Password = txtPassword.Text;
                _User.Permission = Convert.ToInt32( lbPermissin.Text);


                if (_User.Save())
                {
                    txtUserID.Text = _User.User_id.ToString();
                    MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK);
                    _ShowAllUsers();
                }
                else
                    MessageBox.Show("Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK);

            }
            //else in Update Mode
            else
            {
                _User.PersonID = Convert.ToInt32(txtUserIDPerson.Text);
                _User.Username = txtName.Text;
                _User.Password = txtPassword.Text;
                _User.Permission = Convert.ToInt32(lbPermissin.Text);

                if (_User.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Information", MessageBoxButtons.OK);
                    _ShowAllUsers();

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
            txtUserID.Text = "??";
            txtUserIDPerson.Text = "??";
            txtUsername.Text = "";
            txtPassword.Text = "";
            lbPermissin.Text = "??";

            chkManageAppoinment.Checked = false;
            chkManageDoctor.Checked = false;
            chkManagePatient.Checked = false;
            chkManagePayment.Checked = false;
            chkManageUser.Checked = false;
            chkAll.Checked = false;

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



            //Fill User Person Info
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
            txtUserIDPerson.Text = lbPersonID.Text;


        }

        //******************* Form Event Start *******************
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearInput();
            _WhenSelectToolUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                ClearInput();
            }
            _WhenClickAdd();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_UserId == -1)
            {
                SaveUserInfo();        
            }
            else
            {
                SaveUserInfo();
               
            }
            ClearInput();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
               _SetPermission();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this [" + dgvShowUser.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                //Perform Delele and refresh
                if (clsUsers.Delete((int)dgvShowUser.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.");
                    _ShowAllUsers();
                }
                else
                    MessageBox.Show("User is not deleted.");
            }



        }
        //
        private void _WhenClickUpdate()
        {
            guna2TabControl1.Visible = true;
            btnAdd.Visible = false;

            if (btnSave.Visible == false)
            {
                btnSave.Visible = true;
            }

            if (btnCancel.Visible == false)
            {
                btnCancel.Visible = true;
            }
            //=============================

            _User = clsUsers.Find((int)dgvShowUser.CurrentRow.Cells[0].Value);

            _UserId = _User.User_id;
            _PersonIdPrv = _User.PersonID;

            //show doctor data wnat to update
            txtUserID.Text = _UserId.ToString();
            txtUsername.Text = _User.Username.ToString();
            txtPassword.Text = _User.Password.ToString();
            lbPermissin.Text = _User.Permission.ToString();
            _AssignPermissionWhenUpdate(_User.Permission);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ClearInput();
            _WhenClickUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Home.Logout();
            this.Close();
        }
    }
}
