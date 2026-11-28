using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    // RESERVATION: 1 hanggang 5 rooms sa isang reservation.
    // Pagka-Proceed, PENDING muna. Magiging Confirmed kapag nabayaran ang 50% downpayment sa Billing.
    public partial class Reservation : Form
    {
        private GuestController guestController = new GuestController();
        private RoomController roomController = new RoomController();
        private ReservationController reservationController = new ReservationController();

        // Ang napiling guest (0 = wala pa) at ang mga napiling room
        private int selectedGuestId = 0;
        private List<Room> selectedRooms = new List<Room>();

        // Panel ng available rooms (ginagawa sa code, lalabas kapag Find Room / Add Another Room)
        private Panel pnlRooms = new Panel();
        private Label lblRoomsTitle = new Label();
        private DataGridView dgvAvailableRooms = new DataGridView();
        private Button btnCloseRooms = new Button();
        private Label lblRoomInfo = new Label();

        // Panel ng guest list (lalabas kapag maraming guest ang nahanap)
        private Panel pnlGuests = new Panel();
        private Label lblGuestsTitle = new Label();
        private DataGridView dgvGuestList = new DataGridView();
        private Button btnCloseGuests = new Button();

        public Reservation()
        {
            InitializeComponent();
            SetupForm();
            SetupRoomPanel();
            SetupGuestPanel();

            // Sidebar
            btnGuests.Click += btnGuests_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnReservationStatus.Click += btnReservationStatus_Click;
            btnLogout.Click += btnLogout_Click;

            // Guest section
            btnSearchGuest.Click += btnSearchGuest_Click;
            txtSearchGuest.KeyDown += txtSearchGuest_KeyDown;
            btnAddNewGuest.Click += btnAddNewGuest_Click;

            // Room section
            btnFindRoom.Click += btnFindRoom_Click;
            btnAddAnotherRoom.Click += btnAddAnotherRoom_Click;
            btnRemoveRoom.Click += btnRemoveRoom_Click;
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
            SelectGuest(guest);
            txtSearchGuest.Text = guest.GuestCode;
        }

        // ===================== SETUP =====================

        private void SetupForm()
        {
            lblUser.Text = "Front Desk: " + Session.CurrentUser?.Username;

            // Room Type filter: "All" + lahat ng type galing database
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("All");
            try
            {
                foreach (RoomType type in roomController.GetRoomTypes())
                {
                    cmbRoomType.Items.Add(type);    // lalabas ang Name dahil sa ToString()
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbRoomType.SelectedIndex = 0;

            // Beds filter
            cmbBeds.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBeds.Items.Clear();
            cmbBeds.Items.Add("Any");
            for (int b = 1; b <= HotelPolicy.MaxBedsPerRoom; b++)
            {
                cmbBeds.Items.Add(b.ToString());
            }
            cmbBeds.SelectedIndex = 0;

            // Number of guests: hanggang 8 bawat room x 5 rooms = 40
            nudGuests.Minimum = 1;
            nudGuests.Maximum = HotelPolicy.MaxGuestsPerRoom * HotelPolicy.MaxRoomsPerReservation;
            nudGuests.Value = 1;

            // Hindi puwedeng i-type, ang system ang naglalagay
            txtGuestId.ReadOnly = true;
            txtGuestName.ReadOnly = true;
            txtValidId.ReadOnly = true;
            txtReservationId.ReadOnly = true;
            txtNights.ReadOnly = true;

            // Dates: default ay ngayon hanggang bukas
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            // Selected Rooms table
            SetupGrid(dgvSelectedRooms);
            dgvSelectedRooms.Columns.Add("Id", "Id");
            dgvSelectedRooms.Columns.Add("RoomNumber", "Room");
            dgvSelectedRooms.Columns.Add("RoomType", "Type");
            dgvSelectedRooms.Columns.Add("Beds", "Beds");
            dgvSelectedRooms.Columns.Add("MaxGuests", "Max Guests");
            dgvSelectedRooms.Columns.Add("Rate", "Rate / Night");
            dgvSelectedRooms.Columns.Add("Subtotal", "Subtotal");
            dgvSelectedRooms.Columns["Id"].Visible = false;

            ComputeNights();
            UpdateSummary();
        }

        // Pare-parehong setting ng mga table
        private void SetupGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.BackgroundColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Kasing-laki ng font ng ibang forms
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.RowTemplate.Height = 32;
        }

        // Ginagawa ang isang popup panel: title, Close button at table
        private void SetupPopup(Panel panel, Label title, Button close, DataGridView grid, int width, int height)
        {
            panel.Size = new Size(width, height);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Visible = false;

            title.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            title.ForeColor = Color.Black;
            title.Location = new Point(10, 10);
            title.AutoSize = true;

            close.Text = "Close";
            close.Size = new Size(90, 32);
            close.Location = new Point(width - 105, 6);
            close.BackColor = Color.LightGreen;

            SetupGrid(grid);
            grid.Location = new Point(10, 45);

            panel.Controls.Add(title);
            panel.Controls.Add(close);
            panel.Controls.Add(grid);
            this.Controls.Add(panel);
        }

        // Ipapakita ang panel sa gitna ng form, sa ibabaw ng lahat
        private void ShowPopup(Panel panel)
        {
            panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2,
                                       (this.ClientSize.Height - panel.Height) / 2);
            panel.Visible = true;
            panel.BringToFront();
        }

        private void SetupRoomPanel()
        {
            SetupPopup(pnlRooms, lblRoomsTitle, btnCloseRooms, dgvAvailableRooms, 820, 420);
            dgvAvailableRooms.Size = new Size(798, 290);

            dgvAvailableRooms.Columns.Add("Id", "Id");
            dgvAvailableRooms.Columns.Add("RoomNumber", "Room");
            dgvAvailableRooms.Columns.Add("RoomType", "Type");
            dgvAvailableRooms.Columns.Add("Beds", "Beds");
            dgvAvailableRooms.Columns.Add("MaxGuests", "Max Guests");
            dgvAvailableRooms.Columns.Add("Rate", "Rate / Night");
            dgvAvailableRooms.Columns.Add("Amenities", "Amenities");
            dgvAvailableRooms.Columns["Id"].Visible = false;
            dgvAvailableRooms.Columns["Amenities"].FillWeight = 250;   // mas malapad

            // Buong amenities ng room na naka-highlight
            lblRoomInfo.Location = new Point(10, 342);
            lblRoomInfo.Size = new Size(798, 66);
            lblRoomInfo.ForeColor = Color.Black;
            lblRoomInfo.Text = "Double-click a room to add it.";
            pnlRooms.Controls.Add(lblRoomInfo);

            btnCloseRooms.Click += btnCloseRooms_Click;
            dgvAvailableRooms.CellClick += dgvAvailableRooms_CellClick;
            dgvAvailableRooms.CellDoubleClick += dgvAvailableRooms_CellDoubleClick;
        }

        private void SetupGuestPanel()
        {
            SetupPopup(pnlGuests, lblGuestsTitle, btnCloseGuests, dgvGuestList, 820, 360);
            dgvGuestList.Size = new Size(798, 300);
            lblGuestsTitle.Text = "Select the guest";

            dgvGuestList.Columns.Add("Id", "Id");
            dgvGuestList.Columns.Add("GuestCode", "Guest ID");
            dgvGuestList.Columns.Add("Name", "Name");
            dgvGuestList.Columns.Add("Birthdate", "Birthdate");
            dgvGuestList.Columns.Add("Contact", "Contact No.");
            dgvGuestList.Columns.Add("IdType", "ID Type");
            dgvGuestList.Columns.Add("IdNumber", "ID Number");
            dgvGuestList.Columns["Id"].Visible = false;

            btnCloseGuests.Click += btnCloseGuests_Click;
            dgvGuestList.CellClick += dgvGuestList_CellClick;
        }

        // ===================== GUEST =====================

        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            try
            {
                List<Guest> guests = guestController.SearchGuest(txtSearchGuest.Text.Trim());

                // Isa lang ang nakita: piliin na agad
                if (guests.Count == 1)
                {
                    SelectGuest(guests[0]);
                    return;
                }

                // Marami (hal. dalawang "Juan Santos"): ipakita ang listahan para piliin ang tama
                dgvGuestList.Rows.Clear();
                foreach (Guest g in guests)
                {
                    dgvGuestList.Rows.Add(g.Id, g.GuestCode, g.FullName, g.DateOfBirth.ToString("MM/dd/yyyy"),
                        g.ContactNumber, g.IdType, g.IdNumber);
                }
                dgvGuestList.ClearSelection();
                lblGuestsTitle.Text = guests.Count + " guests found - click the correct guest";
                ShowPopup(pnlGuests);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Enter = Search
        private void txtSearchGuest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearchGuest_Click(sender, EventArgs.Empty);
            }
        }

        private void dgvGuestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;     // header ang na-click

            try
            {
                int id = Convert.ToInt32(dgvGuestList.Rows[e.RowIndex].Cells["Id"].Value);
                foreach (Guest g in guestController.GetGuests())
                {
                    if (g.Id == id)
                    {
                        SelectGuest(g);
                        break;
                    }
                }
                pnlGuests.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseGuests_Click(object sender, EventArgs e)
        {
            pnlGuests.Visible = false;
        }

        private void SelectGuest(Guest guest)
        {
            selectedGuestId = guest.Id;
            txtGuestId.Text = guest.GuestCode;
            txtGuestName.Text = guest.FullName;

            if (guest.IdType == "" || guest.IdNumber == "")
            {
                txtValidId.Text = "No Valid ID - please update in Guest Information";
                txtValidId.ForeColor = Color.Firebrick;
            }
            else
            {
                txtValidId.Text = guest.IdType + " - " + guest.IdNumber;
                txtValidId.ForeColor = Color.Black;
            }
        }

        private void btnAddNewGuest_Click(object sender, EventArgs e)
        {
            // true = galing sa Reservation, para bumalik dito pagka-Add
            Navigator.Open(this, new GuestsInformation(true));
        }

        // ===================== FIND ROOM / ADD ANOTHER ROOM =====================

        // Find Room = magsisimula ulit sa unang room
        private void btnFindRoom_Click(object sender, EventArgs e)
        {
            if (selectedRooms.Count > 0)
            {
                DialogResult answer = MessageBox.Show(
                    "Start over and remove the " + selectedRooms.Count + " selected room/s?\n" +
                    "(Use Add Another Room to keep them.)",
                    "Find Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                    return;

                selectedRooms.Clear();
                ShowSelectedRooms();
            }

            OpenRoomPanel();
        }

        // Add Another Room = dagdag na room (hanggang 5)
        private void btnAddAnotherRoom_Click(object sender, EventArgs e)
        {
            if (selectedRooms.Count >= HotelPolicy.MaxRoomsPerReservation)
            {
                MessageBox.Show("Maximum of " + HotelPolicy.MaxRoomsPerReservation + " rooms per reservation.",
                    "Add Another Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenRoomPanel();
        }

        // Ipapakita ang mga bakanteng room ayon sa petsa, room type at beds
        private void OpenRoomPanel()
        {
            try
            {
                int roomTypeId = 0;     // 0 = lahat ng type
                if (cmbRoomType.SelectedItem is RoomType)
                    roomTypeId = ((RoomType)cmbRoomType.SelectedItem).Id;

                // May validation na dito (past date, check-out, max 30 nights)
                List<Room> rooms = reservationController.GetAvailableRooms(dtpCheckIn.Value, dtpCheckOut.Value, roomTypeId);

                dgvAvailableRooms.Rows.Clear();
                foreach (Room room in rooms)
                {
                    // Beds filter
                    if (cmbBeds.Text != "Any" && room.Beds.ToString() != cmbBeds.Text)
                        continue;

                    // Huwag nang ipakita ang napili na
                    if (IsSelected(room.Id))
                        continue;

                    dgvAvailableRooms.Rows.Add(room.Id, room.RoomNumber, room.RoomTypeName, room.BedSize,
                        room.MaxGuests, room.Rate.ToString("N2"), room.Amenities);
                }

                if (dgvAvailableRooms.Rows.Count == 0)
                    throw new Exception("No available rooms match the selected room type and beds. Try \"All\" or \"Any\".");

                dgvAvailableRooms.ClearSelection();
                lblRoomsTitle.Text = "Available Rooms (" + dgvAvailableRooms.Rows.Count + ") - " +
                    dtpCheckIn.Value.ToString("MMM dd") + " to " + dtpCheckOut.Value.ToString("MMM dd, yyyy");
                lblRoomInfo.Text = "Click a room to see its amenities. Double-click to add it.";
                ShowPopup(pnlRooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Find Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Isang click = ipakita ang detalye ng room
        private void dgvAvailableRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvAvailableRooms.Rows[e.RowIndex];
            lblRoomInfo.Text = "Room " + row.Cells["RoomNumber"].Value + " (" + row.Cells["RoomType"].Value + ") - " +
                row.Cells["Beds"].Value + ", up to " + row.Cells["MaxGuests"].Value + " guest/s\n" +
                "Amenities: " + row.Cells["Amenities"].Value + "\n" +
                "Double-click to add this room.";
        }

        // Double-click = idagdag ang room
        private void dgvAvailableRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int roomId = Convert.ToInt32(dgvAvailableRooms.Rows[e.RowIndex].Cells["Id"].Value);

            foreach (Room room in roomController.GetRooms())
            {
                if (room.Id == roomId)
                {
                    selectedRooms.Add(room);
                    break;
                }
            }

            pnlRooms.Visible = false;
            ShowSelectedRooms();
        }

        private void btnCloseRooms_Click(object sender, EventArgs e)
        {
            pnlRooms.Visible = false;
        }

        // TRUE kung napili na ang room
        private bool IsSelected(int roomId)
        {
            foreach (Room r in selectedRooms)
            {
                if (r.Id == roomId) return true;
            }
            return false;
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            if (dgvSelectedRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click the room to remove in the Selected Rooms table.",
                    "Remove Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int roomId = Convert.ToInt32(dgvSelectedRooms.SelectedRows[0].Cells["Id"].Value);

            for (int i = 0; i < selectedRooms.Count; i++)
            {
                if (selectedRooms[i].Id == roomId)
                {
                    selectedRooms.RemoveAt(i);
                    break;
                }
            }

            ShowSelectedRooms();
        }

        // ===================== SELECTED ROOMS AT SUMMARY =====================

        private void ShowSelectedRooms()
        {
            int nights = GetNights();

            dgvSelectedRooms.Rows.Clear();
            foreach (Room room in selectedRooms)
            {
                dgvSelectedRooms.Rows.Add(room.Id, room.RoomNumber, room.RoomTypeName, room.BedSize,
                    room.MaxGuests, room.Rate.ToString("N2"), (room.Rate * nights).ToString("N2"));
            }
            dgvSelectedRooms.ClearSelection();

            UpdateSummary();
        }

        // Rooms, capacity, total at downpayment
        private void UpdateSummary()
        {
            int nights = GetNights();
            int capacity = 0;
            decimal total = 0;

            foreach (Room room in selectedRooms)
            {
                capacity += room.MaxGuests;
                total += room.Rate * nights;
            }

            decimal downpayment = Math.Round(total * HotelPolicy.DownpaymentPercent / 100, 2);
            int guests = (int)nudGuests.Value;

            lblTotalRooms.Text = "Rooms: " + selectedRooms.Count + " / " + HotelPolicy.MaxRoomsPerReservation;
            lblCapacity.Text = "Capacity: " + capacity + " guest/s (" + guests + " selected)";
            lblTotalAmount.Text = "Total: P" + total.ToString("N2");
            lblDownpayment.Text = "Downpayment (" + HotelPolicy.DownpaymentPercent + "%): P" + downpayment.ToString("N2");

            // Pula kapag kulang ang rooms para sa guests
            if (selectedRooms.Count > 0 && capacity < guests)
                lblCapacity.ForeColor = Color.Firebrick;
            else
                lblCapacity.ForeColor = Color.Black;
        }

        private int GetNights()
        {
            return (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
        }

        private void ComputeNights()
        {
            txtNights.Text = GetNights().ToString();
        }

        // Kapag binago ang petsa, baka hindi na bakante ang napiling rooms, kaya pipili ulit
        private void Dates_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value.Date >= dtpCheckOut.Value.Date)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.Date.AddDays(1);
            }

            ComputeNights();
            pnlRooms.Visible = false;

            if (selectedRooms.Count > 0)
            {
                selectedRooms.Clear();
                MessageBox.Show("Dates changed. Please select the rooms again.",
                    "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowSelectedRooms();
        }

        private void nudGuests_ValueChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        // ===================== PROCEED =====================

        // I-save ang reservation (Pending), tapos diretso sa Billing Payment para sa downpayment
        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGuestId == 0)
                    throw new Exception("Please search and select a guest first.");

                if (selectedRooms.Count == 0)
                    throw new Exception("Please click Find Room and select at least one room.");

                List<int> roomIds = new List<int>();
                foreach (Room room in selectedRooms)
                {
                    roomIds.Add(room.Id);
                }

                int guests = (int)nudGuests.Value;

                // May validation na dito (capacity, max 5 rooms, double-booking, Valid ID)
                Model.Reservation reservation = reservationController.CreateReservation(
                    selectedGuestId, roomIds, dtpCheckIn.Value, dtpCheckOut.Value, guests);

                txtReservationId.Text = reservation.ReservationCode;

                MessageBox.Show("Reservation saved as PENDING.\n\n" +
                    "Reservation ID: " + reservation.ReservationCode + "\n" +
                    "Guest: " + txtGuestName.Text + "\n" +
                    "Rooms: " + reservation.RoomNumbers + "\n" +
                    "Guests: " + reservation.NumberOfGuests + "\n" +
                    "Check-in: " + reservation.ExpectedCheckIn.ToString("MM/dd/yyyy hh:mm tt") + "\n" +
                    "Check-out: " + reservation.ExpectedCheckOut.ToString("MM/dd/yyyy hh:mm tt") + "\n" +
                    "Nights: " + reservation.Nights + "\n" +
                    "Total: P" + reservation.TotalBill.ToString("N2") + "\n\n" +
                    "Pay the " + HotelPolicy.DownpaymentPercent + "% downpayment (P" +
                    reservation.DownpaymentAmount.ToString("N2") + ") to confirm and hold the room/s.\n" +
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
            txtSearchGuest.Clear();
            txtGuestId.Clear();
            txtGuestName.Clear();
            txtValidId.Clear();
            txtReservationId.Clear();
            selectedGuestId = 0;

            nudGuests.Value = 1;
            cmbRoomType.SelectedIndex = 0;
            cmbBeds.SelectedIndex = 0;

            selectedRooms.Clear();
            pnlRooms.Visible = false;
            pnlGuests.Visible = false;

            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            ComputeNights();
            ShowSelectedRooms();
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