using System;
using System.Windows.Forms;

namespace HotelReservation   // <-- palitan kung iba ang namespace sa file mo
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();

            // Ikinakabit ang bawat button sa function nito
            btnRoomsMaintenance.Click += btnRoomsMaintenance_Click;
            btnGuestRecords.Click += btnGuestRecords_Click;
            btnReservationRecords.Click += btnReservationRecords_Click;
            btnBillingRecords.Click += btnBillingRecords_Click;
            btnLogout.Click += btnLogout_Click;
            this.Load += AdminDashboard_Load;
            this.FormClosed += AdminDashboard_FormClosed;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Ipakita ang username ng naka-login
            if (BusinessLogic.Session.CurrentUser != null)
            {
                lblUser.Text = BusinessLogic.Session.CurrentUser.Username;
            }
            else
            {
                lblUser.Text = "";
            }
        }

        private void btnRoomsMaintenance_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new RoomMaintenance());
        }

        private void btnGuestRecords_Click(object sender, EventArgs e)
        {
            // Wala pang GuestRecords form. Papalitan natin ito pag nagawa na:
            // Navigator.Open(this, new GuestRecords());
            MessageBox.Show("Guest Records is not available yet.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Kapag pinindot ang X, isasara ang buong program
            Navigator.ExitIfUserClosed(e);
        }
    }
}