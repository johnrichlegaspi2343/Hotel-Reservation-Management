using BusinessLogic;
using BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class GuestsInformation : Form
    {
        private GuestController guestController = new GuestController();
        private List<Guest> currentGuests = new List<Guest>();
        private int selectedGuestId = 0;     // 0 = walang napili
        private bool fromReservation = false;   // BAGO: true kapag galing sa Add New Guest ng Reservation

        public GuestsInformation()
        {
            InitializeComponent();
            lblUser.Text = "Front Desk: " + Session.CurrentUser?.Username;

            SetupForm();
            LoadGuests(guestController.GetGuests());

            btnSearch.Click += btnSearch_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            dgvGuests.CellClick += dgvGuests_CellClick;

            // Sidebar
            btnReservation.Click += btnReservation_Click;
            btnCheckInCheckOut.Click += btnCheckInCheckOut_Click;
            btnBillingPayment.Click += btnBillingPayment_Click;
            btnLogout.Click += btnLogout_Click;
            this.FormClosed += GuestsInformation_FormClosed;
        }

        // BAGO: ginagamit ng Reservation (Add New Guest)
        public GuestsInformation(bool fromReservation) : this()
        {
            this.fromReservation = fromReservation;
        }

        private void SetupForm()
        {
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Items.Clear();
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Other");

            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.MaxDate = DateTime.Today;
            dtpDateOfBirth.Value = DateTime.Today.AddYears(-18);

            dgvGuests.ReadOnly = true;
            dgvGuests.AllowUserToAddRows = false;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.MultiSelect = false;
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.Columns.Clear();
            dgvGuests.Columns.Add("Id", "Id");
            dgvGuests.Columns.Add("GuestCode", "Guest ID");
            dgvGuests.Columns.Add("Name", "Name");
            dgvGuests.Columns.Add("Contact", "Contact Number");
            dgvGuests.Columns.Add("Address", "Address");
            dgvGuests.Columns["Id"].Visible = false;
        }

        // Ipakita ang listahan sa table
        private void LoadGuests(List<Guest> guests)
        {
            currentGuests = guests;
            dgvGuests.Rows.Clear();

            foreach (Guest g in guests)
            {
                dgvGuests.Rows.Add(g.Id, g.GuestCode, g.FullName, g.ContactNumber, g.Address);
            }
        }

        // Kunin ang laman ng mga textbox bilang Guest
        private Guest ReadForm()
        {
            Guest guest = new Guest();
            guest.Id = selectedGuestId;
            guest.FirstName = txtBoxFirstName.Text;
            guest.LastName = txtBoxLastName.Text;
            guest.Gender = cmbGender.Text;
            guest.DateOfBirth = dtpDateOfBirth.Value;
            guest.ContactNumber = txtBoxNumber.Text;
            guest.Address = txtBoxAddress.Text;
            guest.EmergencyContactName = txtBoxEmergencyContact.Text;
            guest.EmergencyContactNumber = txtBoxEmergencyContactNumber.Text;
            return guest;
        }

        // Ilagay ang detalye ng guest sa mga textbox
        private void FillForm(Guest g)
        {
            selectedGuestId = g.Id;
            txtBoxFirstName.Text = g.FirstName;
            txtBoxLastName.Text = g.LastName;
            cmbGender.Text = g.Gender;
            dtpDateOfBirth.Value = g.DateOfBirth;
            txtBoxNumber.Text = g.ContactNumber;
            txtBoxAddress.Text = g.Address;
            txtBoxEmergencyContact.Text = g.EmergencyContactName;
            txtBoxEmergencyContactNumber.Text = g.EmergencyContactNumber;
        }

        private void ClearForm()
        {
            selectedGuestId = 0;
            txtBoxFirstName.Clear();
            txtBoxLastName.Clear();
            cmbGender.SelectedIndex = -1;
            dtpDateOfBirth.Value = DateTime.Today.AddYears(-18);
            txtBoxNumber.Clear();
            txtBoxAddress.Clear();
            txtBoxEmergencyContact.Clear();
            txtBoxEmergencyContactNumber.Clear();
        }

        // ===================== SEARCH =====================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Kapag walang laman, ipakita lahat
                if (txtSearchGuest.Text.Trim() == "")
                    LoadGuests(guestController.GetGuests());
                else
                    LoadGuests(guestController.SearchGuest(txtSearchGuest.Text));
            }
            catch (Exception ex)
            {
                LoadGuests(new List<Guest>());
                MessageBox.Show(ex.Message, "Search Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Pag-click ng guest sa table, ilagay ang detalye sa form
        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;     // header ang na-click

            int id = Convert.ToInt32(dgvGuests.Rows[e.RowIndex].Cells["Id"].Value);

            foreach (Guest g in currentGuests)
            {
                if (g.Id == id)
                {
                    FillForm(g);
                    break;
                }
            }
        }

        // ===================== ADD / UPDATE / DELETE =====================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                selectedGuestId = 0;   // bagong guest
                Guest guest = ReadForm();
                guestController.AddGuest(guest);

                MessageBox.Show("Guest added. Guest ID: " + guest.GuestCode, "Add Guest",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // BAGO: kung galing sa Reservation, bumalik doon na naka-fill ang guest
                if (fromReservation)
                {
                    Navigator.Open(this, new Reservation(guest));
                    return;
                }

                ClearForm();
                LoadGuests(guestController.GetGuests());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedGuestId == 0)
            {
                MessageBox.Show("Please select a guest from the table first.");
                return;
            }

            try
            {
                Guest guest = ReadForm();
                guestController.UpdateGuest(guest);

                MessageBox.Show("Guest " + guest.GuestCode + " updated.", "Update Guest",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadGuests(guestController.GetGuests());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGuestId == 0)
            {
                MessageBox.Show("Please select a guest from the table first.");
                return;
            }

            DialogResult answer = MessageBox.Show("Delete this guest?", "Delete Guest",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            try
            {
                guestController.DeleteGuest(selectedGuestId);
                MessageBox.Show("Guest deleted.", "Delete Guest");

                ClearForm();
                LoadGuests(guestController.GetGuests());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtSearchGuest.Clear();
            LoadGuests(guestController.GetGuests());
        }

        // ===================== SIDEBAR =====================

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

        private void GuestsInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}