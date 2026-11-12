using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using BusinessLogic.Controller;   // kung mag-error, Ctrl + . sa GuestController

namespace HotelReservation   // <-- palitan kung iba ang namespace sa file mo
{
    public partial class GuestRecords : Form
    {
        GuestController guestController = new GuestController();

        public GuestRecords()
        {
            InitializeComponent();

            // Sidebar
            btnRoomsMaintenance.Click += btnRoomsMaintenance_Click;
            btnReservationRecords.Click += btnReservationRecords_Click;
            btnBillingRecords.Click += btnBillingRecords_Click;
            btnLogout.Click += btnLogout_Click;

            // Search
            btnSearch.Click += btnSearch_Click;

            // Form
            this.Load += GuestRecords_Load;
            this.FormClosed += GuestRecords_FormClosed;
        }

        // ================= FORM LOAD =================

        private void GuestRecords_Load(object sender, EventArgs e)
        {
            if (BusinessLogic.Session.CurrentUser != null)
            {
                lblUser.Text = BusinessLogic.Session.CurrentUser.Username;
            }

            SetupGrid();
            LoadAllGuests();
        }

        private void SetupGrid()
        {
            dgvGuests.Columns.Clear();
            dgvGuests.Columns.Add("colCode", "Guest ID");
            dgvGuests.Columns.Add("colName", "Full Name");
            dgvGuests.Columns.Add("colGender", "Gender");
            dgvGuests.Columns.Add("colBirthDate", "Date of Birth");
            dgvGuests.Columns.Add("colContact", "Contact Number");
            dgvGuests.Columns.Add("colEmail", "Email");
            dgvGuests.Columns.Add("colAddress", "Address");
            dgvGuests.Columns.Add("colEmergency", "Emergency Contact");
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= LOAD DATA =================

        private void LoadAllGuests()
        {
            try
            {
                List<Guest> guests = guestController.GetGuests();
                ShowGuests(guests);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Inilalagay sa table ang listahan ng guests
        private void ShowGuests(List<Guest> guests)
        {
            dgvGuests.Rows.Clear();

            foreach (Guest guest in guests)
            {
                string emergency = guest.EmergencyContactName + " (" + guest.EmergencyContactNumber + ")";

                dgvGuests.Rows.Add(
                    guest.GuestCode,
                    guest.FullName,
                    guest.Gender,
                    guest.DateOfBirth.ToString("MMM dd, yyyy"),
                    guest.ContactNumber,
                    guest.Email,
                    guest.Address,
                    emergency);
            }

            dgvGuests.ClearSelection();
        }

        // ================= SEARCH =================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearchGuest.Text.Trim();

            // Kapag walang laman ang search, ipakita ulit lahat
            if (text == "")
            {
                LoadAllGuests();
                return;
            }

            try
            {
                List<Guest> guests = guestController.SearchGuest(text);
                ShowGuests(guests);
            }
            catch (Exception ex)
            {
                // Dito papasok ang "Guest not found." galing sa controller
                MessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= SIDEBAR =================

        private void btnRoomsMaintenance_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new RoomMaintenance());
        }

        private void btnReservationRecords_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new ReservationRecords());
        }

        private void btnBillingRecords_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new BillingRecords());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                Navigator.Logout(this);
            }
        }

        private void GuestRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}