using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class frmLogIn : Form
    {
        // Gawing true nang ISANG BESES kung gusto mong burahin at gawin ulit ang database
        private const bool ResetDatabase = false;

        private UserController userController = new UserController();

        public frmLogIn()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin;

            try
            {
                // Gagawa ng database at maglalagay ng default data (users, rooms, 50 guests)
                SeedData.Seed(ResetDatabase);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hindi makakonek sa database:\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tinatawag kapag nag-logout, para malinis ulit ang login screen
        public void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = userController.Login(txtUsername.Text, txtPassword.Text);

                MessageBox.Show("Login successful! Welcome, " + user.Username + ".",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (user.Role == "Admin")
                {
                    AdminDashboard dashboard = new AdminDashboard();
                    dashboard.Show();
                }
                else
                {
                    FrontDesk frontDesk = new FrontDesk();
                    frontDesk.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {

        }
    }
}