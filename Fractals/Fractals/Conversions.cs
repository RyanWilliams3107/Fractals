using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Fractals
{

    
    public class Conversions
    {
       
        private double ConvX1;
        private double ConvX2;
        private double ConvY1;
        private double ConvY2;

        private double xMin;
        private double xMax;
        private double yMin;
        private double yMax;

        private float Width;
        private float Height;

        public Conversions(Graphics graphics, ComplexNumber bottomLeft, ComplexNumber topRight)
        {
            this.xMin = bottomLeft.Real;
            this.xMax = topRight.Real;
            this.yMin = bottomLeft.Imaginary;
            this.yMax = topRight.Imaginary;
            this.Width = graphics.VisibleClipBounds.Size.Width;
            this.Height = graphics.VisibleClipBounds.Size.Height;       
            ConvX1 = Width / (xMax - xMin);
            ConvX2 = ConvX1 * xMin;
            double temp = yMax - yMin;
            ConvY1 = Height * (1.0 + yMin / temp);
            ConvY2 = Height / temp;
        }

      
        public PixelCoord GetPixelCoord(ComplexNumber cmplxPoint)
        {
            PixelCoord result = new PixelCoord(
                (int)(ConvX1 * cmplxPoint.Real - ConvX2),
                (int)(ConvY1 - ConvY2 * cmplxPoint.Imaginary)
                );
            return result;
        }

       
        public ComplexNumber GetDeltaMathsCoord(ComplexNumber pixelCoord)
        {
            ComplexNumber result = new ComplexNumber(
                 pixelCoord.Real / ConvX1,
                 pixelCoord.Imaginary / ConvY2
                );     
            return result;
        }

        public ComplexNumber GetAbsoluteMathsCoord(ComplexNumber pixelCoord)
        {
            ComplexNumber result = new ComplexNumber(
                   (ConvX2 + pixelCoord.Real) / ConvX1,
                   (ConvY1 - pixelCoord.Imaginary) / ConvY2);
            return result;
        }
    }
}
