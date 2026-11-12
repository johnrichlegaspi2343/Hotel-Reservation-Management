namespace HotelReservation
{
    partial class Reservation
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnGuests = new Button();
            btnReservation = new Button();
            btnReservationStatus = new Button();
            btnCheckInCheckOut = new Button();
            btnBillingPayment = new Button();
            label1 = new Label();
            panel1 = new Panel();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            btnReserve = new Button();
            btnClear = new Button();
            txtNights = new TextBox();
            label19 = new Label();
            label18 = new Label();
            txtReservationId = new TextBox();
            cmbStatus = new ComboBox();
            txtSelectedRoom = new TextBox();
            panel2 = new Panel();
            dgvAvailableRooms = new DataGridView();
            btnCheckAvailability = new Button();
            cmbRoomType = new ComboBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            btnAddNewGuest = new Button();
            btnSearchGuest = new Button();
            txtGuestName = new TextBox();
            txtGuestId = new TextBox();
            txtSearchGuest = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblUser = new Label();
            btnLogout = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableRooms).BeginInit();
            SuspendLayout();
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.OliveDrab;
            btnGuests.Font = new Font("Segoe UI", 11.3F, FontStyle.Bold);
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(28, 131);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(205, 58);
            btnGuests.TabIndex = 4;
            btnGuests.Text = "Guest's Information";
            btnGuests.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.OliveDrab;
            btnReservation.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(28, 205);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(205, 56);
            btnReservation.TabIndex = 6;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnReservationStatus
            // 
            btnReservationStatus.BackColor = Color.OliveDrab;
            btnReservationStatus.Font = new Font("Segoe UI", 11.2F, FontStyle.Bold);
            btnReservationStatus.ForeColor = Color.White;
            btnReservationStatus.Location = new Point(28, 276);
            btnReservationStatus.Name = "btnReservationStatus";
            btnReservationStatus.Size = new Size(205, 53);
            btnReservationStatus.TabIndex = 7;
            btnReservationStatus.Text = "Reservation Status";
            btnReservationStatus.UseVisualStyleBackColor = false;
            // 
            // btnCheckInCheckOut
            // 
            btnCheckInCheckOut.BackColor = Color.OliveDrab;
            btnCheckInCheckOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnCheckInCheckOut.ForeColor = Color.White;
            btnCheckInCheckOut.Location = new Point(28, 335);
            btnCheckInCheckOut.Name = "btnCheckInCheckOut";
            btnCheckInCheckOut.Size = new Size(205, 49);
            btnCheckInCheckOut.TabIndex = 8;
            btnCheckInCheckOut.Text = "Check-In / Check-Out";
            btnCheckInCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnBillingPayment
            // 
            btnBillingPayment.BackColor = Color.OliveDrab;
            btnBillingPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingPayment.ForeColor = Color.White;
            btnBillingPayment.Location = new Point(28, 390);
            btnBillingPayment.Name = "btnBillingPayment";
            btnBillingPayment.Size = new Size(205, 46);
            btnBillingPayment.TabIndex = 9;
            btnBillingPayment.Text = "Billing Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(424, 44);
            label1.Name = "label1";
            label1.Size = new Size(253, 33);
            label1.TabIndex = 10;
            label1.Text = "Hotel Reservation";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dtpCheckOut);
            panel1.Controls.Add(dtpCheckIn);
            panel1.Controls.Add(btnReserve);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(txtNights);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(txtReservationId);
            panel1.Controls.Add(cmbStatus);
            panel1.Controls.Add(txtSelectedRoom);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnCheckAvailability);
            panel1.Controls.Add(cmbRoomType);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnAddNewGuest);
            panel1.Controls.Add(btnSearchGuest);
            panel1.Controls.Add(txtGuestName);
            panel1.Controls.Add(txtGuestId);
            panel1.Controls.Add(txtSearchGuest);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(255, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(874, 622);
            panel1.TabIndex = 11;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Location = new Point(513, 150);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(239, 27);
            dtpCheckOut.TabIndex = 47;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Location = new Point(147, 150);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(239, 27);
            dtpCheckIn.TabIndex = 46;
            // 
            // btnReserve
            // 
            btnReserve.ForeColor = SystemColors.ActiveCaptionText;
            btnReserve.Location = new Point(536, 574);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(87, 34);
            btnReserve.TabIndex = 45;
            btnReserve.Text = "Reserve";
            btnReserve.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.ForeColor = SystemColors.ActiveCaptionText;
            btnClear.Location = new Point(629, 574);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(87, 34);
            btnClear.TabIndex = 44;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtNights
            // 
            txtNights.Location = new Point(687, 492);
            txtNights.Name = "txtNights";
            txtNights.ReadOnly = true;
            txtNights.Size = new Size(117, 27);
            txtNights.TabIndex = 43;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = SystemColors.ActiveCaptionText;
            label19.Location = new Point(294, 495);
            label19.Name = "label19";
            label19.Size = new Size(105, 20);
            label19.TabIndex = 42;
            label19.Text = "Reservation ID";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = SystemColors.ActiveCaptionText;
            label18.Location = new Point(553, 495);
            label18.Name = "label18";
            label18.Size = new Size(128, 20);
            label18.TabIndex = 41;
            label18.Text = "Number of Nights";
            // 
            // txtReservationId
            // 
            txtReservationId.Location = new Point(405, 492);
            txtReservationId.Name = "txtReservationId";
            txtReservationId.ReadOnly = true;
            txtReservationId.Size = new Size(128, 27);
            txtReservationId.TabIndex = 36;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(148, 541);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(128, 28);
            cmbStatus.TabIndex = 35;
            // 
            // txtSelectedRoom
            // 
            txtSelectedRoom.Location = new Point(148, 492);
            txtSelectedRoom.Name = "txtSelectedRoom";
            txtSelectedRoom.Size = new Size(128, 27);
            txtSelectedRoom.TabIndex = 34;
            // 
            // panel2
            // 
            panel2.BackColor = Color.OliveDrab;
            panel2.Controls.Add(dgvAvailableRooms);
            panel2.Location = new Point(16, 280);
            panel2.Name = "panel2";
            panel2.Size = new Size(769, 167);
            panel2.TabIndex = 33;
            // 
            // dgvAvailableRooms
            // 
            dgvAvailableRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvAvailableRooms.DefaultCellStyle = dataGridViewCellStyle1;
            dgvAvailableRooms.Location = new Point(3, 3);
            dgvAvailableRooms.Name = "dgvAvailableRooms";
            dgvAvailableRooms.RowHeadersVisible = false;
            dgvAvailableRooms.RowHeadersWidth = 51;
            dgvAvailableRooms.Size = new Size(763, 161);
            dgvAvailableRooms.TabIndex = 0;
            // 
            // btnCheckAvailability
            // 
            btnCheckAvailability.ForeColor = SystemColors.ActiveCaptionText;
            btnCheckAvailability.Location = new Point(294, 182);
            btnCheckAvailability.Name = "btnCheckAvailability";
            btnCheckAvailability.Size = new Size(162, 34);
            btnCheckAvailability.TabIndex = 32;
            btnCheckAvailability.Text = "Check Availability";
            btnCheckAvailability.UseVisualStyleBackColor = true;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(147, 184);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(128, 28);
            cmbRoomType.TabIndex = 31;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = SystemColors.ActiveCaptionText;
            label13.Location = new Point(392, 157);
            label13.Name = "label13";
            label13.Size = new Size(115, 20);
            label13.TabIndex = 29;
            label13.Text = "Check-out Date:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(54, 189);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 28;
            label12.Text = "Room Type:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(93, 544);
            label11.Name = "label11";
            label11.Size = new Size(49, 20);
            label11.TabIndex = 27;
            label11.Text = "Status";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(32, 495);
            label10.Name = "label10";
            label10.Size = new Size(110, 20);
            label10.TabIndex = 26;
            label10.Text = "Selected Room";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(19, 257);
            label9.Name = "label9";
            label9.Size = new Size(143, 23);
            label9.TabIndex = 25;
            label9.Text = "Available Rooms";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(19, 460);
            label8.Name = "label8";
            label8.Size = new Size(164, 23);
            label8.TabIndex = 24;
            label8.Text = "Reservation Details";
            // 
            // btnAddNewGuest
            // 
            btnAddNewGuest.ForeColor = SystemColors.ActiveCaptionText;
            btnAddNewGuest.Location = new Point(13, 82);
            btnAddNewGuest.Name = "btnAddNewGuest";
            btnAddNewGuest.Size = new Size(162, 34);
            btnAddNewGuest.TabIndex = 22;
            btnAddNewGuest.Text = "Add New Guest";
            btnAddNewGuest.UseVisualStyleBackColor = true;
            // 
            // btnSearchGuest
            // 
            btnSearchGuest.ForeColor = SystemColors.ActiveCaptionText;
            btnSearchGuest.Location = new Point(337, 34);
            btnSearchGuest.Name = "btnSearchGuest";
            btnSearchGuest.Size = new Size(87, 34);
            btnSearchGuest.TabIndex = 21;
            btnSearchGuest.Text = "Search";
            btnSearchGuest.UseVisualStyleBackColor = true;
            // 
            // txtGuestName
            // 
            txtGuestName.Location = new Point(578, 70);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(184, 27);
            txtGuestName.TabIndex = 20;
            // 
            // txtGuestId
            // 
            txtGuestId.Location = new Point(578, 34);
            txtGuestId.Name = "txtGuestId";
            txtGuestId.Size = new Size(184, 27);
            txtGuestId.TabIndex = 19;
            // 
            // txtSearchGuest
            // 
            txtSearchGuest.Location = new Point(135, 38);
            txtSearchGuest.Name = "txtSearchGuest";
            txtSearchGuest.Size = new Size(184, 27);
            txtSearchGuest.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(13, 41);
            label7.Name = "label7";
            label7.Size = new Size(97, 20);
            label7.TabIndex = 17;
            label7.Text = "Search Guest:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(489, 41);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 16;
            label6.Text = "Guest ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(464, 73);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 15;
            label5.Text = "Guest Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(28, 130);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 14;
            label4.Text = "Room Selection";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(43, 157);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 13;
            label3.Text = "Check-in Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(184, 20);
            label2.TabIndex = 12;
            label2.Text = "Guest Information Section:";
            label2.Click += label2_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(12, 11);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(92, 28);
            lblUser.TabIndex = 12;
            lblUser.Text = "< user >";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.OliveDrab;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(882, 28);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(205, 58);
            btnLogout.TabIndex = 13;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1099, 733);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnBillingPayment);
            Controls.Add(btnCheckInCheckOut);
            Controls.Add(btnReservationStatus);
            Controls.Add(btnReservation);
            Controls.Add(btnGuests);
            Name = "Reservation";
            Text = "Reservation";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvailableRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuests;
        private Button btnReservation;
        private Button btnReservationStatus;
        private Button btnCheckInCheckOut;
        private Button btnBillingPayment;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtSearchGuest;
        private TextBox txtGuestName;
        private TextBox txtGuestId;
        private Button btnSearchGuest;
        private Button btnAddNewGuest;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button btnCheckAvailability;
        private ComboBox cmbRoomType;
        private Panel panel2;
        private DataGridView dgvAvailableRooms;
        private Label label19;
        private Label label18;
        private TextBox txtReservationId;
        private ComboBox cmbStatus;
        private TextBox txtSelectedRoom;
        private Button btnReserve;
        private Button btnClear;
        private TextBox txtNights;
        private Label lblUser;
        private Button btnLogout;
        private DateTimePicker dtpCheckOut;
        private DateTimePicker dtpCheckIn;
    }
}