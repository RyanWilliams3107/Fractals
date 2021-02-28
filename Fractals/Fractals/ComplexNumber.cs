using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public class ComplexNumber
    {
        private static readonly ComplexNumber ONE = 1.0;


        public double Real;
        public double Imaginary;
        public ComplexNumber(double Re)
        {
            this.Real = Re;
            this.Imaginary = 0;
        }
        public ComplexNumber(double Re, double Im)
        {
            this.Real = Re;
            this.Imaginary = Im;
        }
        public static ComplexNumber GetOne()
        {
            return ComplexNumber.ONE;
        }
        public void SetReal(double _Real) { this.Real = _Real; }
        public void SetImaginary(double _Imaginary) { this.Imaginary = _Imaginary; }
        public double GetReal() { return this.Real; }
        public double GetImaginary() { return this.Imaginary; }
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber((c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary),
                (c1.Imaginary * c2.Real) + (c1.Real * c2.Imaginary));
        }
        public static ComplexNumber operator *(double n, ComplexNumber c)
        {
            return new ComplexNumber(n * c.Real, n * c.Imaginary);
        }
        public static bool operator ==(ComplexNumber one, ComplexNumber two)
        {
            return ((one.Real == two.Real) && (one.Imaginary == two.Imaginary));
        }
        public static bool operator !=(ComplexNumber one, ComplexNumber two)
        {
            return ((one.Real != two.Real) || (one.Imaginary != two.Imaginary));
        }
        public static explicit operator double(ComplexNumber c)
        {
            return c.Real;
        }
        public static implicit operator ComplexNumber(double n)
        {
            return new ComplexNumber(n, 0.0);

        }
        public override bool Equals(object obj)
        {
           
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            ComplexNumber ComparisonObject = obj as ComplexNumber;
            
            return ((ComparisonObject.GetReal() == this.GetReal()) && (ComparisonObject.GetImaginary() == this.GetImaginary()));
            
        }
        public override int GetHashCode()
        {
            int n1 = 99999997;
            int hash_real_component = this.Real.GetHashCode() % n1;
            int hash_imag_component = this.Imaginary.GetHashCode();
            int final_hashcode = hash_real_component ^ hash_imag_component;
            return final_hashcode;
        }
    }
}
