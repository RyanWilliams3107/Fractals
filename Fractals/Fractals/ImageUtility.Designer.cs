namespace Fractals
{
    partial class ImageUtility
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
            this.Start = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.AmountOfImages = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.AmountOfImages)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.Start.Location = new System.Drawing.Point(61, 51);
            this.Start.Name = "button1";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(9, 9);
            this.Label.Name = "label1";
            this.Label.Size = new System.Drawing.Size(188, 13);
            this.Label.TabIndex = 1;
            this.Label.Text = "Number of frames to render. (MAX: 15)\r\n";
            // 
            // numericUpDown1
            // 
            this.AmountOfImages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmountOfImages.Location = new System.Drawing.Point(12, 25);
            this.AmountOfImages.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.AmountOfImages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmountOfImages.Name = "numericUpDown1";
            this.AmountOfImages.Size = new System.Drawing.Size(185, 16);
            this.AmountOfImages.TabIndex = 2;
            this.AmountOfImages.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ImageUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 79);
            this.Controls.Add(this.AmountOfImages);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageUtility";
            this.Text = "ImageUtility";
            this.Load += new System.EventHandler(this.ImageUtility_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AmountOfImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.NumericUpDown AmountOfImages;
    }
}