using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class BillingPayment : Form
    {
        private ReservationController reservationController = new ReservationController();
        private BillingController billingController = new BillingController();

        // Ang reservation na hinanap (null = wala pa)
        private Model.Reservation? currentReservation = null;

        public BillingPayment()
        {
            InitializeComponent();
            SetupForm();

            btnSearch.Click += btnSearch_Click;
            btnProcessPayment.Click += btnProcessPayment_Click;
            btnClear.Click += btnClear_Click;

            // Sidebar (ang btnGuests ay naka-connect na sa designer: button1_Click)
            btnReservation.Click += btnReservation_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += BillingPayment_FormClosed;
        }

        // ===================== SETUP =====================

        private void SetupForm()
        {
            lblUser.Text = Session.CurrentUser?.Username;

            // Hindi puwedeng i-type, galing sa database ang laman
            txtGuests.ReadOnly = true;
            txtRoom.ReadOnly = true;
            txtRoomRate.ReadOnly = true;
            txtNumberOfNights.ReadOnly = true;
            txtRoomCharges.ReadOnly = true;
            txtServiceCharges.ReadOnly = true;
            txtTotalBill.ReadOnly = true;
            txtRemainingBalance.ReadOnly = true;

            cbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentMethod.Items.Clear();
            cbPaymentMethod.Items.Add("Cash");
            cbPaymentMethod.Items.Add("Card");
            cbPaymentMethod.Items.Add("GCash");
        }

        // ===================== SEARCH =====================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchReservationId.Text.Trim() == "")
                    throw new Exception("Please enter a Reservation ID (ex. RES-0001).");

                currentReservation = reservationController.FindReservation(txtSearchReservationId.Text.Trim());
                ShowBill(currentReservation);
            }
            catch (Exception ex)
            {
                ClearForm();
                MessageBox.Show(ex.Message, "Search Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Ipakita ang bill (automatic computation galing sa Model)
        private void ShowBill(Model.Reservation r)
        {
            txtGuests.Text = r.Guest?.FullName;
            txtRoom.Text = r.Room?.RoomNumber + " (" + r.Room?.RoomTypeName + ")";
            txtRoomRate.Text = r.RoomRate.ToString("N2");
            txtNumberOfNights.Text = r.Nights.ToString();
            txtRoomCharges.Text = r.TotalBill.ToString("N2");     // Rate x Nights
            txtServiceCharges.Text = "0.00";                      // Wala pang services (optional)
            txtTotalBill.Text = r.TotalBill.ToString("N2");
            txtRemainingBalance.Text = r.Balance.ToString("N2");

            // Default na babayaran = natitirang balance
            txtPaymentAmount.Text = r.Balance.ToString("0.00");
            cbPaymentMethod.SelectedIndex = -1;
        }

        // ===================== PAYMENT =====================

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentReservation == null)
                    throw new Exception("Please search a reservation first.");

                decimal amount;
                if (!decimal.TryParse(txtPaymentAmount.Text.Trim(), out amount))
                    throw new Exception("Please enter a valid payment amount.");

                string method = cbPaymentMethod.Text;

                Payment payment = billingController.ProcessPayment(currentReservation.Id, amount, method);

                // Kunin ulit sa database para updated ang balance
                currentReservation = reservationController.FindReservation(currentReservation.ReservationCode);
                ShowBill(currentReservation);

                MessageBox.Show("Payment successful!\nTransaction ID: " + payment.TransactionId,
                    "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ipakita ang resibo
                PaymentReceipt receipt = new PaymentReceipt(payment, currentReservation);
                receipt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchReservationId.Clear();
            ClearForm();
        }

        private void ClearForm()
        {
            currentReservation = null;
            txtGuests.Clear();
            txtRoom.Clear();
            txtRoomRate.Clear();
            txtNumberOfNights.Clear();
            txtRoomCharges.Clear();
            txtServiceCharges.Clear();
            txtTotalBill.Clear();
            txtRemainingBalance.Clear();
            txtPaymentAmount.Clear();
            cbPaymentMethod.SelectedIndex = -1;
        }

        // ===================== SIDEBAR =====================

        // Guests (naka-connect sa designer)
        private void button1_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new GuestsInformation());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new Reservation());
        }

        // TODO: btnReservationStatus kapag nagawa na ang ReservationStatus form

        private void btnCheckInCheckOut_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new CheckinCheckout());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Navigator.Logout(this);
        }

        private void BillingPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }

        // Galing sa designer, hayaan lang
        private void BillingPayment_Load(object sender, EventArgs e)
        {

        }
    }
}