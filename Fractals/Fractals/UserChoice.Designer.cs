namespace Fractals
{
    partial class UserChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserChoice));
            this.Mandelbrot = new System.Windows.Forms.PictureBox();
            this.JuliaSet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Mandelbrot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JuliaSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.Mandelbrot.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.Mandelbrot.Location = new System.Drawing.Point(-6, -2);
            this.Mandelbrot.Name = "pictureBox1";
            this.Mandelbrot.Size = new System.Drawing.Size(476, 310);
            this.Mandelbrot.TabIndex = 3;
            this.Mandelbrot.TabStop = false;
            this.Mandelbrot.Click += new System.EventHandler(this.Mandelbrot_Click);
            // 
            // pictureBox2
            // 
            this.JuliaSet.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.JuliaSet.Location = new System.Drawing.Point(-6, 296);
            this.JuliaSet.Name = "pictureBox2";
            this.JuliaSet.Size = new System.Drawing.Size(476, 310);
            this.JuliaSet.TabIndex = 4;
            this.JuliaSet.TabStop = false;
            this.JuliaSet.Click += new System.EventHandler(this.JuliaSet_Click);
            // 
            // UserChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 593);
            this.Controls.Add(this.JuliaSet);
            this.Controls.Add(this.Mandelbrot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserChoice";
            ((System.ComponentModel.ISupportInitialize)(this.Mandelbrot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JuliaSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Mandelbrot;
        private System.Windows.Forms.PictureBox JuliaSet;
    }
}