namespace Fractals
{
    partial class JuliaSet
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
            this.Generate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.zoom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IterationsTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CImagTb = new System.Windows.Forms.TextBox();
            this.CRealTb = new System.Windows.Forms.TextBox();
            this.YDispTB = new System.Windows.Forms.TextBox();
            this.XDispTB = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RenderProgress = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.ZExpTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CExpTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(8, 45);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(103, 62);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CExpTB);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ZExpTB);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.zoom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.IterationsTB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CImagTb);
            this.groupBox1.Controls.Add(this.CRealTb);
            this.groupBox1.Controls.Add(this.YDispTB);
            this.groupBox1.Controls.Add(this.XDispTB);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 253);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alterations";
            // 
            // zoom
            // 
            this.zoom.Location = new System.Drawing.Point(8, 155);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(100, 20);
            this.zoom.TabIndex = 11;
            this.zoom.Text = "0.90";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Zoom Scale";
            // 
            // IterationsTB
            // 
            this.IterationsTB.Location = new System.Drawing.Point(7, 128);
            this.IterationsTB.Name = "IterationsTB";
            this.IterationsTB.Size = new System.Drawing.Size(100, 20);
            this.IterationsTB.TabIndex = 9;
            this.IterationsTB.Text = "255";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Max Iterations";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "C Y Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "C X Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y Disposition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X Disposition";
            // 
            // CImagTb
            // 
            this.CImagTb.Location = new System.Drawing.Point(7, 101);
            this.CImagTb.Name = "CImagTb";
            this.CImagTb.Size = new System.Drawing.Size(100, 20);
            this.CImagTb.TabIndex = 3;
            this.CImagTb.Text = "0.27015";
            // 
            // CRealTb
            // 
            this.CRealTb.Location = new System.Drawing.Point(7, 74);
            this.CRealTb.Name = "CRealTb";
            this.CRealTb.Size = new System.Drawing.Size(100, 20);
            this.CRealTb.TabIndex = 2;
            this.CRealTb.Text = "-0.7";
            // 
            // YDispTB
            // 
            this.YDispTB.Location = new System.Drawing.Point(7, 47);
            this.YDispTB.Name = "YDispTB";
            this.YDispTB.Size = new System.Drawing.Size(100, 20);
            this.YDispTB.TabIndex = 1;
            this.YDispTB.Text = "1.10";
            // 
            // XDispTB
            // 
            this.XDispTB.Location = new System.Drawing.Point(7, 20);
            this.XDispTB.Name = "XDispTB";
            this.XDispTB.Size = new System.Drawing.Size(100, 20);
            this.XDispTB.TabIndex = 0;
            this.XDispTB.Text = "1.60";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(20, 19);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save Image";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Generate);
            this.groupBox2.Controls.Add(this.Save);
            this.groupBox2.Location = new System.Drawing.Point(13, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 113);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buttons";
            // 
            // RenderProgress
            // 
            this.RenderProgress.Location = new System.Drawing.Point(13, 272);
            this.RenderProgress.Name = "RenderProgress";
            this.RenderProgress.Size = new System.Drawing.Size(200, 24);
            this.RenderProgress.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Z Exponent";
            // 
            // textBox1
            // 
            this.ZExpTB.Location = new System.Drawing.Point(7, 181);
            this.ZExpTB.Name = "textBox1";
            this.ZExpTB.Size = new System.Drawing.Size(100, 20);
            this.ZExpTB.TabIndex = 13;
            this.ZExpTB.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "C Exponent";
            // 
            // textBox2
            // 
            this.CExpTB.Location = new System.Drawing.Point(7, 212);
            this.CExpTB.Name = "textBox2";
            this.CExpTB.Size = new System.Drawing.Size(100, 20);
            this.CExpTB.TabIndex = 15;
            this.CExpTB.Text = "0";
            // 
            // JuliaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 600);
            this.Controls.Add(this.RenderProgress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JuliaSet";
            this.Text = "JuliaSet";
            this.Load += new System.EventHandler(this.JuliaSet_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.JuliaSet_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CImagTb;
        private System.Windows.Forms.TextBox CRealTb;
        private System.Windows.Forms.TextBox YDispTB;
        private System.Windows.Forms.TextBox XDispTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IterationsTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox zoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar RenderProgress;
        private System.Windows.Forms.TextBox CExpTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ZExpTB;
        private System.Windows.Forms.Label label7;
    }
}