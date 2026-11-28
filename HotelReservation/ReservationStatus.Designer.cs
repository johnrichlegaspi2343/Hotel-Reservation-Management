namespace HotelReservation
{
    partial class ReservationStatus
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnLogout = new Button();
            btnGoCheckInOut = new Button();
            btnGoBilling = new Button();
            panel1 = new Panel();
            btnCancelReservation = new Button();
            grpDetails = new GroupBox();
            lstHistory = new ListBox();
            label2 = new Label();
            lblCancelRule = new Label();
            lblDetBalance = new Label();
            lblDetPaid = new Label();
            lblDetTotal = new Label();
            lblDetGuests = new Label();
            lblDetDates = new Label();
            lblDetRooms = new Label();
            lblDetValidId = new Label();
            lblDetGuest = new Label();
            btnAll = new Button();
            btnPendingPayment = new Button();
            btnInHouse = new Button();
            btnDepartures = new Button();
            btnArrivals = new Button();
            panel3 = new Panel();
            dgvReservations = new DataGridView();
            lblShowing = new Label();
            btnSearch = new Button();
            txtSearchReservationId = new TextBox();
            label1 = new Label();
            btnCheckInCheckOut = new Button();
            btnReservationStatus = new Button();
            btnReservation = new Button();
            btnBillingPayment = new Button();
            btnGuests = new Button();
            panel1.SuspendLayout();
            grpDetails.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.OliveDrab;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1657, 151);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(205, 48);
            btnLogout.TabIndex = 22;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnGoCheckInOut
            // 
            btnGoCheckInOut.BackColor = Color.OliveDrab;
            btnGoCheckInOut.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnGoCheckInOut.ForeColor = Color.White;
            btnGoCheckInOut.Location = new Point(901, 746);
            btnGoCheckInOut.Name = "btnGoCheckInOut";
            btnGoCheckInOut.Size = new Size(198, 42);
            btnGoCheckInOut.TabIndex = 45;
            btnGoCheckInOut.Text = "Go to Check In/Check Out";
            btnGoCheckInOut.UseVisualStyleBackColor = false;
            // 
            // btnGoBilling
            // 
            btnGoBilling.BackColor = Color.OliveDrab;
            btnGoBilling.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGoBilling.ForeColor = Color.White;
            btnGoBilling.Location = new Point(697, 746);
            btnGoBilling.Name = "btnGoBilling";
            btnGoBilling.Size = new Size(198, 42);
            btnGoBilling.TabIndex = 44;
            btnGoBilling.Text = "Go to Biling Payment";
            btnGoBilling.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnCancelReservation);
            panel1.Controls.Add(grpDetails);
            panel1.Controls.Add(btnAll);
            panel1.Controls.Add(btnPendingPayment);
            panel1.Controls.Add(btnInHouse);
            panel1.Controls.Add(btnDepartures);
            panel1.Controls.Add(btnArrivals);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(lblShowing);
            panel1.Controls.Add(btnGoCheckInOut);
            panel1.Controls.Add(btnGoBilling);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearchReservationId);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(543, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 800);
            panel1.TabIndex = 20;
            // 
            // btnCancelReservation
            // 
            btnCancelReservation.BackColor = Color.Red;
            btnCancelReservation.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancelReservation.ForeColor = Color.White;
            btnCancelReservation.Location = new Point(1102, 746);
            btnCancelReservation.Name = "btnCancelReservation";
            btnCancelReservation.Size = new Size(198, 42);
            btnCancelReservation.TabIndex = 57;
            btnCancelReservation.Text = "Cancel Reservation";
            btnCancelReservation.UseVisualStyleBackColor = false;
            // 
            // grpDetails
            // 
            grpDetails.BackColor = Color.OliveDrab;
            grpDetails.Controls.Add(lstHistory);
            grpDetails.Controls.Add(label2);
            grpDetails.Controls.Add(lblCancelRule);
            grpDetails.Controls.Add(lblDetBalance);
            grpDetails.Controls.Add(lblDetPaid);
            grpDetails.Controls.Add(lblDetTotal);
            grpDetails.Controls.Add(lblDetGuests);
            grpDetails.Controls.Add(lblDetDates);
            grpDetails.Controls.Add(lblDetRooms);
            grpDetails.Controls.Add(lblDetValidId);
            grpDetails.Controls.Add(lblDetGuest);
            grpDetails.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDetails.ForeColor = Color.White;
            grpDetails.Location = new Point(901, 177);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(396, 563);
            grpDetails.TabIndex = 56;
            grpDetails.TabStop = false;
            grpDetails.Text = "Reservation Details";
            // 
            // lstHistory
            // 
            lstHistory.BorderStyle = BorderStyle.FixedSingle;
            lstHistory.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lstHistory.FormattingEnabled = true;
            lstHistory.HorizontalScrollbar = true;
            lstHistory.Location = new Point(15, 406);
            lstHistory.Name = "lstHistory";
            lstHistory.Size = new Size(366, 77);
            lstHistory.TabIndex = 10;
            // 
            // label2
            // 
            label2.Location = new Point(15, 374);
            label2.Name = "label2";
            label2.Size = new Size(366, 34);
            label2.TabIndex = 9;
            label2.Text = "Payments and Charges:";
            // 
            // lblCancelRule
            // 
            lblCancelRule.Location = new Point(15, 515);
            lblCancelRule.Name = "lblCancelRule";
            lblCancelRule.Size = new Size(366, 34);
            lblCancelRule.TabIndex = 8;
            // 
            // lblDetBalance
            // 
            lblDetBalance.Location = new Point(15, 334);
            lblDetBalance.Name = "lblDetBalance";
            lblDetBalance.Size = new Size(366, 30);
            lblDetBalance.TabIndex = 7;
            // 
            // lblDetPaid
            // 
            lblDetPaid.Location = new Point(15, 300);
            lblDetPaid.Name = "lblDetPaid";
            lblDetPaid.Size = new Size(366, 30);
            lblDetPaid.TabIndex = 6;
            // 
            // lblDetTotal
            // 
            lblDetTotal.Location = new Point(15, 266);
            lblDetTotal.Name = "lblDetTotal";
            lblDetTotal.Size = new Size(366, 30);
            lblDetTotal.TabIndex = 5;
            // 
            // lblDetGuests
            // 
            lblDetGuests.Location = new Point(15, 228);
            lblDetGuests.Name = "lblDetGuests";
            lblDetGuests.Size = new Size(366, 30);
            lblDetGuests.TabIndex = 4;
            // 
            // lblDetDates
            // 
            lblDetDates.Location = new Point(15, 168);
            lblDetDates.Name = "lblDetDates";
            lblDetDates.Size = new Size(366, 30);
            lblDetDates.TabIndex = 3;
            // 
            // lblDetRooms
            // 
            lblDetRooms.Location = new Point(15, 108);
            lblDetRooms.Name = "lblDetRooms";
            lblDetRooms.Size = new Size(366, 30);
            lblDetRooms.TabIndex = 2;
            // 
            // lblDetValidId
            // 
            lblDetValidId.Location = new Point(15, 74);
            lblDetValidId.Name = "lblDetValidId";
            lblDetValidId.Size = new Size(366, 30);
            lblDetValidId.TabIndex = 1;
            // 
            // lblDetGuest
            // 
            lblDetGuest.Location = new Point(15, 40);
            lblDetGuest.Name = "lblDetGuest";
            lblDetGuest.Size = new Size(366, 30);
            lblDetGuest.TabIndex = 0;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.OliveDrab;
            btnAll.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAll.ForeColor = Color.White;
            btnAll.Location = new Point(882, 52);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(210, 57);
            btnAll.TabIndex = 55;
            btnAll.Text = "All";
            btnAll.UseVisualStyleBackColor = false;
            // 
            // btnPendingPayment
            // 
            btnPendingPayment.BackColor = Color.OliveDrab;
            btnPendingPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPendingPayment.ForeColor = Color.White;
            btnPendingPayment.Location = new Point(666, 52);
            btnPendingPayment.Name = "btnPendingPayment";
            btnPendingPayment.Size = new Size(210, 57);
            btnPendingPayment.TabIndex = 54;
            btnPendingPayment.Text = "Pending Payment";
            btnPendingPayment.UseVisualStyleBackColor = false;
            // 
            // btnInHouse
            // 
            btnInHouse.BackColor = Color.OliveDrab;
            btnInHouse.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInHouse.ForeColor = Color.White;
            btnInHouse.Location = new Point(450, 52);
            btnInHouse.Name = "btnInHouse";
            btnInHouse.Size = new Size(210, 57);
            btnInHouse.TabIndex = 53;
            btnInHouse.Text = "In - House";
            btnInHouse.UseVisualStyleBackColor = false;
            // 
            // btnDepartures
            // 
            btnDepartures.BackColor = Color.OliveDrab;
            btnDepartures.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDepartures.ForeColor = Color.White;
            btnDepartures.Location = new Point(234, 52);
            btnDepartures.Name = "btnDepartures";
            btnDepartures.Size = new Size(210, 57);
            btnDepartures.TabIndex = 51;
            btnDepartures.Text = "Today's Departures";
            btnDepartures.UseVisualStyleBackColor = false;
            // 
            // btnArrivals
            // 
            btnArrivals.BackColor = Color.OliveDrab;
            btnArrivals.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnArrivals.ForeColor = Color.White;
            btnArrivals.Location = new Point(18, 52);
            btnArrivals.Name = "btnArrivals";
            btnArrivals.Size = new Size(210, 57);
            btnArrivals.TabIndex = 50;
            btnArrivals.Text = "Today's Arrivals";
            btnArrivals.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.OliveDrab;
            panel3.Controls.Add(dgvReservations);
            panel3.Location = new Point(18, 175);
            panel3.Name = "panel3";
            panel3.Size = new Size(861, 565);
            panel3.TabIndex = 47;
            // 
            // dgvReservations
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReservations.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReservations.Location = new Point(3, 3);
            dgvReservations.Name = "dgvReservations";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvReservations.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.Size = new Size(855, 559);
            dgvReservations.TabIndex = 0;
            // 
            // lblShowing
            // 
            lblShowing.AutoSize = true;
            lblShowing.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowing.ForeColor = Color.Black;
            lblShowing.Location = new Point(18, 131);
            lblShowing.Name = "lblShowing";
            lblShowing.Size = new Size(96, 28);
            lblShowing.TabIndex = 48;
            lblShowing.Text = "Showing:";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.OliveDrab;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1155, 131);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(127, 30);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchReservationId
            // 
            txtSearchReservationId.Font = new Font("Segoe UI", 10F);
            txtSearchReservationId.Location = new Point(912, 131);
            txtSearchReservationId.Name = "txtSearchReservationId";
            txtSearchReservationId.Size = new Size(237, 30);
            txtSearchReservationId.TabIndex = 18;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1902, 100);
            label1.TabIndex = 19;
            label1.Text = "Hotel Reservation";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCheckInCheckOut
            // 
            btnCheckInCheckOut.BackColor = Color.OliveDrab;
            btnCheckInCheckOut.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCheckInCheckOut.ForeColor = Color.White;
            btnCheckInCheckOut.Location = new Point(79, 549);
            btnCheckInCheckOut.Name = "btnCheckInCheckOut";
            btnCheckInCheckOut.Size = new Size(364, 82);
            btnCheckInCheckOut.TabIndex = 17;
            btnCheckInCheckOut.Text = "Check-In / Check-Out";
            btnCheckInCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnReservationStatus
            // 
            btnReservationStatus.BackColor = Color.DarkOliveGreen;
            btnReservationStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnReservationStatus.ForeColor = Color.White;
            btnReservationStatus.Location = new Point(79, 434);
            btnReservationStatus.Name = "btnReservationStatus";
            btnReservationStatus.Size = new Size(364, 82);
            btnReservationStatus.TabIndex = 16;
            btnReservationStatus.Text = "Manage Reservation";
            btnReservationStatus.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.OliveDrab;
            btnReservation.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(79, 312);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(364, 82);
            btnReservation.TabIndex = 15;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnBillingPayment
            // 
            btnBillingPayment.BackColor = Color.OliveDrab;
            btnBillingPayment.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnBillingPayment.ForeColor = Color.White;
            btnBillingPayment.Location = new Point(79, 660);
            btnBillingPayment.Name = "btnBillingPayment";
            btnBillingPayment.Size = new Size(364, 82);
            btnBillingPayment.TabIndex = 18;
            btnBillingPayment.Text = "Billing Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.OliveDrab;
            btnGuests.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(79, 208);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(364, 82);
            btnGuests.TabIndex = 14;
            btnGuests.Text = "Guest's Information";
            btnGuests.UseVisualStyleBackColor = false;
            // 
            // ReservationStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnLogout);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnCheckInCheckOut);
            Controls.Add(btnReservationStatus);
            Controls.Add(btnReservation);
            Controls.Add(btnBillingPayment);
            Controls.Add(btnGuests);
            Name = "ReservationStatus";
            Text = "Manage Reservation";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpDetails.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogout;
        private Button btnGoCheckInOut;
        private Button btnGoBilling;
        private Panel panel1;
        private Button btnSearch;
        private TextBox txtSearchReservationId;
        private Label label1;
        private Button btnCheckInCheckOut;
        private Button btnReservationStatus;
        private Button btnReservation;
        private Button btnBillingPayment;
        private Button btnGuests;
        private Panel panel3;
        private Label lblShowing;
        private DataGridView dgvReservations;
        private Button btnDepartures;
        private Button btnArrivals;
        private Button btnAll;
        private Button btnPendingPayment;
        private Button btnInHouse;
        private GroupBox grpDetails;
        private Button btnCancelReservation;
        private Label lblCancelRule;
        private Label lblDetBalance;
        private Label lblDetPaid;
        private Label lblDetTotal;
        private Label lblDetGuests;
        private Label lblDetDates;
        private Label lblDetRooms;
        private Label lblDetValidId;
        private Label lblDetGuest;
        private Label label2;
        private ListBox lstHistory;
    }
}