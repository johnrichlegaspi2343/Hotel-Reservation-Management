using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class FrontDesk : Form
    {
        public FrontDesk()
        {
            InitializeComponent();
        }

        private void FrontDesk_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogIn loginform = new frmLogIn();
            loginform.Show();
            this.Hide();
        }
    }
}
