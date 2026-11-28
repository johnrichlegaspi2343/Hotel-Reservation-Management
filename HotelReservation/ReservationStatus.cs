using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    // MANAGE RESERVATIONS
    // Trabaho: hanapin, tingnan at i-cancel ang mga booking.
    // Ang bayad ay sa Billing, ang check-in/check-out ay sa Check-In/Out (may "Go to" buttons).
    public partial class ReservationStatus : Form
    {
        private ReservationController reservationController = new ReservationController();

        // Ang napiling reservation (null = wala pang napili)
        private Model.Reservation? currentReservation = null;

        // Kung anong listahan ang nakabukas: Arrivals, Departures, InHouse, Pending, All, Search
        private string currentFilter = "All";

        public ReservationStatus()
        {
            InitializeComponent();
            SetupForm();

            // Filters
            btnArrivals.Click += btnArrivals_Click;
            btnDepartures.Click += btnDepartures_Click;
            btnInHouse.Click += btnInHouse_Click;
            btnPendingPayment.Click += btnPendingPayment_Click;
            btnAll.Click += btnAll_Click;

            // Search at table
            btnSearch.Click += btnSearch_Click;
            txtSearchReservationId.KeyDown += txtSearchReservationId_KeyDown;
            dgvReservations.CellClick += dgvReservations_CellClick;

            // Actions
            btnGoBilling.Click += btnGoBilling_Click;
            btnGoCheckInOut.Click += btnGoCheckInOut_Click;
            btnCancelReservation.Click += btnCancelReservation_Click;

            // Sidebar
            btnGuests.Click += btnGuests_Click;
            btnReservation.Click += btnReservation_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += ReservationStatus_FormClosed;

            ShowList("All");
        }

        // ===================== SETUP =====================

        private void SetupForm()
        {
            txtSearchReservationId.PlaceholderText = "Res ID, name, room";

            // Table
            dgvReservations.ReadOnly = true;
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.DefaultCellStyle.ForeColor = Color.Black;
            dgvReservations.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Kasing-laki ng font ng ibang forms
            dgvReservations.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvReservations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.RowTemplate.Height = 34;

            dgvReservations.Columns.Clear();
            dgvReservations.Columns.Add("Id", "Id");
            dgvReservations.Columns.Add("Code", "Res ID");
            dgvReservations.Columns.Add("Guest", "Guest");
            dgvReservations.Columns.Add("Rooms", "Rooms");
            dgvReservations.Columns.Add("CheckIn", "Check-in");
            dgvReservations.Columns.Add("Status", "Status");
            dgvReservations.Columns.Add("Payment", "Payment");
            dgvReservations.Columns["Id"].Visible = false;

            ClearDetails();
        }

        // ===================== LISTAHAN =====================

        // filter = Arrivals, Departures, InHouse, Pending o All
        private void ShowList(string filter)
        {
            try
            {
                List<Model.Reservation> list;
                string title;

                if (filter == "Arrivals")
                {
                    list = reservationController.GetTodaysArrivals();
                    title = "Today's Arrivals";
                }
                else if (filter == "Departures")
                {
                    list = reservationController.GetTodaysDepartures();
                    title = "Today's Departures";
                }
                else if (filter == "InHouse")
                {
                    list = reservationController.GetInHouse();
                    title = "In-House Guests";
                }
                else if (filter == "Pending")
                {
                    list = reservationController.GetPendingPayment();
                    title = "Pending Payment";
                }
                else
                {
                    filter = "All";
                    list = reservationController.GetReservations();
                    title = "All Reservations";
                }

                currentFilter = filter;
                FillTable(list);
                lblShowing.Text = "Showing: " + title + " (" + list.Count + ")";
                HighlightFilterButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nilalagay ang mga reservation sa table, may kulay bawat status
        private void FillTable(List<Model.Reservation> list)
        {
            dgvReservations.Rows.Clear();

            foreach (Model.Reservation r in list)
            {
                int index = dgvReservations.Rows.Add(
                    r.Id,
                    r.ReservationCode,
                    r.Guest != null ? r.Guest.FullName : "",
                    r.RoomNumbers,
                    r.CheckInDate.ToString("MM/dd/yyyy"),
                    r.Status,
                    r.PaymentStatus);

                DataGridViewRow row = dgvReservations.Rows[index];
                if (r.Status == "Pending") row.DefaultCellStyle.BackColor = Color.Khaki;
                else if (r.Status == "Confirmed") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (r.Status == "CheckedIn") row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                else if (r.Status == "Cancelled") row.DefaultCellStyle.BackColor = Color.LightGray;
                else row.DefaultCellStyle.BackColor = Color.White;
            }

            dgvReservations.ClearSelection();
            ClearDetails();
        }

        // Naka-bold ang filter na nakabukas
        private void HighlightFilterButton()
        {
            Font normal = new Font(btnAll.Font, FontStyle.Regular);
            Font bold = new Font(btnAll.Font, FontStyle.Bold);

            btnArrivals.Font = currentFilter == "Arrivals" ? bold : normal;
            btnDepartures.Font = currentFilter == "Departures" ? bold : normal;
            btnInHouse.Font = currentFilter == "InHouse" ? bold : normal;
            btnPendingPayment.Font = currentFilter == "Pending" ? bold : normal;
            btnAll.Font = currentFilter == "All" ? bold : normal;
        }

        // Ipapakita ulit ang parehong listahan (pagkatapos mag-Cancel)
        private void RefreshList()
        {
            if (currentFilter == "Search")
                SearchReservations();
            else
                ShowList(currentFilter);
        }

        private void btnArrivals_Click(object sender, EventArgs e)
        {
            ShowList("Arrivals");
        }

        private void btnDepartures_Click(object sender, EventArgs e)
        {
            ShowList("Departures");
        }

        private void btnInHouse_Click(object sender, EventArgs e)
        {
            ShowList("InHouse");
        }

        private void btnPendingPayment_Click(object sender, EventArgs e)
        {
            ShowList("Pending");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtSearchReservationId.Clear();
            ShowList("All");
        }

        // ===================== SEARCH =====================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchReservations();
        }

        // Enter = Search
        private void txtSearchReservationId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchReservations();
            }
        }

        // Puwede ang Reservation ID, pangalan ng guest o room number
        private void SearchReservations()
        {
            try
            {
                string text = txtSearchReservationId.Text.Trim();
                List<Model.Reservation> list = reservationController.SearchReservations(text);

                currentFilter = "Search";
                FillTable(list);
                lblShowing.Text = "Search results for \"" + text + "\" (" + list.Count + ")";
                HighlightFilterButton();

                // Isa lang ang nakita: piliin na agad
                if (list.Count == 1)
                {
                    dgvReservations.Rows[0].Selected = true;
                    ShowDetails(list[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ===================== DETALYE =====================

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;     // header ang na-click

            try
            {
                int id = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["Id"].Value);
                ShowDetails(reservationController.GetReservationById(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetails(Model.Reservation r)
        {
            currentReservation = r;

            if (r.Guest != null)
            {
                lblDetGuest.Text = r.Guest.FullName + " (" + r.Guest.GuestCode + ")";
                lblDetValidId.Text = r.Guest.IdType + " - " + r.Guest.IdNumber;
            }

            // Lahat ng room, hal. "301 Deluxe, 401 Family"
            string rooms = "";
            foreach (ReservationRoom rr in r.Rooms)
            {
                if (rooms != "") rooms += ", ";
                rooms += rr.Room?.RoomNumber + " " + rr.Room?.RoomTypeName;
            }
            lblDetRooms.Text = rooms;

            lblDetDates.Text = r.ExpectedCheckIn.ToString("MMM dd h:mm tt") + " - " +
                r.ExpectedCheckOut.ToString("MMM dd h:mm tt");
            lblDetGuests.Text = r.Nights + " night/s  -  " + r.NumberOfGuests + " guest/s  -  " + r.Status;
            lblDetTotal.Text = "Total: P" + r.TotalBill.ToString("N2");
            lblDetPaid.Text = "Paid: P" + r.AmountPaid.ToString("N2");
            lblDetBalance.Text = "Balance: P" + r.Balance.ToString("N2");

            // Kasaysayan ng bayad at charges
            lstHistory.Items.Clear();
            foreach (Payment p in r.Payments)
            {
                lstHistory.Items.Add(p.TransactionId + "  " + p.PaymentDate.ToString("MM/dd") + "  " +
                    p.PaymentMethod + "  P" + p.Amount.ToString("N2"));
            }
            foreach (Charge c in r.Charges)
            {
                lstHistory.Items.Add("Charge: " + c.Description + "  P" + c.Amount.ToString("N2"));
            }
            if (r.SecurityDeposit > 0)
            {
                lstHistory.Items.Add("Security deposit held: P" + r.SecurityDeposit.ToString("N2"));
            }
            if (lstHistory.Items.Count == 0)
            {
                lstHistory.Items.Add("No payments yet");
            }

            // Paalala tungkol sa bayad o cancellation (maliwanag na kulay kasi green ang background)
            lblCancelRule.ForeColor = Color.White;
            if (r.Status == "Pending")
            {
                lblCancelRule.Text = "Downpayment due: P" + r.DownpaymentDue.ToString("N2");
                lblCancelRule.ForeColor = Color.Gold;
            }
            else if (r.Status == "Confirmed")
            {
                if (reservationController.IsFreeCancellation(r))
                {
                    DateTime lastFreeDay = r.CheckInDate.AddDays(-HotelPolicy.FreeCancelDays - 1);
                    lblCancelRule.Text = "Free cancellation until " + lastFreeDay.ToString("MMM dd, yyyy");
                    lblCancelRule.ForeColor = Color.White;
                }
                else
                {
                    lblCancelRule.Text = "Non-refundable (within " + HotelPolicy.FreeCancelDays + " day)";
                    lblCancelRule.ForeColor = Color.Yellow;
                }
            }
            else if (r.Status == "Cancelled")
            {
                lblCancelRule.Text = "Cancelled. Refund: P" + r.RefundAmount.ToString("N2");
            }
            else
            {
                lblCancelRule.Text = "";
            }

            UpdateButtons();
        }

        private void ClearDetails()
        {
            currentReservation = null;
            lblDetGuest.Text = "Select a reservation";
            lblDetValidId.Text = "";
            lblDetRooms.Text = "";
            lblDetDates.Text = "";
            lblDetGuests.Text = "";
            lblDetTotal.Text = "";
            lblDetPaid.Text = "";
            lblDetBalance.Text = "";
            lblCancelRule.Text = "";
            lstHistory.Items.Clear();
            UpdateButtons();
        }

        // Naka-enable lang ang button kapag may silbi ito sa napiling reservation
        private void UpdateButtons()
        {
            Model.Reservation? r = currentReservation;

            // Billing: may babayaran pa (downpayment, balance o charges)
            btnGoBilling.Enabled = r != null &&
                (r.Status == "Pending" || r.Status == "Confirmed" || r.Status == "CheckedIn");

            // Check-In/Out: darating na ngayon, o nandito na at aalis
            btnGoCheckInOut.Enabled = r != null &&
                ((r.Status == "Confirmed" && r.CheckInDate.Date <= DateTime.Today) || r.Status == "CheckedIn");

            // Cancel: hindi pa dumarating
            btnCancelReservation.Enabled = r != null && (r.Status == "Pending" || r.Status == "Confirmed");
        }

        // ===================== ACTIONS =====================

        // Bubuksan ang Billing na naka-search na ang reservation
        private void btnGoBilling_Click(object sender, EventArgs e)
        {
            if (currentReservation == null)
                return;

            Navigator.Open(this, new BillingPayment(currentReservation.ReservationCode));
        }

        // Bubuksan ang Check-In/Out na naka-search na ang reservation
        private void btnGoCheckInOut_Click(object sender, EventArgs e)
        {
            if (currentReservation == null)
                return;

            Navigator.Open(this, new CheckinCheckout(currentReservation.ReservationCode));
        }

        // DITO LANG puwedeng mag-cancel ng reservation
        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (currentReservation == null)
                return;

            Model.Reservation r = currentReservation;

            // Sabihin muna kung may refund o wala
            string refundText;
            if (r.AmountPaid <= 0)
                refundText = "No payment has been made.";
            else if (reservationController.IsFreeCancellation(r))
                refundText = "Free cancellation: P" + r.AmountPaid.ToString("N2") + " will be refunded.";
            else
                refundText = "Within " + HotelPolicy.FreeCancelDays + " day of check-in: the P" +
                    r.AmountPaid.ToString("N2") + " payment is NON-REFUNDABLE.";

            DialogResult answer = MessageBox.Show(
                "Cancel " + r.ReservationCode + " (" + r.Guest?.FullName + ")?\n\n" + refundText,
                "Cancel Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
                return;

            try
            {
                decimal refund = reservationController.CancelReservation(r.Id);

                MessageBox.Show(r.ReservationCode + " has been cancelled.\nRefund: P" + refund.ToString("N2"),
                    "Cancel Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cancel Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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