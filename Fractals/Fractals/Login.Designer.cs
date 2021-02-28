namespace Fractals
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.UNameTextBox = new System.Windows.Forms.TextBox();
            this.PWordTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Accept = new System.Windows.Forms.PictureBox();
            this.NewUser = new System.Windows.Forms.PictureBox();
            this.Quit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quit)).BeginInit();
            this.SuspendLayout();
            // 
            // UNameTextBox
            // 
            this.UNameTextBox.BackColor = System.Drawing.Color.White;
            this.UNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UNameTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.UNameTextBox.Location = new System.Drawing.Point(68, 36);
            this.UNameTextBox.Name = "UNameTextBox";
            this.UNameTextBox.Size = new System.Drawing.Size(154, 28);
            this.UNameTextBox.TabIndex = 2;
            this.UNameTextBox.Text = "User name";
            // 
            // PWordTextBox
            // 
            this.PWordTextBox.BackColor = System.Drawing.Color.White;
            this.PWordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PWordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PWordTextBox.Location = new System.Drawing.Point(68, 114);
            this.PWordTextBox.Name = "PWordTextBox";
            this.PWordTextBox.PasswordChar = '*';
            this.PWordTextBox.Size = new System.Drawing.Size(171, 28);
            this.PWordTextBox.TabIndex = 3;
            this.PWordTextBox.Text = "password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 48);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 48);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Accept
            // 
            this.Accept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Accept.BackgroundImage")));
            this.Accept.Image = ((System.Drawing.Image)(resources.GetObject("Accept.Image")));
            this.Accept.Location = new System.Drawing.Point(12, 168);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(50, 48);
            this.Accept.TabIndex = 8;
            this.Accept.TabStop = false;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // newuser
            // 
            this.NewUser.Image = ((System.Drawing.Image)(resources.GetObject("newuser.Image")));
            this.NewUser.Location = new System.Drawing.Point(108, 168);
            this.NewUser.Name = "newuser";
            this.NewUser.Size = new System.Drawing.Size(50, 48);
            this.NewUser.TabIndex = 9;
            this.NewUser.TabStop = false;
            this.NewUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // pictureBox3
            // 
            this.Quit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.Quit.Location = new System.Drawing.Point(205, 168);
            this.Quit.Name = "pictureBox3";
            this.Quit.Size = new System.Drawing.Size(50, 48);
            this.Quit.TabIndex = 10;
            this.Quit.TabStop = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(267, 233);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.NewUser);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PWordTextBox);
            this.Controls.Add(this.UNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UNameTextBox;
        private System.Windows.Forms.TextBox PWordTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox Accept;
        private System.Windows.Forms.PictureBox NewUser;
        private System.Windows.Forms.PictureBox Quit;
    }
}