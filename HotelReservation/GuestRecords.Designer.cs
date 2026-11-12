namespace HotelReservation
{
    partial class GuestRecords
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
            panel1 = new Panel();
            label6 = new Label();
            dgvGuests = new DataGridView();
            btnSearch = new Button();
            txtSearchGuest = new TextBox();
            label5 = new Label();
            label1 = new Label();
            btnBillingRecords = new Button();
            btnReservationRecords = new Button();
            btnGuestRecords = new Button();
            btnRoomsMaintenance = new Button();
            btnLogout = new Button();
            lblUser = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dgvGuests);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearchGuest);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(253, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 549);
            panel1.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 82);
            label6.Name = "label6";
            label6.Size = new Size(85, 23);
            label6.TabIndex = 18;
            label6.Text = "All Guests";
            // 
            // dgvGuests
            // 
            dgvGuests.AllowUserToAddRows = false;
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuests.Location = new Point(15, 108);
            dgvGuests.MultiSelect = false;
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersWidth = 51;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(813, 428);
            dgvGuests.TabIndex = 17;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightGray;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(326, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(161, 43);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchGuest
            // 
            txtSearchGuest.BackColor = Color.White;
            txtSearchGuest.Location = new Point(135, 16);
            txtSearchGuest.Name = "txtSearchGuest";
            txtSearchGuest.Size = new Size(174, 27);
            txtSearchGuest.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 17);
            label5.Name = "label5";
            label5.Size = new Size(114, 23);
            label5.TabIndex = 1;
            label5.Text = "Search Guest:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(270, 41);
            label1.TabIndex = 25;
            label1.Text = "Hotel Reservation";
            // 
            // btnBillingRecords
            // 
            btnBillingRecords.BackColor = Color.OliveDrab;
            btnBillingRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingRecords.ForeColor = Color.White;
            btnBillingRecords.Location = new Point(3, 372);
            btnBillingRecords.Name = "btnBillingRecords";
            btnBillingRecords.Size = new Size(225, 71);
            btnBillingRecords.TabIndex = 24;
            btnBillingRecords.Text = "Billing Records";
            btnBillingRecords.UseVisualStyleBackColor = false;
            // 
            // btnReservationRecords
            // 
            btnReservationRecords.BackColor = Color.OliveDrab;
            btnReservationRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservationRecords.ForeColor = Color.White;
            btnReservationRecords.Location = new Point(3, 294);
            btnReservationRecords.Name = "btnReservationRecords";
            btnReservationRecords.Size = new Size(225, 72);
            btnReservationRecords.TabIndex = 23;
            btnReservationRecords.Text = "Reservation Records";
            btnReservationRecords.UseVisualStyleBackColor = false;
            // 
            // btnGuestRecords
            // 
            btnGuestRecords.BackColor = Color.OliveDrab;
            btnGuestRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestRecords.ForeColor = Color.White;
            btnGuestRecords.Location = new Point(3, 208);
            btnGuestRecords.Name = "btnGuestRecords";
            btnGuestRecords.Size = new Size(225, 80);
            btnGuestRecords.TabIndex = 22;
            btnGuestRecords.Text = "Guest Records";
            btnGuestRecords.UseVisualStyleBackColor = false;
            // 
            // btnRoomsMaintenance
            // 
            btnRoomsMaintenance.BackColor = Color.OliveDrab;
            btnRoomsMaintenance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoomsMaintenance.ForeColor = Color.White;
            btnRoomsMaintenance.Location = new Point(3, 124);
            btnRoomsMaintenance.Name = "btnRoomsMaintenance";
            btnRoomsMaintenance.Size = new Size(225, 78);
            btnRoomsMaintenance.TabIndex = 21;
            btnRoomsMaintenance.Text = " Rooms Maintenance";
            btnRoomsMaintenance.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(853, 58);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(161, 43);
            btnLogout.TabIndex = 28;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(734, 65);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(51, 28);
            lblUser.TabIndex = 27;
            lblUser.Text = "User";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(253, 73);
            label4.Name = "label4";
            label4.Size = new Size(162, 31);
            label4.TabIndex = 20;
            label4.Text = "Guest Records";
            // 
            // GuestRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1098, 661);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnBillingRecords);
            Controls.Add(btnReservationRecords);
            Controls.Add(btnGuestRecords);
            Controls.Add(btnRoomsMaintenance);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(label4);
            Name = "GuestRecords";
            Text = "GuestRecords";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private DataGridView dgvGuests;
        private Button btnSearch;
        private TextBox txtSearchGuest;
        private Label label5;
        private Label label1;
        private Button btnBillingRecords;
        private Button btnReservationRecords;
        private Button btnGuestRecords;
        private Button btnRoomsMaintenance;
        private Button btnLogout;
        private Label lblUser;
        private Label label4;
    }
}