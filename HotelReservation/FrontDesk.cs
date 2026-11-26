using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class FrontDesk : Form
    {
        RoomController roomController = new RoomController();
        ReservationController reservationController = new ReservationController();

        // Lahat ng rooms galing database (dito kumukuha ang search at filter)
        List<Room> allRooms = new List<Room>();

        public FrontDesk()
        {
            InitializeComponent();
            lblFrontDesk.Text = "Front Desk: " + Session.CurrentUser?.Username;

            // Sidebar (ang btnGuests ay naka-connect na sa designer -> button1_Click)
            btnReservation.Click += btnReservation_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnReservationStatus.Click += btnReservationStatus_Click;
            btnLogout.Click += btnLogout_Click;

            // Room Availability
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnCheckDates.Click += btnCheckDates_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;
            cmbStatus.SelectedIndexChanged += Filter_Changed;
            cmbRoomType.SelectedIndexChanged += Filter_Changed;

            this.FormClosed += FrontDesk_FormClosed;
        }

        // ================= FORM LOAD =================

        private void FrontDesk_Load(object sender, EventArgs e)
        {
            // Petsa ngayon at oras ng check-in / check-out
            lblHotelTime.Text = "Today: " + DateTime.Today.ToString("MMM dd, yyyy") +
                "  |  Check-in: " + HotelPolicy.CheckInTimeText +
                "  |  Check-out: " + HotelPolicy.CheckOutTimeText;

            // Status filter
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Reserved");
            cmbStatus.Items.Add("Occupied");
            cmbStatus.Items.Add("Maintenance");

            // Room type filter (galing database)
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("All");
            try
            {
                foreach (RoomType type in roomController.GetRoomTypes())
                {
                    cmbRoomType.Items.Add(type.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Para hindi mag-filter habang sine-set pa lang
            cmbStatus.SelectedIndexChanged -= Filter_Changed;
            cmbRoomType.SelectedIndexChanged -= Filter_Changed;
            cmbStatus.SelectedIndex = 0;
            cmbRoomType.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += Filter_Changed;
            cmbRoomType.SelectedIndexChanged += Filter_Changed;

            // Check by date: default ay ngayon hanggang bukas
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            nudGuests.Minimum = 1;
            nudGuests.Maximum = 10;
            nudGuests.Value = 1;

            SetupGrid();
            LoadRooms();
        }

        private void SetupGrid()
        {
            dgvRooms.Columns.Clear();
            dgvRooms.Columns.Add("colRoomNo", "Room No.");
            dgvRooms.Columns.Add("colType", "Room Type");
            dgvRooms.Columns.Add("colBed", "Bed Size");
            dgvRooms.Columns.Add("colMax", "Max Guests");
            dgvRooms.Columns.Add("colRate", "Rate");
            dgvRooms.Columns.Add("colStatus", "Status");

            dgvRooms.ReadOnly = true;
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.DefaultCellStyle.ForeColor = Color.Black;
            dgvRooms.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // ================= LOAD AT DISPLAY =================

        // Kinukuha ulit ang rooms sa database
        private void LoadRooms()
        {
            try
            {
                // Kinakansela muna ang mga expired na reservation para tama ang status
                reservationController.CancelExpiredReservations();

                allRooms = roomController.GetRooms();
                UpdateSummary();
                ShowFilteredRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bilang ng bawat status
        private void UpdateSummary()
        {
            int available = 0;
            int reserved = 0;
            int occupied = 0;
            int maintenance = 0;

            foreach (Room room in allRooms)
            {
                if (room.Status == "Available") available++;
                else if (room.Status == "Reserved") reserved++;
                else if (room.Status == "Occupied") occupied++;
                else if (room.Status == "Maintenance") maintenance++;
            }

            lblAvailable.Text = "Available: " + available;
            lblReserved.Text = "Reserved: " + reserved;
            lblOccupied.Text = "Occupied: " + occupied;
            lblMaintenance.Text = "Maintenance: " + maintenance;
        }

        // Ipinapakita ang rooms na pasok sa search, status at room type
        private void ShowFilteredRooms()
        {
            string search = txtSearch.Text.Trim().ToLower();
            string status = cmbStatus.Text;
            string type = cmbRoomType.Text;

            List<Room> result = new List<Room>();

            foreach (Room room in allRooms)
            {
                // Search: room number, room type o status
                if (search != "")
                {
                    bool match = room.RoomNumber.ToLower().StartsWith(search) ||
                                 room.RoomTypeName.ToLower().Contains(search) ||
                                 room.Status.ToLower().Contains(search);
                    if (!match) continue;
                }

                if (status != "" && status != "All" && room.Status != status) continue;
                if (type != "" && type != "All" && room.RoomTypeName != type) continue;

                result.Add(room);
            }

            ShowRooms(result, false);
        }

        // Nilalagay sa table. forDates = true kapag galing sa Check Dates
        private void ShowRooms(List<Room> rooms, bool forDates)
        {
            dgvRooms.Rows.Clear();

            foreach (Room room in rooms)
            {
                int maxGuests = room.RoomType != null ? room.RoomType.MaxGuests : 0;

                // Sa Check Dates, "Available" ang ipinapakita kasi bakante ito sa petsang pinili
                string status = room.Status;
                if (forDates)
                {
                    status = "Available";
                }

                int index = dgvRooms.Rows.Add(room.RoomNumber, room.RoomTypeName, room.BedSize,
                    maxGuests, room.Rate.ToString("N2"), status);

                // Kulay ng row depende sa status
                DataGridViewRow row = dgvRooms.Rows[index];
                if (status == "Available") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "Reserved") row.DefaultCellStyle.BackColor = Color.Khaki;
                else if (status == "Occupied") row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (status == "Maintenance") row.DefaultCellStyle.BackColor = Color.LightGray;
            }

            dgvRooms.ClearSelection();
        }

        // ================= SEARCH AT FILTER =================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowFilteredRooms();

            if (dgvRooms.Rows.Count == 0)
            {
                MessageBox.Show("No rooms found.", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Pindutin ang Enter sa search box = Search
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // para walang "ding" na tunog
                btnSearch.PerformClick();
            }
        }

        // Kapag pinalitan ang Status o Room Type
        private void Filter_Changed(object sender, EventArgs e)
        {
            ShowFilteredRooms();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            cmbStatus.SelectedIndexChanged -= Filter_Changed;
            cmbRoomType.SelectedIndexChanged -= Filter_Changed;
            cmbStatus.SelectedIndex = 0;
            cmbRoomType.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += Filter_Changed;
            cmbRoomType.SelectedIndexChanged += Filter_Changed;

            LoadRooms();
        }

        // ================= CHECK BY DATE =================

        // Mga room na bakante sa napiling petsa at kasya ang bilang ng guests
        private void btnCheckDates_Click(object sender, EventArgs e)
        {
            try
            {
                // May validation na dito (past date, check-out, max 30 nights)
                List<Room> available = reservationController.GetAvailableRooms(
                    dtpCheckIn.Value.Date, dtpCheckOut.Value.Date, 0);

                int guests = (int)nudGuests.Value;
                string type = cmbRoomType.Text;
                List<Room> result = new List<Room>();

                foreach (Room room in available)
                {
                    int maxGuests = room.RoomType != null ? room.RoomType.MaxGuests : 0;
                    if (maxGuests < guests) continue;
                    if (type != "" && type != "All" && room.RoomTypeName != type) continue;

                    result.Add(room);
                }

                if (result.Count == 0)
                {
                    throw new Exception("No available rooms for " + guests + " guest(s) on the selected dates.");
                }

                ShowRooms(result, true);

                int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                MessageBox.Show(result.Count + " room(s) available from " +
                    dtpCheckIn.Value.ToString("MMM dd") + " to " + dtpCheckOut.Value.ToString("MMM dd, yyyy") +
                    " (" + nights + " night(s)) for " + guests + " guest(s).\n\nClick Refresh to show all rooms again.",
                    "Check Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= SIDEBAR =================

        // Guests Information
        private void button1_Click(object sender, EventArgs e)
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

        private void btnReservationStatus_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new ReservationStatus());
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