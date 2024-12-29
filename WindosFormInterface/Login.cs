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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0'; // عرض النص
            }
            else
            {
                txtPassword.PasswordChar = '●'; // عرض النص
            }
        }
        // | done
        private bool _CheckInfoLogin() 
        {

            if (txtusername.Text == null)
            {
                MessageBox.Show("Should Enter Your Info","Error",MessageBoxButtons.OK);
                return false;
            }

            GlobalUser.CurrentUser = clsUsers.FindUserLogin(txtusername.Text,txtPassword.Text);

           

            if (GlobalUser.CurrentUser != null)
            {
                return (GlobalUser.CurrentUser.Username == txtusername.Text &&
                     (GlobalUser.CurrentUser.Password == txtPassword.Text));
            }
           

            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_CheckInfoLogin())
            {
                if (lbErrorLogin.Visible == true)
                {
                    lbErrorLogin.Visible = false;
                }

                txtusername.Text = "";
                txtPassword.Text = "";
                 checkBox1.Checked = false;
                Home home = new Home();
                home.ShowDialog();
                
            }
            else
            {
                lbErrorLogin.Visible = true;
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            string formattedDateTime = now.ToString("dddd, MMMM dd, yyyy hh:mm tt");
            lbDateTime.Text = formattedDateTime;
        }





    }


}
