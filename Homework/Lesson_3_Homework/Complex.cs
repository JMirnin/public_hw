using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_Homework
{
    class Complex
    {
        public double a, b;

        public Complex(double A, double B)
        {
            a = A;
            b = B;
        }

        public static Complex Sum(Complex Z1, Complex Z2)
        {
            //z=(a1+a2)+(b1+b2)i
            return new Complex(Z1.a + Z2.a, Z1.b + Z2.b);
        }

        public static Complex Minus(Complex Z1, Complex Z2)
        {
            ////z=(a1-a2)+(b1-b2)i
            return new Complex(Z1.a - Z2.a, Z1.b - Z2.b);
        }

        public static Complex Mult(Complex Z1, Complex Z2)
        {
            //(a1a2−b1b2)+(a1b2+b1a2)i
            return new Complex(Z1.a * Z2.a - Z1.b * Z2.b, Z1.a * Z2.b + Z1.b * Z2.a);
        }

        /// <summary>
        /// Вывод комплексного числа
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            if (b < 0)
            {
                return $"{a} - {Math.Abs(b)}i";
            }
            else
            {
                return $"{a} + {b}i";
            }
        }
    }

}
