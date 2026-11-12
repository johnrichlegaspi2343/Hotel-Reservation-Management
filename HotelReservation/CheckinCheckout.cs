using BusinessLogic;
using BusinessLogic.Controller;

namespace HotelReservation
{
    public partial class CheckinCheckout : Form
    {
        private ReservationController reservationController = new ReservationController();

        // Ang reservation na nahanap. "Model.Reservation" kasi may form din na "Reservation".
        private Model.Reservation? currentReservation;

        public CheckinCheckout()
        {
            InitializeComponent();
            label3.Text = Session.CurrentUser?.Username;

            btnSearch.Click += btnSearch_Click;
            btnCheckin.Click += btnCheckin_Click;
            btnCheckout.Click += btnCheckout_Click;

            // Sidebar
            btnGuests.Click += btnGuests_Click;
            btnReservation.Click += btnReservation_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += CheckinCheckout_FormClosed;
        }

        // ===================== SEARCH =====================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                currentReservation = reservationController.FindReservation(textBox1.Text);
                ShowReservation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearDetails();
            }
        }

        private void ShowReservation()
        {
            if (currentReservation == null) return;

            txtGuest.Text = currentReservation.Guest?.FullName + " (" + currentReservation.Guest?.GuestCode + ")";
            txtRoom.Text = currentReservation.Room?.RoomNumber + " (" + currentReservation.Room?.RoomTypeName + ")";
            txtCheckInDate.Text = currentReservation.CheckInDate.ToString("MM/dd/yyyy");
            txtCheckOutDate.Text = currentReservation.CheckOutDate.ToString("MM/dd/yyyy");
            txtReservationStatus.Text = currentReservation.Status;
            txtPaymentStatus.Text = currentReservation.PaymentStatus;

            if (currentReservation.ActualCheckIn != null)
                txtActualCheckin.Text = currentReservation.ActualCheckIn.Value.ToString("MM/dd/yyyy hh:mm tt");
            else
                txtActualCheckin.Text = "Pending";

            if (currentReservation.ActualCheckOut != null)
                txtActualCheckout.Text = currentReservation.ActualCheckOut.Value.ToString("MM/dd/yyyy hh:mm tt");
            else
                txtActualCheckout.Text = "Pending";
        }

        private void ClearDetails()
        {
            currentReservation = null;
            txtGuest.Clear();
            txtRoom.Clear();
            txtCheckInDate.Clear();
            txtCheckOutDate.Clear();
            txtReservationStatus.Clear();
            txtPaymentStatus.Clear();
            txtActualCheckin.Clear();
            txtActualCheckout.Clear();
        }

        // ===================== CHECK-IN / CHECK-OUT =====================

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (currentReservation == null)
            {
                MessageBox.Show("Please search a reservation first.");
                return;
            }

            try
            {
                reservationController.CheckIn(currentReservation.Id);
                MessageBox.Show("Guest checked in. Room is now Occupied.", "Check-In",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // I-reload para makita ang bagong status at oras
                currentReservation = reservationController.FindReservation(currentReservation.ReservationCode);
                ShowReservation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check-In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (currentReservation == null)
            {
                MessageBox.Show("Please search a reservation first.");
                return;
            }

            try
            {
                reservationController.CheckOut(currentReservation.Id);
                MessageBox.Show("Guest checked out. Room is now Available.", "Check-Out",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                currentReservation = reservationController.FindReservation(currentReservation.ReservationCode);
                ShowReservation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check-Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ===================== SIDEBAR =====================

        private void btnGuests_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new GuestsInformation());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new Reservation());
        }

        private void btnBillingPayment_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new BillingPayment());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Navigator.Logout(this);
        }

        private void CheckinCheckout_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }

        // Galing sa designer, hayaan lang
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}