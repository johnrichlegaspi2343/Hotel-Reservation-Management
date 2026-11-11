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
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += Dashboard_FormClosed;
            lblFrontDesk.Text = BusinessLogic.Session.CurrentUser?.Username;
        }

        private void FrontDesk_Load(object sender, EventArgs e)
        {

        }

        // Logout button
        private void btnLogout_Click(object sender, EventArgs e)
        {
            BusinessLogic.Session.CurrentUser = null;

            frmLogIn login = (frmLogIn)Application.OpenForms["frmLogIn"];
            login.ClearFields();
            login.Show();
            this.Close();
        }

        // Kapag pinindot ang X (hindi Logout), isara ang buong app
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BusinessLogic.Session.CurrentUser != null)
            {
                Application.Exit();
            }
        }
    }
}