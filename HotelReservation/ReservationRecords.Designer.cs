namespace HotelReservation
{
    partial class ReservationRecords
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
            btnBillingRecords = new Button();
            btnReservationRecords = new Button();
            btnGuestRecords = new Button();
            btnRoomsMaintenance = new Button();
            label1 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            dgvReservations = new DataGridView();
            btnSearch = new Button();
            txtSearchReservationId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            lblUser = new Label();
            btnLogout = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // btnBillingRecords
            // 
            btnBillingRecords.BackColor = Color.OliveDrab;
            btnBillingRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingRecords.ForeColor = Color.White;
            btnBillingRecords.Location = new Point(12, 377);
            btnBillingRecords.Name = "btnBillingRecords";
            btnBillingRecords.Size = new Size(225, 71);
            btnBillingRecords.TabIndex = 14;
            btnBillingRecords.Text = "Billing Records";
            btnBillingRecords.UseVisualStyleBackColor = false;
            // 
            // btnReservationRecords
            // 
            btnReservationRecords.BackColor = Color.OliveDrab;
            btnReservationRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservationRecords.ForeColor = Color.White;
            btnReservationRecords.Location = new Point(12, 299);
            btnReservationRecords.Name = "btnReservationRecords";
            btnReservationRecords.Size = new Size(225, 72);
            btnReservationRecords.TabIndex = 13;
            btnReservationRecords.Text = "Reservation Records";
            btnReservationRecords.UseVisualStyleBackColor = false;
            // 
            // btnGuestRecords
            // 
            btnGuestRecords.BackColor = Color.OliveDrab;
            btnGuestRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestRecords.ForeColor = Color.White;
            btnGuestRecords.Location = new Point(12, 213);
            btnGuestRecords.Name = "btnGuestRecords";
            btnGuestRecords.Size = new Size(225, 80);
            btnGuestRecords.TabIndex = 12;
            btnGuestRecords.Text = "Guest Records";
            btnGuestRecords.UseVisualStyleBackColor = false;
            // 
            // btnRoomsMaintenance
            // 
            btnRoomsMaintenance.BackColor = Color.OliveDrab;
            btnRoomsMaintenance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoomsMaintenance.ForeColor = Color.White;
            btnRoomsMaintenance.Location = new Point(12, 129);
            btnRoomsMaintenance.Name = "btnRoomsMaintenance";
            btnRoomsMaintenance.Size = new Size(225, 78);
            btnRoomsMaintenance.TabIndex = 11;
            btnRoomsMaintenance.Text = " Rooms Maintenance";
            btnRoomsMaintenance.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(270, 41);
            label1.TabIndex = 15;
            label1.Text = "Hotel Reservation";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dgvReservations);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearchReservationId);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(262, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 549);
            panel1.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 82);
            label6.Name = "label6";
            label6.Size = new Size(132, 23);
            label6.TabIndex = 18;
            label6.Text = "All Reservations";
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(15, 108);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(813, 428);
            dgvReservations.TabIndex = 17;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightGray;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(384, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(161, 43);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchReservationId
            // 
            txtSearchReservationId.BackColor = Color.White;
            txtSearchReservationId.Location = new Point(204, 17);
            txtSearchReservationId.Name = "txtSearchReservationId";
            txtSearchReservationId.Size = new Size(174, 27);
            txtSearchReservationId.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 17);
            label5.Name = "label5";
            label5.Size = new Size(183, 23);
            label5.TabIndex = 1;
            label5.Text = "Search Reservation ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(262, 78);
            label4.Name = "label4";
            label4.Size = new Size(225, 31);
            label4.TabIndex = 0;
            label4.Text = "Reservation Records";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(743, 70);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(51, 28);
            lblUser.TabIndex = 17;
            lblUser.Text = "User";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(862, 63);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(161, 43);
            btnLogout.TabIndex = 19;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // ReservationRecords
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1117, 673);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(btnBillingRecords);
            Controls.Add(btnReservationRecords);
            Controls.Add(btnGuestRecords);
            Controls.Add(btnRoomsMaintenance);
            Name = "ReservationRecords";
            Text = "ReservationRecords";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBillingRecords;
        private Button btnReservationRecords;
        private Button btnGuestRecords;
        private Button btnRoomsMaintenance;
        private Label label1;
        private Panel panel1;
        private DataGridView dgvReservations;
        private Button btnSearch;
        private TextBox txtSearchReservationId;
        private Label label5;
        private Label label4;
        private Label lblUser;
        private Button btnLogout;
        private Label label6;
    }
}