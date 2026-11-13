namespace HotelReservation
{
    partial class CheckinCheckout
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
            btnGuests = new Button();
            btnReservation = new Button();
            btnReservationStatus = new Button();
            btnCheckinCheckout = new Button();
            btnBillingPayment = new Button();
            btnLogout = new Button();
            lblUser = new Label();
            panel1 = new Panel();
            txtActualCheckout = new TextBox();
            label14 = new Label();
            txtActualCheckin = new TextBox();
            txtPaymentStatus = new TextBox();
            txtReservationStatus = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            txtCheckOutDate = new TextBox();
            txtCheckInDate = new TextBox();
            label9 = new Label();
            label8 = new Label();
            txtRoom = new TextBox();
            txtGuest = new TextBox();
            btnCheckout = new Button();
            btnCheckin = new Button();
            btnSearch = new Button();
            txtSearchReservationId = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(27, 29);
            label1.Name = "label1";
            label1.Size = new Size(206, 31);
            label1.TabIndex = 1;
            label1.Text = "Hotel Reservation";
            // 
            // btnGuests
            // 
            btnGuests.BackColor = Color.OliveDrab;
            btnGuests.ForeColor = Color.White;
            btnGuests.Location = new Point(27, 88);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(206, 35);
            btnGuests.TabIndex = 2;
            btnGuests.Text = "Guests";
            btnGuests.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.OliveDrab;
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(27, 143);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(206, 35);
            btnReservation.TabIndex = 4;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnReservationStatus
            // 
            btnReservationStatus.BackColor = Color.OliveDrab;
            btnReservationStatus.ForeColor = Color.White;
            btnReservationStatus.Location = new Point(27, 197);
            btnReservationStatus.Name = "btnReservationStatus";
            btnReservationStatus.Size = new Size(206, 35);
            btnReservationStatus.TabIndex = 5;
            btnReservationStatus.Text = "Reservation Records";
            btnReservationStatus.UseVisualStyleBackColor = false;
            // 
            // btnCheckinCheckout
            // 
            btnCheckinCheckout.BackColor = Color.OliveDrab;
            btnCheckinCheckout.ForeColor = Color.White;
            btnCheckinCheckout.Location = new Point(27, 252);
            btnCheckinCheckout.Name = "btnCheckinCheckout";
            btnCheckinCheckout.Size = new Size(206, 35);
            btnCheckinCheckout.TabIndex = 6;
            btnCheckinCheckout.Text = "Check-in / Check-out";
            btnCheckinCheckout.UseVisualStyleBackColor = false;
            btnCheckinCheckout.Click += button5_Click;
            // 
            // btnBillingPayment
            // 
            btnBillingPayment.BackColor = Color.OliveDrab;
            btnBillingPayment.ForeColor = Color.White;
            btnBillingPayment.Location = new Point(27, 309);
            btnBillingPayment.Name = "btnBillingPayment";
            btnBillingPayment.Size = new Size(206, 35);
            btnBillingPayment.TabIndex = 7;
            btnBillingPayment.Text = "Billing / Payment";
            btnBillingPayment.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.OliveDrab;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(649, 38);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(124, 28);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(539, 38);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(92, 28);
            lblUser.TabIndex = 11;
            lblUser.Text = "< user >";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtActualCheckout);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtActualCheckin);
            panel1.Controls.Add(txtPaymentStatus);
            panel1.Controls.Add(txtReservationStatus);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtCheckOutDate);
            panel1.Controls.Add(txtCheckInDate);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtRoom);
            panel1.Controls.Add(txtGuest);
            panel1.Controls.Add(btnCheckout);
            panel1.Controls.Add(btnCheckin);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearchReservationId);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(269, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 350);
            panel1.TabIndex = 12;
            // 
            // txtActualCheckout
            // 
            txtActualCheckout.BackColor = SystemColors.MenuBar;
            txtActualCheckout.Location = new Point(270, 305);
            txtActualCheckout.Name = "txtActualCheckout";
            txtActualCheckout.Size = new Size(135, 27);
            txtActualCheckout.TabIndex = 29;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(41, 282);
            label14.Name = "label14";
            label14.Size = new Size(112, 20);
            label14.TabIndex = 28;
            label14.Text = "Actual Check-in";
            // 
            // txtActualCheckin
            // 
            txtActualCheckin.BackColor = SystemColors.MenuBar;
            txtActualCheckin.Location = new Point(26, 306);
            txtActualCheckin.Name = "txtActualCheckin";
            txtActualCheckin.Size = new Size(135, 27);
            txtActualCheckin.TabIndex = 27;
            // 
            // txtPaymentStatus
            // 
            txtPaymentStatus.BackColor = SystemColors.MenuBar;
            txtPaymentStatus.Location = new Point(170, 208);
            txtPaymentStatus.Name = "txtPaymentStatus";
            txtPaymentStatus.Size = new Size(135, 27);
            txtPaymentStatus.TabIndex = 26;
            // 
            // txtReservationStatus
            // 
            txtReservationStatus.BackColor = SystemColors.MenuBar;
            txtReservationStatus.Location = new Point(13, 208);
            txtReservationStatus.Name = "txtReservationStatus";
            txtReservationStatus.Size = new Size(135, 27);
            txtReservationStatus.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 252);
            label13.Name = "label13";
            label13.Size = new Size(135, 20);
            label13.TabIndex = 24;
            label13.Text = "Actual Timestamps";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(271, 282);
            label12.Name = "label12";
            label12.Size = new Size(122, 20);
            label12.TabIndex = 23;
            label12.Text = "Actual Check-out";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(188, 185);
            label11.Name = "label11";
            label11.Size = new Size(109, 20);
            label11.TabIndex = 22;
            label11.Text = "Payment Status";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 185);
            label10.Name = "label10";
            label10.Size = new Size(130, 20);
            label10.TabIndex = 21;
            label10.Text = "Reservation Status";
            // 
            // txtCheckOutDate
            // 
            txtCheckOutDate.BackColor = SystemColors.MenuBar;
            txtCheckOutDate.Location = new Point(170, 151);
            txtCheckOutDate.Name = "txtCheckOutDate";
            txtCheckOutDate.Size = new Size(135, 27);
            txtCheckOutDate.TabIndex = 20;
            // 
            // txtCheckInDate
            // 
            txtCheckInDate.BackColor = SystemColors.MenuBar;
            txtCheckInDate.Location = new Point(13, 151);
            txtCheckInDate.Name = "txtCheckInDate";
            txtCheckInDate.Size = new Size(135, 27);
            txtCheckInDate.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(185, 128);
            label9.Name = "label9";
            label9.Size = new Size(112, 20);
            label9.TabIndex = 18;
            label9.Text = "Check-out Date";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 128);
            label8.Name = "label8";
            label8.Size = new Size(102, 20);
            label8.TabIndex = 17;
            label8.Text = "Check-in Date";
            // 
            // txtRoom
            // 
            txtRoom.BackColor = SystemColors.Menu;
            txtRoom.Location = new Point(170, 95);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(135, 27);
            txtRoom.TabIndex = 16;
            // 
            // txtGuest
            // 
            txtGuest.BackColor = SystemColors.Menu;
            txtGuest.Location = new Point(13, 93);
            txtGuest.Name = "txtGuest";
            txtGuest.Size = new Size(135, 27);
            txtGuest.TabIndex = 15;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.LightGray;
            btnCheckout.Location = new Point(329, 142);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(175, 77);
            btnCheckout.TabIndex = 14;
            btnCheckout.Text = "Check-out";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnCheckin
            // 
            btnCheckin.BackColor = Color.PaleGreen;
            btnCheckin.Location = new Point(329, 59);
            btnCheckin.Name = "btnCheckin";
            btnCheckin.Size = new Size(175, 77);
            btnCheckin.TabIndex = 13;
            btnCheckin.Text = "Check-in";
            btnCheckin.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightGray;
            btnSearch.Location = new Point(329, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchReservationId
            // 
            txtSearchReservationId.Location = new Point(188, 18);
            txtSearchReservationId.Name = "txtSearchReservationId";
            txtSearchReservationId.Size = new Size(135, 27);
            txtSearchReservationId.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(212, 71);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 3;
            label7.Text = "Room";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 70);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 2;
            label6.Text = "Guests";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 41);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 1;
            label5.Text = "Reservation Details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 21);
            label4.Name = "label4";
            label4.Size = new Size(156, 20);
            label4.TabIndex = 0;
            label4.Text = "Search Reservation ID:";
            // 
            // CheckinCheckout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(lblUser);
            Controls.Add(btnLogout);
            Controls.Add(btnBillingPayment);
            Controls.Add(btnCheckinCheckout);
            Controls.Add(btnReservationStatus);
            Controls.Add(btnReservation);
            Controls.Add(btnGuests);
            Controls.Add(label1);
            Name = "CheckinCheckout";
            Text = "CheckinCheckout";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGuests;
        private Button btnReservation;
        private Button btnReservationStatus;
        private Button btnCheckinCheckout;
        private Button btnBillingPayment;
        private Button btnLogout;
        private Label lblUser;
        private Panel panel1;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label8;
        private TextBox txtRoom;
        private TextBox txtGuest;
        private Button btnCheckout;
        private Button btnCheckin;
        private Button btnSearch;
        private TextBox txtSearchReservationId;
        private Label label7;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private TextBox txtCheckOutDate;
        private TextBox txtCheckInDate;
        private TextBox txtActualCheckout;
        private Label label14;
        private TextBox txtActualCheckin;
        private TextBox txtPaymentStatus;
        private TextBox txtReservationStatus;
    }
}