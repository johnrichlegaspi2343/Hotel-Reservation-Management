using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic.Controller;   // kung mag-error, Ctrl + . sa ReservationController

namespace HotelReservation   // <-- palitan kung iba ang namespace sa file mo
{
    public partial class ReservationRecords : Form
    {
        ReservationController reservationController = new ReservationController();

        public ReservationRecords()
        {
            InitializeComponent();

            // Sidebar
            btnRoomsMaintenance.Click += btnRoomsMaintenance_Click;
            btnGuestRecords.Click += btnGuestRecords_Click;
            btnBillingRecords.Click += btnBillingRecords_Click;
            btnLogout.Click += btnLogout_Click;

            // Search
            btnSearch.Click += btnSearch_Click;

            // Form
            this.Load += ReservationRecords_Load;
            this.FormClosed += ReservationRecords_FormClosed;
        }

        // ================= FORM LOAD =================

        private void ReservationRecords_Load(object sender, EventArgs e)
        {
            if (BusinessLogic.Session.CurrentUser != null)
            {
                lblUser.Text = BusinessLogic.Session.CurrentUser.Username;
            }

            SetupGrid();
            LoadReservations();
        }

        private void SetupGrid()
        {
            dgvReservations.Columns.Clear();
            dgvReservations.Columns.Add("colCode", "Reservation ID");
            dgvReservations.Columns.Add("colGuest", "Guest");
            dgvReservations.Columns.Add("colRoom", "Room");
            dgvReservations.Columns.Add("colCheckIn", "Check-In");
            dgvReservations.Columns.Add("colCheckOut", "Check-Out");
            dgvReservations.Columns.Add("colNights", "Nights");
            dgvReservations.Columns.Add("colStatus", "Status");
            dgvReservations.Columns.Add("colTotal", "Total Bill");
            dgvReservations.Columns.Add("colPayment", "Payment Status");
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= LOAD DATA =================

        // Ipinapakita lahat ng reservations
        private void LoadReservations()
        {
            try
            {
                List<Model.Reservation> reservations = reservationController.GetReservations();

                dgvReservations.Rows.Clear();

                foreach (Model.Reservation reservation in reservations)
                {
                    AddReservationRow(reservation);
                }

                dgvReservations.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Naglalagay ng isang row sa table
        private void AddReservationRow(Model.Reservation reservation)
        {
            string guestName = "";
            if (reservation.Guest != null)
            {
                guestName = reservation.Guest.FullName;
            }

            string roomNumber = "";
            if (reservation.Room != null)
            {
                roomNumber = reservation.Room.RoomNumber;
            }

            dgvReservations.Rows.Add(
                reservation.ReservationCode,
                guestName,
                roomNumber,
                reservation.CheckInDate.ToString("MMM dd, yyyy"),
                reservation.CheckOutDate.ToString("MMM dd, yyyy"),
                reservation.Nights,
                reservation.Status,
                reservation.TotalBill.ToString("N2"),
                reservation.PaymentStatus);
        }

        // ================= SEARCH =================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string code = txtSearchReservationId.Text.Trim().ToUpper();

            // Kapag walang laman ang search, ipakita ulit lahat
            if (code == "")
            {
                LoadReservations();
                return;
            }

            try
            {
                Model.Reservation reservation = reservationController.FindReservation(code);

                if (reservation == null)
                {
                    throw new Exception("Reservation not found.");
                }

                dgvReservations.Rows.Clear();
                AddReservationRow(reservation);
                dgvReservations.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= SIDEBAR =================

        private void btnRoomsMaintenance_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new RoomMaintenance());
        }

        private void btnGuestRecords_Click(object sender, EventArgs e)
        {
            // Papalitan pag nagawa na ang GuestRecords:
            // Navigator.Open(this, new GuestRecords());
            MessageBox.Show("Guest Records is not available yet.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ReservationRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}