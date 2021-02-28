using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Fractals
{
    public static class ComplexMath
    {
        public static double Modulus(ComplexNumber c)
        {
            return Math.Sqrt(c.Real * c.Real + c.Imaginary * c.Imaginary);
        }
        public static double SquareModulus(ComplexNumber c)
        {
            return c.Real * c.Real + c.Imaginary * c.Imaginary;
        }
        public static ComplexNumber Square(ComplexNumber c)
        {
            ComplexNumber result = new ComplexNumber(0, 0);
            result.SetReal(c.Real * c.Real - c.Imaginary * c.Imaginary);
            result.SetImaginary(2  * c.Real * c.Imaginary);
            return result;
        }
        public static ComplexNumber ComplexAdd(ComplexNumber c, ComplexNumber other)
        {
            c.Real += other.Real;
            c.Imaginary += other.Imaginary;
            return c;
        }
        public static ComplexNumber SquarePlus(ComplexNumber c, ComplexNumber other)
        {
            ComplexNumber result = ComplexMath.Square(c);
            result = ComplexMath.ComplexAdd(result, other);
            return result;
        }
        public static ComplexNumber Power(ComplexNumber NumberToPower, int Exponent)
        {
            ComplexNumber result = NumberToPower;
            for (int amount = 1; amount < Exponent; amount++)
            {
                result *= NumberToPower;
            }
            return result;
        }
        public static ComplexNumber PowerPlusConst(ComplexNumber c, int Exponent, ComplexNumber Const)
        {
            ComplexNumber PoweredNumber = ComplexMath.Power(c, Exponent);
            PoweredNumber = ComplexMath.ComplexAdd(PoweredNumber, Const);
            return PoweredNumber;        
        }
    }
}
