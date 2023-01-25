using Exotic_Rentals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            this.ControlBox = false;
            timer1.Start();
        }


        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 1;
            if (panel1.Width >= 330)
            {
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }
    }
}
