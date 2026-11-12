namespace HotelReservation
{
    partial class BillingRecords
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
            dgvBillingRecords = new DataGridView();
            btnSearch = new Button();
            txtSearchReservationId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            lblUser = new Label();
            btnLogout = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillingRecords).BeginInit();
            SuspendLayout();
            // 
            // btnBillingRecords
            // 
            btnBillingRecords.BackColor = Color.OliveDrab;
            btnBillingRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingRecords.ForeColor = Color.White;
            btnBillingRecords.Location = new Point(12, 336);
            btnBillingRecords.Name = "btnBillingRecords";
            btnBillingRecords.Size = new Size(225, 71);
            btnBillingRecords.TabIndex = 10;
            btnBillingRecords.Text = "Billing Records";
            btnBillingRecords.UseVisualStyleBackColor = false;
            // 
            // btnReservationRecords
            // 
            btnReservationRecords.BackColor = Color.OliveDrab;
            btnReservationRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservationRecords.ForeColor = Color.White;
            btnReservationRecords.Location = new Point(12, 258);
            btnReservationRecords.Name = "btnReservationRecords";
            btnReservationRecords.Size = new Size(225, 72);
            btnReservationRecords.TabIndex = 9;
            btnReservationRecords.Text = "Reservation Records";
            btnReservationRecords.UseVisualStyleBackColor = false;
            // 
            // btnGuestRecords
            // 
            btnGuestRecords.BackColor = Color.OliveDrab;
            btnGuestRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestRecords.ForeColor = Color.White;
            btnGuestRecords.Location = new Point(12, 172);
            btnGuestRecords.Name = "btnGuestRecords";
            btnGuestRecords.Size = new Size(225, 80);
            btnGuestRecords.TabIndex = 8;
            btnGuestRecords.Text = "Guest Records";
            btnGuestRecords.UseVisualStyleBackColor = false;
            // 
            // btnRoomsMaintenance
            // 
            btnRoomsMaintenance.BackColor = Color.OliveDrab;
            btnRoomsMaintenance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoomsMaintenance.ForeColor = Color.White;
            btnRoomsMaintenance.Location = new Point(12, 88);
            btnRoomsMaintenance.Name = "btnRoomsMaintenance";
            btnRoomsMaintenance.Size = new Size(225, 78);
            btnRoomsMaintenance.TabIndex = 7;
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
            label1.TabIndex = 11;
            label1.Text = "Hotel Reservation";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgvBillingRecords);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearchReservationId);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(282, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 549);
            panel1.TabIndex = 12;
            // 
            // dgvBillingRecords
            // 
            dgvBillingRecords.AllowUserToAddRows = false;
            dgvBillingRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillingRecords.Location = new Point(9, 128);
            dgvBillingRecords.MultiSelect = false;
            dgvBillingRecords.Name = "dgvBillingRecords";
            dgvBillingRecords.ReadOnly = true;
            dgvBillingRecords.RowHeadersWidth = 51;
            dgvBillingRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillingRecords.Size = new Size(779, 412);
            dgvBillingRecords.TabIndex = 17;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightGray;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(401, 59);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(161, 43);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchReservationId
            // 
            txtSearchReservationId.BackColor = Color.White;
            txtSearchReservationId.Location = new Point(212, 70);
            txtSearchReservationId.Name = "txtSearchReservationId";
            txtSearchReservationId.Size = new Size(174, 27);
            txtSearchReservationId.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 71);
            label5.Name = "label5";
            label5.Size = new Size(183, 23);
            label5.TabIndex = 1;
            label5.Text = "Search Reservation ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 25);
            label4.Name = "label4";
            label4.Size = new Size(294, 31);
            label4.TabIndex = 0;
            label4.Text = "Billing Records (View Only)";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(805, 44);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(51, 28);
            lblUser.TabIndex = 13;
            lblUser.Text = "User";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(882, 37);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(161, 43);
            btnLogout.TabIndex = 15;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // BillingRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1097, 663);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnBillingRecords);
            Controls.Add(btnReservationRecords);
            Controls.Add(btnGuestRecords);
            Controls.Add(btnRoomsMaintenance);
            Name = "BillingRecords";
            Text = "BillingRecords";
            Load += BillingRecords_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillingRecords).EndInit();
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
        private Label lblUser;
        private Label label4;
        private Button btnLogout;
        private DataGridView dgvBillingRecords;
        private Button btnSearch;
        private TextBox txtSearchReservationId;
        private Label label5;
    }
}