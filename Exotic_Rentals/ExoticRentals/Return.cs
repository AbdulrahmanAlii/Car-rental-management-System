using Exotic_Rentals.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exotic_Rentals
{
    public partial class Return : Form
    {
        CarRentalBL BLL = new CarRentalBL();
        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }

        private void populate()
        {
            var ds = BLL.GetRentalsRecord();

            RentDGV.DataSource = ds;
        }
        private void populateRet()
        {
            var ds = BLL.GetReturnsRecord();

            ReturnDGV.DataSource = ds;
        }

        private void DeleteOnReturn()
        {
            if (BLL.DeleteCarRental(Convert.ToInt32(IdTB.Text)))
            {
                MessageBox.Show("Rental Successfully Deleted");

                populate();
            }
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime d1 = ReturnDate.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int NrOfDays = Convert.ToInt32(t.TotalDays);
            if (NrOfDays <= 0)
            {
                DelayTB.Text = "NO DELAY";
                FineTB.Text = "0";
            }
            else
            {
                DelayTB.Text = "" + NrOfDays;
                FineTB.Text = "" + (NrOfDays * 250);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (IdTB.Text == "" || CustNameTB.Text == "" || FineTB.Text == "" || DelayTB.Text == "")
            {
                MessageBox.Show("Missing information");

            }
            else
            {
                try
                {
                    if (BLL.CarRentalReturn(Convert.ToInt32(IdTB.Text), CarIdTB.Text, CustNameTB.Text, ReturnDate.Value, Convert.ToInt32(FineTB.Text)))
                    {
                        MessageBox.Show("Car Successfully Returned");

                        populateRet();
                        DeleteOnReturn();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
}
