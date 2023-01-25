using Exotic_Rentals.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exotic_Rentals
{
    public partial class Login : Form
    {
        CarRentalBL BLL = new CarRentalBL();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please Enter username.");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please Enter password.");
                return;
            }

            if (BLL.ValidateLogin(username, password))
            {
                MessageBox.Show("Login Success.");

                MainForm mainMenu = new MainForm();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Text = tbPassword.Text = string.Empty;
        }
    }
}
