using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Fractals
{
    public partial class JuliaSet : Form
    {
        private ComplexNumber ZValue = new ComplexNumber(0, 0);
        private ComplexNumber CValue = new ComplexNumber(0, 0);
        private double ZoomScale = 0.90;
        private int MaxIter = 255;
        private int width, height;
        private int ZExponent;
        private int CExponent;
        private double XDisposition, YDisposition;
        private string UserName;

        private Graphics GraphicsObject;
        private Bitmap Canvas;
        private Color[] Colours = (from c in Enumerable.Range(0, 256)
                          select Color.FromArgb((c >> 5) * 36, (c >> 3 & 7) * 36, (c & 3) * 85)).ToArray();
        public JuliaSet()
        {
            InitializeComponent();
            this.ZExponent = 2;
        }


        public JuliaSet(ComplexNumber c)
        {
            InitializeComponent();
            CRealTb.Text = Convert.ToString(c.GetReal());
            CImagTb.Text = Convert.ToString(c.GetImaginary());
            this.ZExponent = 2;
        }

        public JuliaSet(ComplexNumber c, int Exponent)
        
        {
            InitializeComponent();

            CRealTb.Text = Convert.ToString(c.GetReal());
            CImagTb.Text = Convert.ToString(c.GetImaginary());
            this.ZExponent = Exponent;
        }
        public void GenerateSet()
        {
            try
            {


                this.ZExponent = Convert.ToInt32(this.ZExpTB.Text);
                this.CExponent = Convert.ToInt32(this.CExpTB.Text);

                RenderProgress.Minimum = 0;
                RenderProgress.Maximum = 1045;

                this.width = ClientRectangle.Width;
                this.height = ClientRectangle.Height;

                this.ZoomScale = Convert.ToDouble(this.zoom.Text);
                if (Convert.ToInt32(IterationsTB.Text) > 255)
                {
                    this.IterationsTB.Text = "255";
                    this.MaxIter = 255;
                }
                else if (Convert.ToInt32(IterationsTB.Text) < 0)
                {
                    this.IterationsTB.Text = "255";
                    this.MaxIter = 255;
                }
                else
                {
                    this.MaxIter = Convert.ToInt32(IterationsTB.Text);
                }


                GraphicsObject.Clear(Color.Black);
                Refresh();

                Color thisColour = Color.Blue;
                Color lastColour = Color.Red;
                double Normalized = 0;

                XDisposition = Convert.ToDouble(XDispTB.Text);
                YDisposition = Convert.ToDouble(YDispTB.Text);
              
                CValue.Real = Convert.ToDouble(CRealTb.Text);
                CValue.Imaginary = Convert.ToDouble(CImagTb.Text);

                Color last = Color.Red;

                int line = 0;
                int iLast = 0;

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        ZValue.Real = 1.5 * (x - width - 1 / 2) / (0.5 * ZoomScale * width) + XDisposition;
                        ZValue.Imaginary = 1.0 * (y - height - 1 / 2) / (0.5 * ZoomScale * height) + YDisposition;


                        int i = 0;
                        if (this.ZExponent == 2 && this.CExponent == 0)
                        {
                            do
                            {
                                ZValue = ComplexMath.SquarePlus(ZValue, CValue);
                                Normalized = ComplexMath.SquareModulus(ZValue);
                                i++;
                            } while (Normalized < 4.0 && i < MaxIter);
                        }

                        else if (this.ZExponent != 2 && this.CExponent == 0)
                        {
                            do
                            {
                                ZValue = ComplexMath.PowerPlusConst(ZValue, ZExponent, CValue);
                                Normalized = ComplexMath.SquareModulus(ZValue);
                                i++;
                            } while (Normalized < 4.0 && i < MaxIter);
                        }
                        else
                        {
                            do
                            {
                                ZValue = ComplexMath.PowerPlusConst(ZValue, ZExponent, ComplexMath.Power(CValue, CExponent));
                                Normalized = ComplexMath.SquareModulus(ZValue);
                                i++;
                            } while (Normalized < 4.0 && i < MaxIter);
                        }
                        Color col;
                        if (i == iLast)
                        {
                            col = last;
                        }
                        else
                        {
                            col = Colours[i];
                        }
                        Canvas.SetPixel(x, y, col);
                    }
                    line++;
                    if (line % 120 == 0)
                    {
                        RenderProgress.Value = line;
                        Refresh();
                    }
                }

                RenderProgress.Value = line;

                Refresh();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        
        
        }
        private void Generate_Click(object sender, EventArgs e)
        {
            this.GenerateSet();
        }
        private void JuliaSet_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                Graphics graphicsObj = e.Graphics;
                graphicsObj.DrawImage(Canvas, 0, 0, Canvas.Width, Canvas.Height);
                graphicsObj.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch (Exception)
            {
                
            }
        }
        private void JuliaSet_Load(object sender, EventArgs e)
        {
            try
            {

                this.UserName = Environment.UserName;
                if (!Directory.Exists(@"C:\Users\" + this.UserName + "\\Documents\\Julia\\SavedImages\\"))
                {
                    Directory.CreateDirectory(@"C:\Users\" + this.UserName + "\\Documents\\Julia\\SavedImages\\");
                }

                Canvas = new Bitmap(ClientRectangle.Width,
                                      ClientRectangle.Height,
                                      System.Drawing.Imaging.PixelFormat.Format24bppRgb
                                      );
                GraphicsObject = Graphics.FromImage(Canvas);
                GraphicsObject.Clear(Color.Black);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                
               

                MessageBox.Show(this.UserName);
                SaveForm f = new SaveForm();
                f.ShowDialog();
                string tmp = f.getName();
                Canvas.Save(@"C:\Users\" + this.UserName + "\\Documents\\Julia\\SavedImages\\" + tmp + ".png");
                f.Dispose();

            }
            catch (Exception saveException)
            {
                MessageBox.Show(saveException.Message);
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.A)
            {
                double tbData = Convert.ToDouble(XDispTB.Text);
                XDispTB.Text = Convert.ToString(tbData - (0.05 / ZoomScale));
            }
            else if (keyData == Keys.Right || keyData == Keys.D)
            {
                double tbData = Convert.ToDouble(XDispTB.Text);
                XDispTB.Text = Convert.ToString(tbData + (0.05 / ZoomScale));
            }
            else if (keyData == Keys.Up || keyData == Keys.W)
            {
                double tbData = Convert.ToDouble(YDispTB.Text);
                YDispTB.Text = Convert.ToString(tbData - (0.05 / ZoomScale));
            }
            else if (keyData == Keys.Down || keyData == Keys.S)
            {
                double tbData = Convert.ToDouble(YDispTB.Text);
                YDispTB.Text = Convert.ToString(tbData + (0.05 / ZoomScale));
            }
            else if (keyData == Keys.Enter)
            {
                this.Generate.PerformClick();
            }

            else
            {
                return false;
            }

            return true;
        }

    }
}
