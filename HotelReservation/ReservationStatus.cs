using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class ReservationStatus : Form
    {
        private ReservationController reservationController = new ReservationController();

        // Lahat ng reservation na nasa table, at ang napili
        private List<Model.Reservation> reservations = new List<Model.Reservation>();
        private Model.Reservation? currentReservation = null;

        public ReservationStatus()
        {
            InitializeComponent();
            SetupForm();
            LoadReservations();

            btnSearch.Click += btnSearch_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            dgvReservations.CellClick += dgvReservations_CellClick;

            // Sidebar
            btnGuests.Click += btnGuests_Click;
            btnReservation.Click += btnReservation_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += ReservationStatus_FormClosed;
        }

        // ===================== SETUP =====================

        private void SetupForm()
        {
            lblUser.Text = "Front Desk: " + Session.CurrentUser?.Username;

            txtGuest.ReadOnly = true;
            txtRoom.ReadOnly = true;
            txtCheckIn.ReadOnly = true;
            txtCheckOut.ReadOnly = true;
            txtCurrentStatus.ReadOnly = true;

            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            btnUpdateStatus.Enabled = false;

            // Table
            dgvReservations.ReadOnly = true;
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.DefaultCellStyle.ForeColor = Color.Black;
            dgvReservations.DefaultCellStyle.BackColor = Color.White;
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvReservations.Columns.Clear();
            dgvReservations.Columns.Add("Id", "Id");
            dgvReservations.Columns.Add("Code", "Reservation ID");
            dgvReservations.Columns.Add("Guest", "Guest");
            dgvReservations.Columns.Add("Room", "Room");
            dgvReservations.Columns.Add("CheckIn", "Check-in");
            dgvReservations.Columns.Add("CheckOut", "Check-out");
            dgvReservations.Columns.Add("Status", "Status");
            dgvReservations.Columns.Add("Payment", "Payment");
            dgvReservations.Columns["Id"].Visible = false;
        }

        // Ipakita lahat ng reservation sa table
        private void LoadReservations()
        {
            dgvReservations.Rows.Clear();

            try
            {
                reservations = reservationController.GetReservations();

                foreach (Model.Reservation r in reservations)
                {
                    dgvReservations.Rows.Add(r.Id, r.ReservationCode, r.Guest?.FullName, r.Room?.RoomNumber,
                        r.CheckInDate.ToString("MM/dd/yyyy"), r.CheckOutDate.ToString("MM/dd/yyyy"),
                        r.Status, r.PaymentStatus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== SEARCH / SELECT =====================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchReservationId.Text.Trim() == "")
                    throw new Exception("Please enter a Reservation ID (ex. RES-0001).");

                currentReservation = reservationController.FindReservation(txtSearchReservationId.Text.Trim());
                ShowDetails(currentReservation);
            }
            catch (Exception ex)
            {
                ClearDetails();
                MessageBox.Show(ex.Message, "Search Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Pag-click ng row sa table
        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;     // header ang na-click

            int id = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["Id"].Value);

            foreach (Model.Reservation r in reservations)
            {
                if (r.Id == id)
                {
                    currentReservation = r;
                    txtSearchReservationId.Text = r.ReservationCode;
                    ShowDetails(r);
                    break;
                }
            }
        }

        private void ShowDetails(Model.Reservation r)
        {
            txtGuest.Text = r.Guest?.FullName;
            txtRoom.Text = r.Room?.RoomNumber + " (" + r.Room?.RoomTypeName + ")";
            txtCheckIn.Text = r.CheckInDate.ToString("MM/dd/yyyy");
            txtCheckOut.Text = r.CheckOutDate.ToString("MM/dd/yyyy");
            txtCurrentStatus.Text = r.Status;

            // Ipakita lang ang mga status na puwedeng pagpilian
            cmbNewStatus.Items.Clear();

            if (r.Status == "Pending")
            {
                cmbNewStatus.Items.Add("Confirmed");
                cmbNewStatus.Items.Add("Cancelled");
            }
            else if (r.Status == "Confirmed")
            {
                cmbNewStatus.Items.Add("Pending");
                cmbNewStatus.Items.Add("Cancelled");
            }

            // CheckedIn, Completed at Cancelled ay hindi na mababago dito
            if (cmbNewStatus.Items.Count > 0)
            {
                cmbNewStatus.SelectedIndex = 0;
                cmbNewStatus.Enabled = true;
                btnUpdateStatus.Enabled = true;
            }
            else
            {
                cmbNewStatus.Enabled = false;
                btnUpdateStatus.Enabled = false;
            }
        }

        private void ClearDetails()
        {
            currentReservation = null;
            txtGuest.Clear();
            txtRoom.Clear();
            txtCheckIn.Clear();
            txtCheckOut.Clear();
            txtCurrentStatus.Clear();
            cmbNewStatus.Items.Clear();
            btnUpdateStatus.Enabled = false;
        }

        // ===================== UPDATE STATUS =====================

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentReservation == null)
                    throw new Exception("Please select a reservation first.");

                string newStatus = cmbNewStatus.Text;

                // Siguraduhin muna bago i-cancel
                if (newStatus == "Cancelled")
                {
                    DialogResult answer = MessageBox.Show("Cancel " + currentReservation.ReservationCode + "?\nThe room will be available again.",
                        "Cancel Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer != DialogResult.Yes) return;
                }

                reservationController.UpdateStatus(currentReservation.Id, newStatus);

                MessageBox.Show(currentReservation.ReservationCode + " is now " + newStatus + ".",
                    "Reservation Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // I-refresh ang details at ang table
                currentReservation = reservationController.FindReservation(currentReservation.ReservationCode);
                ShowDetails(currentReservation);
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reservation Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ReservationStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}