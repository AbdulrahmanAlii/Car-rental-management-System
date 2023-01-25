using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Exotic_Rentals.Business;

namespace Exotic_Rentals
{
    public partial class Users : Form
    {
        CarRentalBL BLL = new CarRentalBL();

        public Users()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            var ds = BLL.GetAllUsers();

            UserDGV.DataSource = ds;
        }
        private void uName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void UId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button_car_Click(object sender, EventArgs e)
        {
            if (UId.Text == "" || uName.Text == "" || uPass.Text == "")
            {
                MessageBox.Show("Missing information");

            }
            else
            {
                try
                {
                    if (BLL.AddUser(Convert.ToInt32(UId.Text), uName.Text, uPass.Text))
                    {
                        MessageBox.Show("User Successfully Added");
                     
                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UId.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (BLL.DeleteUser(Convert.ToInt32(UId.Text)))
                    {
                        MessageBox.Show("User Successfully Deleted");
                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UId.Text == "" || uName.Text == "" || uPass.Text == "")
            {
                MessageBox.Show("Missing information");

            }
            else
            {
                try
                {
                    if (BLL.UpdateUser(Convert.ToInt32(UId.Text), uName.Text, uPass.Text))
                    {
                        MessageBox.Show("User Successfully updated");

                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
