using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using BusinessLogic.Controller;   // kung mag-error, Ctrl + . sa BillingController

namespace HotelReservation   // <-- palitan kung iba ang namespace sa file mo
{
    public partial class BillingRecords : Form
    {
        BillingController billingController = new BillingController();

        public BillingRecords()
        {
            InitializeComponent();

            // Sidebar
            btnRoomsMaintenance.Click += btnRoomsMaintenance_Click;
            btnGuestRecords.Click += btnGuestRecords_Click;
            btnReservationRecords.Click += btnReservationRecords_Click;
            btnLogout.Click += btnLogout_Click;

            // Search at resibo
            btnSearch.Click += btnSearch_Click;
            dgvBillingRecords.CellDoubleClick += dgvBillingRecords_CellDoubleClick;

            // Form
            this.Load += BillingRecords_Load;
            this.FormClosed += BillingRecords_FormClosed;
        }

        // ================= FORM LOAD =================

        private void BillingRecords_Load(object sender, EventArgs e)
        {
            if (BusinessLogic.Session.CurrentUser != null)
            {
                lblUser.Text = BusinessLogic.Session.CurrentUser.Username;
            }

            SetupGrid();
            LoadPayments("");
        }

        private void SetupGrid()
        {
            dgvBillingRecords.Columns.Clear();
            dgvBillingRecords.Columns.Add("colPaymentId", "ID");
            dgvBillingRecords.Columns.Add("colTransaction", "Transaction ID");
            dgvBillingRecords.Columns.Add("colReservation", "Reservation ID");
            dgvBillingRecords.Columns.Add("colGuest", "Guest");
            dgvBillingRecords.Columns.Add("colAmount", "Amount");
            dgvBillingRecords.Columns.Add("colMethod", "Method");
            dgvBillingRecords.Columns.Add("colDate", "Date");
            dgvBillingRecords.Columns.Add("colProcessedBy", "Processed By");
            dgvBillingRecords.Columns["colPaymentId"].Visible = false;
            dgvBillingRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= LOAD DATA =================

        // Kapag "" ang searchCode, lahat ang ipapakita.
        // Kapag may laman, yung payments lang ng reservation na iyon.
        private void LoadPayments(string searchCode)
        {
            try
            {
                List<Payment> payments = billingController.GetPayments();

                dgvBillingRecords.Rows.Clear();
                int count = 0;

                foreach (Payment payment in payments)
                {
                    string reservationCode = "";
                    string guestName = "";

                    if (payment.Reservation != null)
                    {
                        reservationCode = payment.Reservation.ReservationCode;

                        if (payment.Reservation.Guest != null)
                        {
                            guestName = payment.Reservation.Guest.FullName;
                        }
                    }

                    // Laktawan kung may search at hindi tugma ang reservation code
                    if (searchCode != "" && reservationCode != searchCode)
                    {
                        continue;
                    }

                    dgvBillingRecords.Rows.Add(
                        payment.Id,
                        payment.TransactionId,
                        reservationCode,
                        guestName,
                        payment.Amount.ToString("N2"),
                        payment.PaymentMethod,
                        payment.PaymentDate.ToString("MMM dd, yyyy hh:mm tt"),
                        payment.ProcessedBy);

                    count = count + 1;
                }

                dgvBillingRecords.ClearSelection();

                if (searchCode != "" && count == 0)
                {
                    MessageBox.Show("No payments found for " + searchCode + ".", "Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadPayments("");   // ibalik ang lahat
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SEARCH =================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string code = txtSearchReservationId.Text.Trim().ToUpper();
            LoadPayments(code);
        }

        // ================= RESIBO =================

        // I-double-click ang row para makita ang resibo
        private void dgvBillingRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                int paymentId = Convert.ToInt32(dgvBillingRecords.Rows[e.RowIndex].Cells["colPaymentId"].Value);
                string receipt = billingController.GetReceipt(paymentId);

                MessageBox.Show(receipt, "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnReservationRecords_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new ReservationRecords());
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

        private void BillingRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}