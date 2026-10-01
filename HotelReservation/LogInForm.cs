using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class frmLogIn : Form
    {
        // Gawing true lang kapag gusto mong burahin at gawin ulit ang database.
        // Iwanang false para hindi mabura ang mga user sa database.
        private const bool ResetDatabase = false;

        public frmLogIn()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

            // Kapag pinindot ang Enter, gagana na parang pinindot ang Log In button
            this.AcceptButton = btnLogin;

            try
            {
                using (var db = new AppDBContext())
                {
                    if (ResetDatabase)
                    {
                        db.Database.EnsureDeleted();
                    }

                    db.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hindi makakonek sa database:\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter your username and password.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user;
            try
            {
                using (var db = new AppDBContext())
                {
                    // Kunin muna ang user ayon sa username
                    user = db.Users.FirstOrDefault(u => u.Username == username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ang password ay inihahambing dito sa C# para eksakto ang malaki at maliit na letra
            if (user == null || user.Password != password)
            {
                MessageBox.Show("Invalid username or password.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            if (user.Role == "Admin")
            {
                MessageBox.Show("Login successful! Welcome, Admin.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AdminDashboard dashboard = new AdminDashboard();
                dashboard.Show();
                this.Hide();
            }
            else if (user.Role == "FrontDesk")
            {
                MessageBox.Show("Login successful! Welcome, Front Desk.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrontDesk frontDesk = new FrontDesk();
                frontDesk.Show();
                this.Hide();
            }
        }
    }
}