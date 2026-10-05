namespace HotelReservation
{
    partial class frmLogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1048, 269);
            label1.Name = "label1";
            label1.Size = new Size(473, 83);
            label1.TabIndex = 0;
            label1.Text = "Reserve Now!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.c8310782fe7a63a7a5851e8c22f3d7ce;
            pictureBox1.Location = new Point(-3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(752, 1038);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(1084, 425);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(1084, 542);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 16.2F);
            txtUsername.Location = new Point(1084, 456);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(399, 43);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 16.2F);
            txtPassword.Location = new Point(1084, 573);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(399, 43);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.Location = new Point(1173, 707);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(215, 57);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // frmLogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OliveDrab;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "frmLogIn";
            Text = "Login Page";
            Load += frmLogIn_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}
