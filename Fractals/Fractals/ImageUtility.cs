using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Fractals
{
    public partial class ImageUtility : Form
    {
        public Bitmap Image;
        public Mandelbrot UserInstance;
        public ImageUtility(Mandelbrot uInstance)
        {
            InitializeComponent();
            this.Image = (Bitmap)uInstance.Canvas.Clone();
            this.UserInstance = uInstance;
        }
        private void StartProcedure()
        {
            this.Close();
            this.Hide();
            try
            {              
                for (int i = 0; i < Convert.ToInt32(this.AmountOfImages.Value); i++)
                {
                    Image = UserInstance.AutoZoom(Image);
                    UserInstance.QueueOfImages.Enqueue(Image);
                    UserInstance.ZoomButton.Enabled = true;                 
                }
                UserInstance.MBOX("done, closing");
                this.Close();
            }
            catch (NullBitmapException)
            {
                UserInstance.MBOX("Zoomed too far");     
                return;
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            StartProcedure();      
        }
        private void ImageUtility_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            
        }  
    }
}
