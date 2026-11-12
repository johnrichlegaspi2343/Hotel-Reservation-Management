using BusinessLogic;

namespace HotelReservation
{
    public partial class FrontDesk : Form
    {
        public FrontDesk()
        {
            InitializeComponent();
            lblFrontDesk.Text = "Front Desk: " + Session.CurrentUser?.Username;

            // Ang btnGuests ay naka-connect na sa designer (button1_Click)
            btnAvailability.Click += btnAvailability_Click;
            btnReservation.Click += btnReservation_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += FrontDesk_FormClosed;
        }

        private void FrontDesk_Load(object sender, EventArgs e)
        {

        }

        // Guests Information
        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new GuestsInformation());
        }

        // Availability (nasa Reservation form ang Check Availability)
        private void btnAvailability_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new Reservation());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new Reservation());
        }

        private void btnCheckInCheckOut_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new CheckinCheckout());
        }

        private void btnBillingPayment_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new BillingPayment());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Navigator.Logout(this);
        }

        private void FrontDesk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}