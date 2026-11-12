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
            btnLogout = new Button();
            lblUser = new Label();
            btnReserve = new Button();
            btnClear = new Button();
            panel1 = new Panel();
            txtCheckOut = new TextBox();
            panel3 = new Panel();
            dgvReservations = new DataGridView();
            txtRoom = new TextBox();
            label10 = new Label();
            btnUpdateStatus = new Button();
            label2 = new Label();
            cmbNewStatus = new ComboBox();
            txtCurrentStatus = new TextBox();
            txtCheckIn = new TextBox();
            txtGuest = new TextBox();
            label9 = new Label();
            btnSearch = new Button();
            label8 = new Label();
            txtSearchReservationId = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnCheckInCheckOut = new Button();
            btnReservationStatus = new Button();
            btnReservation = new Button();
            btnBillingPayment = new Button();
            btnGuests = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.OliveDrab;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(904, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(205, 48);
            btnLogout.TabIndex = 22;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(808, 23);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(92, 28);
            lblUser.TabIndex = 21;
            lblUser.Text = "< user >";
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
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtCheckOut);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(txtRoom);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnUpdateStatus);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbNewStatus);
            panel1.Controls.Add(txtCurrentStatus);
            panel1.Controls.Add(btnReserve);
            panel1.Controls.Add(txtCheckIn);
            panel1.Controls.Add(txtGuest);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtSearchReservationId);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(244, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(866, 565);
            panel1.TabIndex = 20;
            // 
            // txtCheckOut
            // 
            txtCheckOut.BackColor = Color.White;
            txtCheckOut.Location = new Point(446, 181);
            txtCheckOut.Name = "txtCheckOut";
            txtCheckOut.ReadOnly = true;
            txtCheckOut.Size = new Size(143, 27);
            txtCheckOut.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = Color.OliveDrab;
            panel3.Controls.Add(dgvReservations);
            panel3.Location = new Point(21, 379);
            panel3.Name = "panel3";
            panel3.Size = new Size(818, 159);
            panel3.TabIndex = 47;
            // 
            // dgvReservations
            // 
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(3, 3);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.Size = new Size(812, 152);
            dgvReservations.TabIndex = 0;
            // 
            // txtRoom
            // 
            txtRoom.BackColor = Color.White;
            txtRoom.Location = new Point(446, 141);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new Size(143, 27);
            txtRoom.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(18, 348);
            label10.Name = "label10";
            label10.Size = new Size(157, 28);
            label10.TabIndex = 48;
            label10.Text = "All Reservation";
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.ForeColor = Color.Black;
            btnUpdateStatus.Location = new Point(346, 255);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(115, 29);
            btnUpdateStatus.TabIndex = 10;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(24, 94);
            label2.Name = "label2";
            label2.Size = new Size(197, 28);
            label2.TabIndex = 47;
            label2.Text = "Reservation Details";
            // 
            // cmbNewStatus
            // 
            cmbNewStatus.BackColor = Color.White;
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.FormattingEnabled = true;
            cmbNewStatus.Location = new Point(147, 256);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(181, 28);
            cmbNewStatus.TabIndex = 9;
            // 
            // txtCurrentStatus
            // 
            txtCurrentStatus.BackColor = Color.White;
            txtCurrentStatus.Location = new Point(147, 218);
            txtCurrentStatus.Name = "txtCurrentStatus";
            txtCurrentStatus.ReadOnly = true;
            txtCurrentStatus.Size = new Size(183, 27);
            txtCurrentStatus.TabIndex = 8;
            // 
            // txtCheckIn
            // 
            txtCheckIn.BackColor = Color.White;
            txtCheckIn.Location = new Point(147, 177);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.ReadOnly = true;
            txtCheckIn.Size = new Size(183, 27);
            txtCheckIn.TabIndex = 7;
            // 
            // txtGuest
            // 
            txtGuest.BackColor = Color.White;
            txtGuest.Location = new Point(147, 138);
            txtGuest.Name = "txtGuest";
            txtGuest.ReadOnly = true;
            txtGuest.Size = new Size(183, 27);
            txtGuest.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(346, 181);
            label9.Name = "label9";
            label9.Size = new Size(94, 23);
            label9.TabIndex = 5;
            label9.Text = "Check Out:";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9F);
            btnSearch.ForeColor = SystemColors.ActiveCaptionText;
            btnSearch.Location = new Point(454, 39);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(87, 27);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(381, 142);
            label8.Name = "label8";
            label8.Size = new Size(59, 23);
            label8.TabIndex = 4;
            label8.Text = "Room:";
            // 
            // txtSearchReservationId
            // 
            txtSearchReservationId.Font = new Font("Segoe UI", 10F);
            txtSearchReservationId.Location = new Point(225, 36);
            txtSearchReservationId.Name = "txtSearchReservationId";
            txtSearchReservationId.Size = new Size(223, 30);
            txtSearchReservationId.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(42, 257);
            label6.Name = "label6";
            label6.Size = new Size(99, 23);
            label6.TabIndex = 3;
            label6.Text = "New Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(39, 42);
            label7.Name = "label7";
            label7.Size = new Size(180, 23);
            label7.TabIndex = 17;
            label7.Text = "Search Reservation ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(18, 218);
            label5.Name = "label5";
            label5.Size = new Size(123, 23);
            label5.TabIndex = 2;
            label5.Text = "Current Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(83, 142);
            label3.Name = "label3";
            label3.Size = new Size(58, 23);
            label3.TabIndex = 0;
            label3.Text = "Guest:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(61, 181);
            label4.Name = "label4";
            label4.Size = new Size(80, 23);
            label4.TabIndex = 1;
            label4.Text = "Check In:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(404, 18);
            label1.Name = "label1";
            label1.Size = new Size(253, 33);
            label1.TabIndex = 19;
            label1.Text = "Hotel Reservation";
            // 
            // btnCheckInCheckOut
            // 
            btnCheckInCheckOut.BackColor = Color.OliveDrab;
            btnCheckInCheckOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnCheckInCheckOut.ForeColor = Color.White;
            btnCheckInCheckOut.Location = new Point(33, 364);
            btnCheckInCheckOut.Name = "btnCheckInCheckOut";
            btnCheckInCheckOut.Size = new Size(205, 49);
            btnCheckInCheckOut.TabIndex = 17;
            btnCheckInCheckOut.Text = "Check-In / Check-Out";
            btnCheckInCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnReservationStatus
            // 
            btnReservationStatus.BackColor = Color.OliveDrab;
            btnReservationStatus.Font = new Font("Segoe UI", 11.2F, FontStyle.Bold);
            btnReservationStatus.ForeColor = Color.White;
            btnReservationStatus.Location = new Point(33, 305);
            btnReservationStatus.Name = "btnReservationStatus";
            btnReservationStatus.Size = new Size(205, 53);
            btnReservationStatus.TabIndex = 16;
            btnReservationStatus.Text = "Reservation Status";
            btnReservationStatus.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.OliveDrab;
            btnReservation.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(33, 234);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(205, 56);
            btnReservation.TabIndex = 15;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnBillingPayment
            // 
            btnBillingPayment.BackColor = Color.OliveDrab;
            btnBillingPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingPayment.ForeColor = Color.White;
            btnBillingPayment.Location = new Point(33, 419);
            btnBillingPayment.Name = "btnBillingPayment";
            btnBillingPayment.Size = new Size(205, 46);
            btnBillingPayment.TabIndex = 18;
            btnBillingPayment.Text = "Billing Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.OliveDrab;
            btnGuests.Font = new Font("Segoe UI", 11.3F, FontStyle.Bold);
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(33, 160);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(205, 58);
            btnGuests.TabIndex = 14;
            btnGuests.Text = "Guest's Information";
            btnGuests.UseVisualStyleBackColor = false;
            // 
            // ReservationStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1142, 643);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnCheckInCheckOut);
            Controls.Add(btnReservationStatus);
            Controls.Add(btnReservation);
            Controls.Add(btnBillingPayment);
            Controls.Add(btnGuests);
            Name = "ReservationStatus";
            Text = "ReservationStatus";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Label lblUser;
        private Button btnReserve;
        private Button btnClear;
        private Panel panel1;
        private Button btnSearch;
        private TextBox txtSearchReservationId;
        private Label label7;
        private Label label1;
        private Button btnCheckInCheckOut;
        private Button btnReservationStatus;
        private Button btnReservation;
        private Button btnBillingPayment;
        private Button btnGuests;
        private Label label2;
        private Panel panel3;
        private Label label10;
        private DataGridView dgvReservations;
        private TextBox txtCheckOut;
        private TextBox txtRoom;
        private Button btnUpdateStatus;
        private ComboBox cmbNewStatus;
        private TextBox txtCurrentStatus;
        private TextBox txtCheckIn;
        private TextBox txtGuest;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}