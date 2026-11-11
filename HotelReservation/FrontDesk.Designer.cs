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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
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
            // btnGuestInformation
            // 
            btnGuestInformation.BackColor = Color.OliveDrab;
            btnGuestInformation.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnGuestInformation.ForeColor = Color.White;
            btnGuestInformation.Location = new Point(79, 208);
            btnGuestInformation.Name = "btnGuestInformation";
            btnGuestInformation.Size = new Size(364, 82);
            btnGuestInformation.TabIndex = 2;
            btnGuestInformation.Text = "Guests Information";
            btnGuestInformation.UseVisualStyleBackColor = false;
            btnGuestInformation.Click += button1_Click;
            // 
            // btnAvailability
            // 
            btnAvailability.BackColor = Color.OliveDrab;
            btnAvailability.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnAvailability.ForeColor = Color.White;
            btnAvailability.Location = new Point(79, 312);
            btnAvailability.Name = "btnAvailability";
            btnAvailability.Size = new Size(364, 81);
            btnAvailability.TabIndex = 3;
            btnAvailability.Text = "Availability";
            btnAvailability.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.OliveDrab;
            btnReservation.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(79, 417);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(364, 92);
            btnReservation.TabIndex = 4;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnCheckinCheckout
            // 
            btnCheckinCheckout.BackColor = Color.OliveDrab;
            btnCheckinCheckout.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            btnCheckinCheckout.ForeColor = Color.White;
            btnCheckinCheckout.Location = new Point(79, 539);
            btnCheckinCheckout.Name = "btnCheckinCheckout";
            btnCheckinCheckout.Size = new Size(364, 90);
            btnCheckinCheckout.TabIndex = 5;
            btnCheckinCheckout.Text = "Reservation Status";
            btnCheckinCheckout.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.OliveDrab;
            button5.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(79, 654);
            button5.Name = "button5";
            button5.Size = new Size(364, 89);
            button5.TabIndex = 6;
            button5.Text = "Check-In / Check-Out";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.OliveDrab;
            button6.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(79, 765);
            button6.Name = "button6";
            button6.Size = new Size(364, 91);
            button6.TabIndex = 7;
            button6.Text = "Billing / Payment";
            button6.UseVisualStyleBackColor = false;
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
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button btnLogout;
        private Panel panel1;
    }
}