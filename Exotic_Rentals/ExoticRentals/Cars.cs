using Exotic_Rentals.Business;

namespace Exotic_Rentals
{
    public partial class Cars : Form
    {
        private CarRentalBL BLL = new CarRentalBL();

        public Cars()
        {
            InitializeComponent();
        }

        private void populate()
        {
            var ds = BLL.GetAllCars();

            CarsDGV.DataSource = ds;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (RegNumTB.Text == "" || BrandTB.Text == "" || ModelTB.Text == "" || PriceTB.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    if (BLL.AddCar(RegNumTB.Text, BrandTB.Text, ModelTB.Text, cmbAvailable.Text, Convert.ToDouble(PriceTB.Text)))
                    {
                        MessageBox.Show("Car Successfully Added");

                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Cars_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RegNumTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (BLL.DeleteCar(RegNumTB.Text))
                    {
                        MessageBox.Show("Car Successfully Deleted");
                        populate();
                    }
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CarsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RegNumTB.Text == "" || BrandTB.Text == "" || ModelTB.Text == "" || PriceTB.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    if (BLL.UpdateCar(RegNumTB.Text, BrandTB.Text, ModelTB.Text, cmbAvailable.Text, Convert.ToDouble(PriceTB.Text)))
                    {
                        MessageBox.Show("Car Successfully Updated");

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