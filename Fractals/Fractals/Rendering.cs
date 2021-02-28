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
    public static class Rendering
    {

        private enum ExponentStates : byte
        {
            DEFAULT_EXPONENT_VALUES,
            NON_DEFAULT_Z_EXPONENT,
            ANY_OTHER_CASE
        }

        public static Tuple<int, double> GetEscapeIterations(int ZExponent, int CExponent, ComplexNumber ZComplex, ComplexNumber CComplex, int MaximumIterations)
        {
            int Iterations = 0;
            double Normalized = 0.0;

            ExponentStates state;
            if (ZExponent == 2 && CExponent == 0)
            {
                state = ExponentStates.DEFAULT_EXPONENT_VALUES;
            }
            else if (ZExponent != 2 && CExponent == 0)
            {
                state = ExponentStates.NON_DEFAULT_Z_EXPONENT;
            }
            else
            {
                state = ExponentStates.ANY_OTHER_CASE;
            }

            switch (state)
            {
                case ExponentStates.DEFAULT_EXPONENT_VALUES:
                    do
                    {
                        ZComplex = ComplexMath.SquarePlus(ZComplex, CComplex);
                        Normalized = ComplexMath.SquareModulus(ZComplex);
                        Iterations++;
                    } while ((Normalized <= (4)) && (Iterations < MaximumIterations));

                    break;

                case ExponentStates.NON_DEFAULT_Z_EXPONENT:

                    do
                    {
                        ZComplex = ComplexMath.PowerPlusConst(ZComplex, ZExponent, CComplex);
                        Normalized = ComplexMath.SquareModulus(ZComplex);
                        Iterations++;
                    } while ((Normalized <= (4)) && (Iterations < MaximumIterations));

                    break;

                case ExponentStates.ANY_OTHER_CASE:

                    do
                    {
                        ZComplex = ComplexMath.PowerPlusConst(ZComplex, ZExponent, ComplexMath.Power(CComplex, CExponent));
                        Normalized = ComplexMath.SquareModulus(ZComplex);
                        Iterations++;
                    } while ((Normalized <= (4)) && (Iterations < MaximumIterations));

                    break;

                default:
                    MessageBox.Show("Default Case, No Proper Values inputted");

                    break;

            }
            return new Tuple<int, double>(Iterations, Normalized);
        }




        public static Color ColourFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
            
            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        public static Color SmoothColour(int Iter, double Norm)
        {
            double m = (double)Iter;
            double ZMod = Math.Sqrt(Norm);
            double hue;

            hue = m + 1.0 - Math.Log(Math.Log(Math.Abs(ZMod))) / Math.Log(2.0);
            hue = 0.95 + 20.0 * hue;

            while (hue > 360.0)
            {
                hue -= 360.0;
            }

            while (hue < 0.0)
            {
                hue += 360.0;
            }

            return ColourFromHSV(hue, 0.8, 1.0);
        }

        public static Color GetColourForPixel(int Iterations, int MaximumIterations,
            int LastIterations, Color LastColour, bool Grey, bool BlackWhite, double Normalized)
        {
            Color Colour;
            if (!Grey && !BlackWhite)
            {
                Colour = SmoothColour(Iterations, Normalized);
            }
            else if (BlackWhite)
            {
                if (Iterations < MaximumIterations || Normalized <= 4.0)
                {
                    Colour = Color.White;
                }
                else
                {
                    Colour = Color.Black;
                }
            }
            else
            {
                Color tCol = SmoothColour(Iterations, Normalized);
                double L = 0.2126 * tCol.R + 0.7152 * tCol.G + 0.0722 * tCol.B;
                Colour = Color.FromArgb(Convert.ToInt32(L), Convert.ToInt32(L), Convert.ToInt32(L));
            }
            return Colour;
            
        }
    }
}
