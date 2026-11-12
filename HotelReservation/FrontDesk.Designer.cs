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
            label1 = new Label();
            lblFrontDesk = new Label();
            btnGuests = new Button();
            btnReservation = new Button();
            btnReservationStatus = new Button();
            btnCheckInCheckOut = new Button();
            btnBillingPayment = new Button();
            btnLogout = new Button();
            panel1 = new Panel();
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
            lblFrontDesk.Location = new Point(1539, 128);
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
            btnReservation.Size = new Size(364, 92);
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
            btnReservationStatus.Size = new Size(364, 90);
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
            btnCheckInCheckOut.Size = new Size(364, 89);
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
            btnBillingPayment.Size = new Size(364, 91);
            btnBillingPayment.TabIndex = 7;
            btnBillingPayment.Text = "Billing / Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.OliveDrab;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnLogout.Location = new Point(1714, 122);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(148, 49);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(543, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 800);
            panel1.TabIndex = 10;
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
            Load += FrontDesk_Load;
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
    }
}