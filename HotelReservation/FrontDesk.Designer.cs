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
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label3 = new Label();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1398, 128);
            label2.Name = "label2";
            label2.Size = new Size(169, 38);
            label2.TabIndex = 1;
            label2.Text = "Front Desk:";
            // 
            // button1
            // 
            button1.BackColor = Color.OliveDrab;
            button1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(79, 208);
            button1.Name = "button1";
            button1.Size = new Size(364, 82);
            button1.TabIndex = 2;
            button1.Text = "Guests";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.OliveDrab;
            button2.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(79, 312);
            button2.Name = "button2";
            button2.Size = new Size(364, 81);
            button2.TabIndex = 3;
            button2.Text = "Availability";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.OliveDrab;
            button3.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(79, 417);
            button3.Name = "button3";
            button3.Size = new Size(364, 92);
            button3.TabIndex = 4;
            button3.Text = "Reservation";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.OliveDrab;
            button4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(79, 539);
            button4.Name = "button4";
            button4.Size = new Size(364, 90);
            button4.TabIndex = 5;
            button4.Text = "Reservation Status";
            button4.UseVisualStyleBackColor = false;
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
            // button7
            // 
            button7.BackColor = Color.OliveDrab;
            button7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button7.Location = new Point(1714, 122);
            button7.Name = "button7";
            button7.Size = new Size(148, 49);
            button7.TabIndex = 8;
            button7.Text = "Logout";
            button7.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1564, 128);
            label3.Name = "label3";
            label3.Size = new Size(144, 38);
            label3.TabIndex = 9;
            label3.Text = "frontdesk";
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
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnBack);
            Name = "FrontDesk";
            Text = "FrontDesk";
            Load += FrontDesk_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label3;
        private Panel panel1;
    }
}