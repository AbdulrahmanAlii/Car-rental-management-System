using Exotic_Rentals.Business;

namespace Exotic_Rentals
{
    public partial class Customer : Form
    {
        private CarRentalBL BLL = new CarRentalBL();

        public Customer()
        {
            InitializeComponent();
        }

        private void populate()
        {
            var ds = BLL.GetAllCustomers();

            CustomersDGV.DataSource = ds;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (IdTB.Text == "" || NameTB.Text == "" || AddressTB.Text == "" || PhoneTB.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    if (BLL.AddCustomer(Convert.ToInt32(IdTB.Text), NameTB.Text, AddressTB.Text, PhoneTB.Text))
                    {
                        MessageBox.Show("Customer Successfully Added");

                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
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
                    if (BLL.DeleteCustomer(Convert.ToInt32(IdTB.Text)))
                    {
                        MessageBox.Show("Customer Successfully Deleted");

                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdTB.Text == "" || NameTB.Text == "" || AddressTB.Text == "" || PhoneTB.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    if (BLL.UpdateCustomer(Convert.ToInt32(IdTB.Text), NameTB.Text, AddressTB.Text, PhoneTB.Text))
                    {
                        MessageBox.Show("Customer Successfully Updated");

                        populate();
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