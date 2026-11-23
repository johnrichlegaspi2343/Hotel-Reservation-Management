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

        public Reservation()
        {
            InitializeComponent();
            SetupForm();

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
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            dgvAvailableRooms.CellClick += dgvAvailableRooms_CellClick;
            dtpCheckIn.ValueChanged += Dates_ValueChanged;
            dtpCheckOut.ValueChanged += Dates_ValueChanged;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            nudGuests.ValueChanged += nudGuests_ValueChanged;

            // Reservation section
            btnReserve.Click += btnReserve_Click;
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

            // Room Type: lahat ng room types galing database.
            // Naka-disable kasi automatic itong pinipili base sa number of guests.
            cmbRoomType.Items.Clear();
            cmbRoomType.Enabled = false;
            int maxGuests = 1;
            try
            {
                List<RoomType> types = roomController.GetRoomTypes();
                foreach (RoomType type in types)
                {
                    cmbRoomType.Items.Add(type);

                    // Hanapin ang pinakamaraming guest na kasya sa isang room
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
            txtBedSize.ReadOnly = true;

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Confirmed");
            cmbStatus.SelectedIndex = 0;

            // Dates: default ay ngayon hanggang bukas
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            lblHotelTime.Text = "Check-in: " + HotelPolicy.CheckInTimeText + "  |  Check-out: " + HotelPolicy.CheckOutTimeText;

            

            // Table ng available rooms
            dgvAvailableRooms.ReadOnly = true;
            dgvAvailableRooms.AllowUserToAddRows = false;
            dgvAvailableRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableRooms.MultiSelect = false;
            dgvAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableRooms.RowHeadersVisible = false;

            dgvAvailableRooms.Columns.Clear();
            dgvAvailableRooms.Columns.Add("Id", "Id");
            dgvAvailableRooms.Columns.Add("RoomNumber", "Room No.");
            dgvAvailableRooms.Columns.Add("RoomType", "Room Type");
            dgvAvailableRooms.Columns.Add("BedSize", "Bed Size");
            dgvAvailableRooms.Columns.Add("Rate", "Rate / Night");
            dgvAvailableRooms.Columns.Add("Status", "Status");
            dgvAvailableRooms.Columns["Id"].Visible = false;

            ComputeNights();
            UpdateRoomTypeForGuests();
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

        // ===================== ROOMS =====================

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

        private void LoadAvailableRooms()
        {
            dgvAvailableRooms.Rows.Clear();
            selectedRoomId = 0;
            txtSelectedRoom.Clear();

            try
            {
                // Ang room type ay galing sa number of guests
                if (!(cmbRoomType.SelectedItem is RoomType))
                    throw new Exception("No room type for " + nudGuests.Value + " guest(s).");

                RoomType type = (RoomType)cmbRoomType.SelectedItem;
                int roomTypeId = type.Id;

                List<Room> rooms = reservationController.GetAvailableRooms(dtpCheckIn.Value, dtpCheckOut.Value, roomTypeId);

                foreach (Room room in rooms)
                {
                    dgvAvailableRooms.Rows.Add(room.Id, room.RoomNumber, room.RoomTypeName,
                        room.BedSize, room.Rate.ToString("N2"), room.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check Availability", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Pag-click sa room sa table, iyon ang napiling room
        private void dgvAvailableRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvAvailableRooms.Rows[e.RowIndex];
            selectedRoomId = Convert.ToInt32(row.Cells["Id"].Value);
            txtSelectedRoom.Text = row.Cells["RoomNumber"].Value.ToString();
        }

        // Kapag binago ang petsa o room type, kailangang mag-Check Availability ulit
        private void Dates_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value.Date >= dtpCheckOut.Value.Date)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.Date.AddDays(1);
            }

            ComputeNights();
            ClearRooms();
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearRooms();
        }

        // ===================== NUMBER OF GUESTS =====================

        // Kapag binago ang number of guests, automatic na lalabas ang bed size at room type
        private void nudGuests_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomTypeForGuests();
            ClearRooms();
        }

        // 1 = Single, 2 = Double, 3 = Queen, 4 = King
        private void UpdateRoomTypeForGuests()
        {
            int guests = (int)nudGuests.Value;
            bool found = false;

            foreach (object item in cmbRoomType.Items)
            {
                RoomType type = (RoomType)item;

                // Hanapin ang room type na sakto sa number of guests
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

        private void ClearRooms()
        {
            dgvAvailableRooms.Rows.Clear();
            selectedRoomId = 0;
            txtSelectedRoom.Clear();
        }

        // ===================== RESERVE =====================

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGuestId == 0)
                    throw new Exception("Please search and select a guest first.");

                if (selectedRoomId == 0)
                    throw new Exception("Please click Check Availability and select a room.");

                string status = cmbStatus.SelectedItem.ToString();

                int guests = (int)nudGuests.Value;

                Model.Reservation reservation = reservationController.CreateReservation(
                    selectedGuestId, selectedRoomId, dtpCheckIn.Value, dtpCheckOut.Value, status, guests);

                txtReservationId.Text = reservation.ReservationCode;

                MessageBox.Show("Reservation saved!\n\n" +
                    "Reservation ID: " + reservation.ReservationCode + "\n" +
                    "Guest: " + txtGuestName.Text + "\n" +
                    "Room: " + txtSelectedRoom.Text + "\n" +
                    "Guests: " + reservation.NumberOfGuests + " (" + txtBedSize.Text + ")\n" +
                    "Check-in: " + reservation.ExpectedCheckIn.ToString("MM/dd/yyyy hh:mm tt") + "\n" +
                    "Check-out: " + reservation.ExpectedCheckOut.ToString("MM/dd/yyyy hh:mm tt") + "\n" +
                    "Nights: " + reservation.Nights + "\n" +
                    "Total: " + reservation.TotalBill.ToString("N2") + "\n" +
                    "Status: " + reservation.Status,
                    "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // I-refresh ang listahan para mawala na ang na-book na room
                LoadAvailableRooms();
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
            cmbStatus.SelectedIndex = 0;
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            ClearRooms();
            ComputeNights();
        }

        // ===================== SIDEBAR =====================

        private void btnGuests_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new GuestsInformation());
        }

        // Ang Reservation ay nandito na sa form na ito, kaya walang gagawin

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