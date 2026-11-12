namespace HotelReservation
{
    partial class RoomMaintenance
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
            label9 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            dgvRoomTypes = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnClearRoomType = new Button();
            btnDeleteRoomType = new Button();
            btnEditRoomType = new Button();
            btnAddRoomType = new Button();
            txtRoomTypeRate = new TextBox();
            txtRoomTypeName = new TextBox();
            label11 = new Label();
            label10 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            dgvRooms = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            btnEditRoom = new Button();
            btnClearRoom = new Button();
            btnDeleteRoom = new Button();
            btnAddRoom = new Button();
            cmbRoomStatus = new ComboBox();
            txtRoomRate = new TextBox();
            cmbRoomType = new ComboBox();
            txtRoomNumber = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            lblUser = new Label();
            btnLogout = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // btnBillingRecords
            // 
            btnBillingRecords.BackColor = Color.OliveDrab;
            btnBillingRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillingRecords.ForeColor = Color.White;
            btnBillingRecords.Location = new Point(12, 407);
            btnBillingRecords.Name = "btnBillingRecords";
            btnBillingRecords.Size = new Size(200, 71);
            btnBillingRecords.TabIndex = 18;
            btnBillingRecords.Text = "Billing Records";
            btnBillingRecords.UseVisualStyleBackColor = false;
            // 
            // btnReservationRecords
            // 
            btnReservationRecords.BackColor = Color.OliveDrab;
            btnReservationRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservationRecords.ForeColor = Color.White;
            btnReservationRecords.Location = new Point(12, 329);
            btnReservationRecords.Name = "btnReservationRecords";
            btnReservationRecords.Size = new Size(200, 72);
            btnReservationRecords.TabIndex = 17;
            btnReservationRecords.Text = "Reservation Records";
            btnReservationRecords.UseVisualStyleBackColor = false;
            // 
            // btnGuestRecords
            // 
            btnGuestRecords.BackColor = Color.OliveDrab;
            btnGuestRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuestRecords.ForeColor = Color.White;
            btnGuestRecords.Location = new Point(12, 243);
            btnGuestRecords.Name = "btnGuestRecords";
            btnGuestRecords.Size = new Size(200, 80);
            btnGuestRecords.TabIndex = 16;
            btnGuestRecords.Text = "Guest Records";
            btnGuestRecords.UseVisualStyleBackColor = false;
            // 
            // btnRoomsMaintenance
            // 
            btnRoomsMaintenance.BackColor = Color.OliveDrab;
            btnRoomsMaintenance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoomsMaintenance.ForeColor = Color.White;
            btnRoomsMaintenance.Location = new Point(12, 159);
            btnRoomsMaintenance.Name = "btnRoomsMaintenance";
            btnRoomsMaintenance.Size = new Size(200, 78);
            btnRoomsMaintenance.TabIndex = 15;
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
            label1.TabIndex = 19;
            label1.Text = "Hotel Reservation";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(218, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(941, 570);
            panel1.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(527, 11);
            label9.Name = "label9";
            label9.Size = new Size(200, 28);
            label9.TabIndex = 26;
            label9.Text = "Room Type and Rates";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(btnClearRoomType);
            panel3.Controls.Add(btnDeleteRoomType);
            panel3.Controls.Add(btnEditRoomType);
            panel3.Controls.Add(btnAddRoomType);
            panel3.Controls.Add(txtRoomTypeRate);
            panel3.Controls.Add(txtRoomTypeName);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(527, 42);
            panel3.Name = "panel3";
            panel3.Size = new Size(410, 519);
            panel3.TabIndex = 25;
            // 
            // panel5
            // 
            panel5.BackColor = Color.OliveDrab;
            panel5.Controls.Add(dgvRoomTypes);
            panel5.Location = new Point(8, 207);
            panel5.Name = "panel5";
            panel5.Size = new Size(399, 308);
            panel5.TabIndex = 38;
            // 
            // dgvRoomTypes
            // 
            dgvRoomTypes.AllowUserToAddRows = false;
            dgvRoomTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomTypes.Columns.AddRange(new DataGridViewColumn[] { Column5, Column6 });
            dgvRoomTypes.Location = new Point(1, 1);
            dgvRoomTypes.MultiSelect = false;
            dgvRoomTypes.Name = "dgvRoomTypes";
            dgvRoomTypes.ReadOnly = true;
            dgvRoomTypes.RowHeadersWidth = 51;
            dgvRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomTypes.Size = new Size(401, 250);
            dgvRoomTypes.TabIndex = 0;
            // 
            // Column5
            // 
            Column5.HeaderText = "Room Type Name";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "Rate per Night";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // btnClearRoomType
            // 
            btnClearRoomType.BackColor = Color.LightGray;
            btnClearRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearRoomType.ForeColor = Color.Black;
            btnClearRoomType.Location = new Point(304, 152);
            btnClearRoomType.Name = "btnClearRoomType";
            btnClearRoomType.Size = new Size(92, 43);
            btnClearRoomType.TabIndex = 37;
            btnClearRoomType.Text = "Clear";
            btnClearRoomType.UseVisualStyleBackColor = false;
            // 
            // btnDeleteRoomType
            // 
            btnDeleteRoomType.BackColor = Color.LightGray;
            btnDeleteRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteRoomType.ForeColor = Color.Black;
            btnDeleteRoomType.Location = new Point(206, 152);
            btnDeleteRoomType.Name = "btnDeleteRoomType";
            btnDeleteRoomType.Size = new Size(92, 43);
            btnDeleteRoomType.TabIndex = 37;
            btnDeleteRoomType.Text = "Delete";
            btnDeleteRoomType.UseVisualStyleBackColor = false;
            // 
            // btnEditRoomType
            // 
            btnEditRoomType.BackColor = Color.LightGray;
            btnEditRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditRoomType.ForeColor = Color.Black;
            btnEditRoomType.Location = new Point(108, 152);
            btnEditRoomType.Name = "btnEditRoomType";
            btnEditRoomType.Size = new Size(92, 43);
            btnEditRoomType.TabIndex = 37;
            btnEditRoomType.Text = "Update";
            btnEditRoomType.UseVisualStyleBackColor = false;
            // 
            // btnAddRoomType
            // 
            btnAddRoomType.BackColor = Color.LightGray;
            btnAddRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddRoomType.ForeColor = Color.Black;
            btnAddRoomType.Location = new Point(9, 152);
            btnAddRoomType.Name = "btnAddRoomType";
            btnAddRoomType.Size = new Size(92, 43);
            btnAddRoomType.TabIndex = 36;
            btnAddRoomType.Text = "Add";
            btnAddRoomType.UseVisualStyleBackColor = false;
            // 
            // txtRoomTypeRate
            // 
            txtRoomTypeRate.Location = new Point(199, 29);
            txtRoomTypeRate.Name = "txtRoomTypeRate";
            txtRoomTypeRate.Size = new Size(120, 27);
            txtRoomTypeRate.TabIndex = 33;
            // 
            // txtRoomTypeName
            // 
            txtRoomTypeName.Location = new Point(3, 29);
            txtRoomTypeName.Name = "txtRoomTypeName";
            txtRoomTypeName.Size = new Size(169, 27);
            txtRoomTypeName.TabIndex = 33;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(199, 3);
            label11.Name = "label11";
            label11.Size = new Size(122, 23);
            label11.TabIndex = 28;
            label11.Text = "Rate per Night";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(3, 3);
            label10.Name = "label10";
            label10.Size = new Size(140, 23);
            label10.TabIndex = 27;
            label10.Text = "Enter Room Type";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(btnEditRoom);
            panel2.Controls.Add(btnClearRoom);
            panel2.Controls.Add(btnDeleteRoom);
            panel2.Controls.Add(btnAddRoom);
            panel2.Controls.Add(cmbRoomStatus);
            panel2.Controls.Add(txtRoomRate);
            panel2.Controls.Add(cmbRoomType);
            panel2.Controls.Add(txtRoomNumber);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(16, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(514, 520);
            panel2.TabIndex = 24;
            // 
            // panel4
            // 
            panel4.BackColor = Color.OliveDrab;
            panel4.Controls.Add(dgvRooms);
            panel4.Location = new Point(8, 208);
            panel4.Name = "panel4";
            panel4.Size = new Size(498, 308);
            panel4.TabIndex = 37;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dgvRooms.Location = new Point(-1, 1);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(498, 250);
            dgvRooms.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Room Number";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Room Type";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Rate";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Status";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // btnEditRoom
            // 
            btnEditRoom.BackColor = Color.LightGray;
            btnEditRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditRoom.ForeColor = Color.Black;
            btnEditRoom.Location = new Point(275, 153);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(116, 43);
            btnEditRoom.TabIndex = 36;
            btnEditRoom.Text = "Update";
            btnEditRoom.UseVisualStyleBackColor = false;
            // 
            // btnClearRoom
            // 
            btnClearRoom.BackColor = Color.LightGray;
            btnClearRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearRoom.ForeColor = Color.Black;
            btnClearRoom.Location = new Point(397, 153);
            btnClearRoom.Name = "btnClearRoom";
            btnClearRoom.Size = new Size(114, 43);
            btnClearRoom.TabIndex = 35;
            btnClearRoom.Text = "Clear";
            btnClearRoom.UseVisualStyleBackColor = false;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.BackColor = Color.LightGray;
            btnDeleteRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteRoom.ForeColor = Color.Black;
            btnDeleteRoom.Location = new Point(150, 153);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(119, 43);
            btnDeleteRoom.TabIndex = 33;
            btnDeleteRoom.Text = "Delete";
            btnDeleteRoom.UseVisualStyleBackColor = false;
            // 
            // btnAddRoom
            // 
            btnAddRoom.BackColor = Color.LightGray;
            btnAddRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddRoom.ForeColor = Color.Black;
            btnAddRoom.Location = new Point(8, 153);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(136, 43);
            btnAddRoom.TabIndex = 23;
            btnAddRoom.Text = "Add";
            btnAddRoom.UseVisualStyleBackColor = false;
            // 
            // cmbRoomStatus
            // 
            cmbRoomStatus.FormattingEnabled = true;
            cmbRoomStatus.Location = new Point(380, 31);
            cmbRoomStatus.Name = "cmbRoomStatus";
            cmbRoomStatus.Size = new Size(115, 28);
            cmbRoomStatus.TabIndex = 32;
            // 
            // txtRoomRate
            // 
            txtRoomRate.BackColor = Color.Silver;
            txtRoomRate.Location = new Point(254, 32);
            txtRoomRate.Name = "txtRoomRate";
            txtRoomRate.Size = new Size(120, 27);
            txtRoomRate.TabIndex = 31;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(133, 32);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(115, 28);
            cmbRoomType.TabIndex = 30;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(7, 32);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(120, 27);
            txtRoomNumber.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(407, 4);
            label8.Name = "label8";
            label8.Size = new Size(56, 23);
            label8.TabIndex = 28;
            label8.Text = "Status";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(271, 4);
            label7.Name = "label7";
            label7.Size = new Size(94, 23);
            label7.TabIndex = 27;
            label7.Text = "Room Rate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(142, 4);
            label6.Name = "label6";
            label6.Size = new Size(95, 23);
            label6.TabIndex = 26;
            label6.Text = "Room Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(123, 23);
            label5.TabIndex = 25;
            label5.Text = "Room Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(16, 10);
            label4.Name = "label4";
            label4.Size = new Size(72, 28);
            label4.TabIndex = 23;
            label4.Text = "Rooms";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = SystemColors.ButtonHighlight;
            lblUser.Location = new Point(862, 55);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(51, 28);
            lblUser.TabIndex = 18;
            lblUser.Text = "User";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(980, 48);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(161, 43);
            btnLogout.TabIndex = 22;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // RoomMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1167, 696);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnBillingRecords);
            Controls.Add(btnReservationRecords);
            Controls.Add(btnGuestRecords);
            Controls.Add(btnRoomsMaintenance);
            Name = "RoomMaintenance";
            Text = "RoomMaintenance";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
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
        private Button btnLogout;
        private Panel panel2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Panel panel3;
        private Label label10;
        private ComboBox cmbRoomStatus;
        private TextBox txtRoomRate;
        private ComboBox cmbRoomType;
        private TextBox txtRoomNumber;
        private Button btnDeleteRoomType;
        private Button btnEditRoomType;
        private Button btnAddRoomType;
        private TextBox txtRoomTypeRate;
        private TextBox txtRoomTypeName;
        private Label label11;
        private Button btnEditRoom;
        private Button btnClearRoom;
        private Button btnDeleteRoom;
        private Button btnAddRoom;
        private Panel panel5;
        private DataGridView dgvRoomTypes;
        private Button btnClearRoomType;
        private Panel panel4;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
    }
}