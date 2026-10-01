namespace HotelReservation
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
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
