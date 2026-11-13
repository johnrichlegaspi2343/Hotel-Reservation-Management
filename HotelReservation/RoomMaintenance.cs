using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using BusinessLogic.Controller;   // tingnan ang paalala sa ilalim kung mag-error ito

namespace HotelReservation   // <-- palitan kung iba ang namespace sa file mo
{
    public partial class RoomMaintenance : Form
    {
        RoomController roomController = new RoomController();

        // 0 ang ibig sabihin ay walang napiling row
        int selectedRoomId = 0;
        string selectedRoomStatus = "";
        int selectedRoomTypeId = 0;

        public RoomMaintenance()
        {
            InitializeComponent();

            // Sidebar
            btnGuestRecords.Click += btnGuestRecords_Click;
            btnReservationRecords.Click += btnReservationRecords_Click;
            btnBillingRecords.Click += btnBillingRecords_Click;
            btnLogout.Click += btnLogout_Click;

            // Rooms
            btnAddRoom.Click += btnAddRoom_Click;
            btnEditRoom.Click += btnEditRoom_Click;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            btnClearRoom.Click += btnClearRoom_Click;
            dgvRooms.CellClick += dgvRooms_CellClick;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;

            // Room Types
            btnAddRoomType.Click += btnAddRoomType_Click;
            btnEditRoomType.Click += btnEditRoomType_Click;
            btnClearRoomType.Click += btnClearRoomType_Click;
            dgvRoomTypes.CellClick += dgvRoomTypes_CellClick;

            // Form
            this.Load += RoomMaintenance_Load;
            this.FormClosed += RoomMaintenance_FormClosed;
        }

        // ================= FORM LOAD =================

        private void RoomMaintenance_Load(object sender, EventArgs e)
        {
            if (BusinessLogic.Session.CurrentUser != null)
            {
                lblUser.Text = BusinessLogic.Session.CurrentUser.Username;
            }

            cmbRoomStatus.Items.Clear();
            cmbRoomStatus.Items.Add("Available");
            cmbRoomStatus.Items.Add("Maintenance");

            SetupGrids();
            LoadRoomTypes();
            LoadRooms();
        }

        // Gumagawa ng columns ng dalawang table
        private void SetupGrids()
        {
            dgvRooms.Columns.Clear();
            dgvRooms.Columns.Add("colRoomId", "ID");
            dgvRooms.Columns.Add("colRoomNumber", "Room Number");
            dgvRooms.Columns.Add("colRoomTypeId", "Type ID");
            dgvRooms.Columns.Add("colRoomType", "Room Type");
            dgvRooms.Columns.Add("colRate", "Rate");
            dgvRooms.Columns.Add("colStatus", "Status");
            dgvRooms.Columns["colRoomId"].Visible = false;
            dgvRooms.Columns["colRoomTypeId"].Visible = false;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRoomTypes.Columns.Clear();
            dgvRoomTypes.Columns.Add("colTypeId", "ID");
            dgvRoomTypes.Columns.Add("colTypeName", "Room Type");
            dgvRoomTypes.Columns.Add("colTypeRate", "Rate");
            dgvRoomTypes.Columns["colTypeId"].Visible = false;
            dgvRoomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= LOAD DATA =================

        private void LoadRoomTypes()
        {
            try
            {
                List<RoomType> roomTypes = roomController.GetRoomTypes();

                dgvRoomTypes.Rows.Clear();
                cmbRoomType.Items.Clear();

                foreach (RoomType type in roomTypes)
                {
                    dgvRoomTypes.Rows.Add(type.Id, type.Name, type.Rate.ToString("N2"));
                    cmbRoomType.Items.Add(type);   // lalabas ang Name dahil sa ToString()
                }

                cmbRoomType.SelectedIndex = -1;
                dgvRoomTypes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                List<Room> rooms = roomController.GetRooms();

                dgvRooms.Rows.Clear();

                foreach (Room room in rooms)
                {
                    dgvRooms.Rows.Add(room.Id, room.RoomNumber, room.RoomTypeId,
                        room.RoomTypeName, room.Rate.ToString("N2"), room.Status);
                }

                dgvRooms.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= ROOMS =================

        // Kapag pumili ng room type, lalabas ang rate nito
        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoomType.SelectedItem != null)
            {
                RoomType type = (RoomType)cmbRoomType.SelectedItem;
                txtRoomRate.Text = type.Rate.ToString("N2");
            }
            else
            {
                txtRoomRate.Text = "";
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;   // header ang na-click, hindi row
            }

            DataGridViewRow row = dgvRooms.Rows[e.RowIndex];

            selectedRoomId = Convert.ToInt32(row.Cells["colRoomId"].Value);
            selectedRoomStatus = row.Cells["colStatus"].Value.ToString();
            txtRoomNumber.Text = row.Cells["colRoomNumber"].Value.ToString();

            // Hanapin ang tamang room type sa combobox
            int roomTypeId = Convert.ToInt32(row.Cells["colRoomTypeId"].Value);
            cmbRoomType.SelectedIndex = -1;
            foreach (object item in cmbRoomType.Items)
            {
                RoomType type = (RoomType)item;
                if (type.Id == roomTypeId)
                {
                    cmbRoomType.SelectedItem = item;
                }
            }

            // -1 ang lalabas kung Reserved o Occupied (wala sa pagpipilian)
            cmbRoomStatus.SelectedIndex = cmbRoomStatus.Items.IndexOf(selectedRoomStatus);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoomType.SelectedItem == null)
                {
                    throw new Exception("Please select a room type.");
                }

                RoomType type = (RoomType)cmbRoomType.SelectedItem;
                roomController.AddRoom(txtRoomNumber.Text.Trim(), type.Id);

                MessageBox.Show("Room added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms();
                ClearRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRoomId == 0)
                {
                    throw new Exception("Please select a room from the table first.");
                }
                if (cmbRoomType.SelectedItem == null)
                {
                    throw new Exception("Please select a room type.");
                }

                RoomType type = (RoomType)cmbRoomType.SelectedItem;
                roomController.UpdateRoom(selectedRoomId, txtRoomNumber.Text.Trim(), type.Id);

                // Papalitan lang ang status kung may pinili at iba ito sa dati
                if (cmbRoomStatus.SelectedItem != null)
                {
                    string newStatus = cmbRoomStatus.SelectedItem.ToString();
                    if (newStatus != selectedRoomStatus)
                    {
                        roomController.SetRoomStatus(selectedRoomId, newStatus);
                    }
                }

                MessageBox.Show("Room updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms();
                ClearRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadRooms();
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRoomId == 0)
                {
                    throw new Exception("Please select a room from the table first.");
                }

                DialogResult answer = MessageBox.Show("Are you sure you want to delete this room?",
                    "Delete Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    roomController.DeleteRoom(selectedRoomId);
                    MessageBox.Show("Room deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                    ClearRoom();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearRoom_Click(object sender, EventArgs e)
        {
            ClearRoom();
        }

        private void ClearRoom()
        {
            selectedRoomId = 0;
            selectedRoomStatus = "";
            txtRoomNumber.Text = "";
            cmbRoomType.SelectedIndex = -1;
            txtRoomRate.Text = "";
            cmbRoomStatus.SelectedIndex = -1;
            dgvRooms.ClearSelection();
        }

        // ================= ROOM TYPES =================

        private void dgvRoomTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvRoomTypes.Rows[e.RowIndex];

            selectedRoomTypeId = Convert.ToInt32(row.Cells["colTypeId"].Value);
            txtRoomTypeName.Text = row.Cells["colTypeName"].Value.ToString();
            txtRoomTypeRate.Text = row.Cells["colTypeRate"].Value.ToString();
        }

        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                decimal rate;
                if (!decimal.TryParse(txtRoomTypeRate.Text.Trim(), out rate))
                {
                    throw new Exception("Please enter a valid rate (numbers only).");
                }

                roomController.AddRoomType(txtRoomTypeName.Text.Trim(), rate);

                MessageBox.Show("Room type added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRoomTypes();
                ClearRoomType();
                ClearRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRoomTypeId == 0)
                {
                    throw new Exception("Please select a room type from the table first.");
                }

                decimal rate;
                if (!decimal.TryParse(txtRoomTypeRate.Text.Trim(), out rate))
                {
                    throw new Exception("Please enter a valid rate (numbers only).");
                }

                roomController.UpdateRoomType(selectedRoomTypeId, txtRoomTypeName.Text.Trim(), rate);

                MessageBox.Show("Room type updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRoomTypes();
                LoadRooms();   // para lumabas din ang bagong rate sa rooms table
                ClearRoomType();
                ClearRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearRoomType_Click(object sender, EventArgs e)
        {
            ClearRoomType();
        }

        private void ClearRoomType()
        {
            selectedRoomTypeId = 0;
            txtRoomTypeName.Text = "";
            txtRoomTypeRate.Text = "";
            dgvRoomTypes.ClearSelection();
        }

        // ================= SIDEBAR =================

        private void btnGuestRecords_Click(object sender, EventArgs e)
        {
            Navigator.Open(this, new GuestRecords());
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

        private void RoomMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Navigator.ExitIfUserClosed(e);
        }
    }
}