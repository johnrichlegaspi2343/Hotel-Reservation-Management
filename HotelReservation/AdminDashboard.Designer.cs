namespace HotelReservation
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            label1 = new Label();
            btnRoomsMaintenance = new Button();
            btnGuestRecords = new Button();
            btnReservationRecords = new Button();
            btnBillingRecords = new Button();
            lblUser = new Label();
            btnLogout = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(728, 21);
            label1.Name = "label1";
            label1.Size = new Size(398, 60);
            label1.TabIndex = 2;
            label1.Text = "Hotel Reservation";
            // 
            // btnRoomsMaintenance
            // 
            btnRoomsMaintenance.BackColor = Color.OliveDrab;
            btnRoomsMaintenance.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoomsMaintenance.ForeColor = Color.White;
            btnRoomsMaintenance.Location = new Point(25, 190);
            btnRoomsMaintenance.Name = "btnRoomsMaintenance";
            btnRoomsMaintenance.Size = new Size(471, 88);
            btnRoomsMaintenance.TabIndex = 3;
            btnRoomsMaintenance.Text = " Rooms Maintenance";
            btnRoomsMaintenance.UseVisualStyleBackColor = false;
            // 
            // btnGuestRecords
            // 
            btnGuestRecords.BackColor = Color.OliveDrab;
            btnGuestRecords.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestRecords.ForeColor = Color.White;
            btnGuestRecords.Location = new Point(25, 340);
            btnGuestRecords.Name = "btnGuestRecords";
            btnGuestRecords.Size = new Size(471, 90);
            btnGuestRecords.TabIndex = 4;
            btnGuestRecords.Text = "Guest Records";
            btnGuestRecords.UseVisualStyleBackColor = false;
            // 
            // btnReservationRecords
            // 
            btnReservationRecords.BackColor = Color.OliveDrab;
            btnReservationRecords.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservationRecords.ForeColor = Color.White;
            btnReservationRecords.Location = new Point(25, 487);
            btnReservationRecords.Name = "btnReservationRecords";
            btnReservationRecords.Size = new Size(471, 82);
            btnReservationRecords.TabIndex = 5;
            btnReservationRecords.Text = "Reservation Records";
            btnReservationRecords.UseVisualStyleBackColor = false;
            // 
            // btnBillingRecords
            // 
            btnBillingRecords.BackColor = Color.OliveDrab;
            btnBillingRecords.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingRecords.ForeColor = Color.White;
            btnBillingRecords.Location = new Point(25, 625);
            btnBillingRecords.Name = "btnBillingRecords";
            btnBillingRecords.Size = new Size(471, 81);
            btnBillingRecords.TabIndex = 6;
            btnBillingRecords.Text = "Billing Records";
            btnBillingRecords.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(1498, 103);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(119, 41);
            lblUser.TabIndex = 8;
            lblUser.Text = "<user>";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.OliveDrab;
            btnLogout.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ButtonHighlight;
            btnLogout.Location = new Point(1671, 96);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(167, 54);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "[Logout]";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Ivory;
            panel1.Location = new Point(554, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(1306, 812);
            panel1.TabIndex = 10;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(btnBillingRecords);
            Controls.Add(btnReservationRecords);
            Controls.Add(btnGuestRecords);
            Controls.Add(btnRoomsMaintenance);
            Controls.Add(label1);
            Name = "AdminDashboard";
            Text = resources.GetString("$this.Text");
            Load += AdminDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnRoomsMaintenance;
        private Button btnGuestRecords;
        private Button btnReservationRecords;
        private Button btnBillingRecords;
        private Label lblUser;
        private Button btnLogout;
        private Panel panel1;
    }
}