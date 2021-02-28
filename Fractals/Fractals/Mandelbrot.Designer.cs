using System.Windows.Forms;

namespace Fractals
{
    partial class Mandelbrot : Form
    {
        private System.ComponentModel.IContainer components = null;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        public void InitializeComponent()
        {
            this.RenderButton = new System.Windows.Forms.Button();
            this.GenerateLabel = new System.Windows.Forms.Label();
            this.IterationsLabel = new System.Windows.Forms.Label();
            this.IterationsTextbox = new System.Windows.Forms.TextBox();
            this.ControlsGroupbox = new System.Windows.Forms.GroupBox();
            this.IterScroll = new System.Windows.Forms.TrackBar();
            this.ZExpLabel = new System.Windows.Forms.Label();
            this.CExponentBox = new System.Windows.Forms.NumericUpDown();
            this.CExponentLabel = new System.Windows.Forms.Label();
            this.ZExponentBox = new System.Windows.Forms.NumericUpDown();
            this.DrawJuliaSetEnabled = new System.Windows.Forms.CheckBox();
            this.ZoomInEnabled = new System.Windows.Forms.CheckBox();
            this.ZoomScaleTextBox = new System.Windows.Forms.TextBox();
            this.ZoomTextBox = new System.Windows.Forms.Label();
            this.Greyscale = new System.Windows.Forms.CheckBox();
            this.UndoButton = new System.Windows.Forms.Button();
            this.TimeElapsedLabel = new System.Windows.Forms.Label();
            this.XMaxLabel = new System.Windows.Forms.Label();
            this.XMinLabel = new System.Windows.Forms.Label();
            this.YMaxLabel = new System.Windows.Forms.Label();
            this.YMinLabel = new System.Windows.Forms.Label();
            this.RedoButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BlackAndWhite = new System.Windows.Forms.CheckBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.RenderProgress = new System.Windows.Forms.ProgressBar();
            this.CoordLabel = new System.Windows.Forms.Label();
            this.XCoordLabel = new System.Windows.Forms.Label();
            this.YCoordLabel = new System.Windows.Forms.Label();
            this.ZoomButton = new System.Windows.Forms.Button();
            this.FillButton = new System.Windows.Forms.Button();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.LoadLabel = new System.Windows.Forms.Label();
            this.StateDropDown = new System.Windows.Forms.ComboBox();
            this.SaveStateButton = new System.Windows.Forms.Button();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.PressEnterLabel = new System.Windows.Forms.Label();
            this.ControlsGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IterScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CExponentBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZExponentBox)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RenderButton
            // 
            this.RenderButton.Location = new System.Drawing.Point(6, 50);
            this.RenderButton.Name = "RenderButton";
            this.RenderButton.Size = new System.Drawing.Size(148, 62);
            this.RenderButton.TabIndex = 0;
            this.RenderButton.Text = "Generate";
            this.RenderButton.UseVisualStyleBackColor = true;
            this.RenderButton.Click += new System.EventHandler(this.RenderButton_Click);
            // 
            // GenerateLabel
            // 
            this.GenerateLabel.AutoSize = true;
            this.GenerateLabel.Location = new System.Drawing.Point(3, 28);
            this.GenerateLabel.Name = "GenerateLabel";
            this.GenerateLabel.Size = new System.Drawing.Size(57, 13);
            this.GenerateLabel.TabIndex = 1;
            this.GenerateLabel.Text = "Generate: ";
            // 
            // IterationsLabel
            // 
            this.IterationsLabel.AutoSize = true;
            this.IterationsLabel.Location = new System.Drawing.Point(166, 28);
            this.IterationsLabel.Name = "IterationsLabel";
            this.IterationsLabel.Size = new System.Drawing.Size(97, 13);
            this.IterationsLabel.TabIndex = 2;
            this.IterationsLabel.Text = "Maximum Iterations";
            // 
            // IterationsTextbox
            // 
            this.IterationsTextbox.Location = new System.Drawing.Point(169, 72);
            this.IterationsTextbox.Name = "IterationsTextbox";
            this.IterationsTextbox.Size = new System.Drawing.Size(94, 20);
            this.IterationsTextbox.TabIndex = 3;
            this.IterationsTextbox.Text = "50";
            // 
            // ControlsGroupbox
            // 
            this.ControlsGroupbox.Controls.Add(this.IterScroll);
            this.ControlsGroupbox.Controls.Add(this.ZExpLabel);
            this.ControlsGroupbox.Controls.Add(this.CExponentBox);
            this.ControlsGroupbox.Controls.Add(this.CExponentLabel);
            this.ControlsGroupbox.Controls.Add(this.ZExponentBox);
            this.ControlsGroupbox.Controls.Add(this.DrawJuliaSetEnabled);
            this.ControlsGroupbox.Controls.Add(this.ZoomInEnabled);
            this.ControlsGroupbox.Controls.Add(this.ZoomScaleTextBox);
            this.ControlsGroupbox.Controls.Add(this.ZoomTextBox);
            this.ControlsGroupbox.Controls.Add(this.RenderButton);
            this.ControlsGroupbox.Controls.Add(this.GenerateLabel);
            this.ControlsGroupbox.Controls.Add(this.IterationsLabel);
            this.ControlsGroupbox.Controls.Add(this.IterationsTextbox);
            this.ControlsGroupbox.Location = new System.Drawing.Point(1, 461);
            this.ControlsGroupbox.Name = "ControlsGroupbox";
            this.ControlsGroupbox.Size = new System.Drawing.Size(608, 163);
            this.ControlsGroupbox.TabIndex = 6;
            this.ControlsGroupbox.TabStop = false;
            this.ControlsGroupbox.Text = "Controls";
            // 
            // trackBar1
            // 
            this.IterScroll.Location = new System.Drawing.Point(169, 98);
            this.IterScroll.Maximum = 1000;
            this.IterScroll.Name = "trackBar1";
            this.IterScroll.Size = new System.Drawing.Size(89, 45);
            this.IterScroll.TabIndex = 23;
            this.IterScroll.Value = 50;
            this.IterScroll.Scroll += new System.EventHandler(this.IterScroll_Scroll);
            // 
            // ZExpLabel
            // 
            this.ZExpLabel.AutoSize = true;
            this.ZExpLabel.Location = new System.Drawing.Point(342, 27);
            this.ZExpLabel.Name = "ZExpLabel";
            this.ZExpLabel.Size = new System.Drawing.Size(77, 13);
            this.ZExpLabel.TabIndex = 22;
            this.ZExpLabel.Text = "Exponent for Z";
            // 
            // CExponentBox
            // 
            this.CExponentBox.Location = new System.Drawing.Point(428, 72);
            this.CExponentBox.Name = "CExponentBox";
            this.CExponentBox.Size = new System.Drawing.Size(77, 20);
            this.CExponentBox.TabIndex = 21;
            // 
            // CExponentLabel
            // 
            this.CExponentLabel.AutoSize = true;
            this.CExponentLabel.Location = new System.Drawing.Point(425, 28);
            this.CExponentLabel.Name = "CExponentLabel";
            this.CExponentLabel.Size = new System.Drawing.Size(77, 13);
            this.CExponentLabel.TabIndex = 12;
            this.CExponentLabel.Text = "Exponent for C";
            // 
            // ZExponentBox
            // 
            this.ZExponentBox.AutoSize = true;
            this.ZExponentBox.Location = new System.Drawing.Point(342, 71);
            this.ZExponentBox.Name = "ZExponentBox";
            this.ZExponentBox.Size = new System.Drawing.Size(80, 20);
            this.ZExponentBox.TabIndex = 11;
            this.ZExponentBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // DrawJuliaSetEnabled
            // 
            this.DrawJuliaSetEnabled.AutoSize = true;
            this.DrawJuliaSetEnabled.Location = new System.Drawing.Point(507, 50);
            this.DrawJuliaSetEnabled.Name = "DrawJuliaSetEnabled";
            this.DrawJuliaSetEnabled.Size = new System.Drawing.Size(96, 17);
            this.DrawJuliaSetEnabled.TabIndex = 9;
            this.DrawJuliaSetEnabled.Text = "Make Julia Set";
            this.DrawJuliaSetEnabled.UseVisualStyleBackColor = true;
            // 
            // ZoomInEnabled
            // 
            this.ZoomInEnabled.AutoSize = true;
            this.ZoomInEnabled.Location = new System.Drawing.Point(508, 27);
            this.ZoomInEnabled.Name = "ZoomInEnabled";
            this.ZoomInEnabled.Size = new System.Drawing.Size(95, 17);
            this.ZoomInEnabled.TabIndex = 8;
            this.ZoomInEnabled.Text = "Zoom Enabled";
            this.ZoomInEnabled.UseVisualStyleBackColor = true;
            // 
            // ZoomScaleTextBox
            // 
            this.ZoomScaleTextBox.Location = new System.Drawing.Point(269, 71);
            this.ZoomScaleTextBox.Name = "ZoomScaleTextBox";
            this.ZoomScaleTextBox.Size = new System.Drawing.Size(61, 20);
            this.ZoomScaleTextBox.TabIndex = 7;
            this.ZoomScaleTextBox.Text = "7";
            // 
            // ZoomTextBox
            // 
            this.ZoomTextBox.AutoSize = true;
            this.ZoomTextBox.Location = new System.Drawing.Point(269, 28);
            this.ZoomTextBox.Name = "ZoomTextBox";
            this.ZoomTextBox.Size = new System.Drawing.Size(64, 13);
            this.ZoomTextBox.TabIndex = 6;
            this.ZoomTextBox.Text = "Zoom Scale";
            // 
            // Greyscale
            // 
            this.Greyscale.AutoSize = true;
            this.Greyscale.Location = new System.Drawing.Point(0, 313);
            this.Greyscale.Name = "Greyscale";
            this.Greyscale.Size = new System.Drawing.Size(73, 17);
            this.Greyscale.TabIndex = 7;
            this.Greyscale.Text = "Greyscale";
            this.Greyscale.UseVisualStyleBackColor = true;
            this.Greyscale.CheckedChanged += new System.EventHandler(this.Greyscale_CheckedChanged);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(97, 43);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 8;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // TimeElapsedLabel
            // 
            this.TimeElapsedLabel.AutoSize = true;
            this.TimeElapsedLabel.Location = new System.Drawing.Point(0, 333);
            this.TimeElapsedLabel.Name = "TimeElapsedLabel";
            this.TimeElapsedLabel.Size = new System.Drawing.Size(72, 13);
            this.TimeElapsedLabel.TabIndex = 9;
            this.TimeElapsedLabel.Text = "Elapsed: 0:00";
            // 
            // XMaxLabel
            // 
            this.XMaxLabel.AutoSize = true;
            this.XMaxLabel.Location = new System.Drawing.Point(3, 180);
            this.XMaxLabel.Name = "XMaxLabel";
            this.XMaxLabel.Size = new System.Drawing.Size(38, 13);
            this.XMaxLabel.TabIndex = 10;
            this.XMaxLabel.Text = "xMax: ";
            // 
            // XMinLabel
            // 
            this.XMinLabel.AutoSize = true;
            this.XMinLabel.Location = new System.Drawing.Point(3, 193);
            this.XMinLabel.Name = "XMinLabel";
            this.XMinLabel.Size = new System.Drawing.Size(35, 13);
            this.XMinLabel.TabIndex = 11;
            this.XMinLabel.Text = "xMin: ";
            // 
            // YMaxLabel
            // 
            this.YMaxLabel.AutoSize = true;
            this.YMaxLabel.Location = new System.Drawing.Point(3, 154);
            this.YMaxLabel.Name = "YMaxLabel";
            this.YMaxLabel.Size = new System.Drawing.Size(38, 13);
            this.YMaxLabel.TabIndex = 12;
            this.YMaxLabel.Text = "yMax: ";
            // 
            // YMinLabel
            // 
            this.YMinLabel.AutoSize = true;
            this.YMinLabel.Location = new System.Drawing.Point(3, 167);
            this.YMinLabel.Name = "YMinLabel";
            this.YMinLabel.Size = new System.Drawing.Size(35, 13);
            this.YMinLabel.TabIndex = 13;
            this.YMinLabel.Text = "yMin: ";
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(11, 43);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(75, 23);
            this.RedoButton.TabIndex = 14;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(11, 72);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save Image";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BlackAndWhite
            // 
            this.BlackAndWhite.AutoSize = true;
            this.BlackAndWhite.Location = new System.Drawing.Point(0, 290);
            this.BlackAndWhite.Name = "BlackAndWhite";
            this.BlackAndWhite.Size = new System.Drawing.Size(105, 17);
            this.BlackAndWhite.TabIndex = 16;
            this.BlackAndWhite.Text = "Black and White";
            this.BlackAndWhite.UseVisualStyleBackColor = true;
            this.BlackAndWhite.CheckedChanged += new System.EventHandler(this.BlackAndWhite_CheckedChanged);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(11, 14);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(161, 23);
            this.ResetButton.TabIndex = 17;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // RenderProgress
            // 
            this.RenderProgress.Location = new System.Drawing.Point(0, 261);
            this.RenderProgress.Name = "RenderProgress";
            this.RenderProgress.Size = new System.Drawing.Size(172, 23);
            this.RenderProgress.TabIndex = 18;
            // 
            // CoordLabel
            // 
            this.CoordLabel.AutoSize = true;
            this.CoordLabel.Location = new System.Drawing.Point(3, 219);
            this.CoordLabel.Name = "CoordLabel";
            this.CoordLabel.Size = new System.Drawing.Size(163, 13);
            this.CoordLabel.TabIndex = 21;
            this.CoordLabel.Text = "Screen Coordinatess for Julia Set";
            // 
            // XCoordLabel
            // 
            this.XCoordLabel.AutoSize = true;
            this.XCoordLabel.Location = new System.Drawing.Point(3, 232);
            this.XCoordLabel.Name = "XCoordLabel";
            this.XCoordLabel.Size = new System.Drawing.Size(20, 13);
            this.XCoordLabel.TabIndex = 22;
            this.XCoordLabel.Text = "X: ";
            // 
            // YCoordLabel
            // 
            this.YCoordLabel.AutoSize = true;
            this.YCoordLabel.Location = new System.Drawing.Point(3, 245);
            this.YCoordLabel.Name = "YCoordLabel";
            this.YCoordLabel.Size = new System.Drawing.Size(20, 13);
            this.YCoordLabel.TabIndex = 23;
            this.YCoordLabel.Text = "Y: ";
            // 
            // ZoomButton
            // 
            this.ZoomButton.Enabled = false;
            this.ZoomButton.Location = new System.Drawing.Point(97, 72);
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Size = new System.Drawing.Size(75, 23);
            this.ZoomButton.TabIndex = 24;
            this.ZoomButton.Text = "Zoom";
            this.ZoomButton.UseVisualStyleBackColor = true;
            this.ZoomButton.Click += new System.EventHandler(this.ZoomButton_Click);
            // 
            // FillButton
            // 
            this.FillButton.Location = new System.Drawing.Point(11, 128);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(161, 23);
            this.FillButton.TabIndex = 25;
            this.FillButton.Text = "Start Filling Zoom Queue";
            this.FillButton.UseVisualStyleBackColor = true;
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.LoadLabel);
            this.ControlsPanel.Controls.Add(this.StateDropDown);
            this.ControlsPanel.Controls.Add(this.SaveStateButton);
            this.ControlsPanel.Controls.Add(this.BlackAndWhite);
            this.ControlsPanel.Controls.Add(this.RenderProgress);
            this.ControlsPanel.Controls.Add(this.Greyscale);
            this.ControlsPanel.Controls.Add(this.SaveButton);
            this.ControlsPanel.Controls.Add(this.ZoomButton);
            this.ControlsPanel.Controls.Add(this.FillButton);
            this.ControlsPanel.Controls.Add(this.ResetButton);
            this.ControlsPanel.Controls.Add(this.RedoButton);
            this.ControlsPanel.Controls.Add(this.CoordLabel);
            this.ControlsPanel.Controls.Add(this.YCoordLabel);
            this.ControlsPanel.Controls.Add(this.UndoButton);
            this.ControlsPanel.Controls.Add(this.XCoordLabel);
            this.ControlsPanel.Controls.Add(this.TimeElapsedLabel);
            this.ControlsPanel.Controls.Add(this.XMaxLabel);
            this.ControlsPanel.Controls.Add(this.XMinLabel);
            this.ControlsPanel.Controls.Add(this.YMaxLabel);
            this.ControlsPanel.Controls.Add(this.YMinLabel);
            this.ControlsPanel.Location = new System.Drawing.Point(1, 12);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(175, 414);
            this.ControlsPanel.TabIndex = 26;
            // 
            // LoadLabel
            // 
            this.LoadLabel.AutoSize = true;
            this.LoadLabel.Location = new System.Drawing.Point(3, 353);
            this.LoadLabel.Name = "LoadLabel";
            this.LoadLabel.Size = new System.Drawing.Size(98, 13);
            this.LoadLabel.TabIndex = 29;
            this.LoadLabel.Text = "Load Saved States";
            // 
            // StateDropDown
            // 
            this.StateDropDown.FormattingEnabled = true;
            this.StateDropDown.Location = new System.Drawing.Point(6, 369);
            this.StateDropDown.Name = "StateDropDown";
            this.StateDropDown.Size = new System.Drawing.Size(95, 21);
            this.StateDropDown.TabIndex = 28;
            this.StateDropDown.SelectedIndexChanged += new System.EventHandler(this.StateDropDown_SelectedIndexChanged);
            // 
            // SaveStateButton
            // 
            this.SaveStateButton.Location = new System.Drawing.Point(11, 101);
            this.SaveStateButton.Name = "SaveStateButton";
            this.SaveStateButton.Size = new System.Drawing.Size(161, 23);
            this.SaveStateButton.TabIndex = 26;
            this.SaveStateButton.Text = "Save State";
            this.SaveStateButton.UseVisualStyleBackColor = true;
            this.SaveStateButton.Click += new System.EventHandler(this.SaveStateButton_Click);
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Location = new System.Drawing.Point(183, 13);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(136, 13);
            this.InformationLabel.TabIndex = 27;
            this.InformationLabel.Text = "K: Show / Hide all controls.";
            // 
            // PressEnterLabel
            // 
            this.PressEnterLabel.AutoSize = true;
            this.PressEnterLabel.Location = new System.Drawing.Point(186, 30);
            this.PressEnterLabel.Name = "PressEnterLabel";
            this.PressEnterLabel.Size = new System.Drawing.Size(73, 13);
            this.PressEnterLabel.TabIndex = 28;
            this.PressEnterLabel.Text = "Enter: Render";
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 624);
            this.Controls.Add(this.PressEnterLabel);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.ControlsGroupbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Mandelbrot";
            this.Tag = "Mandelbrot";
            this.Text = "Mandelbrot";
            this.Load += new System.EventHandler(this.Mandelbrot_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Mandelbrot_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseClickOnForm);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mandelbrot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpOnForm);
            this.ControlsGroupbox.ResumeLayout(false);
            this.ControlsGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IterScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CExponentBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZExponentBox)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button RenderButton;
        private Label GenerateLabel;
        private Label IterationsLabel;
        private TextBox IterationsTextbox;
        private GroupBox ControlsGroupbox;
        private CheckBox Greyscale;
        private Button UndoButton;
        private Label TimeElapsedLabel;
        private Label ZoomTextBox;
        private TextBox ZoomScaleTextBox;
        private Label XMaxLabel;
        private Label XMinLabel;
        private Label YMaxLabel;
        private Label YMinLabel;
        private Button RedoButton;
        private Button SaveButton;
        private CheckBox BlackAndWhite;
        private Button ResetButton;
        private ProgressBar RenderProgress;
        private CheckBox DrawJuliaSetEnabled;
        private CheckBox ZoomInEnabled;        
        private Label CExponentLabel;
        private NumericUpDown CExponentBox;
        private NumericUpDown ZExponentBox;
        private Label CoordLabel;
        private Label XCoordLabel;
        private Label YCoordLabel;
        public Button ZoomButton;
        private Button FillButton;
        private Panel ControlsPanel;
        private Label InformationLabel;
        private Button SaveStateButton;
        private ComboBox StateDropDown;
        private Label ZExpLabel;
        private Label PressEnterLabel;
        private Label LoadLabel;
        private TrackBar IterScroll;



    }
}
