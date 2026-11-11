namespace HotelReservation
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += Dashboard_FormClosed;
            label3.Text = BusinessLogic.Session.CurrentUser?.Username;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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