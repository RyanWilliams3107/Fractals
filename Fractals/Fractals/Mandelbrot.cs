using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Text;

namespace Fractals
{

    public partial class Mandelbrot : Form
    {
        private ComplexNumber ZoomCoordinate1 = new ComplexNumber(-1, 1);
        private ComplexNumber ZoomCoordinate2 = new ComplexNumber(-2.5, 1);
        private double MinimumXValue = -2.5;
        private double MinimumYValue = -1.0;
        private double MaximumXValue = 1.0;
        private double MaximumYValue = 1.0;
        private int MaximumIterations = 250;
        private int ZoomScale = 5;
        private bool ControlsHidden = false;
        private bool IsConverterInitialized = false;
        private double IterationsScaleFactor = 2;
        private Graphics GraphicsObject;
        private Bitmap FractalCanvas;
        private double XCoord;
        private double YCoord;    
        private Conversions Converter;
        private string ComputerUserName;
        private const int BITMAP_WIDTH = 983;
        private const int BITMAP_HEIGHT = 624;
        private int ClientHeight;
        private int ClientWidth;
        private string rName = null;
        private Stack<MandelbrotData> UndoData = new Stack<MandelbrotData>();
        private Stack<MandelbrotData> RedoData = new Stack<MandelbrotData>();
        public Queue<Bitmap> QueueOfImages = new Queue<Bitmap>();

        public ComplexNumber ZoomOne
        {
            get
            {
                return this.ZoomCoordinate1;
            }
            set
            {
                this.ZoomCoordinate1 = value;
            }
        }
        public ComplexNumber ZoomTwo
        {
            get
            {
                return this.ZoomCoordinate2;
            }
            set
            {
                this.ZoomCoordinate2 = value;
            }
        }
        public double MinX
        {
            get
            {
                return this.MinimumXValue;
            }
            set
            {
                this.MinimumXValue = value;
            }
        }
        public double MaxX
        {
            get
            {
                return this.MaximumXValue;
            }
            set
            {
                this.MaximumXValue = value;
            }
        }
        public double MinY
        {
            get
            {
                return this.MinimumYValue;
            }
            set
            {
                this.MinimumYValue = value;
            }
        }
        public double MaxY
        {
            get
            {
                return this.MaximumYValue;
            }
            set
            {
                this.MaximumYValue = value;
            }
        }
        public Bitmap Canvas
        {
            get
            {
                return this.FractalCanvas;
            }
            set
            {
                this.FractalCanvas = value;
            }
        }
        public Mandelbrot(string fName)
        {
            if (fName != "guest")
            {
                this.rName = fName;
                int startIndex = 0;
                int endIndex = this.rName.LastIndexOf(@"\");
                this.rName = this.rName.Remove(startIndex, endIndex + 1);

                startIndex = this.rName.LastIndexOf(".");
                this.rName = this.rName.Remove(startIndex);
            }

            else
            {
                this.rName = fName;
            }


            InitializeComponent();
        }
        public void MBOX(string message, string caption = null)
        {
            if (caption != null)
            {
                MessageBox.Show(message, caption);
            }
            else
            {
                MBOX(message, message);
            }
        }


        public Bitmap AutoZoom(Bitmap img)
        {
            string BlackPixel = Color.FromArgb(0, 0, 0).ToString();
            string CurrentPixel;
            for (int XPixel = 0; XPixel < BITMAP_WIDTH; XPixel++)
            {
                for (int YPixel = 0; YPixel < BITMAP_HEIGHT; YPixel++)
                {

                    CurrentPixel = img.GetPixel(XPixel, YPixel).ToString();
                    if (CurrentPixel == BlackPixel)
                    {
                        int XScreenCoordinate = XPixel;
                        int YScreenCoordinate = YPixel;
                        ComplexNumber ZoomCoord1 =
                            Converter.GetAbsoluteMathsCoord(new ComplexNumber((int)(XScreenCoordinate - (BITMAP_WIDTH / (ZoomScale)) / 4),
                                                                              (int)(YScreenCoordinate - (BITMAP_HEIGHT / (ZoomScale)) / 4)));
                        ComplexNumber ZoomCoord2 =
                            Converter.GetAbsoluteMathsCoord(new ComplexNumber((int)(XScreenCoordinate + (BITMAP_WIDTH / (ZoomScale)) / 4),
                                                                              (int)(YScreenCoordinate + (BITMAP_HEIGHT / (ZoomScale)) / 4)));
                        if (ZoomCoord2.Real < ZoomCoord1.Real)
                        {
                            SwapReals(ref ZoomCoord1, ref ZoomCoord2);
                        }
                        if (ZoomCoord2.Imaginary < ZoomCoord1.Imaginary)
                        {
                            SwapImags(ref ZoomCoord1, ref ZoomCoord2);
                        }
                        double YMin = ZoomCoord1.Imaginary;
                        double YMax = ZoomCoord2.Imaginary;
                        double XMin = ZoomCoord1.Real;
                        double XMax = ZoomCoord2.Real;
                        Bitmap NewImage = this.GenerateNewImage(YMin, YMax, XMin, XMax);
                        return NewImage;
                    }
                }
            }


            throw new NullBitmapException("Cannot return image, zoomed too far");

        }

        private void SwapReals(ref ComplexNumber first, ref ComplexNumber second)
        {
            double Temp = first.Real;
            first.Real = second.Real;
            second.Real = Temp;
        }

        private void SwapImags(ref ComplexNumber first, ref ComplexNumber second)
        {
            double Temp = first.Imaginary;
            first.Imaginary = second.Imaginary;
            second.Imaginary = Temp;
        }
        public void HideAllUserControls()
        {
            ControlsPanel.Visible = false;
            ControlsGroupbox.Visible = false;
        }
        public Bitmap GenerateNewImage(double yMin, double yMax, double xMin, double xMax)
        {
            Bitmap newImage = new Bitmap(ClientWidth,
                                ClientHeight,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                );

            if (Convert.ToInt32(this.IterationsTextbox.Text) > 0)
            {
                this.MaximumIterations = Convert.ToInt32(IterationsTextbox.Text);
            }
            else
            {
                this.IterationsTextbox.Text = "50";
                this.MaximumIterations = 50;
            }

            int xyPixelStep = 1;
            bool grey = Greyscale.Checked ? true : false;
            GraphicsObject.Clear(Color.Black);

            int height = (int)GraphicsObject.VisibleClipBounds.Size.Height;
            int kLast = -1;
            Color color;
            Color colorLast = Color.Red;

            ComplexNumber screenBottomLeft = new ComplexNumber(xMin, yMin);
            ComplexNumber screenTopRight = new ComplexNumber(xMax, yMax);
            Converter = new Conversions(GraphicsObject, screenBottomLeft, screenTopRight);
            IsConverterInitialized = true;

            ComplexNumber pixelStep = new ComplexNumber(xyPixelStep, xyPixelStep);
            ComplexNumber xyStep = Converter.GetDeltaMathsCoord(pixelStep);

            int ZExponent = Convert.ToInt32(ZExponentBox.Text);
            int CExponent = Convert.ToInt32(CExponentBox.Text);

            int yPix = FractalCanvas.Height - 1;

            for (double y = yMin; y < yMax; y += xyStep.Imaginary)
            {
                int xPix = 0;
                for (double x = xMin; x < xMax; x += xyStep.Real)
                {
                    ComplexNumber CComplex = new ComplexNumber(x, y);
                    ComplexNumber ZComplex = new ComplexNumber(0.0, 0.0);
                    Tuple<int, double> IterationsNormalizedTuple = Rendering.GetEscapeIterations(ZExponent, CExponent, ZComplex, CComplex, MaximumIterations);
                    int Iterations = IterationsNormalizedTuple.Item1;
                    double Normalized = IterationsNormalizedTuple.Item2;

                    if (Iterations < MaximumIterations)
                    {
                        color = Rendering.GetColourForPixel(Iterations, MaximumIterations, kLast, colorLast, Greyscale.Checked, BlackAndWhite.Checked, Normalized);    
                        colorLast = color;
                        kLast = Iterations;
                        if ((xPix < newImage.Width) && (yPix >= 0))
                        {
                            newImage.SetPixel(xPix, yPix, color);
                        }
                    }
                    xPix += xyPixelStep;
                }
                yPix -= xyPixelStep;
            }
            IterationsTextbox.Text = Convert.ToString(Math.Round(10 + IterationsScaleFactor + Convert.ToInt32(IterationsTextbox.Text)));
            IterationsScaleFactor +=  2;
            return newImage;
        }
        public void RenderImage()
        {
            try
            {
                RenderProgress.Minimum = 0;
                RenderProgress.Maximum = 625;
                XMaxLabel.Text = Convert.ToString("xMax: " + this.MaximumXValue);
                YMaxLabel.Text = Convert.ToString("yMax: " + this.MaximumYValue);
                XMinLabel.Text = Convert.ToString("xMin: " + this.MinimumXValue);
                YMinLabel.Text = Convert.ToString("yMin: " + this.MinimumYValue);

                if (Convert.ToInt32(this.IterationsTextbox.Text) > 0)
                {
                    this.MaximumIterations = Convert.ToInt32(IterationsTextbox.Text);
                }
                else
                {
                    this.IterationsTextbox.Text = "50";
                    this.MaximumIterations = 50;
                }

                int PixelStep = 1;
                bool grey = Greyscale.Checked ? true : false;
                GraphicsObject.Clear(Color.Black);

                int height = (int)GraphicsObject.VisibleClipBounds.Size.Height;
                int LastIteration = -1;

                Color Colour;
                Color LastColour = Color.Red;

                ComplexNumber BottomLeft = new ComplexNumber(MinimumXValue, MinimumYValue);
                ComplexNumber TopRight = new ComplexNumber(MaximumXValue, MaximumYValue);
                Converter = new Conversions(GraphicsObject, BottomLeft, TopRight);

                IsConverterInitialized = true;
                ComplexNumber pixel_step = new ComplexNumber(PixelStep, PixelStep);
                ComplexNumber Step = Converter.GetDeltaMathsCoord(pixel_step);

                Stopwatch RenderTimer = new Stopwatch();
                RenderTimer.Start();

                int ZExponent = Convert.ToInt32(ZExponentBox.Value);
                int CExponent = Convert.ToInt32(CExponentBox.Value);
                int line_number = 0;
                int yPixel = FractalCanvas.Height - 1;
                for (double YRange = MinimumYValue; YRange < MaximumYValue; YRange += Step.Imaginary)
                {
                    int xPixel = 0;
                    for (double XRange = MinimumXValue; XRange < MaximumXValue; XRange += Step.Real)
                    {
                        ComplexNumber CComplex = new ComplexNumber(XRange, YRange);
                        ComplexNumber ZComplex = new ComplexNumber(0.0, 0.0);
                        Tuple<int, double> IterationsNormalizedTuple = Rendering.GetEscapeIterations(ZExponent, CExponent, ZComplex, CComplex, MaximumIterations);

                        int Iterations = IterationsNormalizedTuple.Item1;
                        double Normalized = IterationsNormalizedTuple.Item2;
                        if (Iterations < MaximumIterations)
                        {
                            Colour = Rendering.GetColourForPixel(Iterations, MaximumIterations, LastIteration, LastColour, Greyscale.Checked, BlackAndWhite.Checked, Normalized);
                            LastColour = Colour;
                            LastIteration = Iterations;
                            if ((xPixel < FractalCanvas.Width) && (yPixel >= 0))
                            {
                                FractalCanvas.SetPixel(xPixel, yPixel, Colour);
                            }

                        }
                        xPixel += PixelStep;
                    }
                    yPixel -= PixelStep;

                    line_number++;
                    if ((line_number % 120) == 0)
                    {

                        Refresh();
                    }
                    if ((line_number % 240) == 0)
                    {
                        try
                        {
                            RenderProgress.Value = line_number;
                        }
                        catch (Exception)
                        {
                            RenderProgress.Value = 0;
                        }
                    }
                }
                RenderProgress.Value = line_number;

                Refresh();
                UndoData.Push(new MandelbrotData(MaximumIterations, ZoomScale, grey, BlackAndWhite.Checked, MinimumXValue, MaximumXValue, MinimumYValue, MaximumYValue, ZExponent, CExponent));

                RenderTimer.Stop();

                TimeElapsedLabel.Text = "Elapsed: " + RenderTimer.Elapsed.Seconds + "." + RenderTimer.Elapsed.Milliseconds + " seconds.";
                RenderProgress.Value = 0;
            }
            catch (Exception e2)
            {
                MessageBox.Show("Exception Trapped: " + e2.Message, "Error");
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch (Exception exc)
            {
                MBOX(exc.Message);

            }
        }
        public void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            Graphics Draw = e.Graphics;
            Draw.DrawImage(FractalCanvas, 0, 0, FractalCanvas.Width, FractalCanvas.Height);
            Draw.Dispose();
        }
        public void mouseClickOnForm(object sender, MouseEventArgs e)
        {
            bool RunFunction = true;
            if (!IsConverterInitialized)
            {
                RunFunction = false;
            }
            if (!DrawJuliaSetEnabled.Checked)
            {
                RunFunction = false;
            }
            if (!ZoomInEnabled.Checked)
            {
                RunFunction = false;
            }
            if (!DrawJuliaSetEnabled.Checked && ZoomInEnabled.Checked)
            {
                RunFunction = true;
            }
            if (DrawJuliaSetEnabled.Checked && !ZoomInEnabled.Checked)
            {
                RunFunction = true;
            }
            
            if (RunFunction)
            {
              
                if(ZoomInEnabled.Checked)
                {
                    DrawJuliaSetEnabled.Checked = false;

                    double x_temp = Convert.ToDouble(e.X);
                    XCoord = x_temp;

                    double y_temp = Convert.ToDouble(e.Y);
                    YCoord = y_temp;

                    try
                    {
                        ZoomScale = Convert.ToInt16(ZoomScaleTextBox.Text);
                    }
                    catch (Exception c)
                    {
                        MBOX("Error: " + c.Message, "Error");
                    }
                    if (ZoomScale < 1)
                    {
                        MBOX("Zoom scale must be above 0");
                        ZoomScale = 7;
                        ZoomScaleTextBox.Text = "7";
                        return;
                    }

                    ComplexNumber pixel_coordinate = new ComplexNumber((int)(XCoord - (BITMAP_WIDTH / (ZoomScale)) / 4),
                        (int)(YCoord - (BITMAP_HEIGHT / (ZoomScale)) / 4));
                    ZoomCoordinate1 = Converter.GetAbsoluteMathsCoord(pixel_coordinate);
                }

                else if (DrawJuliaSetEnabled.Checked)
                {
                    ZoomInEnabled.Checked = false;
                    Cursor cursor = new Cursor(Cursor.Current.Handle);
                    double x_pixel = Convert.ToDouble(e.X);
                    double y_pixel = Convert.ToDouble(e.Y);

                    ComplexNumber i = new ComplexNumber(x_pixel, y_pixel);
                    ComplexNumber screen_coordinates = Converter.GetAbsoluteMathsCoord(i);

                    JuliaSet j = new JuliaSet(screen_coordinates, Convert.ToInt32(this.ZExponentBox.Text));
                    j.ShowDialog();
                    j.Dispose();
                }
            
            }
        }

        public void mouseUpOnForm(object sender, MouseEventArgs e)
        {
            bool RunFunction = true;
            if (!ZoomInEnabled.Checked)
            {
                RunFunction = false;
            }
            if (!IsConverterInitialized)
            {
                RunFunction = false;
            }
            if(RunFunction)
            {
                double x_coord = Convert.ToDouble(e.X);
                double y_coord = Convert.ToDouble(e.Y);

                ComplexNumber pixel_coordinate = new ComplexNumber((int)(x_coord + (BITMAP_WIDTH / (ZoomScale)) / 4), 
                    (int)(y_coord + (BITMAP_HEIGHT / (ZoomScale)) / 4));
                ZoomCoordinate2 = Converter.GetAbsoluteMathsCoord(pixel_coordinate);

                if (ZoomCoordinate2.Real < ZoomCoordinate1.Real)
                {
                    SwapReals(ref ZoomCoordinate1, ref ZoomCoordinate2);
                }
                if (ZoomCoordinate2.Imaginary < ZoomCoordinate1.Imaginary)
                {
                    SwapImags(ref ZoomCoordinate1, ref ZoomCoordinate2);
                }

                MinimumYValue = ZoomCoordinate1.Imaginary;
                MaximumYValue = ZoomCoordinate2.Imaginary;
                MinimumXValue = ZoomCoordinate1.Real;
                MaximumXValue = ZoomCoordinate2.Real;
                RenderImage();
             }
            
        }

        public void Mandelbrot_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ComputerUserName = Environment.UserName;
            if (!Directory.Exists(@"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\" + this.rName + "\\SavedImages\\"))
            {
                Directory.CreateDirectory(@"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\" + this.rName + "\\SavedImages\\");
            }

            if (!Directory.Exists(@"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\"+ this.rName + "\\SavedStates\\"))
            {
                Directory.CreateDirectory(@"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\" + this.rName + "\\SavedStates\\");
            }
            FractalCanvas = new Bitmap(ClientRectangle.Width,
                                  ClientRectangle.Height,
                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                  );

            ClientWidth = ClientRectangle.Width;
            ClientHeight = ClientRectangle.Height;
            GraphicsObject = Graphics.FromImage(FractalCanvas);
            GraphicsObject.Clear(Color.Black);

            string XmlFilePath = @"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\" + this.rName + "\\SavedStates\\";

            if (XmlFilePath.ContainsFiles())
            {
                DirectoryInfo Folder = new DirectoryInfo(@"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\"+ this.rName + "\\SavedStates\\");
                FileInfo[] filesInFolder = Folder.GetFiles("*.xml");
                foreach (FileInfo file in filesInFolder)
                {
                    string newName = file.Name.Substring(0, file.Name.LastIndexOf(".xml", StringComparison.OrdinalIgnoreCase));
                    StateDropDown.Items.Add(newName);
                }
            }       

        }

        public void RenderButton_Click(object sender, EventArgs e)
        {
            RenderImage();
        }

        public void UndoButton_Click(object sender, EventArgs e)
        {
            try
            {
                MandelbrotData data = UndoData.Pop();
                IterationsTextbox.Text = Convert.ToString(data.GetIter());
                ZoomScaleTextBox.Text = Convert.ToString(data.GetZoomScale());
                Greyscale.Checked = data.GetGrey();
                BlackAndWhite.Checked = data.GetBlackWhite();
                this.MaximumXValue = data.GetXMax();
                this.MinimumXValue = data.GetXMin();
                this.MaximumYValue = data.GetYMax();
                this.MinimumYValue = data.GetYMin();
                XMinLabel.Text = Convert.ToString(this.MinimumXValue);
                XMaxLabel.Text = Convert.ToString(this.MaximumXValue);
                YMinLabel.Text = Convert.ToString(this.MinimumYValue);
                YMaxLabel.Text = Convert.ToString(this.MaximumYValue);
                this.ZExponentBox.Value = (int)data.GetZExponent();
                this.CExponentBox.Value = (int)data.GetCExponent();
                RedoData.Push(data);

            }
            catch (StackUnderflowException stackException)
            {
                MBOX(stackException.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show("Exception Trapped: " + e2.Message, "Error");
            }
        }

        public void RedoButton_Click(object sender, EventArgs e)
        {
            try
            {
                MandelbrotData data = RedoData.Pop();
                IterationsTextbox.Text = Convert.ToString(data.GetIter());
                ZoomScaleTextBox.Text = Convert.ToString(data.GetZoomScale());
                Greyscale.Checked = data.GetGrey();
                BlackAndWhite.Checked = data.GetBlackWhite();
                this.MaximumXValue = data.GetXMax();
                this.MinimumXValue = data.GetXMin();
                this.MaximumYValue = data.GetYMax();
                this.MinimumYValue = data.GetYMin();
                XMinLabel.Text = Convert.ToString(this.MinimumXValue);
                XMaxLabel.Text = Convert.ToString(this.MaximumXValue);
                YMinLabel.Text = Convert.ToString(this.MinimumYValue);
                YMaxLabel.Text = Convert.ToString(this.MaximumYValue);
                this.ZExponentBox.Value = (int)data.GetZExponent();
                this.CExponentBox.Value = (int)data.GetCExponent();
                UndoData.Push(data);

            }
            catch(StackUnderflowException stackException)
            {
                MBOX(stackException.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show("Exception Trapped: " + e2.Message, "Error");
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(this.ComputerUserName);
                SaveForm save = new SaveForm();
                save.ShowDialog();
                string tmp = save.getName();
                FractalCanvas.Save(@"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\"+ this.rName + "\\SavedImages\\" + tmp + ".png");
                save.Dispose();
            }
            catch (Exception save_exception)
            {
                MessageBox.Show(save_exception.Message);
            }

        }

        public void ResetButton_Click(object sender, EventArgs e)
        {
            GraphicsObject = Graphics.FromImage(FractalCanvas);
            GraphicsObject.Clear(Color.Black);
            while (!UndoData.Empty())
            {
                UndoButton_Click(sender, e);
            }
        }

        public void Mandelbrot_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsConverterInitialized)
            {
                double x = Convert.ToDouble(e.X);
                double y = Convert.ToDouble(e.Y);
                ComplexNumber i = new ComplexNumber(x, y);
                ComplexNumber screenCoordinates = Converter.GetAbsoluteMathsCoord(i);
                XCoordLabel.Text = "X Coordinate: " + screenCoordinates.GetReal();
                YCoordLabel.Text = "Y Coordinate: " + screenCoordinates.GetImaginary();
            }
        }
        public void ZoomButton_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap image = QueueOfImages.Dequeue();
                FractalCanvas = image;
                Refresh();
            }
            catch (QueueUnderflowException queueException)
            {
                MBOX(queueException.Message);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            ImageUtility zoom = new ImageUtility(this);
            MultiWindowContext m = new MultiWindowContext(this, zoom);            
        }

        public void ShowAllUserControls()
        {
            ControlsGroupbox.Show();
            ControlsPanel.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.K)
            {
                ControlsHidden = !ControlsHidden;
                if (ControlsHidden)
                {
                    ShowAllUserControls();
                }
                else if (!ControlsHidden)
                {
                    HideAllUserControls();
                }
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                RenderImage();
                return true;
            }
            return false;
        }
        private void SaveStateButton_Click(object sender, EventArgs e)
        {
            string InstanceName;
            SaveForm save = new SaveForm();
            save.ShowDialog();
           
            InstanceName = save.getName();
            
            save.Dispose();
            MandelbrotData state = new MandelbrotData(
                InstanceName,
                this.MaximumIterations,
                this.ZoomScale,
                this.Greyscale.Checked,
                this.BlackAndWhite.Checked,
                this.MinimumXValue,
                this.MaximumXValue,
                this.MinimumYValue,
                this.MaximumYValue,
                Convert.ToInt32(this.ZExponentBox.Value),
                Convert.ToInt32(this.CExponentBox.Value)
                );
            string XmlData = state.ToXml();
            string XmlFilePath = @"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\"+ this.rName + "\\SavedStates\\" + InstanceName + ".xml";
            File.WriteAllText(XmlFilePath, XmlData);
        }
        private void StateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = StateDropDown.Text + ".xml";
            string XmlFilePath = @"C:\Users\" + this.ComputerUserName + "\\Documents\\Mandelbrot\\"+ this.rName + "\\SavedStates\\" + filename;
            string XmlContents = File.ReadAllText(XmlFilePath);
            MandelbrotData FileData = XmlContents.FromXml<MandelbrotData>();
            this.IterationsTextbox.Text = Convert.ToString(FileData.GetIter());
            this.ZoomScaleTextBox.Text = Convert.ToString(FileData.GetZoomScale());
            this.MaximumXValue = FileData.GetXMax(); 
            this.MaximumYValue = FileData.GetYMax();
            this.MinimumXValue = FileData.GetXMin();
            this.MinimumYValue = FileData.GetYMin();
            this.Greyscale.Checked = FileData.GetGrey();
            this.BlackAndWhite.Checked = FileData.GetBlackWhite();
            this.ZExponentBox.Value = Convert.ToDecimal(FileData.GetZExponent());
            this.CExponentBox.Value = Convert.ToDecimal(FileData.GetCExponent());
        }

        private void BlackAndWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (BlackAndWhite.Checked && Greyscale.Checked)
            {
                Greyscale.Checked = !Greyscale.Checked;   
            }
        }

        private void Greyscale_CheckedChanged(object sender, EventArgs e)
        {
            if (Greyscale.Checked && BlackAndWhite.Checked)
            {
                BlackAndWhite.Checked = !BlackAndWhite.Checked;   
            }
        }

        private void IterScroll_Scroll(object sender, EventArgs e)
        {
            this.MaximumIterations = IterScroll.Value;
            this.IterationsTextbox.Text = Convert.ToString(this.MaximumIterations);
        }

    }
}