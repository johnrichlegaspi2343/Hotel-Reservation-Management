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
            btnGuests = new Button();
            btnReservation = new Button();
            btnReservationStatus = new Button();
            btnCheckInCheckOut = new Button();
            btnBillingPayment = new Button();
            label1 = new Label();
            panel1 = new Panel();
            lblDownpayment = new Label();
            lblCapacity = new Label();
            lblTotalAmount = new Label();
            lblTotalRooms = new Label();
            dgvSelectedRooms = new DataGridView();
            btnRemoveRoom = new Button();
            txtValidId = new TextBox();
            label8 = new Label();
            cmbBeds = new ComboBox();
            btnAddAnotherRoom = new Button();
            btnFindRoom = new Button();
            lblHotelTime = new Label();
            label15 = new Label();
            nudGuests = new NumericUpDown();
            label14 = new Label();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            btnProceed = new Button();
            btnClear = new Button();
            txtNights = new TextBox();
            label19 = new Label();
            label18 = new Label();
            txtReservationId = new TextBox();
            cmbRoomType = new ComboBox();
            label13 = new Label();
            label12 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dgvSelectedRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGuests).BeginInit();
            SuspendLayout();
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.OliveDrab;
            btnGuests.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(79, 208);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(364, 82);
            btnGuests.TabIndex = 4;
            btnGuests.Text = "Guest's Information";
            btnGuests.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.DarkOliveGreen;
            btnReservation.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(79, 312);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(364, 82);
            btnReservation.TabIndex = 6;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnReservationStatus
            // 
            btnReservationStatus.BackColor = Color.OliveDrab;
            btnReservationStatus.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnReservationStatus.ForeColor = Color.White;
            btnReservationStatus.Location = new Point(79, 434);
            btnReservationStatus.Name = "btnReservationStatus";
            btnReservationStatus.Size = new Size(364, 82);
            btnReservationStatus.TabIndex = 7;
            btnReservationStatus.Text = "Reservation Status";
            btnReservationStatus.UseVisualStyleBackColor = false;
            // 
            // btnCheckInCheckOut
            // 
            btnCheckInCheckOut.BackColor = Color.OliveDrab;
            btnCheckInCheckOut.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnCheckInCheckOut.ForeColor = Color.White;
            btnCheckInCheckOut.Location = new Point(79, 549);
            btnCheckInCheckOut.Name = "btnCheckInCheckOut";
            btnCheckInCheckOut.Size = new Size(364, 82);
            btnCheckInCheckOut.TabIndex = 8;
            btnCheckInCheckOut.Text = "Check-In / Check-Out";
            btnCheckInCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnBillingPayment
            // 
            btnBillingPayment.BackColor = Color.OliveDrab;
            btnBillingPayment.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnBillingPayment.ForeColor = Color.White;
            btnBillingPayment.Location = new Point(79, 660);
            btnBillingPayment.Name = "btnBillingPayment";
            btnBillingPayment.Size = new Size(364, 82);
            btnBillingPayment.TabIndex = 9;
            btnBillingPayment.Text = "Billing Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(823, 35);
            label1.Name = "label1";
            label1.Size = new Size(398, 60);
            label1.TabIndex = 10;
            label1.Text = "Hotel Reservation";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblDownpayment);
            panel1.Controls.Add(lblCapacity);
            panel1.Controls.Add(lblTotalAmount);
            panel1.Controls.Add(lblTotalRooms);
            panel1.Controls.Add(dgvSelectedRooms);
            panel1.Controls.Add(btnRemoveRoom);
            panel1.Controls.Add(txtValidId);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(cmbBeds);
            panel1.Controls.Add(btnAddAnotherRoom);
            panel1.Controls.Add(btnFindRoom);
            panel1.Controls.Add(lblHotelTime);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(nudGuests);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(dtpCheckOut);
            panel1.Controls.Add(dtpCheckIn);
            panel1.Controls.Add(btnProceed);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(txtNights);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(txtReservationId);
            panel1.Controls.Add(cmbRoomType);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
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
            panel1.Location = new Point(543, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 800);
            panel1.TabIndex = 11;
            // 
            // lblDownpayment
            // 
            lblDownpayment.AutoSize = true;
            lblDownpayment.Font = new Font("Microsoft Sans Serif", 16.2F);
            lblDownpayment.ForeColor = SystemColors.ActiveCaptionText;
            lblDownpayment.Location = new Point(360, 690);
            lblDownpayment.Name = "lblDownpayment";
            lblDownpayment.Size = new Size(295, 32);
            lblDownpayment.TabIndex = 63;
            lblDownpayment.Text = "Down Payment (50%):";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Microsoft Sans Serif", 16.2F);
            lblCapacity.ForeColor = SystemColors.ActiveCaptionText;
            lblCapacity.Location = new Point(260, 652);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(133, 32);
            lblCapacity.TabIndex = 62;
            lblCapacity.Text = "Capacity:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Microsoft Sans Serif", 16.2F);
            lblTotalAmount.ForeColor = SystemColors.ActiveCaptionText;
            lblTotalAmount.Location = new Point(35, 690);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(86, 32);
            lblTotalAmount.TabIndex = 61;
            lblTotalAmount.Text = "Total:";
            // 
            // lblTotalRooms
            // 
            lblTotalRooms.AutoSize = true;
            lblTotalRooms.Font = new Font("Microsoft Sans Serif", 16.2F);
            lblTotalRooms.ForeColor = SystemColors.ActiveCaptionText;
            lblTotalRooms.Location = new Point(35, 652);
            lblTotalRooms.Name = "lblTotalRooms";
            lblTotalRooms.Size = new Size(158, 32);
            lblTotalRooms.TabIndex = 60;
            lblTotalRooms.Text = "Rooms: 0/5";
            // 
            // dgvSelectedRooms
            // 
            dgvSelectedRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedRooms.Location = new Point(35, 470);
            dgvSelectedRooms.Name = "dgvSelectedRooms";
            dgvSelectedRooms.RowHeadersWidth = 51;
            dgvSelectedRooms.Size = new Size(1240, 170);
            dgvSelectedRooms.TabIndex = 59;
            // 
            // btnRemoveRoom
            // 
            btnRemoveRoom.BackColor = Color.OliveDrab;
            btnRemoveRoom.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveRoom.ForeColor = Color.White;
            btnRemoveRoom.Location = new Point(577, 405);
            btnRemoveRoom.Name = "btnRemoveRoom";
            btnRemoveRoom.Size = new Size(232, 50);
            btnRemoveRoom.TabIndex = 58;
            btnRemoveRoom.Text = "Remove Room";
            btnRemoveRoom.UseVisualStyleBackColor = false;
            // 
            // txtValidId
            // 
            txtValidId.Font = new Font("Segoe UI", 16.2F);
            txtValidId.Location = new Point(938, 185);
            txtValidId.Name = "txtValidId";
            txtValidId.Size = new Size(360, 43);
            txtValidId.TabIndex = 57;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(812, 190);
            label8.Name = "label8";
            label8.Size = new Size(117, 38);
            label8.TabIndex = 56;
            label8.Text = "Valid ID:";
            // 
            // cmbBeds
            // 
            cmbBeds.Font = new Font("Microsoft Sans Serif", 16.2F);
            cmbBeds.FormattingEnabled = true;
            cmbBeds.Location = new Point(925, 345);
            cmbBeds.Name = "cmbBeds";
            cmbBeds.Size = new Size(120, 39);
            cmbBeds.TabIndex = 55;
            // 
            // btnAddAnotherRoom
            // 
            btnAddAnotherRoom.BackColor = Color.OliveDrab;
            btnAddAnotherRoom.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddAnotherRoom.ForeColor = Color.White;
            btnAddAnotherRoom.Location = new Point(282, 405);
            btnAddAnotherRoom.Name = "btnAddAnotherRoom";
            btnAddAnotherRoom.Size = new Size(280, 50);
            btnAddAnotherRoom.TabIndex = 54;
            btnAddAnotherRoom.Text = "Add another Room";
            btnAddAnotherRoom.UseVisualStyleBackColor = false;
            // 
            // btnFindRoom
            // 
            btnFindRoom.BackColor = Color.OliveDrab;
            btnFindRoom.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFindRoom.ForeColor = Color.White;
            btnFindRoom.Location = new Point(35, 405);
            btnFindRoom.Name = "btnFindRoom";
            btnFindRoom.Size = new Size(232, 50);
            btnFindRoom.TabIndex = 53;
            btnFindRoom.Text = "Find Room";
            btnFindRoom.UseVisualStyleBackColor = false;
            // 
            // lblHotelTime
            // 
            lblHotelTime.AutoSize = true;
            lblHotelTime.Font = new Font("Microsoft Sans Serif", 16.2F);
            lblHotelTime.ForeColor = SystemColors.ActiveCaptionText;
            lblHotelTime.Location = new Point(723, 240);
            lblHotelTime.Name = "lblHotelTime";
            lblHotelTime.Size = new Size(496, 32);
            lblHotelTime.TabIndex = 52;
            lblHotelTime.Text = "Time-in: 2:00 PM | Time-out: 12:00 NN";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 16.2F);
            label15.ForeColor = SystemColors.ActiveCaptionText;
            label15.Location = new Point(840, 350);
            label15.Name = "label15";
            label15.Size = new Size(87, 32);
            label15.TabIndex = 50;
            label15.Text = "Beds:";
            // 
            // nudGuests
            // 
            nudGuests.Font = new Font("Microsoft Sans Serif", 16.2F);
            nudGuests.Location = new Point(264, 348);
            nudGuests.Name = "nudGuests";
            nudGuests.Size = new Size(129, 38);
            nudGuests.TabIndex = 49;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 16.2F);
            label14.ForeColor = SystemColors.ActiveCaptionText;
            label14.Location = new Point(22, 350);
            label14.Name = "label14";
            label14.Size = new Size(236, 32);
            label14.TabIndex = 48;
            label14.Text = "Number of Guest:";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckOut.Location = new Point(868, 291);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(327, 34);
            dtpCheckOut.TabIndex = 47;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckIn.Location = new Point(245, 289);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(332, 34);
            dtpCheckIn.TabIndex = 46;
            // 
            // btnProceed
            // 
            btnProceed.BackColor = Color.OliveDrab;
            btnProceed.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProceed.ForeColor = Color.White;
            btnProceed.Location = new Point(900, 728);
            btnProceed.Name = "btnProceed";
            btnProceed.Size = new Size(171, 49);
            btnProceed.TabIndex = 45;
            btnProceed.Text = "Proceed";
            btnProceed.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.OliveDrab;
            btnClear.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(1108, 728);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(162, 49);
            btnClear.TabIndex = 44;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // txtNights
            // 
            txtNights.Font = new Font("Microsoft Sans Serif", 16.2F);
            txtNights.Location = new Point(680, 730);
            txtNights.Name = "txtNights";
            txtNights.ReadOnly = true;
            txtNights.Size = new Size(100, 38);
            txtNights.TabIndex = 43;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 16.2F);
            label19.ForeColor = SystemColors.ActiveCaptionText;
            label19.Location = new Point(35, 735);
            label19.Name = "label19";
            label19.Size = new Size(200, 32);
            label19.TabIndex = 42;
            label19.Text = "Reservation ID";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 16.2F);
            label18.ForeColor = SystemColors.ActiveCaptionText;
            label18.Location = new Point(440, 735);
            label18.Name = "label18";
            label18.Size = new Size(233, 32);
            label18.TabIndex = 41;
            label18.Text = "Number of Nights";
            // 
            // txtReservationId
            // 
            txtReservationId.Font = new Font("Microsoft Sans Serif", 16.2F);
            txtReservationId.Location = new Point(240, 730);
            txtReservationId.Name = "txtReservationId";
            txtReservationId.ReadOnly = true;
            txtReservationId.Size = new Size(178, 38);
            txtReservationId.TabIndex = 36;
            // 
            // cmbRoomType
            // 
            cmbRoomType.Font = new Font("Microsoft Sans Serif", 16.2F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(610, 345);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(200, 39);
            cmbRoomType.TabIndex = 31;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 16.2F);
            label13.ForeColor = SystemColors.ActiveCaptionText;
            label13.Location = new Point(656, 287);
            label13.Name = "label13";
            label13.Size = new Size(216, 38);
            label13.TabIndex = 29;
            label13.Text = "Check-out Date:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 16.2F);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(440, 350);
            label12.Name = "label12";
            label12.Size = new Size(167, 32);
            label12.TabIndex = 28;
            label12.Text = "Room Type:";
            // 
            // btnAddNewGuest
            // 
            btnAddNewGuest.BackColor = Color.OliveDrab;
            btnAddNewGuest.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNewGuest.ForeColor = Color.White;
            btnAddNewGuest.Location = new Point(35, 130);
            btnAddNewGuest.Name = "btnAddNewGuest";
            btnAddNewGuest.Size = new Size(232, 55);
            btnAddNewGuest.TabIndex = 22;
            btnAddNewGuest.Text = "Add New Guest";
            btnAddNewGuest.UseVisualStyleBackColor = false;
            // 
            // btnSearchGuest
            // 
            btnSearchGuest.BackColor = Color.OliveDrab;
            btnSearchGuest.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchGuest.ForeColor = Color.White;
            btnSearchGuest.Location = new Point(428, 50);
            btnSearchGuest.Name = "btnSearchGuest";
            btnSearchGuest.Size = new Size(139, 45);
            btnSearchGuest.TabIndex = 21;
            btnSearchGuest.Text = "Search";
            btnSearchGuest.UseVisualStyleBackColor = false;
            // 
            // txtGuestName
            // 
            txtGuestName.Font = new Font("Segoe UI", 16.2F);
            txtGuestName.Location = new Point(938, 136);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(360, 43);
            txtGuestName.TabIndex = 20;
            // 
            // txtGuestId
            // 
            txtGuestId.Font = new Font("Segoe UI", 16.2F);
            txtGuestId.Location = new Point(938, 87);
            txtGuestId.Name = "txtGuestId";
            txtGuestId.Size = new Size(184, 43);
            txtGuestId.TabIndex = 19;
            // 
            // txtSearchGuest
            // 
            txtSearchGuest.Font = new Font("Segoe UI", 16.2F);
            txtSearchGuest.Location = new Point(226, 52);
            txtSearchGuest.Name = "txtSearchGuest";
            txtSearchGuest.Size = new Size(184, 43);
            txtSearchGuest.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(35, 57);
            label7.Name = "label7";
            label7.Size = new Size(185, 38);
            label7.TabIndex = 17;
            label7.Text = "Search Guest:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(788, 92);
            label6.Name = "label6";
            label6.Size = new Size(129, 38);
            label6.TabIndex = 16;
            label6.Text = "Guest ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(751, 139);
            label5.Name = "label5";
            label5.Size = new Size(176, 38);
            label5.TabIndex = 15;
            label5.Text = "Guest Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(28, 230);
            label4.Name = "label4";
            label4.Size = new Size(269, 46);
            label4.TabIndex = 14;
            label4.Text = "Room Selection";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(41, 287);
            label3.Name = "label3";
            label3.Size = new Size(198, 38);
            label3.TabIndex = 13;
            label3.Text = "Check-in Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(35, 3);
            label2.Name = "label2";
            label2.Size = new Size(345, 38);
            label2.TabIndex = 12;
            label2.Text = "Guest Information Section:";
            label2.Click += label2_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(1540, 128);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(128, 38);
            lblUser.TabIndex = 12;
            lblUser.Text = "< user >";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.OliveDrab;
            btnLogout.Location = new Point(1688, 122);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(148, 49);
            btnLogout.TabIndex = 13;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1902, 1033);
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
            ((System.ComponentModel.ISupportInitialize)dgvSelectedRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGuests).EndInit();
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
        private ComboBox cmbRoomType;
        private Label label19;
        private Label label18;
        private TextBox txtReservationId;
        private Button btnProceed;
        private Button btnClear;
        private TextBox txtNights;
        private Label lblUser;
        private Button btnLogout;
        private DateTimePicker dtpCheckOut;
        private DateTimePicker dtpCheckIn;
        private NumericUpDown nudGuests;
        private Label label14;
        private Label label15;
        private Label lblHotelTime;
        private Button btnFindRoom;
        private TextBox txtValidId;
        private Label label8;
        private ComboBox cmbBeds;
        private Button btnAddAnotherRoom;
        private Label lblTotalAmount;
        private Label lblTotalRooms;
        private DataGridView dgvSelectedRooms;
        private Button btnRemoveRoom;
        private Label lblDownpayment;
        private Label lblCapacity;
    }
}