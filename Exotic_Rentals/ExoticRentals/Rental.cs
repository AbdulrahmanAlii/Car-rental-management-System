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
using System.Security.Cryptography;
using Exotic_Rentals.Business;

namespace Exotic_Rentals
{
    public partial class Rental : Form
    {
        CarRentalBL BLL = new CarRentalBL();
        public Rental()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fillcombo()
        {
            var source = BLL.GetCarsInfo();

            CarRegTB.DataSource = source;
        }

        private void fillCustomer()
        {
            var source = BLL.GetCustomersInfo();

            CustTB.DataSource = source;
        }

        private void fetchCustName()
        {
            CustNameTB.Text = BLL.GetCustomersName(Convert.ToInt32(CustTB.SelectedValue.ToString()));
        }
        private void populate()
        {
            var ds = BLL.GetRentalsRecord();

            RentDGV.DataSource = ds;
        }

        private void UpdateOnRent()
        {
            BLL.UpdateCarAvailability("NO", CarRegTB.SelectedValue.ToString());
        }

        private void UpdateOnRentDelete()
        {
            BLL.UpdateCarAvailability("YES", CarRegTB.SelectedValue.ToString());
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        private void CarRegTB_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (IdTB.Text == "" || CustNameTB.Text == "" || FeesTB.Text == "")
            {
                MessageBox.Show("Missing information");

            }
            else
            {
                try
                {
                    if (BLL.AddCarRental(Convert.ToInt32(IdTB.Text), CarRegTB.SelectedValue.ToString(),
                         CustNameTB.Text, RentDate.Value, Convert.ToInt32(FeesTB.Text)))
                    {
                        MessageBox.Show("Car Successfully Rented");
                        fillcombo();
                        UpdateOnRent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (BLL.DeleteCarRental(Convert.ToInt32(IdTB.Text)))
                    {
                        MessageBox.Show("Rental Successfully Deleted");

                        populate();
                        UpdateOnRentDelete();
                    }

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CustTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCustName();
        }
    }
}
