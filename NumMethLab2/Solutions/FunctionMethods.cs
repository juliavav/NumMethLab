using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace NumMethLab2.Solutions
{
    public static class FunctionMethods
    {
        public static double F(double x) => Cos(x) + 0.25 * x - 0.5;

        public static double Df(double x) => -Sin(x) + 0.25;

        //public static double Phi(double x) => -4 * Cos(x) + 1;

        public static double Phi(double x) => x - Sign(Df(x)) / Max(Abs(Constants.A), Abs(Constants.B))*F(x);
        public static double Dphi(double x) => 1 - Df(x)*Sign(Df(x))/Max(Abs(Constants.A), Abs(Constants.B));
        //public static double Dphi(double x) => 4 * Sin(x);

        //public static double F(double x) => Pow(2,x) + x*x -2;

        //public static double Df(double x) => Pow(2,x)*Log(2)+2*x;

        //public static double Phi(double x) => Sqrt(2-Pow(2,x));

        //public static double Dphi(double x) => Pow(2, x) * Log(2)/(2* Sqrt(2 - Pow(2, x)));
    }
}
