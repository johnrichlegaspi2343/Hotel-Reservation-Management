using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class Reservation : Form
    {
        private GuestController guestController = new GuestController();
        private RoomController roomController = new RoomController();
        private ReservationController reservationController = new ReservationController();

        // Ang napiling guest at room (0 = wala pang napili)
        private int selectedGuestId = 0;
        private int selectedRoomId = 0;

        // Panel ng available rooms (ginagawa sa code, lalabas lang kapag pinindot ang Find Room)
        private Panel pnlRooms = new Panel();
        private Label lblRoomsTitle = new Label();
        private DataGridView dgvAvailableRooms = new DataGridView();
        private Button btnCloseRooms = new Button();

        public Reservation()
        {
            InitializeComponent();
            SetupForm();
            SetupRoomPanel();

            // Sidebar
            btnGuests.Click += btnGuests_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnReservationStatus.Click += btnReservationStatus_Click;
            btnLogout.Click += btnLogout_Click;

            // Guest section
            btnSearchGuest.Click += btnSearchGuest_Click;
            btnAddNewGuest.Click += btnAddNewGuest_Click;

            // Room section
            btnFindRoom.Click += btnFindRoom_Click;
            dtpCheckIn.ValueChanged += Dates_ValueChanged;
            dtpCheckOut.ValueChanged += Dates_ValueChanged;
            nudGuests.ValueChanged += nudGuests_ValueChanged;

            // Reservation section
            btnProceed.Click += btnProceed_Click;
            btnClear.Click += btnClear_Click;

            this.FormClosed += Reservation_FormClosed;
        }

        // Ginagamit kapag galing sa Add New Guest: naka-fill na agad ang guest
        public Reservation(Guest guest) : this()
        {
            selectedGuestId = guest.Id;
            txtSearchGuest.Text = guest.GuestCode;
            txtGuestId.Text = guest.GuestCode;
            txtGuestName.Text = guest.FullName;
        }

        // ===================== SETUP =====================

        private void SetupForm()
        {
            lblUser.Text = "Front Desk: " + Session.CurrentUser?.Username;

            // Room Type: galing database. Naka-disable kasi automatic base sa number of guests.
            cmbRoomType.Items.Clear();
            cmbRoomType.Enabled = false;
            int maxGuests = 1;
            try
            {
                List<RoomType> types = roomController.GetRoomTypes();
                foreach (RoomType type in types)
                {
                    cmbRoomType.Items.Add(type);

                    if (type.MaxGuests > maxGuests)
                        maxGuests = type.MaxGuests;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Number of guests: 1 hanggang sa pinakamalaking room
            nudGuests.Minimum = 1;
            nudGuests.Maximum = maxGuests;
            nudGuests.Value = 1;

            // Hindi puwedeng i-type, ang system ang naglalagay
            txtGuestId.ReadOnly = true;
            txtGuestName.ReadOnly = true;
            txtBedSize.ReadOnly = true;
            txtSelectedRoom.ReadOnly = true;
            txtReservationId.ReadOnly = true;
            txtNights.ReadOnly = true;

            // Dates: default ay ngayon hanggang bukas
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            ComputeNights();
            UpdateRoomTypeForGuests();
        }

        // Ginagawa ang panel at table ng available rooms
        private void SetupRoomPanel()
        {
            pnlRooms.Size = new Size(650, 340);
            pnlRooms.BackColor = Color.White;
            pnlRooms.BorderStyle = BorderStyle.FixedSingle;
            pnlRooms.Visible = false;

            lblRoomsTitle.Text = "Available Rooms - click a room to select";
            lblRoomsTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblRoomsTitle.ForeColor = Color.Black;
            lblRoomsTitle.Location = new Point(10, 10);
            lblRoomsTitle.AutoSize = true;

            btnCloseRooms.Text = "Close";
            btnCloseRooms.Size = new Size(90, 32);
            btnCloseRooms.Location = new Point(545, 6);
            btnCloseRooms.BackColor = Color.LightGreen;
            btnCloseRooms.Click += btnCloseRooms_Click;

            dgvAvailableRooms.Location = new Point(10, 45);
            dgvAvailableRooms.Size = new Size(625, 282);
            dgvAvailableRooms.ReadOnly = true;
            dgvAvailableRooms.AllowUserToAddRows = false;
            dgvAvailableRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableRooms.MultiSelect = false;
            dgvAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableRooms.RowHeadersVisible = false;
            dgvAvailableRooms.BackgroundColor = Color.White;
            dgvAvailableRooms.DefaultCellStyle.ForeColor = Color.Black;

            dgvAvailableRooms.Columns.Add("Id", "Id");
            dgvAvailableRooms.Columns.Add("RoomNumber", "Room No.");
            dgvAvailableRooms.Columns.Add("RoomType", "Room Type");
            dgvAvailableRooms.Columns.Add("BedSize", "Bed Size");
            dgvAvailableRooms.Columns.Add("Rate", "Rate / Night");
            dgvAvailableRooms.Columns.Add("Status", "Status Today");
            dgvAvailableRooms.Columns["Id"].Visible = false;
            dgvAvailableRooms.CellClick += dgvAvailableRooms_CellClick;

            pnlRooms.Controls.Add(lblRoomsTitle);
            pnlRooms.Controls.Add(btnCloseRooms);
            pnlRooms.Controls.Add(dgvAvailableRooms);
            this.Controls.Add(pnlRooms);
        }

        // ===================== GUEST =====================

        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchGuest.Text.Trim() == "")
                    throw new Exception("Please enter a Guest ID or name.");

                List<Guest> guests = guestController.SearchGuest(txtSearchGuest.Text.Trim());
                Guest guest = guests[0];

                selectedGuestId = guest.Id;
                txtGuestId.Text = guest.GuestCode;
                txtGuestName.Text = guest.FullName;

                if (guests.Count > 1)
                {
                    MessageBox.Show(guests.Count + " guests found. The first one was selected.\nUse the Guest ID (ex. GST-001) to be exact.",
                        "Search Guest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                selectedGuestId = 0;
                txtGuestId.Clear();
                txtGuestName.Clear();
                MessageBox.Show(ex.Message, "Search Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddNewGuest_Click(object sender, EventArgs e)
        {
            // true = galing sa Reservation, para bumalik dito pagka-Add
            Navigator.Open(this, new GuestsInformation(true));
        }

        // ===================== FIND ROOM =====================

        private void btnFindRoom_Click(object sender, EventArgs e)
        {
            try
            {
                // Ang room type ay galing sa number of guests
                if (!(cmbRoomType.SelectedItem is RoomType))
                    throw new Exception("No room type for " + nudGuests.Value + " guest(s).");

                RoomType type = (RoomType)cmbRoomType.SelectedItem;

                // May validation na dito (past date, check-out, max 30 nights)
                List<Room> rooms = reservationController.GetAvailableRooms(dtpCheckIn.Value, dtpCheckOut.Value, type.Id);

                dgvAvailableRooms.Rows.Clear();
                foreach (Room room in rooms)
                {
                    dgvAvailableRooms.Rows.Add(room.Id, room.RoomNumber, room.RoomTypeName,
                        room.BedSize, room.Rate.ToString("N2"), room.Status);
                }
                dgvAvailableRooms.ClearSelection();

                lblRoomsTitle.Text = "Available " + type.Name + " Rooms (" +
                    dtpCheckIn.Value.ToString("MMM dd") + " - " + dtpCheckOut.Value.ToString("MMM dd") + ")";

                // Ilagay ang panel sa gitna ng form at ipakita sa ibabaw ng lahat
                pnlRooms.Location = new Point((this.ClientSize.Width - pnlRooms.Width) / 2,
                                              (this.ClientSize.Height - pnlRooms.Height) / 2);
                pnlRooms.Visible = true;
                pnlRooms.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Find Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Pag-click sa room sa table, iyon ang napiling room
        private void dgvAvailableRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;   // header ang na-click

            DataGridViewRow row = dgvAvailableRooms.Rows[e.RowIndex];
            selectedRoomId = Convert.ToInt32(row.Cells["Id"].Value);
            txtSelectedRoom.Text = row.Cells["RoomNumber"].Value.ToString();

            pnlRooms.Visible = false;
        }

        private void btnCloseRooms_Click(object sender, EventArgs e)
        {
            pnlRooms.Visible = false;
        }

        // Kapag binago ang petsa, kailangang mag-Find Room ulit
        private void Dates_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value.Date >= dtpCheckOut.Value.Date)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.Date.AddDays(1);
            }

            ComputeNights();
            ClearRoom();
        }

        // ===================== NUMBER OF GUESTS =====================

        private void nudGuests_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomTypeForGuests();
            ClearRoom();
        }

        // 1 = Standard, 2 = Deluxe, 3 = Family Room, 4 = Suite
        private void UpdateRoomTypeForGuests()
        {
            int guests = (int)nudGuests.Value;
            bool found = false;

            foreach (object item in cmbRoomType.Items)
            {
                RoomType type = (RoomType)item;

                if (type.MaxGuests == guests)
                {
                    cmbRoomType.SelectedItem = item;
                    txtBedSize.Text = type.BedSize + " Bed";
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                cmbRoomType.SelectedIndex = -1;
                txtBedSize.Text = "No room for " + guests + " guest(s)";
            }
        }

        private void ComputeNights()
        {
            int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
            txtNights.Text = nights.ToString();
        }

        private void ClearRoom()
        {
            selectedRoomId = 0;
            txtSelectedRoom.Clear();
            pnlRooms.Visible = false;
        }

        // ===================== PROCEED =====================

        // I-save ang reservation (Confirmed), tapos diretso sa Billing Payment
        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGuestId == 0)
                    throw new Exception("Please search and select a guest first.");

                if (selectedRoomId == 0)
                    throw new Exception("Please click Find Room and select a room.");

                int guests = (int)nudGuests.Value;

                Model.Reservation reservation = reservationController.CreateReservation(
                    selectedGuestId, selectedRoomId, dtpCheckIn.Value, dtpCheckOut.Value, "Confirmed", guests);

                txtReservationId.Text = reservation.ReservationCode;

                MessageBox.Show("Reservation saved!\n\n" +
                    "Reservation ID: " + reservation.ReservationCode + "\n" +
                    "Guest: " + txtGuestName.Text + "\n" +
                    "Room: " + txtSelectedRoom.Text + "\n" +
                    "Guests: " + reservation.NumberOfGuests + " (" + txtBedSize.Text + ")\n" +
                    "Check-in: " + reservation.ExpectedCheckIn.ToString("MM/dd/yyyy hh:mm tt") + "\n" +
                    "Check-out: " + reservation.ExpectedCheckOut.ToString("MM/dd/yyyy hh:mm tt") + "\n" +
                    "Nights: " + reservation.Nights + "\n" +
                    "Total: " + reservation.TotalBill.ToString("N2") + "\n\n" +
                    "Proceeding to Billing Payment...",
                    "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lilipat sa Billing Payment, naka-search na ang reservation
                Navigator.Open(this, new BillingPayment(reservation.ReservationCode));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtSearchGuest.Clear();
            txtGuestId.Clear();
            txtGuestName.Clear();
            txtReservationId.Clear();
            selectedGuestId = 0;

            nudGuests.Value = 1;
            UpdateRoomTypeForGuests();
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            ClearRoom();
            ComputeNights();
        }

        // ===================== SIDEBAR =====================

        private void btnGuests_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new GuestsInformation());
        }

        private void btnCheckInCheckOut_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new CheckinCheckout());
        }

        private void btnBillingPayment_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new BillingPayment());
        }

        private void btnReservationStatus_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new ReservationStatus());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Navigator.Logout(this);
        }

        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }

        // Galing sa designer, hayaan lang (huwag burahin)
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}