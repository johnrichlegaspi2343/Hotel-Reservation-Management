namespace HotelReservation
{
    partial class FrontDesk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            lblFrontDesk = new Label();
            btnGuests = new Button();
            btnReservation = new Button();
            btnReservationStatus = new Button();
            btnCheckInCheckOut = new Button();
            btnBillingPayment = new Button();
            btnLogout = new Button();
            panel1 = new Panel();
            label3 = new Label();
            label8 = new Label();
            nudGuests = new NumericUpDown();
            label7 = new Label();
            btnCheckDates = new Button();
            label6 = new Label();
            label5 = new Label();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            btnRefresh = new Button();
            cmbStatus = new ComboBox();
            lblMaintenance = new Label();
            lblOccupied = new Label();
            lblReserved = new Label();
            btnSearch = new Button();
            cmbRoomType = new ComboBox();
            lblAvailable = new Label();
            lblHotelTime = new Label();
            lblTitle = new Label();
            txtSearch = new TextBox();
            label2 = new Label();
            dgvRooms = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGuests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(823, 35);
            label1.Name = "label1";
            label1.Size = new Size(398, 60);
            label1.TabIndex = 0;
            label1.Text = "Hotel Reservation";
            // 
            // lblFrontDesk
            // 
            lblFrontDesk.AutoSize = true;
            lblFrontDesk.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblFrontDesk.ForeColor = Color.White;
            lblFrontDesk.Location = new Point(1540, 128);
            lblFrontDesk.Name = "lblFrontDesk";
            lblFrontDesk.Size = new Size(128, 38);
            lblFrontDesk.TabIndex = 1;
            lblFrontDesk.Text = "< user >";
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.OliveDrab;
            btnGuests.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(79, 208);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(364, 82);
            btnGuests.TabIndex = 2;
            btnGuests.Text = "Guests Information";
            btnGuests.UseVisualStyleBackColor = false;
            btnGuests.Click += button1_Click;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.OliveDrab;
            btnReservation.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(79, 312);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(364, 82);
            btnReservation.TabIndex = 4;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnReservationStatus
            // 
            btnReservationStatus.BackColor = Color.OliveDrab;
            btnReservationStatus.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnReservationStatus.ForeColor = Color.White;
            btnReservationStatus.Location = new Point(79, 434);
            btnReservationStatus.Name = "btnReservationStatus";
            btnReservationStatus.Size = new Size(364, 82);
            btnReservationStatus.TabIndex = 5;
            btnReservationStatus.Text = "Reservation Status";
            btnReservationStatus.UseVisualStyleBackColor = false;
            // 
            // btnCheckInCheckOut
            // 
            btnCheckInCheckOut.BackColor = Color.OliveDrab;
            btnCheckInCheckOut.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnCheckInCheckOut.ForeColor = Color.White;
            btnCheckInCheckOut.Location = new Point(79, 549);
            btnCheckInCheckOut.Name = "btnCheckInCheckOut";
            btnCheckInCheckOut.Size = new Size(364, 82);
            btnCheckInCheckOut.TabIndex = 6;
            btnCheckInCheckOut.Text = "Check-In / Check-Out";
            btnCheckInCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnBillingPayment
            // 
            btnBillingPayment.BackColor = Color.OliveDrab;
            btnBillingPayment.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnBillingPayment.ForeColor = Color.White;
            btnBillingPayment.Location = new Point(79, 660);
            btnBillingPayment.Name = "btnBillingPayment";
            btnBillingPayment.Size = new Size(364, 82);
            btnBillingPayment.TabIndex = 7;
            btnBillingPayment.Text = "Billing / Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnLogout.ForeColor = Color.OliveDrab;
            btnLogout.Location = new Point(1688, 122);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(148, 49);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(nudGuests);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(btnCheckDates);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dtpCheckOut);
            panel1.Controls.Add(dtpCheckIn);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(cmbStatus);
            panel1.Controls.Add(lblMaintenance);
            panel1.Controls.Add(lblOccupied);
            panel1.Controls.Add(lblReserved);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(cmbRoomType);
            panel1.Controls.Add(lblAvailable);
            panel1.Controls.Add(lblHotelTime);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvRooms);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(543, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 800);
            panel1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(516, 167);
            label3.Name = "label3";
            label3.Size = new Size(97, 38);
            label3.TabIndex = 22;
            label3.Text = "Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(799, 167);
            label8.Name = "label8";
            label8.Size = new Size(81, 38);
            label8.TabIndex = 21;
            label8.Text = "Type:";
            // 
            // nudGuests
            // 
            nudGuests.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudGuests.Location = new Point(1202, 177);
            nudGuests.Name = "nudGuests";
            nudGuests.Size = new Size(65, 31);
            nudGuests.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(1096, 170);
            label7.Name = "label7";
            label7.Size = new Size(114, 38);
            label7.TabIndex = 19;
            label7.Text = "Guests: ";
            // 
            // btnCheckDates
            // 
            btnCheckDates.BackColor = Color.PaleGreen;
            btnCheckDates.ForeColor = Color.Black;
            btnCheckDates.Location = new Point(997, 247);
            btnCheckDates.Name = "btnCheckDates";
            btnCheckDates.Size = new Size(112, 42);
            btnCheckDates.TabIndex = 18;
            btnCheckDates.Text = "Check Dates";
            btnCheckDates.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(507, 251);
            label6.Name = "label6";
            label6.Size = new Size(155, 38);
            label6.TabIndex = 17;
            label6.Text = "Check-Out:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(27, 255);
            label5.Name = "label5";
            label5.Size = new Size(132, 38);
            label5.TabIndex = 16;
            label5.Text = "Check-In:";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckOut.Location = new Point(670, 256);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(291, 31);
            dtpCheckOut.TabIndex = 15;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckIn.Location = new Point(164, 258);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(319, 31);
            dtpCheckIn.TabIndex = 14;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.PaleGreen;
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(1155, 245);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 42);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(619, 178);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 28);
            cmbStatus.TabIndex = 12;
            // 
            // lblMaintenance
            // 
            lblMaintenance.AutoSize = true;
            lblMaintenance.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenance.ForeColor = Color.Black;
            lblMaintenance.Location = new Point(747, 80);
            lblMaintenance.Name = "lblMaintenance";
            lblMaintenance.Size = new Size(214, 38);
            lblMaintenance.TabIndex = 10;
            lblMaintenance.Text = "Maintenance: 0 ";
            // 
            // lblOccupied
            // 
            lblOccupied.AutoSize = true;
            lblOccupied.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOccupied.ForeColor = Color.Black;
            lblOccupied.Location = new Point(507, 80);
            lblOccupied.Name = "lblOccupied";
            lblOccupied.Size = new Size(171, 38);
            lblOccupied.TabIndex = 9;
            lblOccupied.Text = "Occupied: 0 ";
            // 
            // lblReserved
            // 
            lblReserved.AutoSize = true;
            lblReserved.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReserved.ForeColor = Color.Black;
            lblReserved.Location = new Point(271, 80);
            lblReserved.Name = "lblReserved";
            lblReserved.Size = new Size(166, 38);
            lblReserved.TabIndex = 8;
            lblReserved.Text = "Reserved: 0 ";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.PaleGreen;
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(352, 175);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 33);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(886, 177);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(166, 28);
            cmbRoomType.TabIndex = 6;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvailable.ForeColor = Color.Black;
            lblAvailable.Location = new Point(27, 80);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(156, 38);
            lblAvailable.TabIndex = 5;
            lblAvailable.Text = "Available: 0";
            // 
            // lblHotelTime
            // 
            lblHotelTime.AutoSize = true;
            lblHotelTime.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHotelTime.ForeColor = Color.Black;
            lblHotelTime.Location = new Point(747, 12);
            lblHotelTime.Name = "lblHotelTime";
            lblHotelTime.Size = new Size(95, 38);
            lblHotelTime.TabIndex = 4;
            lblHotelTime.Text = "Today:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(27, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(354, 54);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Room Availability";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(132, 178);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(212, 27);
            txtSearch.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(26, 167);
            label2.Name = "label2";
            label2.Size = new Size(114, 38);
            label2.TabIndex = 1;
            label2.Text = "Search: ";
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvRooms.DefaultCellStyle = dataGridViewCellStyle4;
            dgvRooms.Location = new Point(27, 323);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1276, 463);
            dgvRooms.TabIndex = 0;
            // 
            // FrontDesk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(btnBillingPayment);
            Controls.Add(btnCheckInCheckOut);
            Controls.Add(btnReservationStatus);
            Controls.Add(btnReservation);
            Controls.Add(btnGuests);
            Controls.Add(lblFrontDesk);
            Controls.Add(label1);
            ForeColor = Color.White;
            Name = "FrontDesk";
            Text = "FrontDesk";
            WindowState = FormWindowState.Maximized;
            Load += FrontDesk_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGuests).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblFrontDesk;
        private Button btnGuests;
        private Button btnReservation;
        private Button btnReservationStatus;
        private Button btnCheckInCheckOut;
        private Button btnBillingPayment;
        private Button btnLogout;
        private Panel panel1;
        private Label label2;
        private DataGridView dgvRooms;
        private TextBox txtSearch;
        private ComboBox cmbRoomType;
        private Label lblAvailable;
        private Label lblHotelTime;
        private Label lblTitle;
        private Label lblMaintenance;
        private Label lblOccupied;
        private Label lblReserved;
        private Button btnSearch;
        private DateTimePicker dtpCheckOut;
        private DateTimePicker dtpCheckIn;
        private Button btnRefresh;
        private ComboBox cmbStatus;
        private Label label6;
        private Label label5;
        private Label label7;
        private Button btnCheckDates;
        private NumericUpDown nudGuests;
        private Label label8;
        private Label label3;
    }
}